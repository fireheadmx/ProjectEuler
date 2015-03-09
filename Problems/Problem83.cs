using System;
using System.IO;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem83
    {
        int[][] input;
        int[][] sum;

        int size = 80;

        public Problem83() {
            input = new int[size][];
            sum = new int[size][];
        }

        private int Min(int a, int b, int c, int d)
        {
            return Math.Min(Math.Min(Math.Min(a, b), c), d);
        }
        private int Min(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
        }
        private int Min(int a, int b)
        {
            return Math.Min(a, b);
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
                        if (i == 0 && j == 0)
                        {
                            sum[i][j] = input[i][j];
                        }
                        else if (i == 0)
                        {
                            sum[i][j] = input[i][j] + sum[i][j - 1];
                        }
                        else
                        {
                            sum[i][j] = input[i][j] + sum[i - 1][j];
                        }
                    }
                }
            }

            int count = 0;
            do
            {
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            sum[i][j] = input[i][j];
                        }
                        else if (i == 0 && j > 0 && j < size - 1)
                        {
                            sum[i][j] = input[i][j] + Min(sum[i + 1][j], sum[i][j - 1], sum[i][j + 1]);
                        }
                        else if (i == 0 && j == size - 1)
                        {
                            sum[i][j] = input[i][j] + Min(sum[i + 1][j], sum[i][j - 1]);
                        }
                        else if (i > 0 && i < size - 1 && j == 0)
                        {
                            sum[i][j] = input[i][j] + Min(sum[i - 1][j], sum[i + 1][j], sum[i][j + 1]);
                        }
                        else if (i > 0 && i < size - 1 && j > 0 && j < size - 1)
                        {
                            sum[i][j] = input[i][j] + Min(sum[i - 1][j], sum[i + 1][j], sum[i][j - 1], sum[i][j + 1]);
                        }
                        else if (i > 0 && i < size - 1 && j == size - 1)
                        {
                            sum[i][j] = input[i][j] + Min(sum[i - 1][j], sum[i + 1][j], sum[i][j - 1]);
                        }
                        else if (i == size - 1 && j == 0)
                        {
                            sum[i][j] = input[i][j] + Min(sum[i - 1][j], sum[i][j + 1]);
                        }
                        else if (i == size - 1 && j > 0 && j < size - 1)
                        {
                            sum[i][j] = input[i][j] + Min(sum[i - 1][j], sum[i][j - 1], sum[i][j + 1]);
                        }
                        else if (i == size - 1 && j == size - 1)
                        {
                            sum[i][j] = input[i][j] + Min(sum[i - 1][j], sum[i][j - 1]);
                        }
                    }
                }

                count++;
            }
            while (count < 5);

            WriteToFile("Output/p083_sum.txt");

            Console.WriteLine(sum[size-1][size-1]);
            Console.ReadLine();
        }
    }
}
