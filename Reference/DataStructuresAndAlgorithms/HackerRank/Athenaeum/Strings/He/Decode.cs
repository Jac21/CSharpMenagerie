using System;
using System.Text;

namespace Athenaeum.Strings.He
{
    /*
     * Problem
        Given an encrypted message, Erwin encodes it the following way:

        Removes the median letter of the word from the original word and appends it to the end of the encrypted word and repeats the process until there are no letters left.

        A median letter in a word is the letter present in the middle of the word and if the word length is even, the median letter is the left one out of the two middle letters.

        Given an encoded string, write a program to decode it.

        Input Format:

        The first line of input contains T, the number of test cases.
        Each test case contains a String S, denoting the encoded word.

        Output Format:

        Print the decoded word for each test case in a separate line.
     */
    public class Decode
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            var T = Convert.ToInt32(line);

            for (var tI = 0; tI < T; tI++)
            {
                var s = Console.ReadLine();

                var output = Decoder(s);
                Console.Out.WriteLine(output);
            }
        }

        private static string Decoder(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length <= 1)
            {
                return s;
            }

            var decodedString = new StringBuilder();

            for (var i = s.Length - 1; i >= 0; i--)
            {
                var midpoint = decodedString.Length / 2;
                decodedString.Insert(midpoint, s[i]);
            }

            return decodedString.ToString();
        }
    }
}