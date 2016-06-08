using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace HRExpert
{
    /// <summary>
    /// Класс программы
    /// </summary>
    public class Program
    {
        /// <summary>
        /// энтри поинт
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Applications start.");
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            System.Console.WriteLine("Pre run");
            host.Run();
            System.Console.WriteLine("OK.");
        }
    }
}