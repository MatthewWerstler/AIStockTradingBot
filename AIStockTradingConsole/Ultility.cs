using System;
using System.Collections.Generic;
using System.Text;

namespace AIStockTradingConsole
{
    public static class Ultility
    {
        public static void delay(int Time_delay)
        {
            int i = 0;
            var _delayTimer = new System.Timers.Timer();
            _delayTimer.Interval = Time_delay;
            _delayTimer.AutoReset = false; //so that it only calls the method once
            _delayTimer.Elapsed += (s, args) => i = 1;
            _delayTimer.Start();
            while (i == 0) { };
        }
    }
}
