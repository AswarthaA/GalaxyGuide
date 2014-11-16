
using GalaxyGuide.Common;
using GalaxyGuide.Server;

namespace GalaxyGuide.Main
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            //var galacticUnits = new GalaxyDictionary<string, Romans>();
            //var itemCredits = new GalaxyDictionary<string, float>();

            //var manager = new GalaxyManager(galacticUnits,itemCredits);
            var manager = new GalaxyManager();
            PrintInstructions();

            foreach (var arg in args)
            {
                manager.ProcessMessage(arg);
            }

            do
            {
                try
                {
                    var line = Console.ReadLine();
                    if (string.IsNullOrEmpty(line)) continue;

                    var status = manager.ProcessMessage(line);
                    if (!status.Equals("scuess", StringComparison.CurrentCultureIgnoreCase))
                        Console.WriteLine(status);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
            // ReSharper disable once FunctionNeverReturns
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("*****************Welcome to Galaxy Mart**********************************");
            Console.WriteLine("***************** Press ctrl+C to exit **********************************");
            Console.WriteLine("*************************************************************************");
        }
    }
}
