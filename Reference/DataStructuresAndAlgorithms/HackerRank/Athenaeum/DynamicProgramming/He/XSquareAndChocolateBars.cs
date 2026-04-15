using System;
using System.Linq;

namespace Athenaeum.DynamicProgramming.He
{
    /*
     * Xsquare loves to eat chocolates like we all do. Xsquare's father has given him a chocolate bar B of length N where each chocolate piece is either of strawberry flavour S or of caramel flavour C. Xsquare's mom does not want him to eat all the chocolates as she thinks that consumption of too many chocolates will make him chocoholic. Therefore, she decided to take some chocolates back from him. She has some empty boxes to keep chocolates. Each box can contain exactly three chocolates. No box can contain all the chocolates of same flavour. She has ordered Xsquare to return her back, the longest contiguous sub-bar of the original chocolate bar such that she can place every three consecutive chocolates from that contiguous chocolate bar in an empty box. Each empty box can accomodate exactly three chocolates, neither less, nor more. A sub-bar is defined as contiguous peices of chocolates in some particular range.

Xsquare agrees to whatever his mom has ordered. Now, he is wondering how many chocolates he is able to eat at the end after he returns the longest contiguous sub-bar.

Help him in accomplishing this task.

Sample Example Image :
enter image description here

Input :
First line of input contains a single integer T denoting the number of test cases. Each of the next T line of input contains a string B denoting the chocolate bar, where ith character in the jth line denotes the flavour of ith chocolate piece in jth chocolate bar.

Output :
Output consists of T lines, each containing number of chocolates Xsquare manages to eat at the end.

Constraints :
1 ≤ T ≤ 105
1 ≤ |B| ≤ 106
String B consists of character 'S' and 'C' only.
sum of |B| over all test cases does not exceed 106
Subtasks :
sum of |B| over all test cases does not exceed 106 : ( 40 pts )
sum of |B| over all test cases does not exceed 106 : ( 60 pts )
Warning :
Prefer to use scanf / printf instead of cin / cout .

Examples
Input

4
SSSSSSSSS
CCCCCCCCC
SSSSCSCCC
SSCCSSSCS
Output

9
9
3
0

Explanation
Test case 1 : Xsquare cannot return any such bar to his mom. So, he can eat all the chocolates. Test case 2 : Xsquare cannot return any such bar to his mom. So, he can eat all the chocolates. Test case 3 : Xsquare can return "SSCSCC" to his mom such that she can placed "SSC" in one box and "SCC" in other box. Therefore, xsquare can get only 3 chocolates at the end. Test case 4 : Xsquare can return "SSCCSSSCS" to his mom such that she can placed "SSC" in first box, "CSS" in second box and "SCS" in third box. Therefore, xsquare will not receive any chocolate at the end.
     */
    public class XSquareAndChocolateBars
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for(var i = 0; i < testCaseCount; i++) {
                var b = Console.ReadLine();

                var result = Solve(b);

                Console.WriteLine(result);
            }
        }

        private static int Solve(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 3) return s.Length;

            var dp = new int[s.Length];
            var maxValidLength = 0;

            for(int i = 2; i < s.Length; i++) {
                // check if current triplet is valid (unique chocolates in triplicate)
                var isInvalidTriplet = (s[i] == s[i - 1] && s[i] == s[i - 2]);

                // for valid blocks, take length ending 3 chocolates ago and add the box
                if(!isInvalidTriplet) {
                    var previousLength = (i >= 3) ? dp[i - 3] : 0;
                    dp[i] = previousLength + 3;
                } else {
                    // if SSS or CCC, break chain
                    dp[i] = 0;
                }

                maxValidLength = Math.Max(maxValidLength, dp[i]);
            }

            return s.Length - maxValidLength;
        }
    }
}