using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Divend
    {
        public string ticker;
        public DateTime exDate;
        public DateTime paymentDate;
        public DateTime recordDate;
        public float amount;
        public DateTime? AnnouncementDate;
    }
}
