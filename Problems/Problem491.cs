using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem491
    {



        public static void Run()
        {
            DateTime start = DateTime.Now;
            int[] dblpan = {1, 0, 0, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};

            //int[] dblpan = { 4,0,5,6,1,8,1,7,7,0,3,8,2,3,5,6,4,9,2,9  };

            BigInteger counter = 0;

            do {

                // Alternating sum of the number, left to right
                int altSum = dblpan[0] - dblpan[1] +
                    dblpan[2] - dblpan[3] + dblpan[4] - dblpan[5] +
                    dblpan[6] - dblpan[7] + dblpan[8] - dblpan[9] +
                    dblpan[10] - dblpan[11] + dblpan[12] - dblpan[13] +
                    dblpan[14] - dblpan[15] + dblpan[16] - dblpan[17] +
                    dblpan[18] - dblpan[19];
                if (altSum % 11 == 0)
                {
                    /*
                    // Divisible by 11
                    Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}{17}{18}{19}",
                    dblpan[0], dblpan[1], dblpan[2], dblpan[3], dblpan[4], dblpan[5],
                    dblpan[6], dblpan[7], dblpan[8], dblpan[9], dblpan[10], dblpan[11],
                    dblpan[12], dblpan[13], dblpan[14], dblpan[15], dblpan[16], dblpan[17],
                    dblpan[18], dblpan[19]);
                     */
                    counter++;
                }
            }
            while(Permutation.NextPermutation(dblpan));

            using (StreamWriter sw = new StreamWriter("Output/p491.txt", true))
            {
                DateTime end = DateTime.Now;
                sw.WriteLine("Total: {0}", counter);
                sw.WriteLine("Time: {0}h, {1}m, {2}s", (start - end).TotalHours, (start - end).Minutes, (start - end).Seconds);
            }

            Console.WriteLine("Total: {0}", counter);
            Console.ReadLine();

        }
    }
}
