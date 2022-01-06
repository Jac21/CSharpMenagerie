using System.Numerics;

namespace HackerRank
{
    public class ExtraLongFactorials
    {
        public static BigInteger ComputeExtraLongFactorials(BigInteger n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * ComputeExtraLongFactorials(n - 1);
        }
    }
}