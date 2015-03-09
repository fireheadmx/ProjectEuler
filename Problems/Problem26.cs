using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem26
    {
        private int upper = 1000;
        private int maxPrecision = 3000;

        private Sieve s = new Sieve(1000);

        private int RecurringCycleSize(string number)
        {
            while (number.Length > 2 && number[number.Length - 1] == '0' && number[number.Length - 2] == '0')
            {
                // Remove Irrelevant Zeroes
                number = number.Substring(0, number.Length - 1);
            }
            if (number.Length > 20) // Number has Cycle
            {
                int min_cycle_size = maxPrecision;
                for (int i = 0; i < number.Length - 1 && min_cycle_size > 1; i++)
                {
                    for (int size = (number.Length-i) / 2; size >= 1; size--)
                    {
                        string cycleBase = number.Substring(i, size);
                        bool allEqual = true;
                        for (int x = 1; x < (number.Length - i) / size; x++)
                        {
                            allEqual &= cycleBase == number.Substring(i + (x * size), size);
                            if (!allEqual) break;
                        }

                        if(allEqual)
                        {
                            if (size < min_cycle_size)
                            {
                                min_cycle_size = size;
                            }
                        }
                    }
                }
                return min_cycle_size;
            }
            else
            {
                return 0;
            }
        }

        public string Run()
        {
            int max = 0;
            int maxI = 0;

            BigInteger baseNumber = new BigInteger(10000000000);
            for (int bse = 1; bse < maxPrecision; bse++)
            {
                // Add 1 zero precision per time around
                baseNumber *= 10;
            }
            for (int i = upper - (upper/10); i <= upper; i++)
            {
                if (s.prime[i])
                {
                    BigInteger val = baseNumber / i;
                    string str = val.ToString("G");
                    int cycle_size = RecurringCycleSize(str);
                    if (cycle_size < maxPrecision && cycle_size > max)
                    {
                        max = cycle_size;
                        maxI = i;
                        Console.WriteLine("1/" + i.ToString() + ": " + cycle_size.ToString());
                    }
                }
            }

            return "1/" + maxI.ToString() + " (" + max.ToString() + ") = " + (1m/maxI).ToString();
        }
    }
}
