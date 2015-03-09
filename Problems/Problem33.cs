using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem33
    {
        private int upper = 99;

        public void Run()
        {
            List<Fraction33> result = new List<Fraction33>();
            for (int i = 10; i < upper; i++)
            {
                for (int j = i + 1; j <= upper; j++)
                {
                    Fraction33 x = new Fraction33(i, j);
                    if (x.Value() == x.RemoveCommon().Value()  && x.numerator % 10 != 0 && x.denominator % 10 != 0)
                    {
                        result.Add(x);
                    }
                }
            }

            decimal prodD = 1, prodN = 1;
            foreach (Fraction33 f in result)
            {
                prodN *= f.numerator;
                prodD *= f.denominator;
                Console.WriteLine(f.numerator.ToString() + "/" + f.denominator.ToString() + " = " + f.Value().ToString());
            }
            Console.WriteLine(prodN.ToString() + "/" + prodD.ToString() + " = " + (prodN / prodD).ToString());
        }
    }

    class Fraction33 {
        public decimal numerator, denominator;
        public Fraction33(int n, int d) {
            numerator = n;
            denominator = d;
        }
        public decimal Value() {
            if (denominator == 0) return 0;
            return (decimal) (numerator / denominator);
        }

        public Fraction33 RemoveCommon()
        {
            string numS = numerator.ToString();
            string denS = denominator.ToString();

            if (numS.Length < 2 || denS.Length < 2)
            {
                return new Fraction33(0, -1);
            }

            string common = "";
            for (int i = 0; i < numS.Length; i++)
            {
                for (int j = 0; j < denS.Length; j++)
                {
                    if (numS[i] == denS[j])
                    {
                        common = numS[i].ToString();

                        i = numS.Length; // Break first loop
                        break; // Break second loop
                    }
                }
            }

            if (common == "")
            {
                return new Fraction33(0, -1);
            }
            string numR = numS.Replace(common, "") == "" ? common : numS.Replace(common, "");
            string denR = denS.Replace(common, "") == "" ? common : denS.Replace(common, "");
            
            return new Fraction33(int.Parse(numR), int.Parse(denR));
        }
    }
}
