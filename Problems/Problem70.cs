using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem70
    {
        int upper = 10000000;

        private bool ArePermutations(long n1, long n2)
        {
            string n1s = n1.ToString();
            string n2s = n2.ToString();
            if (n1s.Length != n2s.Length)
            {
                return false;
            }
            List<char> n1c = n1s.ToCharArray().ToList();
            List<char> n2c = n2s.ToCharArray().ToList();
            n1c.Sort();
            n2c.Sort();

            for (int i = 0; i < n1c.Count; i++)
            {
                if (n1c[i] != n2c[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void Run()
        {
            DateTime start = DateTime.Now;
            Phi p = new Phi(upper);
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds);

            decimal min_ratio = decimal.MaxValue;
            int min_n = int.MaxValue;

            long totient;
            decimal ratio;

            for (int n = 2; n < upper; n++)
            {
                totient = p.totient[n];
                if(ArePermutations(n, totient)) {
                    ratio = (decimal) n / totient;
                    if (ratio < min_ratio)
                    {
                        min_ratio = ratio;
                        min_n = n;
                    }
                }
            }
            Console.WriteLine("Phi(" + min_n.ToString() + ")= " + min_ratio);
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
