using System;
using System.Threading;

namespace InterruptingThread
{
    class MainApp
    {
        static void DoSomeThing()
        {
            int count = 100;
            try
            {
                Console.WriteLine("Running thread isn't gonna be interrupted");
                Thread.Sleep(100);

                while (count > 0)
                {
                    Console.WriteLine($"DoSomething : {count--}");

                    Console.WriteLine("Entering into WaitJoinSleep State...");
                    Thread.Sleep(10);
                }
                Console.WriteLine("Count : 0");
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e);
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

            Console.WriteLine("Interrupting Thread...");
            t1.Interrupt();


            Console.WriteLine("Waiting until thread stops");
            t1.Join();

            Console.WriteLine("Finished");
        }
    }
}




