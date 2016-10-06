using System;
using System.Threading;

namespace ThreadingCollisions
{
    class Threading
    {
        static DataItem dataitem = new DataItem();
        static Random random = new Random(DateTime.Now.Millisecond);
        static void Main(string[] args)
        {
            ThreadStart threadstart = new ThreadStart(ThreadMethod);
            Thread thread = new Thread(threadstart);
            thread.Start();
            while (true)
            {
                //lock (dataitem)
                //{
                    dataitem.x = random.Next(0, 10);
                    dataitem.y = random.Next(0, 10);
                    Thread.Sleep(random.Next(0, 100));
                    dataitem.sum = dataitem.x + dataitem.y;
                    Thread.Sleep(random.Next(0, 100));
                    if (dataitem.sum == dataitem.x + dataitem.y)
                        Console.Write(".");
                    else
                        Console.Write("COLLISION");
                //}
            }
        }
        static void ThreadMethod()
        {
            while (true)
            {
                //lock (dataitem)
                //{
                    dataitem.x = random.Next(0, 10);
                    dataitem.y = random.Next(0, 10);
                    Thread.Sleep(random.Next(0, 100));
                    dataitem.sum = dataitem.x + dataitem.y;
                    Thread.Sleep(random.Next(0, 100));
                    if (dataitem.sum == dataitem.x + dataitem.y)
                        Console.Write(".");
                    else
                        Console.Write("COLLISION");
                //}
            }
        }
    }

    class DataItem
    {
        public int x = 0;
        public int y = 0;
        public int sum = 0;
    }
}
