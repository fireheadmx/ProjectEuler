using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem61
    {
        private List<int> all_figurates = new List<int>() { 3, 4, 5, 6, 7, 8 };

        private List<int> IsFigurate(int number, ref int[] found)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < all_figurates.Count; i++)
            {
                if (Figurate.IsFigurate(all_figurates[i], number))
                {
                    if(!found.Contains(all_figurates[i])) {
                        res.Add(all_figurates[i]);
                    }
                }
            }
            return res;
        }

        public void Run()
        {
            // Six Cyclical Numbers: AABB, BBCC, CCDD, DDEE, EEFF, FFAA
            for (int a = 10; a <= 99; a++)
            {
                for (int b = 10; b <= 99; b++)
                {
                    int N1 = a * 100 + b;
                    int[] ff1 = { };
                    foreach (int f1 in IsFigurate(N1, ref ff1))
                    {
                        for (int c = 10; c <= 99; c++)
                        {
                            int N2 = b * 100 + c;
                            int[] ff2 = { f1 };
                            foreach (int f2 in IsFigurate(N2, ref ff2)) {
                                for (int d = 10; d <= 99; d++)
                                {
                                    int N3 = c * 100 + d;
                                    int[] ff3 = { f1, f2 };
                                    foreach(int f3 in IsFigurate(N3, ref ff3)) 
                                    {
                                        for (int e = 10; e <= 99; e++)
                                        {
                                            int N4 = d * 100 + e;
                                            int[] ff4 = { f1, f2, f3 };
                                            foreach(int f4 in IsFigurate(N4, ref ff4)) {
                                                for (int f = 10; f <= 99; f++)
                                                {
                                                    int N5 = e * 100 + f;
                                                    int[] ff5 = { f1, f2, f3, f4 };
                                                    foreach(int f5 in IsFigurate(N5, ref ff5)) {
                                                        int N6 = f * 100 + a;
                                                        int[] ff6 = { f1, f2, f3, f4, f5 };
                                                        foreach(int f6 in IsFigurate(N6, ref ff6)) {
                                                            Console.WriteLine(N1.ToString() + "(" + f1.ToString() + ")");
                                                            Console.WriteLine(N2.ToString() + "(" + f2.ToString() + ")");
                                                            Console.WriteLine(N3.ToString() + "(" + f3.ToString() + ")");
                                                            Console.WriteLine(N4.ToString() + "(" + f4.ToString() + ")");
                                                            Console.WriteLine(N5.ToString() + "(" + f5.ToString() + ")");
                                                            Console.WriteLine(N6.ToString() + "(" + f6.ToString() + ")");
                                                            Console.WriteLine("=");
                                                            Console.WriteLine(N1+N2+N3+N4+N5+N6);
                                                            Console.ReadLine();
                                                            return;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }     


            Console.WriteLine("Not found");
            Console.ReadLine();
        }
    }
}
