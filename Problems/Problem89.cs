using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem89
    {

        public void Run()
        {
            int sum = 0;

            try
            {
                using (StreamReader sr = new StreamReader("Input/p089_roman.txt"))
                {
                    string roman_number = "";
                    int i = 0;
                    do
                    {
                        roman_number = sr.ReadLine();
                        int roman_value = RomanNumerals.RomToDec(roman_number);
                        int diff = roman_number.Length - RomanNumerals.DecToRom(roman_value).Length;
                        sum += diff;

                        i++;
                    }
                    while (i < 1000);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(sum.ToString());
        }
    }
}
