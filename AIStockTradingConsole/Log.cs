using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStockTradingConsole
{
    public static class Log
    {
        public static void write(string logOutput, string logType = "Running")
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine($"{DateTime.Now.ToString()}  {logOutput}");
            }
        }

        public static void write(Exception e)
        {
            Console.WriteLine("An exception was thrown.");
            Console.WriteLine(e.Message);
            if (e.Data.Count > 0)
            {
                Console.WriteLine("  Extra details:");
                foreach (DictionaryEntry de in e.Data)
                    Console.WriteLine("    Key: {0,-20}      Value: {1}",
                                      "'" + de.Key.ToString() + "'", de.Value);
            }
        }
    }
}
