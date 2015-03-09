using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem74
    {
        private int[] f;
        public Problem74()
        {
            // Fill Factorials
            f = new int[10];
            f[0] = 1;
            for (int i = 1; i < f.Length; i++)
            {
                f[i] = i * f[i - 1];
            }
        }
        private long SumFact(long number)
        {
            long sum = 0;
            do
            {
                sum += f[number % 10];
                number /= 10;
            }
            while (number > 0);
            return sum;
        }

        private int ChainSize(long number)
        {
            int chainSize = 0;
            HashSet<long> chainElements = new HashSet<long>();
            do {
                chainSize = chainElements.Count();
                chainElements.Add(number);
                number = SumFact(number);
            }
            while(chainSize != chainElements.Count());
            return chainSize;
        }

        public void Run()
        {
            int count = 0;
            for (int i = 1; i < 1000000; i++)
            {
                count += ChainSize(i) == 60 ? 1 : 0;
            }
            Console.WriteLine(count);
        }
    }
}
