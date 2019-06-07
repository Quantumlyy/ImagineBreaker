using ImagineBreaker.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ImagineBreaker.Server
{
    public class Program
    {
        public static StartupHelper StartupHelper { get; } = new StartupHelper();
        
        public static void Main(string[] args)
        {
            StartupHelper.Initialize();
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}