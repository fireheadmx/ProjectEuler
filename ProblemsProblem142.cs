using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem142
    {
        private const int upper = 1000000;

        private bool IsSquare(long number)
        {
            return Math.Sqrt(number) % 1 == 0;
        }

        public void Run()
        {

            long minsum = int.MaxValue;
            int minX = 0, minY = 0, minZ = 0;

            long xpy, xmy, xpz, xmz, ypz, ymz;


            using (StreamWriter swr = new StreamWriter("Output/p142_PerfectSquares.txt", true))
            {
                swr.WriteLine("Run @ {0}", DateTime.Now);
            }

            for (int x = 3; x < upper; x++)
            {
                for (int y = 2; y < x; y++)
                {
                    xpy = x + y;
                    xmy = x - y;

                    if (IsSquare(xpy) && IsSquare(xmy))
                    {
                        for (int z = 1; z < y; z++)
                        {
                            xpz = x + z;
                            xmz = x - z;
                            ypz = y + z;
                            ymz = y - z;

                            if (IsSquare(xpz) && IsSquare(xmz) && IsSquare(ypz) && IsSquare(ymz))
                            {
                                Console.WriteLine("{0}+{1}+{2}={3}", x, y, z, x + y + z);
                                using (StreamWriter swr = new StreamWriter("Output/p142_PerfectSquares.txt", true))
                                {
                                    swr.WriteLine("{0}+{1}+{2}={3}", x, y, z, x + y + z);
                                }                                   
                                if (x + y + z < minsum)
                                {
                                    minX = x;
                                    minY = y;
                                    minZ = z;
                                    minsum = x + y + z;
                                }
                            }
                        }
                    }
                }
            }

            using (StreamWriter swr = new StreamWriter("Output/p142_PerfectSquares.txt", true))
            {
                swr.WriteLine("Min: {0}+{1}+{2}={3}", minX, minY, minZ, minX + minY + minZ);
            } 
            Console.WriteLine("Min: {0}+{1}+{2}={3}", minX, minY, minZ, minX + minY + minZ);
            Console.ReadLine();
        }
    }
}
