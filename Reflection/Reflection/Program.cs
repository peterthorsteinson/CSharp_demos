using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayTypeInfo(Type.GetType("System.String")); //fully qualified and case-sensitive);

            DisplayTypeInfo(Type.GetType("Foo")); //fully qualified and case-sensitive

            InvokeFooMethods();
        }

        static void DisplayTypeInfo(Type t)
        {
            Console.WriteLine("\n*********** Display type info on " + t.Name + " ***********");

            // check to see if we have a valid value. If our object is null, the type does not exist...
            if (t == null)
            {
                // Don't assume that it is a SYSTEM datatype...
                Console.WriteLine("Ensure that you specify valid types.");
                Console.WriteLine("Case matters (Byte is not the same as byte).");
                return; // don't continue processing
            }

            // iterate through all the field members
            FieldInfo[] fi = t.GetFields(); // (BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (FieldInfo f in fi)
            {
                Console.WriteLine(f);
            }

            // iterate through all the method members
            MethodInfo[] mi = t.GetMethods(); // (BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (MethodInfo m in mi)
            {
                Console.WriteLine(m);
            }
        }

        static void InvokeFooMethods()
        {
            Console.WriteLine("\n*********** Invoke methods on Foo ***********");

            Type t = Type.GetType("Foo");

            object[] arguments = { 3, 4 };
            object result;

            Console.WriteLine();

            // invoke a static method
            result = t.InvokeMember("Method1", BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Static, null, null, arguments);
            Console.WriteLine("result: {0}\n", result);

            // invoke an instance method
            Assembly asm = Assembly.GetExecutingAssembly();
            Object obj = asm.CreateInstance("Foo");
            result = t.InvokeMember("Method2", BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance, null, obj, arguments);

            Console.WriteLine("result: {0}\n", result);
        }
    }
}

public class Foo
{
    public int XYZ;
    private int xyz;

    public static int Method1(int x, int y)
    {
        Console.WriteLine("Foo.Method1");
        return x + y;
    }

    public int Method2(int x, int y)
    {
        Console.WriteLine("Foo.Method2");
        return x * y;
    }
}