using System;

class Program
{
    static void Main(string[] args)
    {
        Complex c1 = new Complex(3.0, 4.0);
        double length1 = c1;
        Console.WriteLine("implicit cast: " + c1 + " -> " + length1);

        double length2 = 42.0;
        Complex c2 = (Complex)length2;
        Console.WriteLine("explicit cast: " + length2 + " -> " + c2);

        int x = 13;
        Complex c3 = (Complex)x;
        Console.WriteLine("explicit cast: " + x + " -> " + c3);
    }
}

class Complex
{
    public double r, i;
    public Complex(double r, double i)
    {
        this.r = r; this.i = i;
    }
    public static implicit operator double(Complex c)
    {
        return Math.Sqrt(c.i * c.i + c.r * c.r); //RMS
    }

    public static explicit operator Complex(double r)
    {
        return new Complex(r, 0);
    }


    public override string ToString()
    {
        return "(" + r + ", " + i + ")";
    }
}

