using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem110
    {
        public void Run()
        {
            int upper = 4000000;

            Dictionary<BigInteger, int> divisors_found = new Dictionary<BigInteger, int>();

            BigInteger number17;
            BigInteger min_number = BigInteger.Pow(10, 20);
            int divisors_sq, divisors;
            int two, three, five, seven, eleven, thirteen, seventeen, nineteen, twentythree,
                twentynine, thirtyone, thirtyseven, fortyone, fortythree;
            for (fortythree = 0; fortythree <= 5; fortythree++)
            {
                for (fortyone = 0; fortyone <= 5; fortyone++)
                {
                    for (thirtyseven = 0; thirtyseven <= 5; thirtyseven++)
                    {
                        for (thirtyone = 1; thirtyone <= 5; thirtyone++)
                        {
                            if (3 * upper < (thirtyone * 2 + 1) * (thirtyseven * 2 + 1) * (fortyone * 2 + 1) * (fortythree * 2 + 1))
                                break;
                            for (twentynine = 1; twentynine <= 5; twentynine++)
                            {
                                if (3 * upper < (twentynine * 2 + 1) * (thirtyone * 2 + 1) * (thirtyseven * 2 + 1) * (fortyone * 2 + 1) * (fortythree * 2 + 1))
                                    break;
                                for (twentythree = 1; twentythree <= 5; twentythree++)
                                {
                                    if (3 * upper < (twentythree * 2 + 1) * (twentynine * 2 + 1) * (thirtyone * 2 + 1) * (thirtyseven * 2 + 1) * (fortyone * 2 + 1) * (fortythree * 2 + 1))
                                        break;
                                    for (nineteen = 1; nineteen <= 5; nineteen++)
                                    {
                                        if (3 * upper < (nineteen * 2 + 1) * (twentythree * 2 + 1) * (twentynine * 2 + 1) * (thirtyone * 2 + 1) * (thirtyseven * 2 + 1) * (fortyone * 2 + 1) * (fortythree * 2 + 1))
                                            break;
                                        for (seventeen = 1; seventeen <= 10; seventeen++)
                                        {
                                            if (3 * upper < (seventeen * 2 + 1) * (nineteen * 2 + 1) * (twentythree * 2 + 1) * (twentynine * 2 + 1) * (thirtyone * 2 + 1) * (thirtyseven * 2 + 1) * (fortyone * 2 + 1) * (fortythree * 2 + 1))
                                                break;
                                            for (thirteen = 1; thirteen <= 10; thirteen++)
                                            {
                                                if (3 * upper < (thirteen * 2 + 1) * (seventeen * 2 + 1) * (nineteen * 2 + 1) * (twentythree * 2 + 1) * (twentynine * 2 + 1) * (thirtyone * 2 + 1) * (thirtyseven * 2 + 1) * (fortyone * 2 + 1) * (fortythree * 2 + 1))
                                                    break;
                                                for (eleven = 1; eleven <= 10; eleven++)
                                                {
                                                    if (3 * upper < (eleven * 2 + 1) * (thirteen * 2 + 1) * (seventeen * 2 + 1) * (nineteen * 2 + 1) * (twentythree * 2 + 1) * (twentynine * 2 + 1) * (thirtyone * 2 + 1) * (thirtyseven * 2 + 1) * (fortyone * 2 + 1) * (fortythree * 2 + 1))
                                                        break;
                                                    for (seven = 1; seven <= 10; seven++)
                                                    {
                                                        if (3 * upper < (seven * 2 + 1) * (eleven * 2 + 1) * (thirteen * 2 + 1) * (seventeen * 2 + 1) * (nineteen * 2 + 1) * (twentythree * 2 + 1) * (twentynine * 2 + 1) * (thirtyone * 2 + 1) * (thirtyseven * 2 + 1) * (fortyone * 2 + 1) * (fortythree * 2 + 1))
                                                            break;
                                                        for (five = 1; five <= 10; five++)
                                                        {
                                                            if (3 * upper < (five * 2 + 1) * (seven * 2 + 1) * (eleven * 2 + 1) * (thirteen * 2 + 1) * (seventeen * 2 + 1) * (nineteen * 2 + 1) * (twentythree * 2 + 1) * (twentynine * 2 + 1) * (thirtyone * 2 + 1) * (thirtyseven * 2 + 1) * (fortyone * 2 + 1) * (fortythree * 2 + 1))
                                                                break;
                                                            for (three = 1; three <= 10; three++)
                                                            {
                                                                if (3 * upper < (three * 2 + 1) * (five * 2 + 1) * (seven * 2 + 1) * (eleven * 2 + 1) * (thirteen * 2 + 1) * (seventeen * 2 + 1) * (nineteen * 2 + 1) * (twentythree * 2 + 1) * (twentynine * 2 + 1) * (thirtyone * 2 + 1) * (thirtyseven * 2 + 1) * (fortyone * 2 + 1) * (fortythree * 2 + 1))
                                                                    break;
                                                                for (two = 1; two <= 10; two++)
                                                                {
                                                                    divisors = (two + 1) * (three + 1) * (five + 1) * (seven + 1) * (eleven + 1) * (thirteen + 1) * (seventeen + 1) * (nineteen + 1) * (twentythree + 1) * (twentynine + 1) * (thirtyone + 1) * (thirtyseven + 1) * (fortyone + 1) * (fortythree + 1);
                                                                    divisors_sq = (two * 2 + 1) * (three * 2 + 1) * (five * 2 + 1) * (seven * 2 + 1) * (eleven * 2 + 1) * (thirteen * 2 + 1) * (seventeen * 2 + 1) * (nineteen * 2 + 1) * (twentythree * 2 + 1) * (twentynine * 2 + 1) * (thirtyone * 2 + 1) * (thirtyseven * 2 + 1) * (fortyone * 2 + 1) * (fortythree * 2 + 1);

                                                                    if (3 * upper < divisors_sq)
                                                                        break;

                                                                    if (divisors_sq >= 2 * upper && divisors_sq <= (2 * upper * 13 / 10))
                                                                    {
                                                                        number17 = BigInteger.Pow(2, two) * BigInteger.Pow(3, three) * BigInteger.Pow(5, five) * BigInteger.Pow(7, seven)
                                                                                * BigInteger.Pow(11, eleven) * BigInteger.Pow(13, thirteen) * BigInteger.Pow(17, seventeen)
                                                                                * BigInteger.Pow(19, nineteen) * BigInteger.Pow(23, twentythree) * BigInteger.Pow(29, twentynine)
                                                                                * BigInteger.Pow(31, thirtyone) * BigInteger.Pow(37, thirtyseven) * BigInteger.Pow(41, fortyone)
                                                                                * BigInteger.Pow(43, fortythree);
                                                                        if (number17 < min_number)
                                                                        {
                                                                            Console.WriteLine("{0} : d(n) = {1}, d(n^2) = {2}", number17, divisors, divisors_sq);

                                                                            min_number = number17;
                                                                            if (!divisors_found.Keys.Contains(number17))
                                                                            {
                                                                                divisors_found.Add(number17, (divisors_sq));
                                                                            }
                                                                        }
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Smallest: {0}: {1}, {2}", divisors_found.Keys.Min(), divisors_found[divisors_found.Keys.Min()], divisors_found[divisors_found.Keys.Min()]/2);
            Console.ReadLine();
        }
    }
}
