using System;
using System.Collections;
using System.Data;
using System.Text;

namespace EntityDao.imp
{

    public class CovidSampleStore
    {
        private static ZhiFang.DBUtility.IDBConnection local=ZhiFang.DBUtility.DBFactory.CreateDB("SQLite");
        private static ZhiFang.DBUtility.IDBConnection lis = ZhiFang.DBUtility.DBFactory.CreateDB("LISDB");

        public static DataTable SerchDataByLis(string Condition) {
            try {
                return lis.ExecuteDataSet(string.Format("select * from CovidSampleStore where {0}",Condition)).Tables[0];
            } catch (Exception e) {
                throw new Exception("无法访问服务器！请认网络是否联机");
            }
        }


        public static bool WriteToTable(DataTable dt) {
            ArrayList sqllist = new ArrayList();
            StringBuilder sb = new StringBuilder();
            if (dt == null || dt.Rows.Count <= 0)
                return false;
           
            foreach (DataRow item in dt.Rows)
            {             
                sb.Clear();
                sb.AppendFormat("insert into CovidSampleStore(perName,perCertNo,perDel,Classification,Subcategory,principal,Unit,OldCollectTime) values(");
                sb.AppendFormat("'{0}',", string.IsNullOrEmpty(item["perName"].ToString())? "" : item["perName"].ToString().Trim().Replace("'","~"));
                sb.AppendFormat("'{0}',", string.IsNullOrEmpty(item["perCertNo"].ToString()) ? "" : item["perCertNo"].ToString().Trim().Replace("'","").ToUpper());
                sb.AppendFormat("'{0}',", string.IsNullOrEmpty(item["perDel"].ToString()) ? "" : item["perDel"].ToString().Trim().Replace("'","~"));
                sb.AppendFormat("'{0}',", string.IsNullOrEmpty(item["Classification"].ToString()) ? "" : item["Classification"].ToString());
                sb.AppendFormat("'{0}',", string.IsNullOrEmpty(item["Subcategory"].ToString()) ? "" : item["Subcategory"].ToString());
                sb.AppendFormat("'{0}',", string.IsNullOrEmpty(item["principal"].ToString())?"": item["principal"].ToString().Trim().Replace("'","~"));
                sb.AppendFormat("'{0}',", string.IsNullOrEmpty(item["Unit"].ToString()) ? "" : item["Unit"].ToString().Trim().Replace("'","~"));
                sb.AppendFormat("'{0}',", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

               sqllist.Add(sb.ToString()+")");
            }
            try
            {
                lis.BatchUpdateWithTransaction(sqllist);
                return true;
            }
            catch (Exception e) {
                ZhiFang.Common.Log.Log.Error("::WriteToTable:" + e.Message);
                return false;
            }
        }


        public static bool UploadByLis(DataTable dt) {
            foreach (DataRow item in dt.Rows)
            {
                try
                {
                    string where = string.Format("  perCertNo='{0}'", item["perCertNo"].ToString());
                    if (lis.ExecCount("CovidSampleStore", where) > 0)
                        lis.ExecuteNonQuery(string.Format("Update CovidSampleStore set Classification='{0}',Subcategory='{1}',principal='{2}',Unit='{3}',OldCollectTime= GetDate() where perCertNo='{4}'",
                            item["Classification"].ToString(), item["Subcategory"].ToString(), item["principal"].ToString(), item["Unit"].ToString(), item["OldCollectTime"].ToString()));
                    else
                        lis.ExecuteNonQuery(string.Format("insert into CovidSampleStore(perCertNo,perName,perDel,Classification,Subcategory,principal,Unit,OldCollectTime) values(" +
                            "'{0}','{1}','{2}','{3}','{4}','{5}','{6}',GetDate()" +
                            ")",
                           item["perCertNo"].ToString(), item["perName"].ToString(), item["perDel"].ToString(), item["Classification"].ToString(), item["Subcategory"].ToString(),
                             item["principal"].ToString(), item["Unit"].ToString()));
                }
                catch (Exception e) {
                    ZhiFang.Common.Log.Log.Error("更新基础内容错误："+e.Message);
                }
            }
            return true;
        }
        public static bool ClearTable() {
            try
            {
                local.ExecuteNonQuery("delete From CovidSampleStore");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static DataTable GetDataByMasterDB(String Condition=null) {
            try
            {
                if(Condition==null)
                    return lis.ExecuteDataSet("select * from CovidSampleStore").Tables[0];
                else
                    return lis.ExecuteDataSet(string.Format("select * from CovidSampleStore where {0}", Condition)).Tables[0];
            }
            catch (Exception e)
            {
                throw new Exception("读取对照数据列表发生错误：",e);
            }
        }

        public static DataTable GetMasterJobs()
        {
            try
            {
                return lis.ExecuteDataSet("select * from jobs").Tables[0];
            }
            catch (Exception e)
            {
                throw new Exception("读取对照数据列表发生错误：", e);
            }
        }

        public static bool WriteToJob(DataTable dt) {
            ArrayList sqllist = new ArrayList();
            StringBuilder sb = new StringBuilder();
            
            if (dt == null || dt.Rows.Count <= 0)
                return false;
            local.ExecuteNonQuery("delete From Jobs");
            foreach (DataRow item in dt.Rows)
            {
                sb.Clear();
                sb.AppendFormat("insert into Jobs(JobName,SubJobName) values(");
                sb.AppendFormat("'{0}',", string.IsNullOrEmpty(item["JobName"].ToString()) ? "" : item["JobName"].ToString().Trim().Replace("'", "~"));
                sb.AppendFormat("'{0}'", string.IsNullOrEmpty(item["SubJobName"].ToString()) ? "" : item["SubJobName"].ToString().Trim().Replace("'", "").ToUpper());
                sqllist.Add(sb.ToString() + ")");
            }
            try
            {
                local.BatchUpdateWithTransaction(sqllist);
                return true;
            }
            catch (Exception e)
            {
                ZhiFang.Common.Log.Log.Error("CovidSampleStore::WriteToTable:" + e.Message);
                return false;
            }
        }

        public static DataTable GetJobs() {
            try
            {
                return local.ExecuteDataSet(string.Format("select * from Jobs")).Tables[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataTable GetSendUnit(string unitname) {
            string sql = string.Format("select distinct principal from CovidSampleStore where principal like '{0}%'",unitname);
            return lis.ExecuteDataSet(sql).Tables[0];
        }

        public static DataTable GetDataOnline(string sql) {
            try
            {
                return lis.ExecuteDataSet(sql).Tables[0];
            }
            catch (Exception e) {
                throw new Exception("查询错误："+e.Message);
            }
        }
    }
}
