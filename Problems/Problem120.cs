using System;
using System.Numerics;
namespace ProjectEuler.Problems
{
    class Problem120
    {

        private int r(int a, int n)
        {
            // ( (a-1)^n + (a+1)^n ) % a*a
            // = ( ((a-1)^n) % a*a + ((a+1)^n) % a*a ) % a*a
            int sq_a = a * a;
            return ((int)BigInteger.ModPow(a - 1, n, sq_a) + (int)BigInteger.ModPow(a + 1, n, sq_a)) % (sq_a);
        }

        public void Run()
        {
            BigInteger sum = 0;
            int max_r, current_r;
            for (int a = 3; a <= 1000; a++)
            {
                max_r = int.MinValue;

                for (int n = 3; n <= 3*a; n++)
                {
                    current_r = r(a, n);
                    max_r = Math.Max(max_r, current_r);
                }
                //Console.WriteLine("r_max(" + a.ToString() + ")= " + max_r.ToString());
                sum += max_r;
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
