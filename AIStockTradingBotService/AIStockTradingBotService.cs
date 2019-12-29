using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AIStockTradingBotService
{
    public partial class AIStockTradingBotService : ServiceBase
    {
        Timer timer = new Timer();
        private int timerInterval = 10;
        

        public AIStockTradingBotService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Log.write("Started Service");
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = timerInterval; // in milliseconds 10 = 100th of a second API call limit is 120 per minute
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            Log.write("Stopped Service");
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            Log.write("Elapsed Time Method Called");
        }

        public void RunAsConsole(string[] args)
        {

            Log.write("Run As Console method triggered");
            timerInterval = 250;
            OnStart(args);
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
            OnStop();
        }
    }
}
