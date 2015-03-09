using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem92
    {
        private int lower = -1;
        private int upper = -1;

        public Problem92(int l, int u)
        {
            lower = l;
            upper = u;
        }

        public int Run()
        {
            int count = 0;
            for (int i = lower; i <= upper; i++)
            {
                if (DigitSquares(i) == 89)
                {
                    count++;
                }
            }
            return count;
        }

        private int DigitSquares(int num)
        {
            int res = num;
            while (res > 0 && res != 1 && res != 89)
            {
                int sum = 0;
                string stres = res.ToString();
                for(int i = 0; i < stres.Length; i++) {
                    int r = int.Parse(stres[i].ToString());
                    sum += r * r;
                }
                res = sum;
                //Console.WriteLine(res.ToString());
            }
            return res;
        }
    }
}
