using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Arrays
{
    public static class ReverseToMakeEqual
    {
        public static bool AreTheyEqual(int[] arrA, int[] arrB)
        {
            if (!arrA.Any() &&
                !arrB.Any())
            {
                return false;
            }

            var dictionary = new Dictionary<int, int>();

            foreach (var t in arrA)
            {
                if (!dictionary.ContainsKey(t))
                {
                    dictionary.Add(t, 1);
                }
                else
                {
                    dictionary[t] += 1;
                }
            }

            foreach (var element in arrB)
            {
                if (dictionary.ContainsKey(element))
                {
                    dictionary[element] -= 1;
                }
                else
                {
                    return false;
                }

                if (dictionary[element] == 0)
                {
                    dictionary.Remove(element);
                }
            }

            return !dictionary.Any();
        }
    }
}