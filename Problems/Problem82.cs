using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem82
    {
        int[][] input;
        int[][] sum;

        int size = 80;

        public Problem82() {
            input = new int[size][];
            sum = new int[size][];
        }

        private void WriteToFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        sw.Write(sum[i][j]);
                        if (j < size - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine();
                }
            }
        }

        public void Run()
        {
            string[] str_input;
            using (StreamReader sr = new StreamReader("Input/p082_matrix.txt"))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    input[i] = new int[size];
                    sum[i] = new int[size];
                    str_input = sr.ReadLine().Split(',');
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        input[i][j] = int.Parse(str_input[j]);
                        if (j == 0)
                        {
                            sum[i][j] = input[i][j];
                        }
                        else
                        {
                            sum[i][j] = input[i][j] + sum[i][j - 1];
                        }
                    }
                }
            }

            //int min_last = int.MaxValue;
            int count = 0;
            int current_min = int.MaxValue;
            do
            {
                //min_last = current_min;
                current_min = int.MaxValue;
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 1; j < input[i].Length; j++)
                    {
                        if (i == 0)
                        {
                            sum[i][j] = Math.Min(input[i][j] + sum[i][j-1], input[i][j] + sum[i + 1][j]);
                        }
                        else if (i == input.Length - 1)
                        {
                            sum[i][j] = Math.Min(input[i][j] + sum[i][j - 1], input[i][j] + sum[i - 1][j]);
                        }
                        else
                        {
                            sum[i][j] = Math.Min(Math.Min(input[i][j] + sum[i][j - 1], input[i][j] + sum[i + 1][j]), input[i][j] + sum[i - 1][j]);
                        }

                        if (j == size-1)
                        {
                            current_min = Math.Min(current_min, sum[i][j]);
                        }
                    }
                }

                count++;
            }
            while (count < size);

            WriteToFile("Output/p082_sum.txt");

            Console.WriteLine(current_min);
            Console.ReadLine();
        }
    }
}
