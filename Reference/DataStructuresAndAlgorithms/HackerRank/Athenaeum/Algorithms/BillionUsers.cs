using System;

namespace Athenaeum.Algorithms
{
    public static class BillionUsers
    {
        private const double OneBillion = 1_000_000_000;

        public static int GetBillionUsersDayIterative(float[] growthRates)
        {
            if (growthRates.Length == 0) return 0;

            double totalUsers = 0;
            var totalDays = 0;

            while (totalUsers < OneBillion)
            {
                totalDays += 1;

                double totalUsersTemp = 0;

                foreach (var growthRate in growthRates)
                {
                    totalUsersTemp += Math.Pow(growthRate, totalDays);
                }

                totalUsers = totalUsersTemp;
            }

            return totalDays;
        }

        public static int GetBillionUsersDayBinary(float[] growthRates)
        {
            if (growthRates.Length == 0) return 0;

            var start = 1;
            var end = 1_000;

            while (start < end)
            {
                double total = 0;
                var mid = start + (end - start) / 2;

                // calculate mid value
                foreach (var growthRate in growthRates)
                {
                    total += Math.Pow(growthRate, mid);
                }

                if (total == OneBillion)
                {
                    return mid;
                }

                if (total > OneBillion)
                {
                    end = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return start;
        }
    }
}