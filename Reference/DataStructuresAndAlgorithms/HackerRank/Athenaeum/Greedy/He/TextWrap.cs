using System;
using System.Linq;
using System.Text;

/*
 * Text Wrap
87% Success
3569 Attempts
30 Points
1s Time Limit
256MB Memory
1024 KB Max Code
Prakhar has a string with 
 words where the length of the 
 word is 
. 

The words are displayed in the window separated by a space. More precisely, when the sentence is displayed in a window of width 
, the following conditions are satisfied.

The first word is displayed at the beginning of the top line.
The 
 word (
) is displayed either with a gap of 
 after the 
 word, or at the beginning of the line below the line containing the 
 word
The width of each line does not exceed 
. Here, the width of a line refers to the distance from the left end of the leftmost word to the right end of the rightmost word.
A word should not be broken into 
 or more lines 
Prakhar Wants to fit these words in 
 or less than 
 lines, find the minimum possible width 
 of the window.

Input Format:

The first line contains 
 space seperated integers 
 - the total number of words and 
 - the required number of lines. 

The next line contains 
 space seperated integers 
 

Output Format:

Print the minimum possible width 
 of the window

Constraints:


Examples
Input

6 4
5 4 3 6 2 4
Output

8
Explanation
It can be proven that we cannot fit these words in 4 or less than 4 lines with width 7 or lesser.
 */
namespace Athenaeum.Greedy.He
{
    public class TextWrap
    {
        public static void Main()
        {
            // read input
            var inputLineSplit = Console.ReadLine().Split();
            var n = Convert.ToInt32(inputLineSplit[0]);
            var m = Convert.ToInt32(inputLineSplit[1]);

            var wordLengths = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            // binary search on answer

            // minimum width - at least the length of the longest word
            long left = wordLengths.Max();

            // maximum width - everything on one line (including spaces)
            long right = wordLengths.Sum() + (n - 1);

            long result = right;

            while (left <= right)
            {
                long mid = left + (right - left) / 2;

                if (CanFit(wordLengths, n, m, mid))
                {
                    result = mid; // width works, but try to minimize
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1; // too narrow
                }
            }

            Console.WriteLine(result);
        }

        private static bool CanFit(long[] words, int n, int m, long maxWidth)
        {
            int linesCount = 1;
            long currentWidth = words[0];

            for (int i = 1; i < n; i++)
            {
                // check if we can add the word + 1 space to current line
                if (currentWidth + 1 + words[i] <= maxWidth)
                {
                    currentWidth += 1 + words[i];
                }
                else
                {
                    linesCount++;
                    currentWidth = words[i]; // start new line with current word

                    if (linesCount > m) return false;
                }
            }

            return linesCount <= m;
        }
    }
}