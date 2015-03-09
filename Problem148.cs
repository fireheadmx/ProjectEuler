using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem148
    {

        public static void Run()
        {
            DateTime start = DateTime.Now;

            List<BigInteger> low = new List<BigInteger>();
            low.Add(1);
            List<BigInteger> high = new List<BigInteger>();
            high.Add(1);

            List<int> printRow = new List<int>();
            printRow.Add(10);
            printRow.Add(100);
            printRow.Add(1000);
            printRow.Add(2000);
            printRow.Add(3000);
            printRow.Add(4000);
            printRow.Add(5000);
            printRow.Add(6000);
            printRow.Add(7000);
            printRow.Add(8000);
            printRow.Add(9000);
            printRow.Add(10000);

            List<BigInteger> temp;

            int row = 2;
            BigInteger count = 0;
            BigInteger total = 3;
            BigInteger num;

            do
            {
                row++;
                total += row;
                temp = new List<BigInteger>();
                temp.Add(1);
                for (int i = 0; i < high.Count - 1; i++)
                {
                    num = high[i] + high[i + 1];
                    temp.Add(num);
                    

                    if(num % 7 == 0)
                    {
                        count+= 2;
                    }
                }
                if (row % 2 == 1)
                {
                    num = high[high.Count - 1] * 2;
                    temp.Add(num);

                    if (num % 7 == 0)
                    {
                        count++;
                    }
                }

                if (row % 1000 == 0)
                {
                    Console.WriteLine("#{0} \tT={1} \t%7={2} \t%!7={3}", row, total, count, total - count);
                    using (StreamWriter sw = new StreamWriter("Output/p148.txt", true))
                    {
                        sw.WriteLine("#{0} \tT={1} \t%7={2} \t%!7={3}", row, total, count, total - count);
                    }
                }

                low = high;
                high = temp;
            }
            while (row < 1000000);

            Console.WriteLine("Total: {0}", total);
            Console.WriteLine("%7!=0: {0}", total-count);
            Console.WriteLine("{0} ms", (DateTime.Now - start).TotalMilliseconds);
            Console.WriteLine("{0} s", (DateTime.Now - start).TotalSeconds);
            Console.WriteLine("{0} mins", (DateTime.Now - start).TotalMinutes);
            Console.ReadLine();
        }

    }
}
