using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem119
    {
        public BigInteger SumDigits(BigInteger number)
        {
            BigInteger sum = 0;
            while (number > 0)
            {
                sum += (number % 10);
                number /= 10;
            }
            return sum;
            // 12.5 s @ 12
        }

        //public void RunLinear()
        //{
        //    DateTime start = DateTime.Now;
        //    long i = 612220032;
        //    long sum_i;
        //    int found = 17;
        //    decimal log;
        //    int mod;
        //    while (found < 30)
        //    {
        //        i+= 1;
        //        sum_i = SumDigits(i);
        //        if (sum_i > 1)
        //        {
        //            log = (decimal)Math.Log(i, sum_i);
        //            if (log % 1 == 0)
        //            {
        //                found++;
        //                Console.WriteLine(String.Format("{0}: {1}", found, i));
        //            }
        //        }
                
        //    }
        //    Console.WriteLine(String.Format("Time: {0}ms", (DateTime.Now - start).TotalMilliseconds));
        //    Console.ReadLine();
        //}

        public void RunY9() {
            int count = 0;
            int count9 = 0;
            for (int i = 2; i < 10000; i++)
            {
                BigInteger sum_digits = SumDigits(i);
                if (sum_digits % 9 == 0)
                {
                    if (sum_digits == SumDigits(137 * i))
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }

        public void Run()
        {
            List<BigInteger> found = new List<BigInteger>();
            for (int x = 2; x < 300; x++)
            {
                BigInteger val = x;
                for (int y = 2; y < 100; y++)
                {
                    val *= x;
                    if (val > 10)
                    {
                        if (SumDigits(val) == x)
                        {        
                            found.Add(val);
                        }
                    }
                }
            }
            found.Sort();

            Console.WriteLine("Found {0}:", found.Count);
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("{0}: {1}", i + 1, found[i]);
            }
            Console.ReadLine();
        }
    }
}
