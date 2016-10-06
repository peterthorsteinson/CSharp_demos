using System;

namespace CS_Closure
{
    delegate string ClosureDelegate(string augend);

    class Program
    {
        static void Main(string[] args)
        {
            ClosureClass cc = new ClosureClass();
            ClosureDelegate cd = cc.ClosureMethod("outerParameter");
            string str = cd("innerParameter");
            Console.WriteLine(str);
        }
    }

    class ClosureClass
    {
        public ClosureDelegate ClosureMethod(string outerParameter)
        {
            string outerLocalVariable = "outerLocalVariable";

            return delegate(string innerParameter)
            {
                string innerLocalVariable = "innerLocaVariable";
                return outerParameter + "\n" + outerLocalVariable + "\n"
                    + innerParameter + "\n" + innerLocalVariable;
            };
        }

    }
}
