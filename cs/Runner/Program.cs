using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common;
using Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Runner
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //SimpleRun();
            await Run(args);
        }

        private static async Task Run(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true);
                    config.AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }

                    Log.Logger = new LoggerConfiguration()
                        //.Enrich.FromLogContext()
                        //.WriteTo.ColoredConsole()
                        .ReadFrom.Configuration(config.Build())
                        .CreateLogger();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions();
                    services.Configure<AppSettings>(hostContext.Configuration.GetSection("AppSettings"));

                    services.AddSingleton<IHostedService, App>();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    // serilog logging
                    logging.AddSerilog(dispose:true);

                    // traditional logging
                    //logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    //logging.AddConsole();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(containerBuilder =>
                {
                    containerBuilder.RegisterModule<CommonModule>();
                    containerBuilder.RegisterModule<ImplementationModule>();
                })
                .UseConsoleLifetime();

            await builder.RunConsoleAsync();
        }

        private static void SimpleRun()
        {
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            log.Information("Hello, Serilog!");

            Log.Logger = log;
            Log.Information("The global logger has been configured");
        }
    }
}