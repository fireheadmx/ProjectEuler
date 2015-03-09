using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem67
    {
        private int upper = 100;

        private Fraction Convergent(int convBase, int[] convDigits)
        {
            return new Fraction(convBase) + ConvergentF(convDigits, 0);
        }
        private Fraction ConvergentF(int[] convDigits, int index)
        {
            if (index == upper - 2)
            {
                return new Fraction(1, convDigits[index % convDigits.Length]);
            }
            else if (index > upper - 2)
            {
                return new Fraction(0, 1);
            }
            else
            {
                return new Fraction(1) / (new Fraction(convDigits[index % convDigits.Length]) + ConvergentF(convDigits, (index + 1)));
            }
        }

        public void Run()
        {
            List<int> convergent_digits = new List<int>();
            for (int i = 1; i <= (upper/3); i++)
            {
                convergent_digits.Add(1);
                convergent_digits.Add(2*i);
                convergent_digits.Add(1);
            }
            while (convergent_digits.Count > upper)
            {
                convergent_digits.RemoveAt(convergent_digits.Count - 1);
            }

            Fraction resultConv = Convergent(2, convergent_digits.ToArray());
            int sum = 0;
            foreach (char c in resultConv.Numerator.ToString())
            {
                sum += int.Parse(c.ToString());
            }

            Console.WriteLine(resultConv);
            Console.WriteLine(sum);
        }
    }
}
