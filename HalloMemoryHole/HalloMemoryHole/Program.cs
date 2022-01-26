using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloMemoryHole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            LadeA();
            LadeA();

            //GC.Collect();

            Console.ReadLine();
        }

        private static void LadeA()
        {

            var aListe = new List<A>(10000000);

            for (int i = 0; i < 10000000; i++)
            {
                var a = new A() { Text="AAAAA"};
                var b = new B() { A = a };
                a.B = b;
                //bListe.Add(b);
                aListe.Add(a);
                if (i % 1000000 == 0)
                    Console.WriteLine(i);
            }
            Console.ReadLine();

        }
        //static List<B> bListe = new List<B>();
    }

    class A
    {
        public string Text { get; set; }
        public B B { get; set; }
    }

    class B
    {
        public string Text { get; set; }
        public A A { get; set; }
    }
}
