using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem146
    {
        private const int upper = 10000;
        SieveBig s = new SieveBig(upper*upper + 27);

        int[] add = new int[] { 1, 3, 7, 9, 13, 27 };

        private bool ConsecutivePrimes(long prime)
        {
            if (s.isPrime(prime + 2))
            {
                int ix = s.primeList.IndexOf(prime + 2);
                if (s.isPrime(prime + 6))
                    if (s.primeList.IndexOf(prime + 6) == ix + 1)
                        if (s.isPrime(prime + 8))
                            if (s.primeList.IndexOf(prime + 8) == ix + 2)
                                if (s.isPrime(prime + 12))
                                    if (s.primeList.IndexOf(prime + 12) == ix + 3)
                                        if (s.isPrime(prime + 26))
                                            if (s.primeList.IndexOf(prime + 26) == ix + 4)
                                                return true;
            }
            return false;
        }

        //private bool ConsecutivePrimes(int n)
        //{
        //    BigInteger last_prime = -1;
        //    BigInteger number;
        //    for (int i = 0; i < add.Length; i++)
        //    {
        //        number = BigInteger.Pow(n, 2) + add[i];
        //        if (!Sieve.isPrime(number))
        //        {
        //            return false;
        //        }
        //        if (last_prime > 0)
        //        {
        //            for (BigInteger j = last_prime + 1; j < number; j++)
        //            {
        //                if (Sieve.isPrime(j))
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //        last_prime = number;
        //    }
        //    return true;
        //}

        public void Run()
        {
            long sum = 0;
            int primeLen = s.primeList.Count;
            long prime;
            double root;
            for (int i = 0; i < primeLen; i++)
            {
                prime = s.primeList[i];
                if (ConsecutivePrimes(prime))
                {
                    root = Math.Sqrt(prime - 1);
                    if (root % 1 == 0)
                    {
                        Console.WriteLine(root);
                        sum += (long) root;
                    }
                }
            }
            Console.WriteLine(sum);
            // < 1000000 == 1242490
            Console.ReadLine();
        }
    }
}
