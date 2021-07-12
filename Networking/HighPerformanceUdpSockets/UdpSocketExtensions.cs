using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Extensions.ObjectPool;

namespace HighPerformanceUdpSockets
{
    public static class UdpSocketExtensions
    {
        private static readonly ObjectPool<UdpAwaitableSocketAsyncEventArgs> SocketEventPool =
            ObjectPool.Create<UdpAwaitableSocketAsyncEventArgs>();

        private static readonly IPEndPoint BlankEndpoint = new IPEndPoint(IPAddress.Any, 0);

        /// <summary>
        /// Send a block, complete async
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="destination"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async ValueTask<int> SendToAsync(this Socket socket, EndPoint destination,
            ReadOnlyMemory<byte> data)
        {
            var asyncArgs = SocketEventPool.Get();

            asyncArgs.RemoteEndPoint = destination;
            asyncArgs.SetBuffer(MemoryMarshal.AsMemory(data));

            try
            {
                return await asyncArgs.DoSendToAsync(socket);
            }
            finally
            {
                SocketEventPool.Return(asyncArgs);
            }
        }

        public static async ValueTask<SocketReceiveFromResult> ReceiveFromAsync(this Socket socket, Memory<byte> buffer)
        {
            // Get an async argument from the socket event pool.
            var asyncArgs = SocketEventPool.Get();

            asyncArgs.RemoteEndPoint = BlankEndpoint;
            asyncArgs.SetBuffer(buffer);

            try
            {
                var receivedByes = await asyncArgs.DoReceiveFromAsync(socket);

                return new SocketReceiveFromResult
                {
                    ReceivedBytes = receivedByes,
                    RemoteEndPoint = asyncArgs.RemoteEndPoint
                };
            }
            finally
            {
                SocketEventPool.Return(asyncArgs);
            }
        }
    }
}