using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem49
    {
        private Sieve s;
        private int upper = 10000;
        private int step = 3330;
        public Problem49()
        {
            s = new Sieve(upper + step * 2);
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
                if (s.prime[i] && s.prime[i + step] && s.prime[i + 2 * step])
                {
                    var foundPermutations =  GetPermutations(i);
                    if(foundPermutations.Contains(i+step) && foundPermutations.Contains(i+2*step)) {
                        permutablePrimes.Add(i);
                        permutablePrimes.Add(i+step);
                        permutablePrimes.Add(i + 2*step);
                    }
                }
            }

            foreach (int prime in permutablePrimes)
            {
                if (prime != 1487 && prime != 4817 && prime != 8147)
                {
                    Console.Write(prime);
                }
            }
        }

    }
}
