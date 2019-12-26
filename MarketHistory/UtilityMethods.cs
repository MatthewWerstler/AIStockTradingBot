using System;
using System.Collections.Generic;
using System.Text;

namespace MarketHistory
{
    public static class UtilityMethods
    {
        public static DateTime FromUnixTime(long unixTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(unixTime);
        }

        public static string EnochToyyyyMMddhhmmString(string unixtime)
        {
            DateTime dt = UtilityMethods.FromUnixTime(long.Parse(unixtime));
            return dt.ToString("yyyyMMddhhmm");
        }
    }
}
