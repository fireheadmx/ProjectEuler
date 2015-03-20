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
            bool printOutput = true;
            DateTime start = DateTime.Now;
            int[] dblpan = {1, 0, 0, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};
            BigInteger counter = 0;
            BigInteger permCounter = 0;
            // Max Reached
            //dblpan = new int[]{1,0,0,1,7,8,4,3,7,4,8,5,9,2,6,2,5,3,9,6};
            //counter = BigInteger.Parse("5535256117");
            do {
                permCounter++;
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

            DateTime end = DateTime.Now;

            if (printOutput)
            {
                using (StreamWriter sw = new StreamWriter("Output/p491.txt", true))
                {
                    sw.WriteLine("Permutations: {0}", permCounter);
                    sw.WriteLine("Total %11=0: {0}", counter);
                    sw.WriteLine("Time: {0}h, {1}m, {2}s", (start - end).TotalHours, (start - end).Minutes, (start - end).Seconds);
                }
            }

            Console.WriteLine("Permutations: {0}", permCounter);
            Console.WriteLine("Total: {0}", counter);
            Console.WriteLine("Time: {0}h, {1}m, {2}s", (start - end).TotalHours, (start - end).Minutes, (start - end).Seconds);
            Console.ReadLine();

        }
    }
}
