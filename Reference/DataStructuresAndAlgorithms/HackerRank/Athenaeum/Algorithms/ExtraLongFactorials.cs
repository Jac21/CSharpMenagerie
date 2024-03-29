﻿using System.Numerics;

namespace Athenaeum.Algorithms
{
    public static class ExtraLongFactorials
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