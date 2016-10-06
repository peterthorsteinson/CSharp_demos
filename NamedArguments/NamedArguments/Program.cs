using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamedArguments
{
    class Program
    {
        static void Main(string[] args)
        {
            // method called in  normal way, using positional arguments
            Console.WriteLine(CalculateBMI(123, 64));

            // Named arguments supplied for  parameters in either order
            Console.WriteLine(CalculateBMI(weight: 123, height: 64));
            Console.WriteLine(CalculateBMI(height: 64, weight: 123));

            // Positional arguments cannot follow named arguments
            // The following statement causes a compiler error
            //Console.WriteLine(CalculateBMI(weight: 123, 64));

            // Named arguments can follow positional arguments
            Console.WriteLine(CalculateBMI(123, height: 64));
        }

        static int CalculateBMI(int weight, int height)
        {
            return (weight * 703) / (height * height);
        }

    }
}
