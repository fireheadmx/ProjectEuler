using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem38
    {
        private bool IsPandigital(string numS)//int num)
        {
            //string numS = num.ToString();
            if (numS.Length != 9)
            {
                return false;
            }
            List<char> numC = new List<char>();
            for(int c = 0; c < numS.Length; c++)
            {
                numC.Add(numS[c]); 
            }
            numC.Sort();

            string numS2 = "";
            foreach (char c in numC)
            {
                numS2 += c;
            }

            return (numS2 == "123456789");
        }

        public void Run()
        {
            List<int> pandigitals = new List<int>();
            for (int num = 100; num <= 9999; num++)
            {
                int i = 1;
                string conc = "";
                while (conc.Length < 9)
                {
                    conc += (num * i).ToString();
                    i++;
                }

                if(IsPandigital(conc)) {
                    pandigitals.Add(int.Parse(conc));
                }
            }

            Console.WriteLine(pandigitals.Max().ToString());
        }
    }
}
