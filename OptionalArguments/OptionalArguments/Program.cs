using System;

namespace OptionalArguments
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleMethod("1", "One", 42);
            ExampleMethod("2", "Two");
            ExampleMethod("3");
            //ExampleMethod(3,,42); //not allowed
        }

        static public void ExampleMethod(
            string param1_required,
            string param2_optional = "default string", 
            int param3_optional = 13)
        {
            Console.Write("param1_required: " + param1_required +", ");
            Console.Write("param2_optional: " + param2_optional + ", ");
            Console.WriteLine("param3_optional: " + param3_optional);
        }
    }
}
