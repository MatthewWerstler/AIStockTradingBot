using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStockTradingBotService
{
    public static class Log
    {
        public static void write(string logOutput, string logType = "Running")
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine($"{DateTime.Now.ToString("yyyyMMdd(hh:mm)")}-{logOutput}");
            }
        }
    }
}
