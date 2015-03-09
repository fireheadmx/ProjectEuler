using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem50
    {
        private long upper;
        private Sieve s;
        public Problem50() 
        {
            upper = 1000000;
            //upper = 1000;
            s = new Sieve(upper);
        }

        public void Run()
        {
            long maxPrime = 953;
            int maxCount = 21;
            int maxJ = 0;
            for (int i =(int)(s.primeList.Count*0.9); i < s.primeList.Count; i++)
            // Prime being checked
            {
                long currentPrime = s.primeList[i];
                for (int j = 0; j < i - 1; j++)
                // Point from where to start adding
                {
                    long sum = 0;
                    int count = 0;
                    for (int k = j; k < i - 1; k++)
                    // Add consecutive Primes
                    {
                        if (i - k < maxCount)
                        {
                            // Skip if there are less primes remaining than the highest count
                            break;
                        }
                        sum += s.primeList[k];
                        count++;
                        if (sum == currentPrime)
                        {
                            if (count > maxCount)
                            {
                                maxCount = count;
                                maxPrime = currentPrime;
                                maxJ = j;
                            }
                            break;
                        }
                        else if (sum > currentPrime)
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(maxPrime.ToString() + ": " + maxCount.ToString() + " (" + s.primeList[maxJ].ToString() + "..." + s.primeList[maxJ + maxCount] + ")");
        }
    }
}
