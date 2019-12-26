using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

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
    }
}
