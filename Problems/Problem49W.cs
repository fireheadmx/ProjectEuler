using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem49W
    {
        private Sieve s;
        private int upper = 10000;
        public Problem49W()
        {
            s = new Sieve(upper);
        }

        private List<int> GetPermutations(int number)
        {
            List<int> numberList = new List<int>();
            while (number > 0)
            {
                numberList.Add(number % 10);
                number = number / 10;
            }
            numberList.Sort();

            int[] permutable = numberList.ToArray();
            List<int> result = new List<int>();
            do
            {
                int permuted = 0;
                for (int i = 0; i <= permutable.Length - 1; i++)
                {
                    permuted += permutable[i] * (int)Math.Pow(10, (permutable.Length - 1 - i));
                }
                result.Add(permuted);
            }
            while (Permutation.NextPermutation(permutable));

            return result;
        }

        public void Run()
        {
            List<int> permutablePrimes = new List<int>();
            List<int> allPermutablePrimes = new List<int>();
            for(int i = 1000; i < upper; i++) {
                if (s.prime[i])
                {
                    int countPrimes = 0;
                    List<int> foundPrimes = new List<int>();
                    foreach (int value in GetPermutations(i))
                    {
                        if (s.prime[value])
                        {
                            foundPrimes.Add(value);
                            countPrimes++;
                        }
                    }
                    if (countPrimes >= 2)
                    {
                        allPermutablePrimes.AddRange(foundPrimes);
                    }
                    if (countPrimes == 3)
                    {
                        permutablePrimes.AddRange(foundPrimes);
                    }
                }
            }

            foreach (int prime in permutablePrimes)
            {
                Console.WriteLine(prime);
            }
        }
    }
}
