using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Data.OleDb;

namespace PcMonitor
{
    partial class PcMonitor : ServiceBase
    {
        public PcMonitor()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。
            //托管代码的实体类
            MyTimer();
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
        }
        //托管定时器
        private void MyTimer() {
            int _Sleep = 60000;//60秒记录一次
            System.Timers.Timer _MT = new System.Timers.Timer(_Sleep);
            _MT.Elapsed += new System.Timers.ElapsedEventHandler(MTimedEvent);
            //MT.AutoReset   =false;
            //MT.Start();
            _MT.Enabled = true;        
        }
        //构造System.Timers.Timer实例   间隔时间事件
        private void MTimedEvent(object source, System.Timers.ElapsedEventArgs e) {
            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            strConnection += @"Data Source=|DataDirectory|Data\Data.mdb";
            OleDbConnection conn = new OleDbConnection(strConnection);
            conn.Open();

            //String _sql = "insert into [Test] ([Title]) VALUES ('" + DateTime.Now.ToString() + "')";
            //OleDbCommand cmd = new OleDbCommand(_sql, conn);
            //cmd.ExecuteNonQuery();

            conn.Dispose();
            GC.Collect();
        }
    }
}
