using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{

    class Factorial
    {
        private List<BigInteger> value;
        public Factorial() {
            value = new List<BigInteger>();
            value.Add(1);
            value.Add(1);
        }

        public Factorial(int value) {
            new Factorial();
            //val(value);
        }

        public BigInteger val(int ix)
        {
            while (value.Count <= ix)
            {
                value.Add(value[value.Count - 1] * value.Count);
            }
            return value[ix];
        }
    }
}
