using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace PcMonitor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main(String[] args)
        {
            if (args.Length >= 1 && args[0] == "debug")
            {
                PcMonitor s = new PcMonitor();
                s.Start();
                Thread.Sleep(30000);

            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { new PcMonitor()};
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
