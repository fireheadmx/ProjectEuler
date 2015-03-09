using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    class Phi
    {
        public long[] totient;
        Sieve s;
        public BigInteger sumTotient = 0;

        public Phi(long upper)
        {
            s = new Sieve(upper);
            totient = new long[upper + 1];
            for (int i = 2; i <= upper; i++)
            {
                if (totient[i] == 0)
                {
                    totient[i] = Totient(i);
                    if (i % 2 == 0)
                    {
                        // Mark multiples
                        for (int j = 2; i * j <= upper; j *= 2)
                        {
                            if (totient[i * j] == 0)
                            {
                                totient[i * j] = totient[i] * j;
                            }
                        }
                    }
                    else
                    {
                        long i2 = i * 2;
                        for (int j = 2; i2 * j <= upper; j *= 2)
                        {
                            if (totient[i2 * j] == 0)
                            {
                                totient[i2 * j] = totient[i] * j;
                            }
                        }
                    }

                    for (int p = 0; p < s.primeList.Count && i * s.primeList[p] <= upper; p++)
                    {
                        if (s.primeList[p] > i)
                        {
                            totient[i * s.primeList[p]] = totient[i] * (s.primeList[p] - 1);
                        }
                    }
                }
                sumTotient += totient[i];
            }
        }

        public static long GCD(long a, long b) // Greatest Common Denominator
        {
            while (b != 0)
            {
                long c = a % b;
                a = b;
                b = c;
            }
            return a;
        }

        private long Totient(long number)
        {
            if (number <= 1) { return 0; }

            long multiplier = 1;
            while (number % 4 == 0)
            {
                multiplier *= 2;
                number /= 2;
            };

            if (totient[number] > 0)
            {
                return multiplier * totient[number];
            }

            if (s.prime[number])
            {
                return multiplier * (number - 1);
            };

            for (long n = 2; n < Math.Sqrt(number) + 1; n++)
            {
                if (number % n == 0)
                {
                    long m = number / n;
                    if (GCD(m, n) == 1)
                    {
                        return multiplier * totient[m] * totient[n];
                    }
                }
            }

            int countTot = 1;
            for (int i = 2; i < number; i++)
            {
                if (GCD(number, i) == 1)
                {
                    countTot++;
                }
            }
            return multiplier * countTot;
        }
    }
}
