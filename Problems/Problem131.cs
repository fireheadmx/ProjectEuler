using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace ProjectEuler.Problems
{
    static class Problem131
    {

        public static void Run()
        {
            int upper = 1000000;
            Sieve s = new Sieve(2*upper);
            using (StreamWriter swr = new StreamWriter("Output/p131_4.txt", true))
            {
                swr.WriteLine("Started 131. Target = {0}", upper);
            }

            DateTime start1 = DateTime.Now;

            long count = 0;
            BigInteger n = 0;
            int n_root_found = 1;
            long p = 0;
            int prime_ix_found = -1;
            BigInteger x, x3, x_limit;

            BigInteger xcub;
            for (int n_root = n_root_found; ; n_root++)
            {
                if (n_root > 1.5 * n_root_found + 10)
                {
                    break;
                }
                n = BigInteger.Pow(n_root, 3);
                for (int prime_ix = prime_ix_found + 1; prime_ix < 100 + (1.2 * prime_ix_found); prime_ix++)
                {
                    p = s.primeList[prime_ix];

                    if (p > upper)
                    {
                        break;
                    }

                    xcub = BigInteger.Pow(n, 2) * (n + p);
                    
                    x_limit = n + n/10 + 20;
                    for (x = n; x < x_limit; x+= n_root)
                    {
                        x3 = BigInteger.Pow(x, 3);
                        if (xcub == x3)
                        {
                            count++;
                            Console.WriteLine("{0}. p={1}, n={2} \t pix={3}, nroot={4}, xroot={5}", count, p, n, prime_ix + 1, n_root, x);
                            using (StreamWriter swr = new StreamWriter("Output/p131_4.txt", true))
                            {
                                swr.WriteLine("{0}. p={1}, n={2} \t pix={3}, nroot={4}, xroot={5}", count, p, n, prime_ix + 1, n_root, x);
                            }
                            prime_ix_found = prime_ix;
                            n_root_found = n_root;
                            break;
                        }
                        else if (xcub < x3)
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(count);
            Console.WriteLine("{0}ms", (DateTime.Now - start1).TotalMilliseconds);

            using (StreamWriter swr = new StreamWriter("Output/p131_4.txt", true))
            {
                swr.WriteLine("E 131: {0} minutes", (DateTime.Now - start1).TotalMinutes);
                swr.WriteLine(DateTime.Now);
                swr.WriteLine("Count({0}) ==> {1}", upper, count);
            }
        }

        private static List<BigInteger> cube = new List<BigInteger>();
        private static BigInteger last_cube_added = 0;
        private static bool IsInCubeList(BigInteger number)
        {
            while (number > cube[cube.Count - 1])
            {
                cube.Add(BigInteger.Pow(++last_cube_added, 3));
            }
            return cube.Contains(number);
        }

        public static void StoreCubes_Run()
        {
            int upper = 1000000;
            Sieve s = new Sieve(upper);
            //List<BigInteger> cube = new List<BigInteger>();
            //for (int c = 0; c <= upper; c++)
            //{
            //    cube.Add(BigInteger.Pow(c, 3));
            //}
            //last_cube_added = upper;
            //BigInteger cubeLast = cube[cube.Count - 1];

            using (StreamWriter swr = new StreamWriter("Output/p131_2.txt", true))
            {
                swr.WriteLine("Started 131. Target = {0}", upper);
            }

            int total_primes = s.primeList.Count;
            DateTime start1 = DateTime.Now;
            BigInteger n = 0;
            BigInteger n6;
            BigInteger xcub = 0;
            ////From the start
            long p = 0;
            int prime_ix_found = -1;
            int n_root_found = 1;
            int count = 0;

            //Largest found
            //long p = 65269;
            //int prime_ix_found = 6521;
            //int n_root_found = 147;
            //int count = 54;

            //long p = 61;
            //int prime_ix_found = 18;
            //int n_root_found = 4;
            //int count = 4;

            for (BigInteger c = BigInteger.Pow(n_root_found, 2); c <= BigInteger.Pow(n_root_found, 3); c++)
            {
                cube.Add(BigInteger.Pow(c, 3));
            }
            last_cube_added = BigInteger.Pow(n_root_found, 3);

            for (int n_root = n_root_found; n < cube.Count; n_root++)
            {
                if (n_root > (1.5* n_root_found) + 10)
                {
                    // Cut final delay
                    break;
                }

                n = BigInteger.Pow(n_root, 3);
                n6 = BigInteger.Pow(n, 2);
                //while (cube[0] < n6)
                //{
                //    cube.RemoveAt(0);
                //}
                for (int prime_index = prime_ix_found + 1; prime_index < 100 + (1.2 * prime_ix_found) && prime_index < total_primes; prime_index++)
                {
                    p = s.primeList[prime_index];

                    xcub = BigInteger.Pow(n, 2) * (n + p);
                    //while (xcub > cubeLast)
                    //{
                    //    //cube.RemoveAt(0);
                    //    cube.Add(BigInteger.Pow(cube.Count, 3));
                    //    cubeLast = cube[cube.Count - 1];
                    //}

                    //if (cube.Contains(xcub))
                    if (IsInCubeList(xcub))
                    {
                        int x_root = cube.IndexOf(xcub);
                        count++;
                        Console.WriteLine("{0}. p={1}, n={2} \t pix={3}, nroot={4}, xroot={5}", count, p, n, prime_index + 1, n_root, x_root);
                        using (StreamWriter swr = new StreamWriter("Output/p131_2.txt", true))
                        {
                            swr.WriteLine("{0}. p={1}, n={2} \t pix={3}, nroot={4}, xroot={5}", count, p, n, prime_index + 1, n_root, x_root);
                        }
                        prime_ix_found = prime_index;
                        n_root_found = n_root;
                        break;
                    }
                }
            }
            Console.WriteLine(count);
            Console.WriteLine("{0}ms", (DateTime.Now - start1).TotalMilliseconds);

            using (StreamWriter swr = new StreamWriter("Output/p131_2.txt", true))
            {
                swr.WriteLine("E 131: {0} minutes", (DateTime.Now - start1).TotalMinutes);
                swr.WriteLine(DateTime.Now);
                swr.WriteLine("Count({0}) ==> {1}", upper, count);
            }

            Console.ReadLine();
        }

        public static void OkRun() // Problem: How many cubes should I precalculate?
        {
            int upper = 10000;
            Sieve s = new Sieve(upper);
            List<BigInteger> cube = new List<BigInteger>();
            for (int c = 0; c <= 20* upper; c++)
            {
                cube.Add(BigInteger.Pow(c, 3));
            }
            BigInteger cubeLast = cube[20* upper];

            int count = 0;
            int total_primes = s.primeList.Count;
            DateTime start1 = DateTime.Now;
            BigInteger n = 0;
            BigInteger xcub = 0;
            long p = 0;
            int prime_ix_found = -1;
            for (int n_root = 1; n < cube.Count; n_root++)
            {
                n = BigInteger.Pow(n_root, 3);

                for (int prime_index = prime_ix_found + 1; prime_index < 10 + (2 * prime_ix_found) && prime_index < total_primes; prime_index++)
                {
                    p = s.primeList[prime_index];
                    xcub = BigInteger.Pow(n, 2) * (n + p);
                    if (xcub > cubeLast)
                    {
                        break;
                    }
                    if (cube.Contains(xcub))
                    {
                        Console.WriteLine("p={0}, n={1} \t pix={2}, nroot={3}", p, n, prime_index+1, n_root);
                        count++;
                        prime_ix_found = prime_index;
                        break;
                    }
                }
            }
            Console.WriteLine(count);
            Console.WriteLine("{0}ms", (DateTime.Now - start1).TotalMilliseconds);

            using (StreamWriter swr = new StreamWriter("Output/p131_2.txt", true))
            {
                swr.WriteLine("E 131: {0} minutes", (DateTime.Now - start1).TotalMinutes);
                swr.WriteLine(DateTime.Now);
                swr.WriteLine("=== {0}", count);
            }

            Console.ReadLine();
        }



        public static void VerySlowRun()
        {
            int upper = 1000;

            Sieve s = new Sieve(upper);
            List<BigInteger> cube = new List<BigInteger>();
            for (int c = 0; c <= 2*upper; c++)
            {
                cube.Add(BigInteger.Pow(c, 3));
            }

            int count = 0;
            DateTime start1 = DateTime.Now;
            foreach (long p in s.primeList)
            {
                for (int n = 1; n < p * 10; n++)
                {
                    if (cube.Contains(BigInteger.Pow(n, 2) * (n+p)))
                    {
                        count++;
                        Console.WriteLine("p={0}, n={1}", p, n);
                        break;
                    }
                }
            }
            Console.WriteLine(count);
            var diff1 = (DateTime.Now - start1).Milliseconds;
            Console.WriteLine(diff1);

            //count = 0;
            //DateTime start2 = DateTime.Now;
            //for (int n = 1; n < upper * 5; n++)
            //{
            //    foreach (long p in s.primeList)
            //    {
            //        if (cube.Contains(BigInteger.Pow(n, 3) + BigInteger.Pow(n, 2) * p))
            //        {
            //            count++;
            //            Console.WriteLine("p={0}, n={1}", p, n);
            //            break;
            //        }
            //    }
            //}
            //Console.WriteLine(count);
            //var diff2 = (DateTime.Now - start2).Milliseconds;
            //Console.WriteLine(diff2);
            //Console.WriteLine(diff1 - diff2);

            Console.ReadLine();
        }
    }
}
