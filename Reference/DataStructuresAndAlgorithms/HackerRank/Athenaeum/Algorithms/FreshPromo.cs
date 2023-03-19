using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Algorithms
{
    public static class FreshPromo
    {
        /*
         * Complete the 'foo' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. STRING_ARRAY codeList
         *  2. STRING_ARRAY shoppingCart
         */

        public static int foo(List<string> codeList, List<string> shoppingCart)
        {
            if (!codeList.Any()) return 1;

            if (!shoppingCart.Any()) return 0;

            var isWinner = false;

            foreach (var listGroup in codeList)
            {
                var listGroupList = listGroup
                    .Split(',')
                    .Select(t => t.Trim())
                    .ToList();

                var isAnythingIndex =
                    listGroupList.FindIndex(x => string.Equals(x, "anything", StringComparison.OrdinalIgnoreCase));

                if (isAnythingIndex != -1)
                {
                    var uniqueItems = shoppingCart.Distinct();

                    foreach (var uniqueItem in uniqueItems)
                    {
                        var newCodeList = listGroupList.ToArray();

                        newCodeList[isAnythingIndex] = uniqueItem;

                        isWinner = !newCodeList.Except(shoppingCart).Any();

                        if (isWinner) break;
                    }
                }
                else
                {
                    isWinner = !listGroupList.Except(shoppingCart).Any();
                }
            }

            return isWinner ? 1 : 0;
        }
    }
}