using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ProjectEuler.Problems
{
    class Problem57
    {
        private int upper = 1000;

        private decimal Evaluate(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return decimal.Parse((string)row["expression"]);
        }

        public void Run()
        {
            upper = 1000;
            int count = 0;
            // sqrt(2) = 1 + 1/(2 + 1/(2 + 1/(2 + ... )))

            Fraction right = new Fraction(1 / 2);
            Fraction res = new Fraction(1) + right;
            for (int i = 1; i <= upper; i++)
            {
                right = new Fraction(1) / (new Fraction(2) + right);
                res = new Fraction(1) + right;

                if (res.Numerator.ToString().Length > res.Denominator.ToString().Length)
                {
                    count++;
                }
                //Console.WriteLine("[" + i.ToString() + "]: " + res.Numerator.ToString() + "/" + res.Denominator.ToString());
            }
            Console.WriteLine(count);
        }
    }
}
