using System;
using System.Collections;
using System.Collections.Generic;

namespace MagicalMethods
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello, Magical Methods!");

            var customList = new CustomList<int>
            {
                1, 1, 2, 3, 5, 8
            };

            var customListWithMultipleParameters = new CustomListWithMultipleParameters<string>
            {
                {"item1", "extraParamOne", 2},
                {"item2", "extraParamOne", 2}
            };

            var myList = new List<int>
            {
                1, 2, 3, 4
            };

            var customListWithDynamicParameters = new CustomListWithDynamicParameters<int>
            {
                myList
            };

            var headers = new HttpHeaders
            {
                ["access-control-allow-origin"] = "*",
                ["cache-control"] = "max-age=315360000, public, immutable"
            };

            var point = new Point(12, 24);
            var (x, y) = point;
        }
    }
}