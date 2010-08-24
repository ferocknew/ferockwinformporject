using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemFunction
{
    class FileObj
    {
        ///<summary>
        ///模块编号：文件下载绑定进度条函数
        ///作用：用于通过进度条显示文件下载百分比
        ///作者：兼哲
        ///编写日期：2010-08-22
        ///</summary>
        ///<param   name="URL">下载文件URL</param>
        ///<returns>说明</returns>
        public static void DownFile(string URL, string Filename, ProgressBar Prog)
        {
            System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL); System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse(); long totalBytes = myrp.ContentLength; Prog.Maximum = (int)totalBytes; System.IO.Stream st = myrp.GetResponseStream(); System.IO.Stream so = new System.IO.FileStream(Filename, System.IO.FileMode.Create); long totalDownloadedByte = 0; byte[] by = new byte[1024]; int osize = st.Read(by, 0, (int)by.Length); while (osize > 0) { totalDownloadedByte = osize + totalDownloadedByte; Application.DoEvents(); so.Write(by, 0, osize); Prog.Value = (int)totalDownloadedByte; osize = st.Read(by, 0, (int)by.Length); } so.Close(); st.Close();
        }
    }
}
