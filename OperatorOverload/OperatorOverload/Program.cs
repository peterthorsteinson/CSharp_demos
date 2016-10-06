using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatorOverload
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(3, 4);
            Complex c2 = new Complex(5, 6);
            Complex c3 = c1 + c2;

            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine(c3);
        }
    }

    class Complex
    {
        public int r, i;
        public Complex(int r, int i)
        {
            this.r = r; this.i = i;
        }
        public static Complex operator +(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.r + rhs.r, lhs.i + rhs.i);
        }
        public override string ToString()
        {
            return "(" + r + ", " + i + ")";
        }
    }
}
