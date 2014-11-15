
using GalaxyGuide.Server;

namespace GalaxyGuide.Main
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var manager = new GalaxyManager();

            PrintInstructions();

            foreach (var arg in args)
            {
                manager.ProcessMessage(arg);
            }

            do
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) continue;

                var status = manager.ProcessMessage(line);
                if (!status.Equals("scuess", StringComparison.CurrentCultureIgnoreCase))
                    Console.WriteLine(status);
            } while (true);
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
