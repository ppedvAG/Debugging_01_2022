using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace HalloTPL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Hallo TPL ***");

            Parallel.Invoke(Zähle, Zähle, Zähle, Zähle, Zähle);


            Console.WriteLine("Ende");
            Console.ReadLine();
        }

        private static void Zähle()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 4)
                    Debugger.Break();

                ShowText(i);
            }
        }

        private static void ShowText(int i)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
        }
    }
}
