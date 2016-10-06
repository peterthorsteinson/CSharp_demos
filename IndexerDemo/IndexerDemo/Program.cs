using System;

class Program
{
    static void Main(string[] args)
    {
        Primes primes = new Primes();
        for (int i = 0; i < 10; i++)
            Console.WriteLine(primes[i]);
    }
}

class Primes
{
    public int this[int index]
    {
        get
        {
            int pos = 0;
            int candidate = 2;
            while (pos < index)
            {
                pos++;
                candidate++;
                while (!candidate.IsPrime())
                {
                    candidate++;
                }
            }
            return candidate;
        }
    }
}

static class Extensions
{
    public static bool IsPrime(this int number)
    {
        if ((number % 2) == 0)
        {
            return number == 2;
        }
        int sqrt = (int)Math.Sqrt(number);
        for (int t = 3; t <= sqrt; t = t + 2)
        {
            if (number % t == 0)
            {
                return false;
            }
        }
        return number != 1;
    }
}


