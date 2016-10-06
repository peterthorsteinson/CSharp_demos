using System;

class Generics
{
    static void Main(string[] args)
    {
        // create arrays of various types
        int[] intArray = { 1, 2, 3, 4, 5, 6 };
        double[] doubleArray = { 1.0, 2.0, 3.0, 4.0, 5.0 };
        char[] charArray = { 'A', 'B', 'C', 'D', 'E' };

        DisplayArray(intArray);
        DisplayArray(doubleArray);
        DisplayArray(charArray);

        MyGeneric<int, string> mg1 = new MyGeneric<int, string>();
        mg1.GenericMethod1(3);
        mg1.GenericMethod2(4, "hello");

        MyGeneric<double, char> mg2 = new MyGeneric<double, char>();
        mg2.GenericMethod1(3.141592);
        mg2.GenericMethod2(3.33333, 'Z');

        Console.ReadLine();
    }

    // generic method displays array of any type
    static void DisplayArray<E>(E[] array)
    {
        Console.WriteLine("Display array of type " + array.GetType() + ":");
        foreach (E element in array)
            Console.Write(element + " ");

        Console.WriteLine();
    }
}

public class MyGeneric<T1, T2>
{
    public T1 GenericField;
    public void GenericMethod1(T1 t)
    {
        Console.WriteLine("GenericMethod1 parameter type: " + t.GetType());
    }

    public void GenericMethod2(T1 t1, T2 t2)
    {
        Console.WriteLine("GenericMethod2 parameter types: " + t1.GetType() + ", " + t2.GetType());
    }
}


