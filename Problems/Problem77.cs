using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem77
    {
        private Sieve s;
        private int upper = 5000;

        public Problem77()
        {
            s = new Sieve(upper / 10);
        }

        private long count_comb(long num, long largest)
        {
            if (num == 0)
            {
                return 1;
            }
            else if (num < 0)
            {
                return 0;
            }
            else
            {
                long total = 0;
                foreach (long unit in s.primeList)
                {
                    if (unit <= largest)
                    {
                        total += count_comb(num - unit, num);
                    }
                }
                return total;
            }
        }

        public void Run()
        {
            long current = 4;
            long combinations = 0;
            do
            {
                current += 1;
                combinations = count_comb(current, current);
                Console.WriteLine(current.ToString() + " @ " + combinations.ToString());
            }
            while (combinations < upper);
            Console.WriteLine(current);
        }
    }
}
