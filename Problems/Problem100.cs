using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    static class Problem100
    {
        public static void Run()
        {
            decimal prob;
            decimal min = 1000000000000m;
            decimal blue = 707106781184m; // 70m // 10m
            //decimal red = blue / 2.41422m - ((blue / 2.41422m) % 1);
            decimal red = 292893000000m;

            do
            {
                prob = (blue / (red + blue)) * ((blue - 1) / (red + blue - 1));
                if (prob < 0.5m)
                {
                    blue++;
                }
                else if (prob > 0.5m)
                {
                    red++;
                }
            }
            while (prob != 0.5m && blue + red < min);

            Console.WriteLine("Blu: {0}", blue);
            Console.WriteLine("Red: {0}", red);
            Console.WriteLine("Tot: {0}", blue + red);

            Console.ReadLine();
        }
    }
}
