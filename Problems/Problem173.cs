using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem173
    {
        public static void Run()
        {
            int upper = 1000000;
            List<int> perimeter = new List<int>();
            perimeter.Add(0); // 0
            perimeter.Add(0); // 1
            perimeter.Add(0); // 2

            int side = 3;
            int perim = 2 * side + 2 * (side - 1);

            while (perim <= upper)
            {
                perimeter.Add(perim);
                side++;
                perim = 2 * side + 2 * (side - 2);
            }

            long count = 0;
            int total_tiles;
            for (int i = 3; i < perimeter.Count; i++)
            {
                total_tiles = perimeter[i];
                if (total_tiles <= upper)
                {
                    count++;
                }
                for (int j = i - 2; j >= 3; j-= 2)
                {
                    total_tiles += perimeter[j];
                    if (total_tiles <= upper)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }

                }
            }

            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
