using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AppClient.Utiles
{
    public class UploadUtiles
    {
        public static bool SendDatRow(DataRow item, out string message)
        {
            string url = "http://10.1.1.221:8000/id";//Utiles.Readcfg.ReadIniConfig("server");          
            string id = item["id"].ToString();
            string paramstr = string.Format("id=" + id + "&user=cctv");
            string rs = "";
            try
            {
                rs = UploadUtiles.Post(url, paramstr);
            }
            catch (Exception E)
            {
                message = "调用服务错误:" + E.Message;
                MessageBox.Show("调用服务错误:" + E.Message);
                return false;
            }
            if (rs.Equals(""))
            {
                message = "调用服务地址错误";
                MessageBox.Show("调用服务地址错误，请正确配置地址");
                return false;
            }
            JObject jo = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(rs);

            //if (jo["code"].ToString() != "0")
            //    item["SendMessage"] = jo["message"].ToString();
            //else
            item["SendMessage"] = jo["message"].ToString();
            if (jo["code"].ToString() != "0")
            {
                message = jo["message"].ToString();
                return false;
            }
            else
            {
                message = "上报成功";
                return true;
            }

        }

        public static string Post(string url, string paramData)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            int i = 0;
            byte[] data = Encoding.UTF8.GetBytes(paramData);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw e;

            }
            return result;

        }
    }
}
