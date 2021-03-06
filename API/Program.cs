using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistance;
using Microsoft.EntityFrameworkCore;
namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
               var host = CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try 
                {
                    var context = services.GetRequiredService<DataContext>();
                     context.Database.Migrate();
                     await Seed.SeedData(context);
                }
                catch(Exception ex)
                {
                   var logger = loggerFactory.CreateLogger<Program>();
                   logger.LogError($"An error occurred during migration: {ex.Message}"); 
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
