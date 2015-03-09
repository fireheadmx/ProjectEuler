using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem243
    {
        Phi p;
        //long upper = 50000000;
        long upper = 50000;

        public Problem243()
        {
            DateTime start = DateTime.Now;
            p = new Phi(upper);
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
        }

        private Fraction R(long number)
        {
            return new Fraction(p.totient[number], number - 1);
        }

        public void Run()
        {
            long denom = 4594590;
            Fraction resilience = R(denom);
            long min_denom = denom;
            Fraction min_resilience = resilience;
            Fraction lower = new Fraction(15499, 94744);

            while (resilience >= lower && denom < upper)
            {
                denom++;
                resilience = R(denom);
                if (resilience < min_resilience) {
                    min_denom = denom;
                    min_resilience = resilience;
                }
            }
            if (resilience < lower)
            {
                Console.WriteLine("Found!");
            }

            Console.WriteLine("R(" + min_denom.ToString() + ") = " + min_resilience);
            Console.WriteLine("R(" + denom.ToString() + ") = " + resilience);
            Console.ReadLine();
        }
    }
}
