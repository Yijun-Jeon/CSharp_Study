using System;
using System.Threading;

namespace AbortingThread
{
    class MainApp
    {
        static void DoSomeThing()
        {
            int count = 100;
            try
            {
                while (count > 0)
                {
                    Console.WriteLine($"DoSomething : {count--}");
                    Thread.Sleep(10);
                }
                Console.WriteLine("Count : 0");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine(e);
                Thread.ResetAbort();
            }
            finally
            {
                Console.WriteLine("Clearing resource...");
            }

        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(DoSomeThing));
            t1.IsBackground = false;

            Console.WriteLine("Starting thread...");
            t1.Start();

            Thread.Sleep(100);

            Console.WriteLine("Aborting Thread...");
            t1.Abort();


            Console.WriteLine("Waiting until thread stops");
            t1.Join();

            Console.WriteLine("Finished");
        }
    }
}




