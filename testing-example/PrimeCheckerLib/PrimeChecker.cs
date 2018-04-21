using System;

namespace PrimeCheckerLib
{
    public static class PrimeChecker
    {
        public static bool IsPrime(int n)
        {
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (var i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
