using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestExercise.Services;

namespace TestExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IHostBuilder builder = Host.CreateDefaultBuilder().ConfigureAppConfiguration(configBuilder =>
            {
               configBuilder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            }).ConfigureServices((context, config) =>
            {
                config.AddTransient<ILogger, FileLogger>();
                config.AddTransient<IPrintService, ConsolePrintService>();

                config.AddTransient<NumberPrinter>();
            });
            IHost app = builder.Build();

            var numberPrinter = app.Services.GetService<NumberPrinter>();
            numberPrinter?.Execute();
        }
    }
}