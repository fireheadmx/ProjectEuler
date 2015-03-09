using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem55
    {
        private int upper = 10000;
        private int lycrel = 50;

        private bool Palindrome(BigInteger number)
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

        private BigInteger ReverseAndAdd(BigInteger number)
        {
            string numberStr = number.ToString();
            string invertStr = "";
            for(int i=numberStr.Length-1; i>=0;i--) {
                invertStr += numberStr[i];
            }

            return number + BigInteger.Parse(invertStr);
        }

        public string Run()
        {
            int count = 0;
            List<int> lycrel_numbers = new List<int>();
            for (int number = 1; number <= upper; number++)
            {
                int i = 1;
                BigInteger candidate = new BigInteger(number);
                do
                {
                    candidate = ReverseAndAdd(candidate);
                    if (Palindrome(candidate))
                    {
                        break;
                    }
                    i++;
                }
                while (i <= lycrel);

                if (i > lycrel)
                {
                    lycrel_numbers.Add(number);
                    count++;
                }
            }

            return count.ToString();
        }
    }
}
