using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class RomanNumerals
    {
        public static string DecToRom(int number)
        {
            List<int> dec = new List<int> { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            List<string> rom = new List<string> { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            string res = "";
            for (int i = 0; i < dec.Count; i++)
            {
                while (number >= dec[i])
                {
                    res += rom[i];
                    number -= dec[i];
                }

                if (number == 0)
                {
                    return res;
                }
            }

            return res;
        }

        public static int RomToDec(string number)
        {
            List<string> romComp = new List<string> { "CM", "CD", "XC", "XL", "IX", "IV" };
            List<int> decComp = new List<int> { 900, 400, 90, 40, 9, 4 };
            List<char> rom = new List<char> { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
            List<int> dec = new List<int> { 1000, 500, 100, 50, 10, 5, 1 };

            int res = 0;
            for (int i = 0; i < romComp.Count; i++)
            {
                if (number.Contains(romComp[i]))
                {
                    res += decComp[i];
                    number = number.Replace(romComp[i], "");
                }

                if (number.Length == 0)
                {
                    return res;
                }
            }
            for (int j = 0; j < number.Length; j++)
            {
                res += dec[rom.IndexOf(number[j])];
            }

            return res;
        }
    }
}
