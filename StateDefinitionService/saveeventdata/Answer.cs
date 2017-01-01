using System;
using System.Text;
using System.IO;
using System.Net;

namespace StateDefinitionService.saveeventdata
{
    static public class Answer
    {
        public static string POST(string Data)
        {//http://localhost:62736/ws.asmx/Print
            string _url = GetUrl();
            if (_url == "")
                return "";
            string _data = string.Format("text={0}", Data);
            WebRequest req = WebRequest.Create(_url);
            req.Method = "POST";
            req.Timeout = 100000;
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(_data);
            req.ContentLength = sentData.Length;
            Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            WebResponse res = req.GetResponse();
            Stream ReceiveStream = res.GetResponseStream();
            StreamReader sr = new StreamReader(ReceiveStream, Encoding.UTF8);

            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }
            return Out;
        }
        static string GetUrl()
        {
            //var config = Config.Get();
            //return config.Target.url;
            return "";
        }
        public static string Map(string Data)
        {
            string _url = GetMapUrl();
            if (_url == "")
                return "";
            string _data = string.Format("text={0}", Data);
            WebRequest req = WebRequest.Create(_url);
            req.Method = "POST";
            req.Timeout = 100000;
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(_data);
            req.ContentLength = sentData.Length;
            Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            WebResponse res = req.GetResponse();
            Stream ReceiveStream = res.GetResponseStream();
            StreamReader sr = new StreamReader(ReceiveStream, Encoding.UTF8);

            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }
            return Out;
        }
        static string GetMapUrl()
        {
            //var config = Config.Get();
            //return config.Map.url;
            return "";
        }
    }
}