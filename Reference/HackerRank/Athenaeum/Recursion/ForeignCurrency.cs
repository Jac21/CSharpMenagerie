namespace Athenaeum.Recursion
{
    public static class ForeignCurrency
    {
        public static bool CanGetExactChange(int targetMoney, int[] denominations)
        {
            if (targetMoney < 0) return false;

            if (denominations.Length == 0) return false;

            if (targetMoney == 0) return true;

            for (var i = 0; i < denominations.Length; i++)
            {
                if (CanGetExactChange(targetMoney - denominations[i], denominations))
                {
                    return true;
                }
            }

            return false;
        }
    }
}