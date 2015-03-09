using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem1
    {
        public static void Run()
        {
            long sum = 0;
            for (int n = 1; n < 1000; n++)
            {
                if (n % 3 == 0 || n % 5 == 0)
                {
                    sum += n;
                }
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
