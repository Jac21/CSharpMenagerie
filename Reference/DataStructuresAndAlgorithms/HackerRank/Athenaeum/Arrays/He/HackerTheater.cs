using System;
using System.Linq;

namespace Athenaeum.Arrays.He
{
    public class HackerTheater
    {
        static void Main()
        {
            // Read input and convert to an integer array
            var seats = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var n = seats.Length;
            var maxDist = 0;
            var lastPerson = -1;

            for (var i = 0; i < n; i++)
            {
                if (seats[i] == 1)
                {
                    if (lastPerson == -1)
                    {
                        // Scenario 1: Left Edge (distance from start to first person)
                        maxDist = i;
                    }
                    else
                    {
                        // Scenario 3: Between two people
                        // The best seat is right in the middle
                        maxDist = Math.Max(maxDist, (i - lastPerson) / 2);
                    }

                    lastPerson = i;
                }
            }

            // Scenario 2: Right Edge (distance from last person to the end)
            maxDist = Math.Max(maxDist, (n - 1) - lastPerson);

            Console.WriteLine(maxDist);
        }
    }
}