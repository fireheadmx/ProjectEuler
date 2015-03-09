using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem68
    {
        //      a
        //       \ 
        //        v      b
        //      /   \   /
        //    z       w
        //   / \     /
        //  e   y---x -- c
        //       \
        //        d
        //
        public static void Run()
        {
            SortedSet<BigInteger> res = new SortedSet<BigInteger>();
            SortedSet<String> resStr = new SortedSet<string>();
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int a, b, c, d, e, v, w, x, y, z;
            int avw, bwx, cxy, dyz, ezv;
            string calcString;
            do
            {
                a = nums[0];
                b = nums[1];
                c = nums[2];
                d = nums[3];
                e = nums[4];
                v = nums[5];
                w = nums[6];
                x = nums[7];
                y = nums[8];
                z = nums[9];

                avw = a + v + w;
                bwx = b + w + x;
                cxy = c + x + y;
                dyz = d + y + z;
                ezv = e + z + v;

                if (avw == bwx && avw == cxy && avw == dyz && avw == ezv)
                {
                    // Result:
                    // a<b,c,d,e: avw bwx cxy dyz ezv
                    // b<a,c,d,e: bwx cxy dyz ezv avw
                    // c<a,b,d,e: cxy dyz ezv avw bwx
                    // d<a,b,c,e: dyz ezv avw bwx cxy
                    // e<a,b,c,d: ezv avw bwx cxy dyz

                    if (a < b && a < c && a < d && a < e)
                    {
                        calcString = String.Format("{0},{1},{2};\t{3},{4},{5};\t{6},{7},{8};\t{9},{10},{11};\t{12},{13},{14}", a, v, w, b, w, x, c, x, y, d, y, z, e, z, v);
                    }
                    else if (b < a && b < c && b < d && b < e)
                    {
                        calcString = String.Format("{0},{1},{2};\t{3},{4},{5};\t{6},{7},{8};\t{9},{10},{11};\t{12},{13},{14}", b, w, x, c, x, y, d, y, z, e, z, v, a, v, w);
                    }
                    else if (c < a && c < b && c < d && c < e)
                    {
                        calcString = String.Format("{0},{1},{2};\t{3},{4},{5};\t{6},{7},{8};\t{9},{10},{11};\t{12},{13},{14}", c, x, y, d, y, z, e, z, v, a, v, w, b, w, x);
                    }
                    else if (d < a && d < b && d < c && d < e)
                    {
                        calcString = String.Format("{0},{1},{2};\t{3},{4},{5};\t{6},{7},{8};\t{9},{10},{11};\t{12},{13},{14}", d, y, z, e, z, v, a, v, w, b, w, x, c, x, y);
                    }
                    else// if (e < a && e < b && e < c && e < d)
                    {
                        calcString = String.Format("{0},{1},{2};\t{3},{4},{5};\t{6},{7},{8};\t{9},{10},{11};\t{12},{13},{14}", e, z, v, a, v, w, b, w, x, c, x, y, d, y, z);
                    }

                    resStr.Add(calcString);
                    res.Add(BigInteger.Parse(calcString.Replace(";","").Replace(",","").Replace("\t","")));
                }
            }
            while (Permutation.NextPermutation(nums));

            foreach (BigInteger r in res)
            {
                Console.WriteLine(r);
            }
            foreach (string r in resStr)
            {
                Console.WriteLine(r);
            }
            Console.ReadLine();
        }
        public static void Run3Gon()
        {
            SortedSet<int> res = new SortedSet<int>();
            int[] nums = { 1, 2, 3, 4, 5, 6 };
            int a, b, c, x, y, z;
            int axy, byz, czx;
            do
            {
                a = nums[0];
                b = nums[1];
                c = nums[2];
                x = nums[3];
                y = nums[4];
                z = nums[5];

                axy = a + x + y;
                byz = b + y + z;
                czx = c + z + x;

                if (axy == byz && byz == czx)
                {
                    // Result:
                    // a<b,c: axy byz czx
                    // b<a,c: byz czx axy
                    // c<a,b: czx axy byz

                    if (a < b && a < c)
                    {
                        res.Add(int.Parse(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", a, x, y, b, y, z, c, z, x)));
                    }
                    else if (b < a && b < c)
                    {
                        res.Add(int.Parse(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", b, y, z, c, z, x, a, x, y)));
                    }
                    else if (c < a && c < b)
                    {
                        res.Add(int.Parse(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", c, z, x, a, x, y, b, y, z)));
                    }
                }
            }
            while (Permutation.NextPermutation(nums));

            Console.WriteLine(res.Last());
            Console.ReadLine();
        }
    }
}
