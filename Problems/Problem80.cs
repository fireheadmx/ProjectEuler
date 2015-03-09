using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem80
    {
        private static BigInteger Squareroot(int n, int digits)
        {
            BigInteger limit = BigInteger.Pow(10, digits + 1);
            BigInteger a = 5 * n;
            BigInteger b = 5;

            while (b < limit)
            {
                if (a >= b)
                {
                    a -= b;
                    b += 10;
                }
                else
                {
                    a *= 100;
                    b = (b / 10) * 100 + 5;
                }
            }

            return b / 100;
        }

        public static void Run()
        {
            string hundredDigits;
            long sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                double sqrt = Math.Sqrt(i);
                if (sqrt != (int)sqrt)
                {
                    hundredDigits = Squareroot(i, 100).ToString();
                    Console.WriteLine("{0}: {1}", i, hundredDigits);
                    foreach(char digit in hundredDigits) {
                        sum += (digit-'0');
                    }
                }
            }

            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
