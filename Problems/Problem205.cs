using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem205
    {
        private static void GetCombination(List<int> list)
        {
            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        Console.Write(list[j]);
                    }
                }
                Console.WriteLine();
            }
        }

        public static void Run()
        {

            // Store Dice's sum value frequency
            int[] dice4 = new int[4 * 9 + 1];
            int[] dice6 = new int[6 * 6 + 1];

            for (int a = 1; a <= 4; a++)
            {
                for (int b = 1; b <= 4; b++)
                {
                    for (int c = 1; c <= 4; c++)
                    {
                        for (int d = 1; d <= 4; d++)
                        {
                            for (int e = 1; e <= 4; e++)
                            {
                                for (int f = 1; f <= 4; f++)
                                {
                                    for (int g = 1; g <= 4; g++)
                                    {
                                        for (int h = 1; h <= 4; h++)
                                        {
                                            for (int i = 1; i <= 4; i++)
                                            {
                                                // Store each total for 9 dices of 4 sides
                                                dice4[a + b + c + d + e + f + g + h + i]++;
                                            }
                                        }
                                    }
                                }
                            }                            
                        }
                    }
                }
            }

            for (int a = 1; a <= 6; a++)
            {
                for (int b = 1; b <= 6; b++)
                {
                    for (int c = 1; c <= 6; c++)
                    {
                        for (int d = 1; d <= 6; d++)
                        {
                            for (int e = 1; e <= 6; e++)
                            {
                                for (int f = 1; f <= 6; f++)
                                {
                                    // Store each total for 6 dices of 6 sides
                                    dice6[a + b + c + d + e + f ]++;
                                }
                            }
                        }
                    }
                }
            }

            int dice6all = 0;
            for (int x = 0; x < dice6.Length; x++)
            {
                dice6all += dice6[x];
            }       

            int[] diceWin4 = new int[4 * 9 + 1];
            int[] diceDraw = new int[4 * 9 + 1];
            int[] diceLose4 = new int[4 * 9 + 1];
            int[] diceAll = new int[4 * 9 + 1];

            for (int i = 4; i < dice4.Length; i++)
            {
                for (int j = 6; j < dice6.Length; j++)
                {
                    if (i == j)
                    {
                        diceDraw[i] += dice6[j];
                    }
                    else if(i < j) 
                    {
                        diceLose4[i] += dice6[j];
                    }
                    else if(i > j) {
                        diceWin4[i] += dice6[j];
                    }
                }
                diceAll[i] = diceDraw[i] + diceWin4[i] + diceLose4[i];
            }

            decimal sumWin = 0;
            // Calculate favorable vs all cases
            for (int x = 0; x < diceWin4.Length; x++)
            {
                sumWin += dice4[x] * diceWin4[x];
            }
            double sumAll = Math.Pow(4, 9) * Math.Pow(6, 6);

            Console.WriteLine((decimal)sumWin / (decimal)sumAll);
            Console.ReadLine();
        }
    }
}
