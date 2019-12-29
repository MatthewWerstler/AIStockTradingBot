using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AIStockTradingBotService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            //https://alastaircrabtree.com/how-to-run-a-dotnet-windows-service-as-a-console-app/
            AIStockTradingBotService service = new AIStockTradingBotService();
            if (Environment.UserInteractive)
            {
                service.RunAsConsole(args);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { service };
                ServiceBase.Run(ServicesToRun);
            }
            ////Original Free Code
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new AIStockTradingBotService()
            //};
            //ServiceBase.Run(ServicesToRun);
        }
    }
}
