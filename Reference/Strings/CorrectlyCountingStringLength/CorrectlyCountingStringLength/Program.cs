using System;

namespace CorrectlyCountingStringLength
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, string length!");

            // UTF-32: Record code-points as they are at a fixed length
            // of 4 bytes

            // UTF-16: Code-points that fit below 2 bytes are recorded
            // as integers of 2 bytes, and those that exceed are
            // recorded using pairs (4 bytes at 2x2)

            // UTF-8: Record with variable length of 1 to 4 bytes

            Console.WriteLine("👩‍👩‍👧‍👧".Length); // 11

            // .NET char is a UTF-16 code unit, can check if char
            // needs two characters to be represented
            Console.WriteLine(char.IsSurrogatePair('\u0061', '\u0300'));

            Console.WriteLine(char.IsSurrogatePair('\uD852', '\uDF62'));

            Console.ReadLine();
        }
    }
}