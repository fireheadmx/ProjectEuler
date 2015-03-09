using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem81
    {
        int[][] input;
        int[][] sum;

        public Problem81() {
            input = new int[80][];
            sum = new int[80][];
        }

        public void Run()
        {
            string[] str_input;
            using (StreamReader sr = new StreamReader("Input/p081_matrix.txt"))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    input[i] = new int[80];
                    sum[i] = new int[80];
                    str_input = sr.ReadLine().Split(',');
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        input[i][j] = int.Parse(str_input[j]);

                        if (i > 0 && j > 0)
                        {
                            sum[i][j] = input[i][j] + (sum[i - 1][j] < sum[i][j - 1] ? sum[i - 1][j] : sum[i][j - 1]);
                        }
                        else if (i > 0)
                        {
                            sum[i][j] = input[i][j] + sum[i - 1][j];
                        }
                        else if (j > 0)
                        {
                            sum[i][j] = input[i][j] + sum[i][j - 1];
                        }
                        else
                        {
                            sum[i][j] = input[i][j];
                        }
                    }
                }
            }

            Console.WriteLine(sum[79][79]);
            Console.ReadLine();
        }
    }
}
