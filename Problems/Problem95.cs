using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem95
    {
        private SortedSet<int> chain = new SortedSet<int>();

        private int SumDivisors(int number)
        {
            int sum = 1;
            double number_sqrt = Math.Sqrt(number);
            for (int i = 2; i <= number_sqrt; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                    if (number / i != i)
                    {
                        sum += number / i;
                    }
                }
            }
            return sum;
        }

        private int[] Chain(int number)
        {
            int[] no_chain = new int[1] { 0 };
            int orig_number = number;
            chain.Clear();
            int prev_chain_size;
            do
            {
                prev_chain_size = chain.Count;
                chain.Add(number);
                number = SumDivisors(number);
                if (number == orig_number)
                {
                    return chain.ToArray();
                }
                else if (number > 1000000)
                {
                    return no_chain;
                }
            }
            while (prev_chain_size < chain.Count);

            return no_chain;
        }

        public void Run()
        {
            int n = 12496;
            int[] longest_chain = Chain(n);
            int longest_n = n;
            int[] chain_n;
            do
            {
                n++;
                chain_n = Chain(n);
                if (chain_n.Count() > longest_chain.Count())
                {
                    longest_chain = chain_n;
                    longest_n = n;
                }
            }
            while (n < 1000000);

            Console.WriteLine(longest_chain.First().ToString());
            Console.ReadLine();
        }
    }
}
