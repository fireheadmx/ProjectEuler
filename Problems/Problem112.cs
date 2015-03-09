using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem112
    {
        private bool IsBouncy(int number)
        {
            if (number < 100) { return false; }
            int a, b;
            bool increasing = true;
            bool decreasing = true;
            do
            {
                a = number % 10;
                b = (number / 10) % 10;
                increasing &= (a >= b);
                decreasing &= (a <= b);
                number /= 10;
            } while (number >= 10);

            return !(increasing || decreasing);
        }

        private bool IsBouncy2(int number)
        {
            if (number < 100) { return false; }
            string numberS = number.ToString();
            bool increasing = true;
            bool decreasing = true;
            bool allEqual = true;
            for (int i = 0; i < numberS.Length - 1; i++)
            {
                increasing &= int.Parse(numberS[i].ToString()) <= int.Parse(numberS[i + 1].ToString());
                decreasing &= int.Parse(numberS[i].ToString()) >= int.Parse(numberS[i + 1].ToString());
                allEqual &= int.Parse(numberS[i].ToString()) == int.Parse(numberS[i + 1].ToString());
            }
            return !(increasing || decreasing || allEqual);
        }

        public void Run()
        {
            double target = 0.99;
            double count = 0;
            double rate = 0;
            int i;
            for (i = 100; rate < target; )
            {
                if (IsBouncy2(i))
                {
                    count++;
                    //Console.WriteLine(i.ToString() + " @ " + rate.ToString());
                }
                rate = (count / (i)); // Zero counts as Number
                if (rate == target)
                {
                    break;
                }
                i++;
            }
            Console.WriteLine(i.ToString() + " @ " + rate.ToString());
        }
    }
}
