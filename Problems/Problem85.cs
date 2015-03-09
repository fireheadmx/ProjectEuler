using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem85
    {
        public void Run()
        {
            int minX = 0, minY = 0, min = 1800000;
            int maxX = 0, maxY = 0, max = 2200000;

            // [3,2] = (3 + 2 + 1) + 2*( 3 + 2 + 1)

            for (int x = 3; x < 100; x++)
            {
                for (int y = 2; y < 100; y++)
                {
                    int sum = 0;
                    for (int i = 1; i <= x; i++)
                    {
                        sum += i;
                    }

                    int prodSum = 0;
                    for (int j = 1; j <= y; j++)
                    {
                        prodSum += j * sum;
                    }

                    if (prodSum > min && prodSum < 2000000)
                    {
                        min = prodSum;
                        minX = x;
                        minY = y;
                    }
                    else if (prodSum < max && prodSum > 2000000)
                    {
                        max = prodSum;
                        maxX = x;
                        maxY = y;
                    }

                    if (prodSum > 2100000)
                    {
                        break;
                    }
                }
            }

            int result = 2000000 - min < max - 2000000 ? min : max;
            int resultX = 2000000 - min < max - 2000000 ? minX : maxX;
            int resultY = 2000000 - min < max - 2000000 ? minY : maxY;

            Console.WriteLine("{0}x{1} ({2}) : {3}", resultX, resultY, resultX * resultY, result);

            Console.ReadLine();
        }
    }
}
