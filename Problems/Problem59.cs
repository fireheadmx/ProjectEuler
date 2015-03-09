using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem59
    {
        private Dictionary<byte, char> ByteToChar = new Dictionary<byte, char>();
        private Dictionary<char, byte> CharToByte = new Dictionary<char, byte>();

        public Problem59()
        {
        }

        private List<string> GenerateKeys()
        {
            string lower = "abcdefghijklmnopqrstuvwxyz";
            List<string> res = new List<string>();
            foreach (char x in lower)
            {
                foreach (char y in lower)
                {
                    foreach (char z in lower)
                    {
                        res.Add(x.ToString() +  y + z);
                    }
                }
            }
            return res;
        }

        private int SumASCII(string text)
        {
            int sum = 0;
            foreach (char t in text)
            {
                sum += (byte)t;
            }
            return sum;
        }

        public void Run()
        {
            
            string[] str_input;
            byte[] byte_input;

            using (StreamReader sr = new StreamReader("Input/p059_cipher.txt"))
            {
                str_input = sr.ReadLine().Split(',');
            }

            byte_input = new byte[str_input.Length];
            for (int i = 0; i < str_input.Length; i++)
            {
                byte_input[i] = byte.Parse(str_input[i]);
            }

            List<string> keys = GenerateKeys();
            foreach (string key in keys)
            {
                string str_output = "";
                for (int ix = 0; ix < byte_input.Length; ix++)
                {
                    str_output += (char)(byte_input[ix] ^ (byte)key[ix % 3]);
                }

                string[] commonWords = new string[] { "the", "and", "of" };
                bool passTest = true;
                string str_lower = str_output.ToLower();
                foreach (string word in commonWords)
                {
                    passTest &= str_lower.Contains(word);
                }

                if (passTest)
                {
                    Console.WriteLine(key + " = " + SumASCII(str_output));
                    Console.WriteLine(str_output.Substring(0, 100));
                }
            }
            
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
