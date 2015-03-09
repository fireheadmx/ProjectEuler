using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem32
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        private int NumberInArray(int start, int end)
        {
            int result = 0;
            for (int i = start; i <= end; i++)
            {
                result += numbers[i] * (int) Math.Pow(10, (end - i));
            }
            return result;
        }

        public string Run()
        {
            List<int> res = new List<int>();
            List<int[]> resFull = new List<int[]>();
            do
            {
                for (int i = 0; i < (numbers.Length*2/3) +1; i++)
                {
                    for (int j = i + 1; j <= (numbers.Length*2/3) +1; j++)
                    {
                        int a = NumberInArray(0, i);
                        int b = NumberInArray(i+1, j);
                        int c = NumberInArray(j+1, numbers.Length - 1);

                        if (a * b == c)
                        {
                            if (!res.Contains(c))
                            {
                                res.Add(c);
                            }
                            resFull.Add(new int[] {a, b, c});
                        }
                    }
                }
            }
            while (Permutation.NextPermutation(numbers));

            int sum = 0;
            foreach (int r in res)
            {
                sum += r;
            }
            return sum.ToString() ;
        }
    }
}
