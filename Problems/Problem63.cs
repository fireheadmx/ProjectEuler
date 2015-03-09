using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem63
    {
        public void Run()
        {
            int upper = 500;
            int count = 0;
            string largest = "";

            for(int x = 1; x <= upper*2; x++) {
                for (int y = 1; y <= upper; y++)
                {
                    var num = BigInteger.Pow(x, y);
                    string numStr = num.ToString();
                    if (numStr.Length == y)
                    {
                        count++;
                        largest = x.ToString() + "^" + y.ToString() + " = " + numStr + "     ";
                    }
                    else if (numStr.Length > y)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(largest);
            Console.WriteLine(count);

        }
    }
}
