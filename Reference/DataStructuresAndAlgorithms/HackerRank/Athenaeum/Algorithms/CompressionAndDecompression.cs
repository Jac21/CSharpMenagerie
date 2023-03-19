using System;
using System.Collections.Generic;

namespace Athenaeum.Algorithms
{
    public static class CompressionAndDecompression
    {
        public static string DecompressString(string input)
        {
            if (string.IsNullOrEmpty(input)) throw new ArgumentNullException(nameof(input));

            var decompressedString = string.Empty;
            var compressedStack = new Stack<char>();

            foreach (var character in input)
            {
                compressedStack.Push(character);
            }

            while (compressedStack.TryPop(out var result))
            {
                if (result == ']')
                {
                    // emit characters
                    var temporaryResultString = string.Empty;

                    while (compressedStack.TryPop(out var chunkResult) &&
                           chunkResult != '[')
                    {
                        temporaryResultString += chunkResult;
                    }

                    // emit digits
                    var temporaryResultCount = string.Empty;

                    while (compressedStack.TryPeek(out var peekResult) &&
                           peekResult != ']' &&
                           compressedStack.TryPop(out var chunkResult) &&
                           chunkResult != ']')
                    {
                        temporaryResultCount += chunkResult;
                    }

                    var resultCountArray = temporaryResultCount.ToCharArray();

                    Array.Reverse(resultCountArray);
                    var resultCountOriented = new string(resultCountArray);

                    var count = Convert.ToInt32(resultCountOriented);

                    for (var i = 0; i < count; i++)
                    {
                        decompressedString += temporaryResultString;
                    }
                }
                else
                {
                    // add stray character to result
                    decompressedString += result;
                }
            }

            var decompressedStringArray = decompressedString.ToCharArray();
            Array.Reverse(decompressedStringArray);
            var decompressedResult = new string(decompressedStringArray);

            return decompressedResult;
        }
    }
}