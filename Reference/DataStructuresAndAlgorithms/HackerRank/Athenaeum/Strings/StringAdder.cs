using System;
using System.Text;

namespace Athenaeum.Strings
{
    public static class StringAdder
    {
        public static string AddStrings(string num1, string num2)
        {
            var j = num1.Length - 1;
            var k = num2.Length - 1;

            var carry = 0;

            var builder = new StringBuilder();
            var l = j > k ? j : k;

            while(l >= 0)
            {
                var n1 = 0;
                var n2 = 0;

                if(j >= 0)
                {
                    n1 = num1[j] - '0';
                    j--;
                }

                if(k >= 0)
                {
                    n2 = num2[k] - '0';
                    k--;
                }

                var sum = n1 + n2 + carry;
                carry = sum / 10;
                var no = sum % 10;

                builder.Insert(0, no);

                l--;
            }

            if(carry > 0)
            {
                builder.Insert(0, carry);
            }

            return builder.ToString();
        }
    }
}
