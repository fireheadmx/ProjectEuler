using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem145
    {
        private int Reverse(int number)
        {
            int res = 0;

            if (number % 10 > 0)
            {
                while (number > 0)
                {
                    res *= 10;

                    res += number % 10;
                    number /= 10;
                }
            }
            return res;
        }

        private bool DigitsAreOdd(int number)
        {
            while (number > 0 )
            {
                if ((number % 10) % 2 == 0)
                {
                    return false;
                }
                number /= 10;
            }
            
            return true;
        }

        private bool IsReversible(int number)
        {
            int revNumber = Reverse(number);
            if (revNumber > 0)
            {
                return DigitsAreOdd(number + revNumber);
            }
            else
            {
                return false;
            }
        }

        public void Run()
        {
            int upper = 1000000000;
            int count = 0;
            for (int i = 0; i < upper; i++)
            {
                if (IsReversible(i))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
