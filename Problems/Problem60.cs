using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem60
    {
        private Sieve s = new Sieve(10000000);
        private bool PrimesConcat(int[] p)
        {
            for (int i = 0; i < p.Length - 1; i++)
            {
                for(int j = i + 1; j < p.Length; j++) {
                    int concat1 = int.Parse(p[i].ToString() + p[j].ToString());
                    int concat2 = int.Parse(p[j].ToString() + p[i].ToString());
                    if (concat1 < 10000000)
                    {
                        if (!s.prime[concat1])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!Sieve.isPrime(concat1))
                        {
                            return false;
                        }
                    }
                    if (concat2 < 10000000)
                    {
                        if (!s.prime[concat2])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!Sieve.isPrime(concat2))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void Run()
        {
            DateTime start = DateTime.Now;
            int upper = s.primeList.Count;
            bool found = false;
            for (int z = 4; z < upper; z++)
            {
                for (int y = z - 1; y >= 3; y--)
                {
                     if(PrimesConcat(new int[] {(int) s.primeList[y], (int) s.primeList[z]})){
                    for (int x = y - 1; x >= 2; x--)
                    {
                        if (PrimesConcat(new int[] { (int)s.primeList[x], (int)s.primeList[y], (int)s.primeList[z] }))
                        {
                            for (int w = x - 1; w >= 1; w--)
                            {
                                if (PrimesConcat(new int[] { (int)s.primeList[w], (int)s.primeList[x], (int)s.primeList[y], (int)s.primeList[z] }))
                                {
                                    for (int v = w - 1; v >= 0; v--)
                                    {
                                        int[] primes = new int[] { (int)s.primeList[v], (int)s.primeList[w], (int)s.primeList[x], (int)s.primeList[y], (int)s.primeList[z] };
                                        if (PrimesConcat(primes))
                                        {
                                            int sum = 0;
                                            foreach (int p in primes)
                                            {
                                                Console.WriteLine(p.ToString() + ", ");
                                                sum += p;
                                            }
                                            Console.WriteLine(" = " + sum.ToString());
                                            found = true;
                                        }
                                    }
                                    if (found)
                                    {
                                        Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
                                        Console.ReadLine();
                                        return;
                                    }
                                }
                            }
                        }
                        }
                    }
                }
            }

            Console.WriteLine("Not found");
            Console.ReadLine();
        }
    }
}
