namespace test1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PingUrlText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PingButton = new System.Windows.Forms.Button();
            this.ShowBackLabel = new System.Windows.Forms.Label();
            this.ShowBackLab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PingUrlText
            // 
            this.PingUrlText.Location = new System.Drawing.Point(78, 12);
            this.PingUrlText.Name = "PingUrlText";
            this.PingUrlText.Size = new System.Drawing.Size(149, 21);
            this.PingUrlText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入地址：";
            // 
            // PingButton
            // 
            this.PingButton.Location = new System.Drawing.Point(233, 11);
            this.PingButton.Name = "PingButton";
            this.PingButton.Size = new System.Drawing.Size(39, 23);
            this.PingButton.TabIndex = 2;
            this.PingButton.Text = "连接";
            this.PingButton.UseVisualStyleBackColor = true;
            this.PingButton.Click += new System.EventHandler(this.PingButton_Click);
            // 
            // ShowBackLabel
            // 
            this.ShowBackLabel.AutoSize = true;
            this.ShowBackLabel.Location = new System.Drawing.Point(13, 43);
            this.ShowBackLabel.Name = "ShowBackLabel";
            this.ShowBackLabel.Size = new System.Drawing.Size(0, 12);
            this.ShowBackLabel.TabIndex = 3;
            // 
            // ShowBackLab
            // 
            this.ShowBackLab.AutoSize = true;
            this.ShowBackLab.Location = new System.Drawing.Point(15, 42);
            this.ShowBackLab.Name = "ShowBackLab";
            this.ShowBackLab.Size = new System.Drawing.Size(0, 12);
            this.ShowBackLab.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ShowBackLab);
            this.Controls.Add(this.ShowBackLabel);
            this.Controls.Add(this.PingButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PingUrlText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PingUrlText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PingButton;
        private System.Windows.Forms.Label ShowBackLabel;
        private System.Windows.Forms.Label ShowBackLab;
    }
}

