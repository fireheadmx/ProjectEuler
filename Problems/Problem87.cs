using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem87
    {
        private Sieve s;
        private HashSet<long> found;
        private long upper = 50000000;

        public Problem87()
        {
            s = new Sieve((long)Math.Sqrt(upper) + 1);
            found = new HashSet<long>();
        }

        public void Run()
        {
            BigInteger a2b3, a2b3c4;
            int prime_upper = s.primeList.Count;
            for (int i = 0; i < prime_upper; i++)
            {
                for (int j = 0; j < prime_upper; j++)
                {   
                    a2b3 = BigInteger.Pow(s.primeList[i], 2) + BigInteger.Pow(s.primeList[j], 3);
                    if (a2b3 > upper)
                    {
                        break;
                    }
                    for (int k = 0; k < prime_upper; k++)
                    {
                        a2b3c4 = a2b3 + BigInteger.Pow(s.primeList[k], 4);
                        if (a2b3c4 < upper)
                        {
                            found.Add((long)a2b3c4);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(found.Count);
            Console.ReadLine();
        }
    }
}
