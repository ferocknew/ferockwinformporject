using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using SystemFunction;
using System.Data.SqlServerCe;
using System.IO.MemoryMappedFiles;
using System.Net.Sockets;

namespace test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Show();
            this.PingUrlText.Focus();
            String _sql;

            /*
            //SQLite
            SQLiteConnection conn = new SQLiteConnection();
            String datasource = @"Data Source=appData\new_sqlite.db3";
            conn.ConnectionString = datasource;
            conn.Open();

            _sql = "select name from [admin] where (id=1)";
            SQLiteCommand cmd = new SQLiteCommand(_sql, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();

            if (dr.Read()) {
                //MessageBox.Show(dr.GetValue(0).ToString());
            }*/

            //SQLcompact
            SqlCeConnection connSQLcompact = new SqlCeConnection();
            connSQLcompact.ConnectionString = @"Data Source=appData\sql_compact.db.sdf;Persist Security Info=False;Password=ferock;";
            connSQLcompact.Open();
            _sql = "select * from [NewTest]";
            DataSet ds = new DataSet();
            SqlCeDataAdapter da = new SqlCeDataAdapter(_sql, connSQLcompact);
            da.Fill(ds);
            //MessageBox.Show(ds.Tables[0].Rows.Count.ToString());

            DataRow myRow;
            myRow = ds.Tables[0].Rows[0];
            MessageBox.Show(myRow["UserName"].ToString());

            //MessageBox.Show(ReadLocalVerifyResult());

            MessageBox.Show(_sql_compact_dbDataSet.DataSetName.ToString());
        }
        private void PingButton_Click(object sender, EventArgs e)
        {
            if (PingUrlText.Text == "")
            {
                MessageBox.Show("请输入尝试地址！");
                this.ActiveControl = this.PingUrlText;
            }
            else
            {
                //ShowBackLab.Text = PingUrlText.Text;
                PingReply reply = new Ping().Send(PingUrlText.Text.Trim());
                if (reply.Status == IPStatus.Success)
                {
                    MessageBox.Show("Ping successfully.");
                }
                else
                {
                    MessageBox.Show("Ping failure.");
                }
                //System.Net.WebClient myWebClient = new System.Net.WebClient();
                //myWebClient.DownloadFileAsync(new Uri("http://dbo.365pub.com/rc/jobs/jobs.rar"), "job.rar");
                //if (myWebClient.IsBusy)
                //{
                //    DownloadBar.Value = 10;
                //}
                //else
                //{
                //    ShowBackLab.Text = "完成";
                //}
                //FileObj.DownFile("http://dbo.365pub.com/rc/jobs/jobs.rar", "job.rar", DownloadBar);
            }
        }

        //读取够娱乐信息类
        static string ReadLocalVerifyResult()
        {
            try
            {
                using (MemoryMappedFile memfile = MemoryMappedFile.OpenExisting(@"Global\GogoVerifyClient_VerifyResult",
                    MemoryMappedFileRights.Read))
                {
                    if (memfile != null)
                    {
                        using (var accessor = memfile.CreateViewAccessor(0, 128, MemoryMappedFileAccess.Read))
                        {
                            if (accessor != null)
                            {
                                byte[] readbuf = new byte[128];
                                if (0 != accessor.ReadArray<byte>(0, readbuf, 0, 128))
                                {
                                    var encode = Encoding.GetEncoding("gb2312");
                                    return encode.GetString(readbuf).TrimEnd(new char[] { '\0', '\n', '\r' });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e) { 
            
            }

            using (TcpClient tcpclient = new TcpClient())
            {
                tcpclient.Connect("127.0.0.1", 13344);
                using (var stream = tcpclient.GetStream())
                {
                    if (stream != null && stream.CanRead)
                    {
                        byte[] readbuf = new byte[128];
                        if (0 != stream.Read(readbuf, 0, 128))
                        {
                            var encode = Encoding.GetEncoding("gb2312");
                            return encode.GetString(readbuf).TrimEnd(new char[] { '\0', '\n', '\r' });
                        }
                    }
                }
            }
            return string.Empty;
        }

    private void Form1_Deactivate(object sender, EventArgs e)  
    {  
     
       if (this.WindowState == FormWindowState.Minimized)  
      {  
            this.ShowInTaskbar = false;  
            this.Hide();  
        }  
    } 
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;  //显示在系统任务栏
                this.WindowState = FormWindowState.Normal;  //还原窗体
                notifyIcon.Visible = true;  //托盘图标隐藏
            }
        }
    }
}
