using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem46
    {
        private Sieve s;
        private int upper = 10000;
        public Problem46()
        {
            s = new Sieve(upper);
        }

        public void Run()
        {
            for (int i = 3; i < upper; i += 2)
            {
                if (!s.prime[i]) // Composite Odd numbers
                {
                    bool foundSum = false;
                    for(int p = 0; p < s.primeList.Count(); p++)
                    {
                        long prime = s.primeList[p];
                        if (prime >= i)
                        {
                            break;
                        }
                        for(int x = 1; x < (i - prime); x++) 
                        {
                            if (i == prime + (x * x) * 2)
                            {
                                foundSum = true;
                            }
                        }
                        if (foundSum)
                        {
                            break;
                        }
                    }
                    if (!foundSum)
                    {
                        Console.WriteLine(i);
                        return;
                    }
                }
            }
            Console.WriteLine("Not found in first " + upper.ToString());
        }
    }
}
