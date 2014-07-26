using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace ProtestService
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;

        public Installer1()
        {
            InitializeComponent();

            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceInstaller1.ServiceName = "Protest Service";
            this.Installers.AddRange(new System.Configuration.Install.Installer[] { this.serviceProcessInstaller1, this.serviceInstaller1 });
        }

    }
}
