using System;
using System.Threading;

namespace BasicThread
{
    class MainApp
    {
        static void DoSomeThing()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"DoSomething : {i}");
                Thread.Sleep(10);
            }
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(DoSomeThing));

            Console.WriteLine("Starting thread...");
            t1.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main : " + i);
                Thread.Sleep(10);
            }

            Console.WriteLine("Waiting until thread stops");
            t1.Join();

            Console.WriteLine("Finished");
        }
    }
}




