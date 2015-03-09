using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem51
    {
        private Sieve p = new Sieve(999999);

        public int primes(string template)
        {
            int count = 0;
            for (int i = 0; i <= 9; i++)
            {
                string number = template.Replace("*", i.ToString());
                if(number[0] != '0') {
                    if (p.prime[int.Parse(number)])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public string[] getTemplates(int number)
        {
            List<string> res = new List<string>();
            string numStr = number.ToString();
            List<int> resLength = new List<int>();
            res.Add(numStr);
            resLength.Add(1);
            for (int stars = 1; stars < numStr.Length; stars++)
            {
                resLength.Add(res.Count);
                for(int index = resLength[stars-1]; index <= res.Count; index++) {
                    string currStr = res[index-1];

                    for(int ix = 0; ix < numStr.Length; ix++) {
                        if (currStr[ix] != '*')
                        {
                            char[] newStr = currStr.ToCharArray();
                            newStr[ix] = '*';
                            string generatedStr = new string(newStr);
                            if (!res.Contains(generatedStr))
                            {
                                res.Add(generatedStr);
                            }
                        }
                    }
                }
            }
            res.Remove(numStr);
            res.RemoveAt(res.Count - 1);

            return res.ToArray();
        }

        public void Run()
        {
            foreach (int prime in p.primeList)
            {
                if (prime > 10)
                {
                    foreach (string template in getTemplates(prime))
                    {
                        int primeCount = primes(template);
                        if (primeCount >= 8)
                        {
                            Console.WriteLine("{0}: {1}", primeCount, template);
                            for (int i = 0; i <= 9; i++)
                            {
                                string strVal = template.Replace("*", i.ToString());
                                if (strVal[0] != '0')
                                {
                                    int val = int.Parse(strVal);
                                    if (p.prime[val])
                                    {
                                        Console.WriteLine(val);
                                    }
                                }
                            }
                            Console.ReadLine();
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("Not found");
            Console.ReadLine(); 
        }
    }
}
