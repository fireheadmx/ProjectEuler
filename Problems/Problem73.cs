using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem73
    {
        //SortedSet<Fraction> all_f = new SortedSet<Fraction>();
        int upper = 12000;

        public void Run()
        {
            Fraction f_1_3 = new Fraction(1, 3);
            Fraction f_1_2 = new Fraction(1, 2);

            int count = 0;

            for (int d = 2; d <= upper; d++)
            {
                for (int n = 1; n <= d / 2; n++)
                {
                    Fraction f = new Fraction(n, d);
                    if (f.Denominator == d)
                    {
                        if (f > f_1_3 && f < f_1_2)
                        {
                            //all_f.Add(f);
                            count++;
                        }
                    }
                }
            }

            //Console.Write(all_f.Count);
            Console.WriteLine(count);
        }

        public void Run73()
        {
            int n = 1000;
            /* you need two fractions to start with!!! */
            double x0 = 333;
            double y0 = n;
            double x1 = 1;
            double y1 = 3;
            /* lower limit and upper limit */
            double ll = 1.0 / 3.0;
            double ul = 1.0 / 2.0;
            double b = 0.0;
            int s = 0;
            while (b <= ul)
            {
                double d = Math.Floor((y0 + n) / y1);
                double xx = d * x1 - x0;
                double yy = d * y1 - y0;
                if (xx <= yy)
                {
                    double x2 = xx;
                    double y2 = yy;
                    /* if within the interval add 1 to s */
                    b = (double)x2 / (double)y2;
                    if ((b > ll) && (b < ul)) s++;
                    /* done? */
                    if (b > ul) break;
                    /* update */
                    x0 = x1;
                    y0 = y1;
                    x1 = x2;
                    y1 = y2;
                }
            }
            Console.Write(s);
        }
    }
}
