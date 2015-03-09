using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem94
    {
        //long upper = 1000000000;
        long upper = 1000000000;

        //public void Run()
        //{
        //    // Heron's Formula for the area of a triangle
        //    // A = SQRT( p * (p-a) * (p-b) * (p-c) )
        //    // Where p = (a+b+c)/2
        //    BigInteger sum = 0;
        //    long perim1 = 0;
        //    long perim2 = 0;
        //    int a = 1;
        //    while (true)
        //    {
        //        a++;
        //        perim1 = (3 * a) + 1;
        //        perim2 = (3 * a) - 1;
        //        if (perim1 >= upper && perim2 >= upper)
        //        {
        //            break;
        //        }

        //        if (perim1 < upper)
        //        {
        //            var p = perim1 / 2.0;

        //            decimal Area = (decimal)Math.Sqrt(p * (p - a) * (p - a) * (p - (a + 1)));
        //            if (Area % 1 == 0)
        //            {
        //                sum += perim1;
        //            }
        //        }
        //        if (perim2 < upper)
        //        {

        //            var p = perim2 / 2.0;

        //            decimal Area = (decimal)Math.Sqrt(p * (p - a) * (p - a) * (p - (a - 1)));
        //            if (Area % 1 == 0)
        //            {
        //                sum += perim2;
        //            }

        //        }

        //    }
        //    Console.WriteLine(sum);
        //    // 78132992318931446 // perim / 2 % 1 == 0
        //    // 156265902712058790 // double precision
        //    // 166354090790353765 // decimal precision, but one side greater
        //}

        public void Run()
        {
            // Heron's Formula for the area of a triangle
            // A = SQRT( p * (p-a) * (p-b) * (p-c) )
            // Where p = (a+b+c)/2
            BigInteger sum = 0;
            int a = 2;
            long perim = (3*a)-1;
            while (perim <= upper)
            {
                decimal p = perim / 2.0M;

                //var Area1 = Math.Sqrt((double)(p * (p - a) * (p - a) * (p - (a - 1))));
                var Area1 = Math.Exp(Math.Log((double) (p * (p - a) * (p - a) * (p - (a - 1)))) / 2);
                if (Area1 % 1 == 0)
                {
                    sum += perim;
                }

                perim = (3*a)+1;

                if (perim <= upper)
                {
                    p = perim / 2.0M;

                    //var Area2 = Math.Sqrt((double)(p * (p - a) * (p - a) * (p - (a + 1))));
                    var Area2 = Math.Exp(Math.Log((double)(p * (p - a) * (p - a) * (p - (a +1)))) / 2);
                    if (Area2 % 1 == 0)
                    {
                        sum += perim;
                    }
                }

                perim = (3 * ++a) - 1;
            }
            Console.WriteLine(sum);
        }
    }
}
