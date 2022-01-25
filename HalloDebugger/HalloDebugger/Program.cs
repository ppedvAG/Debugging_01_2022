using System;
using TolleLib;

namespace HalloDebugger
{
    internal class Program
    {

        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("DEBUG MODE");
#elif Wurst
            Console.WriteLine("Wurst MODE");
    
#else
            Console.WriteLine("RELEASE MODE");
#endif


            Console.WriteLine("Hallo Debugger");
            Console.WriteLine("Pause");
            Console.ReadLine();
            MachSachen();


            var c1 = new Class1();
            c1.SagHallo();

            Console.ReadKey();
        }

        private static void MachSachen()
        {
            for (int i = 0; i < 10; i++)
            {
                ZeigeText($"Hallo Welt {i}");
            }

        }

        private static void ZeigeText(string v)
        {
            Console.WriteLine(v);


            if (v.Contains("8"))
            {
                Console.WriteLine("Press 4 Error");
                Console.ReadLine();
                throw new ExecutionEngineException();
            }

        }
    }
}
