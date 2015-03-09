using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem47
    {
        Sieve s;
        private int upper = 1000000;
        public Problem47()
        {
            s = new Sieve(upper/2);
        }

        private int CountFactors(int number)
        {
            int count = 0;
            for (int i = 0; i < s.primeList.Count; i++)
            {
                long prime = s.primeList[i];
                if (prime > number / 2)
                {
                    break;
                }

                if (number % prime == 0)
                {
                    count++;
                }
            }
            return count;
        }

        public void Run()
        {
            for (int num = 10; num < upper - 3; num++)
            {
                if (CountFactors(num) == 4)
                {
                    if (CountFactors(num+1) == 4)
                    {
                        if (CountFactors(num+2) == 4)
                        {
                            if (CountFactors(num + 3) == 4)
                            {
                                Console.WriteLine(num);
                                return;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Not found in first " + upper.ToString());
        }
    }
}
