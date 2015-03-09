using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem43
    {
        int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public string Run()
        {
            long sum = 0;
            do
            {
                if (d(2, 3, 4, 2) && d(3, 4, 5, 3) && d(4, 5, 6, 5) && d(5, 6, 7, 7) 
                    && d(6, 7, 8, 11) && d(7, 8, 9, 13) && d(8, 9, 10, 17))
                {
                    // Add number
                    long current = 0;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        current += (long)Math.Pow(10, i) * numbers[numbers.Length - 1 - i];
                    }
                    Console.WriteLine(current.ToString());
                    sum += current;
                }
            }
            while (Permutation.NextPermutation(numbers));

            return sum.ToString();
        }

        private bool d(int i, int j, int k, int factor)
        {
            int val = numbers[i - 1] * 100 + numbers[j - 1] * 10 + numbers[k - 1];
            return val % factor == 0;
        }

        
    }
}
