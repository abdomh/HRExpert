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
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
}