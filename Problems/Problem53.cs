using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
    class Problem53
    {
        private Factorial fact;
        private int upper;

        public Problem53()
        {
            upper = 100;
            fact = new Factorial(upper);
        }

        private BigInteger C(int n, int r)
        {
            if (r <= n)
            {
                return fact.val(n) / (fact.val(r) * fact.val(n - r));
            }
            else
            {
                return 0;
            }
        }

        public string Run() {
            int count = 0;

            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (C(i, j) > 1000000)
                    {
                        count++;
                    }
                }
            }

            return count.ToString();
        }
    }
}
