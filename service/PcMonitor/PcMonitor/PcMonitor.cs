using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Data.OleDb;
using System.Collections;

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
            Hashtable _HTNetworkMonitor = new Hashtable();
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
        }
        //托管定时器
        private void MyTimer() {
            int _Sleep = 30000;//60秒记录一次
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

            Dictionary<string, string> _Dic = new Dictionary<string, string>();

            //实例化网络监视类
            Common.Network.NetworkMonitor monitor = new Common.Network.NetworkMonitor();
            for (int i = 0; i < monitor.Adapters.Length;i++ ) {
                _Dic.Add(monitor.Adapters[i].Name, monitor.Adapters[i].Name);
            }



            foreach (KeyValuePair<string, string> item in _Dic)
            {
                OleDbCommand _cmd = new OleDbCommand("Select count(ID) From [Network] Where NetworkDevice='" + item.Value + "'", conn);
                int _count = Convert.ToInt32(_cmd.ExecuteScalar());
                if(_count==0){
                    String _sql = "insert into [Network] ([NetworkDevice]) VALUES ('" + item.Value + "')";
                    OleDbCommand cmd = new OleDbCommand(_sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }

            conn.Dispose();
            GC.Collect();
        }
    }
}
