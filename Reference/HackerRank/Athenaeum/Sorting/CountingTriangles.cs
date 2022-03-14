using System;
using System.Collections.Generic;

namespace Athenaeum.Sorting
{
    public static class CountingTriangles
    {
        public static int CountDistinctTriangles(int[][] arr)
        {
            if (arr.Length == 0) return 0;

            var triangles = new HashSet<string>();

            foreach (var triangle in arr)
            {
                Array.Sort(triangle);

                var stringRepresentation = string.Join(string.Empty, triangle);

                if (!triangles.Contains(stringRepresentation))
                {
                    triangles.Add(stringRepresentation);
                }
            }

            return triangles.Count;
        }
    }
}