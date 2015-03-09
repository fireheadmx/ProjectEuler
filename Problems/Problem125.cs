using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem125
    {
        private bool Palindrome(int number)
        {
            bool is_palindrome = true;
            string numberStr = number.ToString();
            for (int i = 0; i < numberStr.Length / 2; i++)
            {
                is_palindrome &= numberStr[i] == numberStr[numberStr.Length - 1 - i];
                if (!is_palindrome)
                {
                    break;
                }
            }
            return is_palindrome;
        }

        private bool SumOfSquares(int number)
        {
            var upper = Math.Sqrt(number);
            for (int i = (int) upper; i > 1; i--)
            {
                int sum = i * i;
                int j = i;
                do
                {
                    j--;
                    sum += (j * j);
                    if (sum == number)
                    {
                        return true;
                    }
                    else if (sum > number)
                    {
                        break;
                    }
                }
                while (j >= 1);
            }
            return false;
            // 100K @ 40ms
        }

        public void Run()
        {
            DateTime start = DateTime.Now;
            int count = 0;
            long sum = 0;
            for (int n = 2; n < 100000000; n++)
            {
                if(Palindrome(n)) {
                    if (SumOfSquares(n))
                    {
                        count++;
                        sum += n;
                    }
                    
                }
            }
            Console.WriteLine(count);
            Console.WriteLine(sum);
            Console.Write((DateTime.Now - start).TotalMilliseconds);
            Console.WriteLine(" ms");
            Console.ReadLine();
        }

    }
}
