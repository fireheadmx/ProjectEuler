using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem102
    {

        private double sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        private bool PointInTriangle(Point pt, Point v1, Point v2, Point v3)
        {
            bool b1, b2, b3;

            b1 = sign(pt, v1, v2) < 0.0;
            b2 = sign(pt, v2, v3) < 0.0;
            b3 = sign(pt, v3, v1) < 0.0;

            return ((b1 == b2) && (b2 == b3));
        }

        public void Run()
        {
            int[][] input = new int[1000][];

            using (StreamReader sr = new StreamReader("Input/p102_triangles.txt"))
            {
                string[] str_input;
                int i = 0;
                do
                {
                    str_input = sr.ReadLine().Split(',');
                    input[i] = new int[6];
                    input[i][0] = int.Parse(str_input[0]);
                    input[i][1] = int.Parse(str_input[1]);
                    input[i][2] = int.Parse(str_input[2]);
                    input[i][3] = int.Parse(str_input[3]);
                    input[i][4] = int.Parse(str_input[4]);
                    input[i][5] = int.Parse(str_input[5]);
                    i++;
                }
                while (i < 1000);
            }

            int count = 0;
            for (int i = 0; i < 1000; i++)
            {
                if(PointInTriangle(new Point(0, 0), new Point(input[i][0], input[i][1]),new Point(input[i][2], input[i][3]),new Point(input[i][4], input[i][5])))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }

    struct Point
    {
        public double X, Y;
        public Point(double x1, double y1)
        {
            this.X = x1;
            this.Y = y1;
        }
    }
}
