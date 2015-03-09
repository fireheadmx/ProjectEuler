using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    class Sieve
    {
        public bool[] prime;
        public List<long> primeList;

        public static bool isPrime(long n)
        {
            if (n % 2 == 0 || n % 3 == 0)
                return false;
            for (int i = 5; i < (long)Math.Sqrt(n) + 1; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }
            return true;
        }

        public static bool isPrime(BigInteger n)
        {
            if (n % 2 == 0 || n % 3 == 0)
                return false;
            double sqrt = Math.Exp(BigInteger.Log(n) / 2);
            for (long i = 5; i < sqrt; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }
            return true;
        }

        public Sieve(object obj)
        {
            new Sieve((long)obj);
        }

        public Sieve(long upper)
        {
            primeList = new List<long>();
            prime = new bool[upper+1];
            // Fill through Sieve of Eratosthenes
            prime[0] = false;
            prime[1] = false;
            for (int i = 2; i <= upper; i++)
            {
                prime[i] = true;
            }
            for (int a = 2; a <= upper; a++)
            {
                if (prime[a])
                {
                    primeList.Add(a);
                    for (int b = 2; a * b <= upper; b++)
                    {
                        prime[a * b] = false;
                    }
                }
            }
        }
    }

    class SieveBig
    {
        private bool[] prime;
        long max = 1283400000;

        public List<long> primeList;

        public SieveBig(long upper)
        {
            if (upper > max)
            {
                upper = max;
            }
            prime = new bool[upper+1];
            primeList = new List<long>();
            // Fill through Sieve of Eratosthenes
            prime[0] = false;
            prime[1] = false;
            prime[2] = true; primeList.Add(2);
            prime[3] = true; primeList.Add(3);
            prime[4] = false;
            prime[5] = true; primeList.Add(5);
            prime[6] = false;
            prime[7] = true; primeList.Add(7);
            prime[8] = false;
            prime[9] = false;
            prime[10] = false;
            prime[11] = true; primeList.Add(11);
            for (long i = 12; i < prime.LongLength; i++)
            {
                if (i % 2 == 0 || i % 3 == 0 || i % 5 == 0 || i % 7 == 0 || i % 11 == 0)
                {
                    prime[i] = false;
                }
                else
                {
                    prime[i] = true;
                }
            }
            for (long a = 12; a < prime.LongLength; a++)
            {
                if (prime[a])
                {
                    primeList.Add(a);
                    for (int b = 2; a * b < prime.LongLength; b++)
                    {
                        prime[(a * b)] = false;
                    }
                }
            }
        }

        public bool isPrime(BigInteger n)
        {
            if (n < prime.Length)
            {
                return prime[(long)n];
            }
            if (n % 2 == 0 || n % 3 == 0)
                return false;
            double sqrt = Math.Exp(BigInteger.Log(n) / 2);
            for (long i = 5; i < sqrt; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }
            return true;
        }
    }
}
