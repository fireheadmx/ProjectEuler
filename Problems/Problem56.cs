using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
    class Problem56
    {
        private long IntegerSum(BigInteger number)
        {
            long res = 0;
            while (number > 0)
            {
                res += (long)(number % 10);

                number -= number % 10;
                number /= 10;
            }
            return res;
        }

        public string Run()
        {
            long max = 0;
            List<long> maxs = new List<long>();
            BigInteger maxInt = 0;
            int maxI = 0, maxJ = 0;
            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++) {
                    // Math.Pow(i,j) fails for some reason.
                    // Manually exponentiated instead.
                    BigInteger x = 1;
                    for (int k = 1; k <= j; k++)
                    {
                        x *= i;
                    }
                    long sum = IntegerSum(x);
                    if (sum > max)
                    {
                        max = sum;
                        maxInt = x;
                        maxI = i;
                        maxJ = j;
                    }
                }
            }
            Console.WriteLine("(" + maxI.ToString() + ", " + maxJ.ToString() + ") = " + maxInt.ToString());
            return max.ToString();
        }
    }
}
