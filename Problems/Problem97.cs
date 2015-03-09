using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem97
    {
        private BigInteger modpow(BigInteger bas, BigInteger exponent, BigInteger modulus)
        {

            BigInteger result = 1;

            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                {
                    // multiply in this bit's contribution while using modulus to keep result small
                    result = (result * bas) % modulus;
                }
                // move to the next bit of the exponent, square (and mod) the base accordingly
                exponent >>= 1;
                bas = (bas * bas) % modulus;
            }

            return result;
        }

        public void Run()
        {
            BigInteger lastTen = 0;
            //for (int i = 0; i < 10; i++)
            //{
            //    Math.Pow(10, i)
            //}
            lastTen = modpow(2, 7830457, (long)Math.Pow(10, 10));

            //lastTen = BigInteger.Pow(2, 7830457);

            BigInteger lastTen2 = (28433 * lastTen) + 1;
            string strLastTen2 = lastTen2.ToString();
            Console.WriteLine(strLastTen2.Substring(strLastTen2.Length-10));
        }
    }
}
