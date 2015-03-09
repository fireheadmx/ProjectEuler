using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem69
    {
        int upper = 1000000;
        Sieve s;
        int[] totients;

        public Problem69()
        {
            DateTime start = DateTime.Now;
            s = new Sieve(upper + 1);
            totients = new int[upper + 1];
            Console.WriteLine("Init: " + (DateTime.Now - start).TotalMilliseconds.ToString() + " ms");
        }

        private int GCD(int a, int b) // Greatest Common Denominator
        {
            while (b != 0)
            {
                int c = a % b;
                a = b;
                b = c;
            }
            return a;
        }

        private int Totient(int number)
        {
            if (number <= 1) { return 0; }

            int multiplier = 1;
            while (number % 4 == 0)
            {
                multiplier *= 2;
                number /= 2;
            };

            if (totients[number] > 0)
            {
                return multiplier * totients[number];
            }

            if (s.prime[number])
            {
                return multiplier * (number - 1);
            };

            for (int n = number - 1; n > Math.Sqrt(number); n--)
            {
                if (number % n == 0)
                {
                    int m = number/n;
                    if (GCD(m, n) == 1)
                    {
                        return multiplier * totients[m] * totients[n];
                    }
                }
            }

            int countTot = 1;
            for (int i = 2; i < number; i++)
            {
                if (GCD(number, i) == 1)
                {
                    countTot++;
                }
            }
            return multiplier * countTot;
        }

        public void Run()
        {
            DateTime start = DateTime.Now;
            int maxN = 1;
            int maxTot = 1;
            decimal maxNtotN = 1;
            for (int n = 2; n <= upper; n++)
            {
                int totientN = Totient(n);
                totients[n] = totientN;
                decimal n_totN = (decimal)n / totientN;

                if (n_totN > maxNtotN)
                {
                    maxN = n;
                    maxTot = totientN;
                    maxNtotN = n_totN;
                    //Console.WriteLine(n.ToString() + " / " + totientN + " = " + ((decimal)n / totientN).ToString());
                }
            }

            Console.WriteLine(maxN.ToString() + " / " + maxTot + " = " + maxNtotN.ToString());
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds.ToString() + " ms");
        }
    }
}
