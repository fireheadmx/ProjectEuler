using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem71
    {
        int upper = 1000000;

        public void Run()
        {
            Fraction f_closest = new Fraction(2, 5);
            Fraction f_3_7 = new Fraction(3, 7);
            for (int d = 2; d <= upper; d++)
            {
                for (long n = f_closest.Numerator; n < d; n++)
                {
                    if (Fraction.GCD(n, d) == 1)
                    {
                        Fraction f = new Fraction(n, d);
                        if (f > f_3_7)
                        {
                            break;
                        }
                        else if (f > f_closest && f < f_3_7)
                        {
                            f_closest = f;
                        }
                    }
                }
            }
            Console.WriteLine(f_closest.Numerator);
        }
    }
}
