using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem40
    {
        private int upper = -1;
        public Problem40(int u)
        {
            upper = u;
        }

        public int Run()
        {
            int res = 1;
            int i = 0;

            int num = 1;
            string numS = "1";

            while (i < upper)
            {
                if (numS.Length == 0)
                {
                    num++;
                    numS = num.ToString();
                }

                int top = int.Parse(numS[0].ToString());
                numS = numS.Substring(1);
                i++;

                if (i == 1 || i == 10 || i == 100 || i == 1000 || i == 10000 || i == 100000 || i == 1000000)
                {
                    Console.WriteLine(" " + top.ToString());
                    res *= top;
                }
            }

            return res;
        }
    }
}
