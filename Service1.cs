using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ProtestService
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer5;     //every 5 min

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer5 = new System.Timers.Timer(300000); //5 minutes
            timer5.Elapsed += new System.Timers.ElapsedEventHandler(timer5_Elapsed);
            timer5.Start();

        }

        protected override void OnStop()
        {
        }

        void timer5_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer5.Stop();
            try {
                ProtestLib.Protests.UpdateStatus();
                ProtestLib.Notifications.SendPending();
            }
            catch { }
            timer5.Start();
        }



    }
}
