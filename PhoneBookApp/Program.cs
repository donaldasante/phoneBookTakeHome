using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                //Configure serilog logger with fluent
                Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                            .Enrich.FromLogContext()
                            .WriteTo.Console()
                            .WriteTo.File(
                                           AppDomain.CurrentDomain.BaseDirectory + "\\logs\\PhoneBook.txt",
                                            restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error,
                                            rollingInterval: RollingInterval.Day,
                                            retainedFileCountLimit: 7,
                                            shared: true
                                          )
                            .CreateLogger();


                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
