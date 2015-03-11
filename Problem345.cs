using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem345
    {
        //private static int[][] matrix = {
        //                                    new int[] {7,53,183,439,863},
        //                                    new int[] {497,383,563,79,973},
        //                                    new int[] {287,63,343,169,583},
        //                                    new int[] {627,343,773,959,943},
        //                                    new int[] {767,473,103,699,303}
        //                                };

        private static int[][] matrix = {
                                            new int[] {7,53,183,439,863,497,383,563,79,973,287,63,343,169,583},
                                            new int[] {627,343,773,959,943,767,473,103,699,303,957,703,583,639,913},
                                            new int[] {447,283,463,29,23,487,463,993,119,883,327,493,423,159,743},
                                            new int[] {217,623,3,399,853,407,103,983,89,463,290,516,212,462,350},
                                            new int[] {960,376,682,962,300,780,486,502,912,800,250,346,172,812,350},
                                            new int[] {870,456,192,162,593,473,915,45,989,873,823,965,425,329,803},
                                            new int[] {973,965,905,919,133,673,665,235,509,613,673,815,165,992,326},
                                            new int[] {322,148,972,962,286,255,941,541,265,323,925,281,601,95,973},
                                            new int[] {445,721,11,525,473,65,511,164,138,672,18,428,154,448,848},
                                            new int[] {414,456,310,312,798,104,566,520,302,248,694,976,430,392,198},
                                            new int[] {184,829,373,181,631,101,969,613,840,740,778,458,284,760,390},
                                            new int[] {821,461,843,513,17,901,711,993,293,157,274,94,192,156,574},
                                            new int[] {34,124,4,878,450,476,712,914,838,669,875,299,823,329,699},
                                            new int[] {815,559,813,459,522,788,168,586,966,232,308,833,251,631,107},
                                            new int[] {813,883,451,509,615,77,281,613,459,205,380,274,302,35,805}
                                        };

        public static void Run()
        {
            // We define the Matrix Sum of a matrix as the maximum sum of matrix elements with each element being the only one in his row and column. 
            // For example, the Matrix Sum of the matrix below equals 3315 ( = 863 + 383 + 343 + 959 + 767)
            
            List<int> colList = new List<int>();
            for(int c = 0; c < matrix[0].Length;c++) {
                colList.Add(c);
            }

            int[] columns = colList.ToArray();
            long maxSum = 0;
            int[] maxColumns = new int[columns.Length];
            long sum;
            int i,j;

            do {
                sum = 0;
                for(i = 0; i < matrix.Length; i++) {
                    j = columns[i];
                    sum += matrix[i][j];
                }
                if(sum > maxSum) {
                    maxSum = sum;
                    maxColumns = columns.ToArray();
                }
            }
            while(Permutation.NextPermutation(columns));

            Console.Write("(");
            for(int ix = 0; ix < maxColumns.Length - 1; ix++) {
                Console.Write("{0},",matrix[ix][maxColumns[ix]]);
            }
            Console.Write("{0}) = ", matrix[maxColumns.Length-1][maxColumns[maxColumns.Length-1]]);
            Console.WriteLine(maxSum);
            Console.ReadLine();
        }
    }
}
