using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class AccountInformation
    {
        private string _AccountId;
        public string AccountId { get { return _AccountId; } }
        public bool isActivelyTrading { get; set; } = false;
        public List<WatchList> WatchLists { get; set; }

        public AccountInformation(string acctNumber)
        {
            _AccountId = acctNumber;
        }
    }
}
