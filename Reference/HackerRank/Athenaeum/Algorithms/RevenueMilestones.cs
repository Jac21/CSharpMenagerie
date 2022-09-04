using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Algorithms
{
    public static class RevenueMilestones
    {
        public static int[] GetMilestoneDaysIterative(int[] revenues, int[] milestones)
        {
            if (revenues.Length == 0 ||
                milestones.Length == 0)
                return new[]
                {
                    -1
                };

            var milestoneDays = new Dictionary<int, int>();

            var totalRevenue = 0;

            // O(n)
            for (var i = 0; i < revenues.Length; i++)
            {
                totalRevenue += revenues[i];

                var milestonesHit = milestones
                    .Where(x => x <= totalRevenue)
                    .ToList();

                foreach (var milestone in milestonesHit)
                {
                    if (!milestoneDays.ContainsKey(milestone))
                    {
                        milestoneDays.Add(milestone, i + 1);
                    }
                }
            }

            return milestoneDays.Values.ToArray();
        }
    }
}