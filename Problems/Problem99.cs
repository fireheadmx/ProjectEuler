using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem99
    {
        private int Compare(int x1, int y1, int x2, int y2)
        {
            int yc = (int)Fraction.GCD(y1, y2);
            y1 /= yc;
            y2 /= yc;

            if (x1 == x2)
            {
                if (y1 > y2)
                {
                    return 1;
                }
                else if (y1 == y2)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else if (x1 == 1)
            {
                return -1;
            }
            else if (x1 > x2)
            {
                return -1 * Compare(x2, y2, x1, y1);
            }
            else // if (x1 < x2)
            {
                if (y1 <= y2)
                {
                    return -1;
                }
                else// (y1 > y2)
                {
                    if (((decimal)x2 / x1) % 1 == 0)
                    {
                        return Compare(x1, y1 - y2, (x2 / x1), y2);
                    }
                    else
                    {
                        //double log1 = Math.Log(y1, x1);
                        //double log2 = Math.Log(y2, x2);
                        //double log1 = Math.Log(x1, y1);
                        //double log2 = Math.Log(x2, y2);
                        //if (log1 > log2)
                        //{
                        //    return 1;
                        //}
                        //else if (log1 == log2)
                        //{
                        //    return 0;
                        //}
                        //else // log1 < log2
                        //{
                        //    return -1;
                        //}

                        double log1 = y1 * Math.Log(x1);
                        double log2 = y2 * Math.Log(x2);
                        if (log1 > log2)
                        {
                            return 1;
                        }
                        else if (log1 == log2)
                        {
                            return 0;
                        }
                        else // log1 < log2
                        {
                            return -1;
                        }

                        //return BigInteger.Compare(BigInteger.Pow(x1, y1), BigInteger.Pow(x2, y2));
                    }
                }
            }
        }

        public void Run()
        {
            try
            {
                int maxI = -1;
                int maxX = 1;
                int maxY = 1;

                int[][] input = new int[1000][];

                using (StreamReader sr = new StreamReader("Input/p099_base_exp.txt"))
                {
                    string[] str_input;
                        int i = 0;
                        do
                        {
                            str_input = sr.ReadLine().Split(',');
                            input[i] = new int[2];
                            input[i][0] = int.Parse(str_input[0]);
                            input[i][1] = int.Parse(str_input[1]);
                            i++;
                        }
                        while (i < 1000);
                    
                }

                for (int i = 0; i < 1000; i++)
                {
                    if (Compare(input[i][0], input[i][1], maxX, maxY) > 0)
                    {
                        maxX = input[i][0];
                        maxY = input[i][1];
                        maxI = (i+1);
                    }
                }

                Console.Write(maxI.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
        //public void Run()
        //{
        //    try
        //    {
        //        BigInteger max = 0;
        //        double maxLog = 1;
        //        int maxI = 1;

        //        using (StreamReader sr = new StreamReader("Input/p099_base_exp.txt"))
        //        {
        //            string str_input = "";
        //            int i = 1;
        //            do
        //            {
        //                str_input = sr.ReadLine();
        //                int x = int.Parse(str_input.Split(',')[0]);
        //                int y = int.Parse(str_input.Split(',')[1]);
        //                double logRange = Math.Log10(x) * Math.Log10(y);
        //                if (logRange >= maxLog)
        //                {
        //                    // Candidate for comparison
        //                    BigInteger currentNumber = BigInteger.Pow(x,y);
        //                    if (currentNumber > max)
        //                    {
        //                        max = currentNumber;
        //                        maxI = i;
        //                        maxLog = logRange;
        //                    }
        //                }
        //                i++;
        //            }
        //            while (i <= 1000);
        //        }

        //        Console.Write(maxI.ToString());
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("The file could not be read:");
        //        Console.WriteLine(e.Message);
        //    }

        //    Console.ReadLine();
        //}
    }
}
