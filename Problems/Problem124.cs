using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem124
    {
        private static Sieve s;

        public static void Run()
        {
            int upper = 100000;
            int resIndex = 9999;
            //int upper = 10;
            //int resIndex = 3;
            s = new Sieve(upper);

            List<long[]> radList = new List<long[]>();
            radList.Add(new long[]{1,1}); // {Number,Rad}
            for (int n = 2; n <= upper; n++)
            {
                long rad = 1;
                for (int prime_index = 0; prime_index < s.primeList.Count; prime_index++)
                {
                    long prime = s.primeList[prime_index];
                    if (prime > n)
                    {
                        break;
                    }
                    if (n % prime == 0)
                    {
                        rad *= prime;
                    }
                }

                int insert_index = 0;
                while(insert_index < radList.Count)
                {
                    if (radList[insert_index][1] > rad)
                    {
                        break;
                    }
                    insert_index++;
                }
                radList.Insert(insert_index, new long[] { n, rad });
            }//for n
            Console.WriteLine("Rad({0}) = {1}", radList[resIndex][0], radList[resIndex][1]);
            Console.ReadLine();
        }

    }
}
