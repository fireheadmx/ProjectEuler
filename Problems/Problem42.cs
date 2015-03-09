using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectEuler
{
    class Problem42
    {
        private Dictionary<char, int> letter;
        public Problem42()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            letter = new Dictionary<char, int>();
            for (int i = 0; i < alphabet.Length; i++)
            {
                letter.Add(alphabet[i], i + 1);
            }
        }

        private bool Triangle(int t)
        {
            decimal n1 = (-1 * (decimal) Math.Sqrt(8 * t + 1) - 1) / 2;
            decimal n2 = ((decimal)Math.Sqrt(8 * t + 1) - 1) / 2;

            return ((int)n1 == n1) && ((int)n2 == n2);
        }

        private int TextValue(string s)
        {
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if(letter.ContainsKey(s[i])) {
                    sum += letter[s[i]];
                }
            }
            return sum;
        }

        public string Run()
        {
            int count = 0;

            //try
            //{
                using (StreamReader sr = new StreamReader("Input/p042_words.txt"))
                {
                    string words = sr.ReadLine();
                    string[] wordList = words.Split(',');
                    for (int i = 0; i < wordList.Length; i++)
                    {
                        if (Triangle(TextValue(wordList[i])))
                        {
                            count++;
                        }
                    }
                }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("The file could not be read:");
            //    Console.WriteLine(e.Message);
            //}

            return count.ToString();
        }
    }
}
