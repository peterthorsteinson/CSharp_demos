using System;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using IronPython.Runtime.Types;
using IronRuby;
using System.IO;

namespace DynamicLanguageInterop
{
    class Program
    {
        static void Main(string[] args)
        {
            DemonstratePython();

            DemonstrateRuby();

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static void DemonstratePython()
        {
            Console.WriteLine("Python...");

            var runtime = Python.CreateRuntime();

            string pythonFile = Directory.GetParent("..\\..\\").FullName + "\\Python\\PythonCode.py";
            dynamic python = runtime.UseFile(pythonFile);
            ScriptEngine engine = Python.CreateEngine();

            int sum = python.Add(3, 4);
            Console.WriteLine("Add(3, 4) -> " + sum);

            Console.WriteLine(python.SayHello("Joe"));

            int factorial = python.Factorial(10);
            Console.WriteLine("factorial 10 -> " + factorial);

            ScriptScope builtins = engine.GetBuiltinModule();
            var pow = builtins.GetVariable<Func<double, double, double>>("pow");
            Console.WriteLine("2 power 10 -> " + pow(2, 10));
        }

        private static void DemonstrateRuby()
        {
            //# Open With... Source Code (Text) Editor With Encoding... Unicode (UTF-7) - Codepage 65000

            Console.WriteLine("Ruby...");

            var runtime = Ruby.CreateRuntime();

            string rubynFile = Directory.GetParent("..\\..\\").FullName + "\\Ruby\\RubyCode.rb";
            dynamic ruby = runtime.UseFile(rubynFile);
            ScriptEngine engine = Ruby.CreateEngine();

            string str = (string)ruby.say_hello("Sally");
            Console.WriteLine(str);
        }
    }
}
