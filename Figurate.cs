using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Figurate
    {
        /*
            Triangle 	  	P3,n=n(n+1)/2 	  	1, 3, 6, 10, 15, ...
                            n = 0.5 * (-1 (+-) sqrt(8*x + 1))
            Square 	  	    P4,n=n2 	  	    1, 4, 9, 16, 25, ...
                            n = sqrt(x)
            Pentagonal 	  	P5,n=n(3n−1)/2 	  	1, 5, 12, 22, 35, ...
                            n = 1/6 * (1 (+-) sqrt(24*x + 1))
            Hexagonal 	  	P6,n=n(2n−1) 	  	1, 6, 15, 28, 45, ...
                            n = 0.25 * (1 (+-) sqrt(8*x + 1)
            Heptagonal 	  	P7,n=n(5n−3)/2 	  	1, 7, 18, 34, 55, ...
                            n = 0.10 * (3 (+-) sqrt(40*x + 9))
            Octagonal 	  	P8,n=n(3n−2) 	  	1, 8, 21, 40, 65, ...
                            n = 1/3 * (1 (+-) sqrt(3*x + 1))
        */

        public static bool IsFigurate(int type, int number)
        {
            switch (type)
            {
                case 3:
                    return IsTriangle(number);
                case 4:
                    return IsSquare(number);
                case 5:
                    return IsPentagonal(number);
                case 6:
                    return IsHexagonal(number);
                case 7:
                    return IsHeptagonal(number);
                case 8:
                    return IsOctagonal(number);
                default:
                    return false;
            }
        }

        public static bool IsTriangle(int number)
        {
            // T = n (n+1) / 2
            // n = (sqrt(8*T + 1) - 1) / 2

            return ((Math.Sqrt(8 * number + 1) - 1) / 2) % 1 == 0;
        }

        public static bool IsSquare(int number)
        {
            // S = n * n
            // n = sqrt(S)
            return Math.Sqrt(number) % 1 == 0;
        }

        public static bool IsPentagonal(int number)
        {
            // P = n(3n-1) / 2
            // n = (1 + sqrt(24*P + 1)) / 6
            return ((1 + Math.Sqrt(24 * number + 1)) / 6) % 1 == 0;
        }

        public static bool IsHexagonal(int number)
        {
            // Hx = n (2n - 1)
            // n = (1 + sqrt(8*Hx + 1)) / 4
            return ((1 + Math.Sqrt(8 * number + 1)) / 4) % 1 == 0;
        }

        public static bool IsHeptagonal(int number)
        {
            // Hp = n(5n - 3) / 2
            // n = (3 + sqrt(40*Hp + 9)) / 10
            return ((3 + Math.Sqrt(40 * number + 9)) / 10) % 1 == 0;
        }

        public static bool IsOctagonal(int number)
        {
            // Oc = n(3n - 2)
            // n = (1 + sqrt(3*Oc + 1)) / 3
            return ((1 + Math.Sqrt(3 * number + 1)) / 3) % 1 == 0;
        }
    }
}
