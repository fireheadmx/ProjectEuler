using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem62
    {
        private string getDigits(BigInteger number)
        {
            List<char> charNumber = number.ToString().ToCharArray().ToList();
            charNumber.Sort();
            return new string(charNumber.ToArray());
        }

        public void Run()
        {
            Dictionary<string, List<int>> digitSignatures = new Dictionary<string, List<int>>();
            
            BigInteger num;
            string numStr;
            BigInteger upper = BigInteger.Pow(10,13);
            int n = 1;
            do
            {
                n++;
                num = BigInteger.Pow(n, 3);
                numStr = getDigits(num);
                if (!digitSignatures.ContainsKey(numStr))
                {
                    digitSignatures.Add(numStr, new List<int>());
                }

                digitSignatures[numStr].Add(n);
            } 
            while (num < upper);

            foreach (var pair in digitSignatures)
            {
                if (pair.Value.Count == 5)
                {
                    Console.WriteLine("{0}", BigInteger.Pow(pair.Value[0], 3));
                }
            }
        }
    }
}
