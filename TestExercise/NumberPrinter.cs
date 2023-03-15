using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestExercise.Services;

namespace TestExercise
{
    internal class NumberPrinter
    {
        private ILogger? logger;
        public ILogger? Logger
        {
            get => logger;
            set
            {
                if (value != null) logger = value;
            }
        }

        private IPrintService? printService;
        public IPrintService? PrintService
        {
            get => printService;
            set
            {
                if (value != null) printService = value;
            }
        }

        private IConfiguration configuration;


        public NumberPrinter(ILogger logger, IPrintService printService, IConfiguration configuration) 
        { 
            Logger = logger;
            PrintService = printService;
            this.configuration = configuration;
        }

        public void Execute()
        {
            try
            {
                var maxIteration = int.Parse(configuration.GetRequiredSection("value").Value);
                for (int i = 0; i <= maxIteration; i++)
                {
                    printService?.Print(i.ToString());
                    Logger?.LogInformation(i.ToString());
                }
            }
            catch(Exception ex)
            {
                printService?.Print(ex.Message);
                Logger?.LogInformation(ex.Message);
            }
            
        }
    }
}
