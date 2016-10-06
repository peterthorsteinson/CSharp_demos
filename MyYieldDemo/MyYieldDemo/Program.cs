using System;
using System.Collections;
using System.Collections.Generic;

namespace MyYieldDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in GetPowers(2, 8))
            {
                Console.WriteLine("{0} ", i);
            }
            foreach (int i in GetPowersUsingYield(2, 8))
            {
                Console.WriteLine("{0} ", i);
            }
        }

        public static IEnumerable GetPowers(int number, int exponent)
        {
            int counter = 0;
            int result = 1;
            List<int> al = new List<int>(); 
            while (counter++ < exponent)
            {
                result = result * number;
                al.Add(result);
            }
            return al;
        }

        public static IEnumerable GetPowersUsingYield(int number, int exponent)
        {
            int counter = 0;
            int result = 1;
            while (counter++ < exponent)
            {
                result = result * number;
                yield return result;
            }
        }
    }
}
