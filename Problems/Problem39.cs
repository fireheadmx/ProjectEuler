using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem39
    {
        int max = -1;
        int maxP = -1;

        public string Run(int upper)
        {
            for(int p=3; p<=upper; p++) {
                int val = Solutions(p);
                if (val > max)
                {
                    max = val;
                    maxP = p;
                }
            }
            return maxP.ToString();
        }

        private int Solutions(int p)
        {
            int res = 0;

            for (int a = 1; a < p / 2; a++)
            {
                for (int b = a; b < p - a; b++)
                {
                    int cTemp = p - a - b;
                    double c2 = Math.Pow(a, 2) + Math.Pow(b, 2);
                    decimal c = (decimal)Math.Sqrt(c2);

                    if (cTemp == c)
                    {
                        //Console.WriteLine(p.ToString() + ": (" + a.ToString() + ", " + b.ToString() + ", " + cTemp.ToString() + ") ");
                        res++;
                    }
                }
            }

            return res;
        }
    }
}
