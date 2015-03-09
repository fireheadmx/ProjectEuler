using System;

namespace ProjectEuler
{
    class Problem23
    {
        private int upper = 28124;
        private bool[] abundant;

        public Problem23()
        {
            abundant = new bool[upper];
            for (int i = 1; i < upper; i++)
            {
                // Mark abundant numbers to avoid recalculating
                abundant[i] = IsAbundant(i);
            }
        }

        private int FactorSum(int number)
        {
            int sum = 0;
            for (int i = 1; i <= (number / 2); i++)
            {
                if (number % i == 0)
                {
                    // Found a factor
                    sum += i;
                }
            }
            return sum;
        }

        private bool IsAbundant(int number)
        {
            return number < FactorSum(number);
        }

        public int Run()
        {
            int res = 1;
            for(int i = 2; i < upper; i++) {
                bool abundantSum = false;
                for (int j = 1; j <= (i / 2); j++)
                {
                    abundantSum |= abundant[j] && abundant[i - j];
                }
                if (!abundantSum)
                {
                    res += i;
                }
            }
            return res;
        }
    }
}

