using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem72
    {
        int upper = 1000000;
        Phi p;
        public Problem72()
        {
            DateTime start = DateTime.Now;
            p = new Phi(upper);
            Console.WriteLine("Init: " + (DateTime.Now - start).TotalMilliseconds.ToString() + " ms");
        }
        
        public void RunBrute()
        {
            BigInteger count = 0;

            for (int d = 2; d <= upper; d++)
            {
                int skip = (d % 2 == 0) ? 2 : 1;
                for (long n = 1; n < d; n+= skip)
                {
                    count += Phi.GCD(n, d) == 1 ? 1 : 0;
                }
            }
            Console.WriteLine(count);
        }

        public void RunTotient()
        {
            //BigInteger sum = 0;
            //for (int i = 0; i <= upper; i++)
            //{
            //    sum += p.totient[i];
            //}
            Console.WriteLine(p.sumTotient);
        }

        public void RunApprox()
        {
            Fraction f_low = new Fraction(1, 32);
            Fraction f_up = new Fraction(1, 16);

            int count = 0;

            for (int d = 2; d <= upper; d++)
            {
                for (int n = 1; n <= d / 2; n++)
                {
                    Fraction f = new Fraction(n, d);
                    if (f.Denominator == d)
                    {
                        if (f > f_low && f < f_up)
                        {
                            //all_f.Add(f);
                            count++;
                        }
                    }
                }
            }

            //Console.Write(all_f.Count);
            Console.WriteLine(count * (1 / (f_up - f_low)));
        }

        public void Run()
        {
            DateTime start = DateTime.Now;
            RunTotient();
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds.ToString() + " ms");
        }

        
    }
}
