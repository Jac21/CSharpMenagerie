#nullable enable
using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace HighPerformanceUdpSockets
{
    internal sealed class UdpAwaitableSocketAsyncEventArgs : SocketAsyncEventArgs, IValueTaskSource<int>
    {
        private static readonly Action<object?> CompletedSentinel =
            state => throw new InvalidOperationException("Task misuse");

        private short _token;
        private Action<object?>? _continuation;

        public UdpAwaitableSocketAsyncEventArgs()
            : base(true)
        {
        }

        public ValueTask<int> DoReceiveFromAsync(Socket socket)
        {
            if (socket.ReceiveAsync(this))
            {
                return new ValueTask<int>(this, _token);
            }

            return CompleteSynchronously();
        }

        public ValueTask<int> DoSendToAsync(Socket socket)
        {
            if (socket.SendToAsync(this))
            {
                return new ValueTask<int>(this, _token);
            }

            return CompleteSynchronously();
        }

        private ValueTask<int> CompleteSynchronously()
        {
            Reset();

            var error = SocketError;

            if (error == SocketError.Success)
            {
                return new ValueTask<int>(BytesTransferred);
            }

            return ValueTask.FromException<int>(new SocketException((int) error));
        }

        private void Reset()
        {
            _token++;
            _continuation = null;
        }

        public int GetResult(short token)
        {
            // Detect multiple awaits on a single ValueTask.
            if (token != _token)
            {
                ThrowMisuseException();
            }

            // We're done, reset.
            Reset();

            // Now we just return the result (or throw if there was an error).
            var error = SocketError;
            if (error == SocketError.Success)
            {
                return BytesTransferred;
            }

            throw new SocketException((int) error);
        }

        public ValueTaskSourceStatus GetStatus(short token)
        {
            if (token != _token)
            {
                ThrowMisuseException();
            }

            return !ReferenceEquals(_continuation, CompletedSentinel) ? ValueTaskSourceStatus.Pending :
                SocketError == SocketError.Success ? ValueTaskSourceStatus.Succeeded :
                ValueTaskSourceStatus.Faulted;
        }

        protected override void OnCompleted(SocketAsyncEventArgs e)
        {
            var c = _continuation;

            if (c != null || (c = Interlocked.CompareExchange(ref _continuation, CompletedSentinel, null)) != null)
            {
                var continuationState = UserToken;

                UserToken = null;

                _continuation = CompletedSentinel;

                InvokeContinuation(c, continuationState, false);
            }
        }

        public void InvokeContinuation(Action<object?> continuation, object? state, bool forceAsync)
        {
            if (forceAsync)
            {
                // Dispatch the operation on the thread pool.
                ThreadPool.UnsafeQueueUserWorkItem(continuation, state, preferLocal: true);
            }
            else
            {
                // Just complete the continuation inline (on the IO thread that completed the socket operation).
                continuation(state);
            }
        }

        public void OnCompleted(Action<object?> continuation, object? state, short token,
            ValueTaskSourceOnCompletedFlags flags)
        {
            if (token != _token)
            {
                ThrowMisuseException();
            }

            UserToken = state;

            // Do the exchange so we know we're the only ones that could invoke the continuation.
            var prevContinuation = Interlocked.CompareExchange(ref _continuation, continuation, null);

            // Check whether we've already finished.
            if (ReferenceEquals(prevContinuation, CompletedSentinel))
            {
                // This means the operation has already completed; most likely because we completed before
                // we could attach the continuation.
                // Don't need to store the user token.
                UserToken = null;

                // We need to set forceAsync here and dispatch on the ThreadPool, otherwise
                // we can hit a stackoverflow!
                InvokeContinuation(continuation, state, forceAsync: true);
            }
            else if (prevContinuation != null)
            {
                throw new InvalidOperationException("Continuation being attached more than once.");
            }
        }

        private static void ThrowMisuseException()
        {
            throw new InvalidOperationException("ValueTask mis-use; multiple await?");
        }
    }
}