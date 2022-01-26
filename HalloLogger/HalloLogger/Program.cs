using Serilog;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Serilog.Formatting.Log4Net;

namespace HalloLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo Logger");

            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            //Trace.Listeners.Add(new EventLogTraceListener("Application"));
            Trace.AutoFlush = true;

            Debug.WriteLine("Hallo Debug Logger");
            Trace.WriteLine("Hallo Trace Logger");
            Trace.TraceWarning("Hallo Trace WARNING");
            Trace.TraceError("Hallo Trace ERROR");
            Trace.TraceInformation("Hallo Trace INFO");

            var bäume = new List<Baum>();
            bäume.Add(new Baum()
            {
                Bezeichnung = "Tanne",
                Höhe = 250,
                Durchmesser = 20,
                Pflanzdatum = DateTime.Now.AddDays(-4),
                Art = BaumArt.Nadel
            });

            bäume.Add(new Baum()
            {
                Bezeichnung = "Birke",
                Höhe = 180,
                Durchmesser = 17,
                Pflanzdatum = DateTime.Now.AddDays(-20),
                Art = BaumArt.Laub
            });


            Trace.WriteLine($"Problembaum: {bäume[1]}");

            //Serilog

            Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
                                                  .WriteTo.Console()
                                                  //.WriteTo.Console(new JsonFormatter(renderMessage: true))
                                                  .WriteTo.File("serilog.log", rollingInterval: RollingInterval.Day)
                                                  .WriteTo.Seq("http://localhost:5341/")
                                                  .WriteTo.File(new Log4NetTextFormatter(c => c.UseCDataMode(CDataMode.Never)), "log4net.LOG")
                                                  .CreateLogger();

            for (int i = 0; i < 10; i++)
            {
                foreach (var b in bäume)
                {
                    b.Pflanzdatum = b.Pflanzdatum.AddDays(i * 10 * -1);
                    b.Höhe += i * 3;
                    Log.Logger.Warning("Neuerbaum: {@baum}", b);
                }
            }

            Log.Logger.Information("Problembaum: {@baum}", bäume[1]);


            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }

    public class Baum
    {
        public string Bezeichnung { get; set; }
        public int Höhe { get; set; }
        public decimal Durchmesser { get; set; }
        public DateTime Pflanzdatum { get; set; }
        public BaumArt Art { get; set; }

    }

    public enum BaumArt
    {
        Nadel,
        Laub
    }
}
