using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{

    public class Dividend
    {
        public string ticker { get; set; }
        public string exDate { get; set; }
        public string paymentDate { get; set; }
        public string recordDate { get; set; }
        public float amount { get; set; }
    }
}
