using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EntityDao.imp
{
    public class ImportTable
    {
        private static ZhiFang.DBUtility.IDBConnection local = ZhiFang.DBUtility.DBFactory.CreateDB("SQLite");
        private static string path = Application.StartupPath + "\\TempXML\\";
        public static bool WriteToDisk(DataTable dt)
        {          
            try
            {               
                if (Directory.Exists(path)==false)
                  Directory.CreateDirectory(path);
                path = path + "Temp.xml";
                if (File.Exists(path))
                    File.Delete(path);
                dt.TableName = "import";
                dt.WriteXml(path,XmlWriteMode.WriteSchema);
                return true;
            }
            catch (Exception e)
            {
                ZhiFang.Common.Log.Log.Error("ImportTable::WriteToTable:" + e.Message);
                return false;
            }
        }

        public static DataTable ReadDataFormDisk(out string info)
        {
            string xml = path + "Temp.xml";
            if (File.Exists(xml))
            {
                info="";
                DataTable dt = new DataTable("Import");
                dt.ReadXml(xml);
                return dt;
            }
            info = "缓存文件不存在！";
            return null;
        }

        public static bool isNotEmpty() {
            string filePath = path + "Temp.xml";
            return File.Exists(filePath) ?true:false;
        }


       
    }
}
