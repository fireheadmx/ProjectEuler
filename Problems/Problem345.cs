using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Numerics;

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
            bool printPartials = false;

            List<List<int>> matrixList = new List<List<int>>();
            List<List<int>> matrixListSorted = new List<List<int>>();
            foreach(var row in matrix) {
                matrixList.Add(row.ToList());
                matrixListSorted.Add(row.ToList());
            }

            foreach (var row in matrixListSorted)
            {
                row.Sort();
                row.Reverse();
            }

            List<List<int>> indexSorted = new List<List<int>>();
            for(int i = 0; i < matrixListSorted.Count; i++)
            {
                indexSorted.Add(new List<int>());
                for (int j = 0; j < matrixListSorted[i].Count; j++)
                {
                    indexSorted[i].Add(matrixList[i].IndexOf(matrixListSorted[i][j]));
                }
            }

            foreach (var row in indexSorted)
            {
                foreach (var ix in row)
                {
                    if(printPartials) Console.Write("{0} ", ix);
                }
                if (printPartials) Console.WriteLine();
            }
            if (printPartials) Console.WriteLine();

            int maxSum = 0;
            for (int startRow = 0; startRow < matrix.Length; startRow++)
            {
                // Check valid combinations starting from a specific Row
                for (int startIndex = 0; startIndex < matrix.Length; startIndex++)
                {
                    // Check for valid combinations using Largest, then Second Largest
                    List<int> usedColumns = new List<int>(); ;
                    for (int i = startRow; true; i = i == matrix.Length - 1 ? 0 : i+1)
                    {
                        // Check all rows from starting point. Prevent overflow by making it "round"
                        for (int j = (i == startRow ? startIndex : 0); j < matrix[0].Length; j++)
                        {
                            if (!usedColumns.Contains(indexSorted[i][j]))
                            {
                                usedColumns.Add(indexSorted[i][j]);
                                break;
                            }
                        }
                        if(usedColumns.Count == matrix.Length) {
                            // Stop when you've selected all columns
                            break;
                        }
                    }
                    foreach (var item in usedColumns)
                        if (printPartials) Console.Write("{0} ", item);

                    int sum = 0;
                    for (int ix = 0; ix < usedColumns.Count; ix++)
                    {
                        // Add numbers, by row, by column
                        int i = startRow + ix < matrix.Length ? startRow + ix : (startRow + ix) - matrix.Length;
                        int j = usedColumns[ix];
                        sum += matrix[i][j];
                    }
                    if (printPartials) Console.Write(" = {0}", sum);
                    maxSum = sum > maxSum ? sum : maxSum;
                    if (printPartials) Console.WriteLine();
                }
                if (printPartials) Console.WriteLine("=====");
            }
            Console.WriteLine("Max: {0}", maxSum);
            Console.ReadLine();

        }

        public static void RunSortedMatrix()
        {
            List<List<int>> matrixList = new List<List<int>>();
            List<List<int>> matrixListSorted = new List<List<int>>();
            foreach(var row in matrix) {
                matrixList.Add(row.ToList());
                matrixListSorted.Add(row.ToList());
            }

            foreach (var row in matrixListSorted)
            {
                row.Sort();
                row.Reverse();
            }

            List<List<int>> indexSorted = new List<List<int>>();
            for(int i = 0; i < matrixListSorted.Count; i++)
            {
                indexSorted.Add(new List<int>());
                for (int j = 0; j < matrixListSorted[i].Count; j++)
                {
                    indexSorted[i].Add(matrixList[i].IndexOf(matrixListSorted[i][j]));
                }
            }

            foreach (var row in indexSorted)
            {
                foreach (var ix in row)
                {
                    Console.Write("{0} ", ix);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int maxSum = 0;
            for (int startIndex = 0; startIndex < matrix.Length; startIndex++)
            {
                List<int> usedColumns = new List<int>(); ;
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = (i==0 ? startIndex : 0); j < matrix[0].Length; j++)
                    {
                        if (!usedColumns.Contains(indexSorted[i][j]))
                        {
                            usedColumns.Add(indexSorted[i][j]);
                            break;
                        }
                    }
                }
                foreach (var item in usedColumns)
                    Console.Write("{0} ", item);

                int sum = 0;
                for (int i = 0; i < usedColumns.Count; i++)
                {
                    int j = usedColumns[i];
                    sum += matrix[i][j];
                }
                Console.Write(" = {0}", sum);
                maxSum = sum > maxSum ? sum : maxSum;
                Console.WriteLine();
            }
            Console.WriteLine("Max: {0}", maxSum);
            Console.ReadLine();



        }

        public static void Run_AllButLargestPermutations()
        {
            /**********  DOESNT WORK EVEN ON SMALLEST EXAMPLE *********/
            List<List<int>> matrixCopy = new List<List<int>>();
            foreach (var row in matrix)
            {
                matrixCopy.Add(row.ToList());
            }
            int maxDrop = 0;
            int maxX = 0, maxY = 0;
            for (int x = 0; x < matrixCopy.Count; x++)
            {
                for (int y = 0; y < matrixCopy[x].Count; y++)
                {
                    if (matrixCopy[x][y] > maxDrop)
                    {
                        maxDrop = matrixCopy[x][y];
                        maxX = x;
                        maxY = y;
                    }
                }
            }
            foreach (List<int> row in matrixCopy)
            {
                row.RemoveAt(maxY);
            }
            matrixCopy.RemoveAt(maxX);



            List<int> colList = new List<int>();
            for (int c = 0; c < matrixCopy[0].Count; c++)
            {
                colList.Add(c);
            }

            int[] columns = colList.ToArray();
            long maxSum = 0;
            int[] maxColumns = new int[columns.Length];
            long sum;
            int i, j;

            do
            {
                sum = maxDrop;
                for (i = 0; i < matrixCopy.Count; i++)
                {
                    j = columns[i];
                    sum += matrixCopy[i][j];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxColumns = columns.ToArray();

                    /**********/
                    string partialPrintOut = "";
                    partialPrintOut += string.Format("({0},", maxDrop);
                    for (int ix = 0; ix < maxColumns.Length - 1; ix++)
                    {
                        partialPrintOut += string.Format("{0},", matrixCopy[ix][maxColumns[ix]]);
                    }
                    partialPrintOut += string.Format("{0}) = ", matrixCopy[maxColumns.Length - 1][maxColumns[maxColumns.Length - 1]]);
                    partialPrintOut += string.Format("{0}", maxSum);
                    Console.WriteLine(partialPrintOut);
                    using (StreamWriter str_out = new StreamWriter("C:/data/p345.txt", true))
                    {
                        str_out.WriteLine(partialPrintOut);
                    }
                    /********/
                }
            }
            while (Permutation.NextPermutation(columns));


            string printOut = "FINAL: ";
            printOut += string.Format("({0},",maxDrop);
            for (int ix = 0; ix < maxColumns.Length - 1; ix++)
            {
                printOut += string.Format("{0},", matrixCopy[ix][maxColumns[ix]]);
            }
            printOut += string.Format("{0}) = ", matrixCopy[maxColumns.Length - 1][maxColumns[maxColumns.Length - 1]]);
            printOut += string.Format("{0}", maxSum);

            Console.WriteLine(printOut);

            using (StreamWriter str_out = new StreamWriter("C:/data/p345.txt", true))
            {
                str_out.WriteLine(printOut);
            }

            Console.ReadLine();
        }

        public static void Run_AllPermutations()
        {
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

                    /**********/
                    string partialPrintOut = "";
                    partialPrintOut += "(";
                    for(int ix = 0; ix < maxColumns.Length - 1; ix++) {
                        partialPrintOut += string.Format("{0},",matrix[ix][maxColumns[ix]]);
                    }
                    partialPrintOut += string.Format("{0}) = ", matrix[maxColumns.Length - 1][maxColumns[maxColumns.Length - 1]]);
                    partialPrintOut += string.Format("{0}", maxSum);
                    Console.WriteLine(partialPrintOut);
                    using (StreamWriter str_out = new StreamWriter("C:/data/p345.txt", true))
                    {
                        str_out.WriteLine(partialPrintOut);
                    }
                    /********/
                }
            }
            while(Permutation.NextPermutation(columns));

            
            string printOut = "FINAL: ";
            printOut += "(";
            for(int ix = 0; ix < maxColumns.Length - 1; ix++) {
                printOut += string.Format("{0},",matrix[ix][maxColumns[ix]]);
            }
            printOut += string.Format("{0}) = ", matrix[maxColumns.Length - 1][maxColumns[maxColumns.Length - 1]]);
            printOut += string.Format("{0}", maxSum);

            Console.WriteLine(printOut);

            using (StreamWriter str_out = new StreamWriter("C:/data/p345.txt", true))
                {
                str_out.WriteLine(printOut);
            }

            Console.ReadLine();
        }

        public static void Run_UsingLargestNumber()
        {
            // We define the Matrix Sum of a matrix as the maximum sum of matrix elements with each element being the only one in his row and column. 
            // For example, the Matrix Sum of the matrix below equals 3315 ( = 863 + 383 + 343 + 959 + 767)

            int maxNumber = 0;
            int maxI = 0, maxJ = 0;
            for (int a = 0; a < matrix.Length; a++)
            {
                for (int b = 0; b < matrix[a].Length; b++)
                {
                    if (matrix[a][b] > maxNumber)
                    {
                        maxI = a;
                        maxJ = b;
                        maxNumber = matrix[a][b];
                    }
                }
            }

            List<int> colList = new List<int>();
            for (int c = 0; c < matrix[0].Length; c++)
            {
                if (c != maxJ)
                {
                    colList.Add(c);
                }
            }

            int[] columns = colList.ToArray();
            long maxSum = 0;
            int[] maxColumns = new int[columns.Length];
            long sum;
            int i, j;
            List<int> columnsToAdd;

            do
            {
                columnsToAdd = columns.ToList();
                columnsToAdd.Insert(maxI, maxJ);
                sum = 0;
                for (i = 0; i < matrix.Length; i++)
                {
                    j = columnsToAdd[i];
                    sum += matrix[i][j];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxColumns = columns.ToArray();
                }
            }
            while (Permutation.NextPermutation(columns));

            Console.Write("(");
            for (int ix = 0; ix < maxColumns.Length - 1; ix++)
            {
                Console.Write("{0},", matrix[ix][maxColumns[ix]]);
            }
            Console.Write("{0}) = ", matrix[maxColumns.Length - 1][maxColumns[maxColumns.Length - 1]]);
            Console.WriteLine(maxSum);
            Console.ReadLine();
        }
    }
}
