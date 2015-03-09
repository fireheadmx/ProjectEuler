using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    class Problem34
    {
        private int upper = 2540162; // 7*9! = 2540160
        private int[] f;
        public Problem34()
        {
            // Populate Factorials
            f = new int[10];
            f[0] = 1;
            for (int i = 1; i < f.Length; i++)
            {
                f[i] = i * f[i - 1];
            }
        }

        public int Run()
        {
            int result = 0;
            List<int> values = new List<int>();
            for (int num = 10; num < upper; num++)
            {
                string numS = num.ToString();
                int sum = 0;
                for (int i = 0; i < numS.Length; i++)
                {
                    sum += f[int.Parse(numS[i].ToString())];
                    if (sum > num)
                    {
                        break;
                    }
                }
                if (num == sum)
                {
                    values.Add(num);
                    result += num;
                }
            }
            foreach (int n in values)
            {
                Console.WriteLine(n);
            }
            return result;
        }
    }
}
