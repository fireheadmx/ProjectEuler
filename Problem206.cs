using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem206
    {
        // Find the unique positive integer whose square has the form 1_2_3_4_5_6_7_8_9_0,
        // where each “_” is a single digit.
        
        BigInteger lowerSq = 1020304050607080900;
        BigInteger upperSq = 1929394959697989990;

        private bool Match(ulong val)
        {
            val = val * val;
            string valS = val.ToString();
            if (valS.Length != 19)
            {
                return false;
            }
            return valS[0] == '1'
                && valS[2] == '2'
                && valS[4] == '3'
                && valS[6] == '4'
                && valS[8] == '5'
                && valS[10] == '6'
                && valS[12] == '7'
                && valS[14] == '8'
                && valS[16] == '9'
                && valS[18] == '0';
        }

        public void Run() {
            ulong lower = 1010101010;
            ulong upper = 1389026624;
            for (ulong i = lower; i < upper; i++)
            {
                if (Match(i))
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("Not found");
        }

    }
}
