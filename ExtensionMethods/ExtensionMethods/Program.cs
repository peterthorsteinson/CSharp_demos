using System;

class Program
{
    static void Main(string[] args)
    {
        string s = "Hello Extension Methods";
        int i = s.WordCount();
        Console.WriteLine("\"{0}\" contains {1} words", s, i);
    }
}
public static class MyExtensions
{
    public static int WordCount(this String str)
    {
        return str.Split(new char[] { ' ', '.', '?' },
            StringSplitOptions.RemoveEmptyEntries).Length;
    }
}

