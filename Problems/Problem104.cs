using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem104
    {
        private bool IsPandigital(ref string st)
        {
            if (st.Length < 9)
            {
                return false;
            }
            List<char> st_char = st.ToCharArray().ToList();
            st_char.Sort();
            string sorted_st = new string(st_char.ToArray());
            return sorted_st == "123456789";
        }

        //private bool IsDoublePandigital(BigInteger number)
        //{
        //    string numS = number.ToString();
        //    if (numS.Length < 18)
        //    {
        //        return false;
        //    }
        //    if(IsPandigital(numS.Substring(0, 9))) {
        //        return IsPandigital(numS.Substring(numS.Length - 9));
        //    }
        //    return false;
        //}

        public void Run()
        {
            BigInteger Fa = BigInteger.Parse("19717556437089196581097595986132868777484357362710277396538804282697604657932286856665006090315514324457397722361");
            BigInteger Fb = BigInteger.Parse("31903676490304597847185685736169548906931858202641803975680844768196795244879691985828019808017263472521442003280"); ;
            BigInteger Fk = BigInteger.Parse("51621232927393794428283281722302417684416215565352081372219649050894399902811978842493025898332777796978839725641"); ;
            int k = 541;
            BigInteger e10_9 = BigInteger.Pow(10, 9);

            string strFk, strFrontK, strBackK;
            do
            {
                k++;

                Fa = Fb;
                Fb = Fk;
                Fk = Fa + Fb;
                strBackK = (Fk % e10_9).ToString();
                if (IsPandigital(ref strBackK))
                {
                    Console.WriteLine(k);
                    //strFk = Fk.ToString();
                    strFrontK = Fk.ToString().Substring(0, 9);
                    if (IsPandigital(ref strFrontK))
                    {
                        Console.WriteLine("FOUND");
                        Console.WriteLine(k);
                        break;
                    }
                }
                
            }
            while (true);
            //while (!IsDoublePandigital(Fk));
            Console.WriteLine(k);
            Console.ReadLine();
        }
    }
}
