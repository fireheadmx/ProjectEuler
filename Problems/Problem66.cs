using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem66
    {
        public void Run()
        {
            // x**2 - D*y**2 = 1
            // D not square

            ulong maxX = 1;
            ulong maxY = 0;
            ulong maxD = 0;

            ulong y;
            double x;

            for (ulong D = 2; D <= 1000; D++)
            {
                if (Math.Sqrt(D) % 1 != 0)
                {
                    y = 0;
                    do
                    {
                        y++;
                        x = Math.Sqrt(1 + D * (y * y));
                    }
                    //while (x % 1 > 0.0000000000000000001);
                    //while (x % 1 != 0);
                    while (x != (ulong)x);

                    if (D * y * y < 0)
                    {
                        break;
                    }

                    if (x * x - D * y * y == 1)
                    {
                        if (x > maxX)
                        {
                            maxX = (ulong)x;
                            maxY = y;
                            maxD = D;

                            Console.WriteLine("{0}^2 - {1}*{2}^2 = 1\t\t<< ", x, D, y);
                        }
                    }
                    else
                    {
                        //Console.WriteLine("{0}^2 - {1}*{2}^2 = {3}", x, D, y, x * x - D * y * y);
                    }
                }
            }
            Console.WriteLine("==========");
            Console.WriteLine("D={0}", maxD);
            Console.WriteLine("x={0}", maxX);
            Console.WriteLine("y={0}", maxY);

            Console.ReadLine();
        }

        public void QuickRun()
        {
            // x**2 - D*y**2 = 1
            // D not square

            int maxX = 1;
            int maxY = 0;
            int maxD = 0;

            int y;
            double x;

            for (int D = 2; D <= 1000; D++)
            {
                if (Math.Sqrt(D) % 1 != 0)
                {
                    y = 0;
                    do
                    {
                        y++;
                        x = Math.Sqrt(1 + D * (y * y));
                    }
                    //while (x % 1 > 0.0000000000000000001);
                    //while (x % 1 != 0);
                    while (x != (int)x);

                    if (D * y * y < 0)
                    {
                        break;
                    }

                    if (x * x - D * y * y == 1)
                    {
                        if (x > maxX)
                        {
                            maxX = (int)x;
                            maxY = y;
                            maxD = D;

                            Console.WriteLine("{0}^2 - {1}*{2}^2 = 1                << ", x, D, y);
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0}^2 - {1}*{2}^2 = {3}", x, D, y, x * x - D * y * y);
                    }
                }
            }
            Console.WriteLine("==========");
            Console.WriteLine("D={0}", maxD);
            Console.WriteLine("x={0}", maxX);
            Console.WriteLine("y={0}", maxY);

            Console.ReadLine();
        }

        public void LongRun()
        {
            // x**2 - D*y**2 = 1
            // D not square

            int maxX = 1;
            int maxY = 0;
            int maxD = 0;

            //double x, y;
            double x;
            int y;

            BigInteger xx, dyy;

            for (int D = 2; D <= 1000; D++)
            {
                if (Math.Sqrt(D) % 1 != 0)
                {
                    //x = 1;
                    //do
                    //{
                    //    x++;

                    //    xx = BigInteger.Pow((int) x, 2);
                    //    var yy = (1 - xx) / -D;

                    //    BigInteger.ModPow(10, BigInteger.Log10(yy) / 2, 2);

                    //    //y = Math.Sqrt(yy);
                    //}
                    ////while (y != (int)y);
                    //while (y % 1 > 0.0000000001);

                    y = 0;

                    bool smallNumbers = true;
                    do
                    {
                        y++;
                        if (D * y * y < 0)
                        {
                            smallNumbers = false;
                        }
                        if (smallNumbers)
                        {
                            x = Math.Sqrt(1 + D * y * y);
                        }
                        else
                        {
                            dyy = 1 + (new BigInteger(y)) * y * D;
                            x = Math.Exp(BigInteger.Log(dyy) / 2);
                        }
                    }
                    while (x % 1 > 0.000000001);
                    //while (x % 1 != 0);
                    //while (x != (int)x);

                    if (x * x - D * y * y == 1)
                    {
                        if (x > maxX)
                        {
                            maxX = (int)x;
                            maxY = (int)y;
                            maxD = D;

                            Console.WriteLine("{0}^2 - {1}*{2}^2 = 1", x, D, y);
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0}^2 - {1}*{2}^2 = {3}", x, D, y, x * x - D * y * y);
                    }
                }
            }
            Console.WriteLine("==========");
            Console.WriteLine("D={0}", maxD);
            Console.WriteLine("x={0}", maxX);
            Console.WriteLine("y={0}", maxY);

            Console.ReadLine();
        }
    }
}
