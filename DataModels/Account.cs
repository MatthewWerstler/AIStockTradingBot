using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Account
    {
        private string _AccountId;
        public string AccountId { get { return _AccountId; } }
        public bool isActivelyTrading { get; set; } = false;
        public List<WatchList> WatchLists { get; set; }

        public Account(string acctNumber)
        {
            _AccountId = acctNumber;
        }
    }
}
