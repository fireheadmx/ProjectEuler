using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem290
    {
        private int SumDigits(BigInteger n)
        {
            int sum = 0;
            do
            {
                sum += (int)(n % 10);
                n /= 10;
            }
            while (n > 0);
            return sum;
        }

        public void Run()
        {
            BigInteger n = 0;
            BigInteger upper = BigInteger.Pow(10, 18);
            BigInteger count = 0;
            int power = 0;
            int sum_digits;
            
            for (; n <= upper; n++)
            {
                sum_digits = SumDigits(n);
                if (sum_digits == SumDigits(137 * n))
                {
                    count++;
                }

                if (sum_digits == 1)
                {
                    using (StreamWriter str_out = new StreamWriter("C:/data/p290_" + power.ToString() + ".txt"))
                    {
                        str_out.WriteLine("10**" + (power++).ToString() + " : " + count.ToString());
                    }
                }
            }

            using (StreamWriter str_out = new StreamWriter("C:/data/p290.txt"))
            {
                str_out.WriteLine(count);
                str_out.WriteLine();
            }
            
        }
    }
}
