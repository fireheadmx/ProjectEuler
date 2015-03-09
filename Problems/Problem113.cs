using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem113
    {
        private bool IsBouncy(BigInteger number)
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
            DateTime start = DateTime.Now;
            BigInteger count = 0;
            BigInteger gogol = 100000;
            do
            {
                gogol *= 100000;
            }
            while (gogol.ToString().Length < 101);
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds);

            BigInteger i = 100;
            for (; i < gogol; i++)
            {
                count += IsBouncy(i) ? 0 : 1;
            }
            Console.WriteLine(count);
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
