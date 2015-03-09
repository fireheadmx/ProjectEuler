using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem52
    {
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
            long number = 125873; //142857
            bool found = false;
            while (!found)
            {
                number++;
                found = Integers(number) == Integers(number * 2)
                        && Integers(number) == Integers(number * 3)
                        && Integers(number) == Integers(number * 4)
                        && Integers(number) == Integers(number * 5)
                        && Integers(number) == Integers(number * 6);
            }
            return number.ToString() + " (" + Integers(number) + ")";
        }
    }
}
