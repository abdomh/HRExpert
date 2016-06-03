using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace HRExpert
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Hello world1");
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            System.Console.WriteLine("Hello world");
            host.Run();
        }
    }
}