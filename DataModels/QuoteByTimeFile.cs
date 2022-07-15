using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class QuoteByTimeFile
    {
        public string path { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public System.IO.FileInfo info { get; set; }
    }
}
