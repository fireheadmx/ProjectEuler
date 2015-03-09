using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem58
    {
        private int isPrime(long n) {
            if (n % 2 == 0 || n % 3 == 0)
                return 0;
            for (int i = 5; i < (long)Math.Sqrt(n) + 1; i += 6) {
                if (n % i == 0 || n % (i + 2) == 0)
                    return 0;
            }
            return 1;
        }
        public void Run()
        {
            DateTime start = DateTime.Now;   

            int primes = 0;
            long size = 1;
            long arm1,arm2,arm3;
            double primes_rate = 1;
            do
            {
                size += 2;
                arm1 = (size * size) - (size - 1) * 3;
                arm2 = (size * size) - (size - 1) * 2;
                arm3 = (size * size) - (size - 1) * 1;
                primes += isPrime(arm1);
                primes += isPrime(arm2);
                primes += isPrime(arm3);
                primes_rate = primes / (size * 2.0 - 1);
            }
            while (primes_rate >= 0.1);
            Console.WriteLine("PrimesInSpiralArms(" + size.ToString() + ")= " + primes_rate.ToString());
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
            Console.ReadLine();
        }
    }

    /*******  Spiral building  *******/

    class Problem58_Overflow
    {
        List<List<int>> spiral;
        int size = 10001;
        SieveBig s;
        public Problem58_Overflow()
        {
            s = new SieveBig(51 * 50);
            //s = new SieveBig((new BigInteger(1000000)) * 535);
        }

        private void InitSpiral()
        {
            spiral = new List<List<int>>();
            for (int i = 0; i < size; i++)
            {
                spiral.Add(new List<int>());
                for (int j = 0; j < size; j++)
                {
                    spiral[i].Add(0);
                }
            }

            int x = (size - 1) / 2;
            int y = x;

            spiral[x][y] = 1;
            FillSpiral(x, y, 2, "right");
        }

        private void FillSpiral(int x, int y, int current, string direction)
        {
            int currentSize = spiral[0].Count;
            while (current <= currentSize * currentSize && x < currentSize && y < currentSize && x >= 0 && y >= 0)
            {

                if (direction == "right")
                {
                    y = y + 1;
                    if (y < currentSize)
                    {
                        spiral[x][y] = current;
                        if (x - 1 > 0)
                        {
                            if (spiral[x - 1][y] == 0)
                            {
                                direction = "up";
                            }
                        }
                    }
                }
                else if (direction == "up")
                {
                    x = x - 1;
                    if (x >= 0)
                    {
                        spiral[x][y] = current;
                        if (y - 1 > 0)
                        {
                            if (spiral[x][y - 1] == 0)
                            {
                                direction = "left";
                            }
                        }
                    }
                }
                else if (direction == "left")
                {
                    y = y - 1;
                    if (y >= 0)
                    {
                        spiral[x][y] = current;
                        if (x + 1 < currentSize)
                        {
                            if (spiral[x + 1][y] == 0)
                            {
                                direction = "down";
                            }
                        }
                    }
                }
                else if (direction == "down")
                {
                    x = x + 1;
                    if (x < currentSize)
                    {
                        spiral[x][y] = current;
                        if (y + 1 < currentSize)
                        {
                            if (spiral[x][y + 1] == 0)
                            {
                                direction = "right";
                            }
                        }
                    }
                }
                current++;
            }
        }

        private void PrintSpiral()
        {

            string blank = " ";
            for (int i = 0; i < (size * size).ToString().Length; i++)
            {
                blank += " ";
            }

            for (int i = 0; i < spiral.Count; i++)
            {
                for (int j = 0; j < spiral[i].Count; j++)
                {
                    string to_print = spiral[i][j].ToString();;
                    Console.Write((blank + to_print).Substring(to_print.Length - 1));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void GrowSpiral()
        {
            size += 2;

            for (int i = 0; i < spiral.Count; i++)
            {
                spiral[i].Insert(0, 0);
                spiral[i].Add(0);
            }

            List<int> newLine = new List<int>();
            List<int> newLine2 = new List<int>();
            for (int i = 0; i < size; i++)
            {
                newLine.Add(0);
                newLine2.Add(0);
            }
            spiral.Insert(0, newLine);
            spiral.Add(newLine2);

            FillSpiral(size - 2, size - 2, (size - 2) * (size - 2) + 1, "right");
        }

        private int CountPrimes()
        {
            int count = 0;
            for (int i = 0; i < spiral.Count; i++)
            {
                if (s.isPrime(spiral[i][i]))
                {
                    count++;
                }
                if (s.isPrime(spiral[i][size - i - 1]))
                {
                    count++;
                }
            }
            return count;
        }

        public void Run()
        {
            InitSpiral();
            int primes = CountPrimes();
            double primes_ratio = primes / (size * 2.0 - 1);
            while (primes_ratio > 0.1)
            {
                GrowSpiral();
                primes += s.isPrime(spiral[0][0]) ? 1 : 0;
                primes += s.isPrime(spiral[0][size - 1]) ? 1 : 0;
                primes += s.isPrime(spiral[size - 1][0]) ? 1 : 0;
                //primes += s.prime[spiral[size-1][size-1]] ? 1 : 0; // Always a Square Number
                primes_ratio = primes / (size * 2.0 - 1);
            }
            Console.WriteLine(primes.ToString() + "/" + (size * 2 - 1).ToString() + " = " + primes_ratio.ToString());
            Console.ReadLine();
        }
    }
}
