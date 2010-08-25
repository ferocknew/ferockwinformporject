using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using SystemFunction;
using System.Data.SqlServerCe;

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

            //SQLite
            SQLiteConnection conn = new SQLiteConnection();
            String datasource = @"Data Source=new_sqlite.db3";
            conn.ConnectionString = datasource;
            conn.Open();

            String _sql = "select name from [admin] where (id=1)";
            SQLiteCommand cmd = new SQLiteCommand(_sql, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();

            if (dr.Read()) {
                //MessageBox.Show(dr.GetValue(0).ToString());
            }

            //SQLcompact
            SqlCeConnection connSQLcompact = new SqlCeConnection();
            connSQLcompact.ConnectionString = @"Data Source=sql_compact.db.sdf;Persist Security Info=False;Password=ferock;";
            connSQLcompact.Open();
            _sql = "select * from [NewTest]";
            DataSet ds = new DataSet();
            SqlCeDataAdapter da = new SqlCeDataAdapter(_sql, connSQLcompact);
            da.Fill(ds);
            //MessageBox.Show(ds.Tables[0].Rows.Count.ToString());

            DataRow myRow;
            myRow = ds.Tables[0].Rows[0];
            MessageBox.Show(myRow["UserName"].ToString());



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

    }
}
