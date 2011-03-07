using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace PcMonitor.Common.Service
{
    public class Http
    {
        int ProxyPort;
        /// <summary>
        /// 代理服务器入口类构造函数
        /// </summary>
        /// <param name="Port">Http Proxy监听的端口</param>
        public Http(int Port)
        {
            ProxyPort = Port;
        }

        /// <summary>
        /// 启动Http代理服务器
        /// </summary>
        public void Start()
        {
            HttpListener _listerner = new HttpListener();
            _listerner.AuthenticationSchemes = AuthenticationSchemes.Anonymous;//指定身份验证  Anonymous匿名访问
            _listerner.Prefixes.Add("http://localhost:" + ProxyPort + "/");
            _listerner.Prefixes.Add("http://127.0.0.1:" + ProxyPort + "/");
            _listerner.Start();
            Console.WriteLine("Listening...");

            while (true)
            {
                //等待请求连接
                //没有请求则GetContext处于阻塞状态
                HttpListenerContext _ctx = _listerner.GetContext();         
                //HttpListenerRequest _request = _ctx.Request;
                HttpListenerResponse _response = _ctx.Response;
                _response.StatusCode = 200;//设置返回给客服端http状态代码
                _response.ContentType = "text/javascript";

                string _name = _ctx.Request.QueryString["callback"];
                //string _name = "<?xml version=\"1.0\" encoding=\"utf-8\"?><root>78787878</root>";
                string _jsonp = _name + "({\"show\":\"" + _name + "\"})";
                byte[] _buffer = System.Text.Encoding.UTF8.GetBytes(_jsonp);
                
                _response.ContentLength64 = _buffer.Length;
                System.IO.Stream _output = _response.OutputStream;
                _output.Write(_buffer, 0, _buffer.Length);
                _output.Close();
                _ctx.Response.Close();

            }
        }
    }
}
