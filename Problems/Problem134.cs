using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem134
    {
        private static BigInteger CommonP1P2(long p1, long p2)
        {
            string p1Str = p1.ToString();
            string p2str;
            for (BigInteger i = 1; ; i++)
            {
                p2str = (p2 * i).ToString();
                if (p2str.Substring(p2str.Length - p1Str.Length) == p1Str)
                {
                    return p2*i;
                }
            }
            
        }


        private static BigInteger CommonP1P2N(long p1, long p2) 
        {
            BigInteger p2i;
            int p1Length = ((int)Math.Log10(p1)) + 1;
            BigInteger p1size = BigInteger.Pow(10, p1Length);
            for (BigInteger i = 1; ; i++)
            {
                p2i = p2 * i;
                if ((p2i - p1) % p1size == 0)
                {
                    return p2i;
                }
            }
        }

        public static void Run()
        {
            int upper = 1000000;
            Sieve s = new Sieve(upper + (upper / 10));

            BigInteger sum = 0;
            DateTime start = DateTime.Now;
            for (int p_index = 2; s.primeList[p_index] < upper; p_index++)
            {
                //Console.WriteLine("{0},{1}: {2}", s.primeList[p_index], s.primeList[p_index + 1], CommonP1P2(s.primeList[p_index], s.primeList[p_index + 1]));
                sum += CommonP1P2N(s.primeList[p_index], s.primeList[p_index + 1]);
            }
            Console.WriteLine(sum);
            Console.WriteLine("{0}ms", (DateTime.Now - start).TotalMilliseconds);
            using (StreamWriter swr = new StreamWriter("Output/p134.txt", true))
            {
                swr.WriteLine("E 134: {0} minutes", (DateTime.Now - start).TotalMinutes);
                swr.WriteLine(DateTime.Now);
                swr.WriteLine(sum);
            }

            //Console.ReadLine();
        }
    }
}
