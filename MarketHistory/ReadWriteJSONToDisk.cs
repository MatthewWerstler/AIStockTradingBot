using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace MarketHistory
{
    public static class ReadWriteJSONToDisk
    {
        public static void testCreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static void writeDataAsJSON(string filePath, dynamic data)
        {
            string jsonFileContent = JsonConvert.SerializeObject(data);
            using (StreamWriter str = new StreamWriter(filePath))
            {
                str.Write(jsonFileContent);
            }
        }

        public static List<DataModels.Quote> getQuotesFromJSON(string jsonFilePath)
        {
            List<DataModels.Quote> items;
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<DataModels.Quote>>(json);
            }
            return items;
        }

        public static List<DataModels.QuoteFile> getQuotesFileListFromDirectory(string path)
        {
            string[] files = Directory.GetFiles(path);
            List<DataModels.QuoteFile> quoteFiles = new List<DataModels.QuoteFile>();
            foreach (string file in files)
            {
                if(file.EndsWith(".json"))
                { 
                    DataModels.QuoteFile thisFile = new DataModels.QuoteFile();
                    thisFile.path = file;
                    thisFile.info = new FileInfo(file);
                    List<string> splitname = thisFile.info.Name.Replace(".json", "").Split('-').ToList();
                    Regex rgx = new Regex(@"\d");
                    thisFile.startDate = splitname.Where(q => rgx.IsMatch(q.ToString())).First();
                    thisFile.endDate = splitname.Where(q => rgx.IsMatch(q)).Last();
                    quoteFiles.Add(thisFile);
                }
            }
            return quoteFiles;
        }

        public static int deleteFiles(List<DataModels.QuoteFile> filesToDelete)
        {
            int count = 0;
            foreach(DataModels.QuoteFile file in filesToDelete)
            {
                File.Delete(file.path);
                count++;
            }
            return count;
        }

        public static List<string> getListOfStocksWithHistory(string tradeDataPath)
        {
            List<string> returnSymbols = new List<string>();
            foreach (string dir in Directory.GetDirectories($"{tradeDataPath}\\Price_History"))
                returnSymbols.Add(new DirectoryInfo(dir).Name);
            return returnSymbols;
        }
    }
}
