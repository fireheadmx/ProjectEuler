using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem108
    {
        public void Run()
        {
            //int max_solutions = 850;
            //int max_n = 120120;
            //int n = 120120;

            int max_solutions = 14;
            int max_n = 30;
            int n = 30;

            int solutions;
            Fraction fraction_n;
            while (max_solutions < 1000)
            {
                n+= 10;
                if (n % 3 == 0 && n % 7 == 0 && n % 11 == 0 ) 
                {
                    fraction_n = new Fraction(1, n);
                    solutions = 0;
                    for (int m = n + 1; m <= n * 2; m++)
                    {
                        if ((fraction_n - (new Fraction(1, m))).Numerator == 1)
                            solutions++;
                    }
                    if (solutions > max_solutions)
                    {
                        max_n = n;
                        max_solutions = solutions;

                        Console.WriteLine("1/{0}: {1}", n, solutions);
                    }
                }
            }
            Console.WriteLine(max_n);
            Console.ReadLine();
        }
    }
}
