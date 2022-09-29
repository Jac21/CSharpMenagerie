using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Arrays
{
    public static class OptimizingBoxWeights
    {
        public static int[] MinimalHeaviestSetA(int[] arr)
        {
            if (arr.Length == 0) return Array.Empty<int>();

            var aSetSum = 0;

            Array.Sort(arr);

            var threshold = arr.Sum() / 2;

            var aSetList = new List<int>();

            for (var i = arr.Length - 1; i >= 0; i--)
            {
                aSetSum += arr[i];
                aSetList.Add(arr[i]);

                if (aSetSum > threshold) break;
            }

            aSetList.Sort();
            return aSetList.ToArray();
        }
        
        public static int[] MinimalHeaviestSetAStack(int[] arr)
        {
            if (arr.Length == 0) return Array.Empty<int>();

            Array.Sort(arr);
            var stack = new Stack<int>();
            var totalRemainingWeight = 0;
            var subAList = new List<int>();

            foreach (var weight in arr)
            {
                totalRemainingWeight += weight;
                
                stack.Push(weight);
            }

            while (stack.Count > 0)
            {
                var currentWeight = stack.Pop();
                
                subAList.Insert(0, currentWeight);

                var totalWeightA = 0;

                foreach (var entry in subAList)
                {
                    totalWeightA += entry;
                }

                totalRemainingWeight -= currentWeight;
                
                if(!(currentWeight < totalRemainingWeight - totalWeightA)) break;
            }

            return subAList.ToArray();
        }
    }
}