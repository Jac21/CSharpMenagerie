using System;
using System.Buffers;
using System.Buffers.Binary;

namespace Stackalloc
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello, Stackalloc!");

            // dos and don'ts!
            Span<byte> data = stackalloc byte[256];

            // DON’T: Use variable allocation lengths
            // Can result in StackOverflowExceptions
            Span<char> badBuffer = stackalloc char[UserInput.Length];

            // DO: Use a constant for allocation size
            Span<char> buffer = stackalloc char[256]; //better
            Span<char> input = buffer.Slice(0, UserInput.Length);

            // DON’T: Use stackalloc in non-constant loops
            for (int i = 0; i < UserInput.Length; i++)
            {
                Span<char> badLoopBuffer = stackalloc char[256];
            }

            // DO: Allocate outside of loops
            Span<char> betterLoopBuffer = stackalloc char[256]; //better
            for (int i = 0; i < UserInput.Length; i++)
            {
                //Do something with buffer
                Span<char> loopInput = betterLoopBuffer.Slice(0, UserInput.Length);
            }

            // DON’T: Allocate a lot on the stack
            Span<byte> bigData = stackalloc byte[8000 * 1 /*1024*/];

            // DO: Conservatively use the stack (anything larger than a kilobyte is a point of concern)
            const int maxStackSize = 256;

            Span<byte> betterSmallDataBuffer =
                UserInput.Length > maxStackSize
                    ? new byte[UserInput.Length]
                    : stackalloc byte[maxStackSize];

            Span<byte> smallData = betterSmallDataBuffer.Slice(0, UserInput.Length);

            // can also use ArrayPool renting
            byte[] rentedFromPool = null;
            Span<byte> rentedBuffer =
                UserInput.Length > maxStackSize
                    ? (rentedFromPool = ArrayPool<byte>.Shared.Rent(UserInput.Length))
                    : stackalloc byte[maxStackSize];

            // use data
            Span<byte> rentedDate = rentedBuffer.Slice(0, UserInput.Length);

            // return from pool if we rented
            if (rentedFromPool != null)
            {
                ArrayPool<byte>.Shared.Return(rentedFromPool, clearArray: true);
            }

            // DON’T: Assume stack allocations are zero initialized
            Span<byte> perhapsZeroInitializedBuffer = stackalloc byte[sizeof(int)];
            perhapsZeroInitializedBuffer.Clear(); // DO: explicitly zero initlaize
            const byte lo = 1;
            const byte hi = 1;
            perhapsZeroInitializedBuffer[0] = lo;
            perhapsZeroInitializedBuffer[1] = hi;
            // DONT: depend on elements at 2 and 3 being zero-initialized
            int result = BinaryPrimitives.ReadInt32LittleEndian(perhapsZeroInitializedBuffer);

            //DO: Initialize if required

            Console.ReadLine();
        }
    }

    internal class UserInput
    {
        public static int Length { get; set; }
    }
}