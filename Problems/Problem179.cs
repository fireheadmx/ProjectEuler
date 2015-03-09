using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem179
    {
        private const int upper = 10000000;
        private Sieve s = new Sieve(upper);

        private long CountDivisors(int number)
        {
            if (s.prime[number])
            {
                return 2; // Self and Unit
            }
            else
            {
                List<int> exponents = new List<int>();
                int number_copy = number;
                double number_2 = (number / 2.0);

                for (int i = 0; s.primeList[i] <= number_2 && number_copy > 1; i++)
                {
                    exponents.Add(0);
                    while (number_copy % s.primeList[i] == 0)
                    {
                        exponents[i]++;
                        number_copy /= (int)s.primeList[i];
                    }

                    if (s.prime[number_copy])
                    {
                        exponents.Add(1);
                        break;
                    }
                }
                int divisors = 1;
                foreach (int e in exponents)
                {
                    divisors *= (e + 1);
                }
                return divisors;
            }
        }

        public void Run()
        {
            long[] divisors = new long[upper+1];
            divisors[0] = 0;
            divisors[1] = 1;
            divisors[2] = 2;
            int count = 0;
            for (int n = 2; n < upper; n++)
            {
                divisors[n + 1] = CountDivisors(n + 1);
                if (divisors[n] == divisors[n + 1])
                {
                    count++;
                }
                if (n == 10 || n == 100 || n == 1000 || n == 10000 || n == 100000 || n % 1000000 == 0)
                {
                    Console.WriteLine("{0} @ {1}", count, n);
                }
            }

            Console.WriteLine("{0} @ {1}", count, 10000000);
            Console.ReadLine();
        }
    }
}
