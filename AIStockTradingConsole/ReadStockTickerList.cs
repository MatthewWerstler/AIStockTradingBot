using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace AIStockTradingConsole
{
    public static class ReadStockTickerList
    {
        public static List<string> ReadStockTickerListByLineOfText(string filePath)
        {
            List<string> tickerList = new List<string>();

            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                    new System.IO.StreamReader(filePath);  
            while((line = file.ReadLine()) != null)  
            {  
                tickerList.Add(line.Trim());  
                counter++;  
            }

            file.Close();  
            System.Console.WriteLine("There were {0} lines.", counter);  
            // Suspend the screen.  
            System.Console.ReadLine();

            return tickerList;
        }
    }
}
