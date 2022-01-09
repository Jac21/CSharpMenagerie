using System.Linq;

namespace HackerRank.Array
{
    public static class CarPooler
    {
        /// <summary>
        /// O|stops|
        /// </summary>
        /// <param name="trips"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public static bool CarPooling(int[][] trips, int capacity)
        {
            var stops = new int[1001];

            foreach (var trip in trips)
            {
                stops[trip[1]] += trip.FirstOrDefault();
                stops[trip[2]] -= trip.FirstOrDefault();
            }

            for (int stop = 0; stop <= 1000; stop++)
            {
                capacity -= stops[stop];

                if (capacity < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}