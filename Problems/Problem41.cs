using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem41
    {
        private Sieve s;
        private string pandigital;
        private long upper;
        public Problem41()
        {
            upper = 987654321;
            pandigital = "123456789";

            s = new Sieve(upper + 1);
            Console.WriteLine("Sieve populated");
        }
        private string Integers(long n)
        {
            List<int> intList = new List<int>();
            string strN = n.ToString();
            for (int i = 0; i < strN.Length; i++)
            {
                intList.Add(int.Parse(strN[i].ToString()));
            }
            intList.Sort();
            string res = "";
            foreach (int item in intList)
            {
                res += item.ToString();
            }
            return res;
        }

        public string Run()
        {
            long number = upper;

            while (number > 0)
            {
                if (s.prime[number])
                {
                    if (Integers(number) == pandigital.Substring(0, number.ToString().Length))
                    {
                        return number.ToString();
                    }
                }

                number--;
            }

            return "Not found";
        }
    }
}
