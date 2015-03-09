using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem153
    {
        public static void Run()
        {
            int upper = 35;
            List<int> intList = new List<int>();
            for (int x = 2; x <= upper; x++)
            {
                intList.Add(x);
            }
            int[] intArray = intList.ToArray();

            FractionBig half = new FractionBig(1, 2);
            FractionBig sum;
            List<int> sumParts;

            int count = 0;
            List<List<int>> res = new List<List<int>>();
            BigInteger sq;
            do
            {
                sumParts = new List<int>();
                sum = new FractionBig(0);
                for (int ix = 0; ix < intArray.Length; ix++)
                {
                    sq = BigInteger.Pow(intArray[ix],2);
                    FractionBig presum = sum + new FractionBig(1, sq);
                    if (presum == half)
                    {
                        sum += new FractionBig(1, sq);
                        sumParts.Add(intArray[ix]);

                        sumParts.Sort();
                        if (!res.Contains(sumParts))
                        {
                            count++;
                            res.Add(sumParts);

                            Console.Write("{");
                            foreach (var sp in sumParts)
                            {
                                Console.Write("{0} ", sp);
                            }
                            Console.WriteLine("}");
                        }
                        break;
                    }
                    else if (presum < half)
                    {
                        sum += new FractionBig(1, sq);
                        sumParts.Add(intArray[ix]);
                    }
                    else if (presum > half)
                    {
                        // If number exceeded, try next combination
                        //break;
                    }
                }   
            }
            while(Permutation.NextPermutation(intArray));

            foreach (var r in res)
            {
                Console.Write("{");
                foreach (var x in r)
                {
                    Console.Write("{0},", x);
                }
                Console.WriteLine("}");
            }

            Console.WriteLine("Total: {0}", count);

            Console.ReadLine();
        }
    }
}
