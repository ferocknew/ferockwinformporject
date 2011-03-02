using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Data.OleDb;
using System.Management;

namespace PcMonitor
{
    public partial class PcMonitor : ServiceBase
    {
        public PcMonitor()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            MyTimer();
        }

        protected override void OnStop()
        {
        }

        private void MyTimer(){
            int _Sleep = 60000;//1分钟记录一次
            System.Timers.Timer MT = new System.Timers.Timer(_Sleep);
            MT.Elapsed += new System.Timers.ElapsedEventHandler(MTimedEvent);
            //MT.AutoReset   =false;
            //MT.Start();
            MT.Enabled = true;
        }
        
        //构造System.Timers.Timer实例   间隔时间事件
        private void MTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            strConnection += @"Data Source=|DataDirectory|MDB.mdb";
            OleDbConnection conn = new OleDbConnection(strConnection);
            conn.Open();

            //硬件信息调用
            string _cpuInfo = "";//cpu信息 
            ManagementClass cimobject = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = cimobject.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                _cpuInfo = mo.Properties["ProcessorId"].Value.ToString();

            }

            String _sql = "insert into [Test] ([Title]) VALUES ('" + DateTime.Now.ToString() + "')";
            OleDbCommand cmd = new OleDbCommand(_sql, conn);
            cmd.ExecuteNonQuery();

            conn.Dispose();
            GC.Collect();
        }       
    }
}
