using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem357
    {
        private static Sieve s;

        private static bool SumDivIsPrime(long num)
        {
            // divisor d of n, d+n/d is prime
            long top = (long)Math.Sqrt(num);

            // d = 1
            if (!s.prime[num + 1])
            {
                // 1 + num/1 = num+1 (Must be prime)
                return false;
            }

            for (long d = 2; d <= top; d++)
            {
                if (num % d == 0)
                {
                    if (!s.prime[d + num / d])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool SumDivIsPrimeB(long num)
        {
            // divisor d of n, d+n/d is prime
            long top = (long) Math.Sqrt(num);

            // d = 1
            if (!Sieve.isPrime(num + 1))
            {
                // 1 + num/1 = num+1 (Must be prime)
                return false;
            }

            for (long d = 2; d <= top; d++)
            {
                if (num % d == 0)
                {
                    if (!Sieve.isPrime(d + num/d)) {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void Run()
        {
            BigInteger sum = 0; // 1 + 1/1 = 2 (prime)
            long count = 0;
            bool printNext = false;
            long upper = 100000000;
            s = new Sieve(upper+1);
            long period = upper / 100;

            for (long n = 1; n <= upper; n++)
            {
                if (n % period == 0)
                {
                    printNext = true;
                }
                if (SumDivIsPrime(n))
                {
                    sum += n;
                    count++;
                    if (printNext)
                    {
                        printNext = false;
                        Console.WriteLine("({0}) {1} = {2}", count, n, sum);
                    }
                }
            }
            using (StreamWriter str_out = new StreamWriter("C:/data/p357.txt", true))
            {
                str_out.WriteLine("({0})<={1} : {2}", count, upper, sum);
            }
            Console.WriteLine("TOTAL({0}) = {1}", count, sum);
            Console.ReadLine();
        }
    }
}
