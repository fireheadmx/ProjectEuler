using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem203
    {
        private const int upper = 51;
        Sieve s = new Sieve(upper*upper);

        // Pascal's Triangle
        void printPascal(int n)
        {
            for (int line = 1; line <= n; line++)
            {
                int C = 1;  // used to represent C(line, i)
                for (int i = 1; i <= line; i++)
                {
                    Console.Write(String.Format("{0} ", C));  // The first value in a line is always 1
                    C = C * (line - i) / i;
                }
                Console.WriteLine();
            }
        }

        private bool SquareFree(BigInteger n)
        {
            foreach (int p in s.primeList)
            {
                if (p * p > n)
                {
                    break;
                }
                if (n % (p * p) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private BigInteger[] fillPascal(int n)
        {
            HashSet<BigInteger> pascal_ints = new HashSet<BigInteger>();

            for (int line = 1; line <= n; line++)
            {
                BigInteger C = 1;  // used to represent C(line, i)
                for (int i = 1; i <= line; i++)
                {
                    if (!pascal_ints.Contains(C))
                    {
                        if (SquareFree(C))
                        {
                            pascal_ints.Add(C);
                        }
                    }
                    C = C * (line - i) / i;
                }
            }

            return pascal_ints.ToArray();
        }

        public void Run()
        {
            BigInteger[] different_squarefrees = fillPascal(upper);
            BigInteger sum = 0;
            foreach (BigInteger dsf in different_squarefrees)
            {
                sum += dsf;
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }

    }
}
