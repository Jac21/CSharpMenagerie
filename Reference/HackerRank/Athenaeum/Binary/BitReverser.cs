using System;
using System.Linq;

namespace Athenaeum.Binary
{
    public static class BitReverser
    {
        public static uint ReverseBits(uint n)
        {
            var representationString = Convert
                .ToString(n, 2);

            var paddedString = representationString
                .PadLeft(32, '0');

            var reversedArray = paddedString
                .Reverse()
                .ToArray();
            
            var result = Convert
                .ToUInt32(new string(reversedArray), 2);

            return result;
        }

        public static uint ReverseBitsBitwise(uint n)
        {
            uint result = 0;
            var bits = 31;

            while (n != 0)
            {
                result += (n & 1) << bits;
                bits--;
                n >>= 1;
            }

            return result;
        }
    }
}