using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem123
    {
        Sieve s = new Sieve(10000000);

        private BigInteger p(int n)
        {
            long pn = s.primeList[n-1];

            BigInteger pn_sq = BigInteger.Pow(pn, 2);
            return (BigInteger.ModPow(pn - 1, n, pn_sq) + BigInteger.ModPow(pn + 1, n, pn_sq)) % pn_sq;
        }

        public void Run()
        {
            int upper = s.primeList.Count;
            BigInteger bigUpper = BigInteger.Pow(10, 10);
            BigInteger remainder;

            for (int i = 7000; i < upper; i++)
            {
                if (BigInteger.Pow(s.primeList[i], 2) > bigUpper)
                {
                    remainder = p(i);
                    if (remainder > bigUpper)
                    {
                        Console.WriteLine("Rem:");
                        Console.WriteLine(remainder);
                        Console.WriteLine(i);
                        Console.WriteLine(s.primeList[i]);
                        break;
                    }

                }
            }
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
