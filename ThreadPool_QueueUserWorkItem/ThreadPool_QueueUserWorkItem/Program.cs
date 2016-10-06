using System;
using System.Threading;

namespace ThreadPool_QueueUserWorkItem
{
    public class Example
    {
        public static void Main()
        {
            ThreadData td = new ThreadData("This report displays the number {0}.", 42);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), td);

            Console.WriteLine("Main thread does some work, then sleeps.");

            // If you comment out Sleep, main thread exits before
            // ThreadPool task has chance to run.  ThreadPool uses 
            // background threads which do not keep  application 
            // running.  (race condition)
            Thread.Sleep(1000);

            Console.WriteLine("Main thread exits");
        }

        static void ThreadProc(Object threadData)
        {
            ThreadData td = (ThreadData)threadData;
            Console.WriteLine(td.text, td.number);
            Console.WriteLine("Secondary thread exits");
        }
    }

    public class ThreadData
    {
        public string text;
        public int number;
        public ThreadData(string text, int number)
        {
            this.text = text;
            this.number = number;
        }
    }
}
