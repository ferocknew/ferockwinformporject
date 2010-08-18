using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

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
        }

        private void PingButton_Click(object sender, EventArgs e)
        {
            if (PingUrlText.Text == "")
            {
                MessageBox.Show("请输入尝试地址！");
                this.ActiveControl = this.PingUrlText;
            }
            else {
                //ShowBackLab.Text = PingUrlText.Text;
                PingReply reply = new Ping().Send("222.32.2.2");
                if (reply.Status == IPStatus.Success)
                {
                    ShowBackLab.Text = "Ping successfully.";
                }
                else {
                    ShowBackLab.Text = "Ping failure.";
                }
            }
        }

    }
}
