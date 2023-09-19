using System;

namespace ex14_2
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int[] array = { 11, 22, 33, 44, 55 };

            Func<int, int> func = (a) => a * a;

            foreach(int a in array)
            {
                Console.WriteLine(func(a));
            }
        }
    }
}