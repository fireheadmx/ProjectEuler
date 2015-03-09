using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem27
    {
        public void Run()
        {
            int x = 1000;
            Sieve s = new Sieve(x*x + x*x + x); // n^2 + a*n + b @ n,a,b = 1000
            List<int> primes = new List<int>();
            for (int i = 0; i < x; i++)
            {
                if (s.prime[i])
                {
                    primes.Add(i);
                    primes.Add(i * -1);
                }
            }
            //primes.Sort();

            int max = 0;
            int maxA = 0;
            int maxB = 0;

            foreach (int a in primes)
            {
                foreach (int b in primes)
                {
                    int counter = 0;
                    for (int n = 0; n < Math.Abs(b); n++)
                    {
                        int number = n * n + a * n + b;
                        if (number > 0 && number < s.prime.Length)
                        {
                            if (s.prime[number])
                            {
                                counter++;
                                if (counter > max)
                                {
                                    max = counter;
                                    maxA = a;
                                    maxB = b;
                                }
                            }
                            else
                            {
                                counter = 0;
                            }
                        }
                        else
                        {
                            counter = 0;
                        }
                    }
                }
            }

            Console.WriteLine("" + maxA.ToString() + ", " + maxB.ToString() + ": " + max.ToString());
            Console.WriteLine((maxA * maxB).ToString());
            Console.ReadLine();
        }
    }
}
