using DevExpress.XtraGrid.Columns;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using ZhiFang.DBUtility;

namespace EntityDao.imp
{
    public class Covid
    {
        /// <summary>
        /// Entity.Patient : 用户信息实体类
        /// </summary>
        /// <param name="patient">采集者基本信息</param>
        /// <param name="isSerch">插入后是否返回查询</param>
        /// <param name="dt">返回查询表</param>
        /// <returns>int 类型：1.插入成功，-1.插入失败,2.已经存在</returns>
        public static int WriteData(Entity.Patient patient, Boolean isSerch = false, DataTable dt = null) {
            try
            {
                
                using (IDBConnection local = DBFactory.CreateDB("SQLite")) {
                    StringBuilder field = new StringBuilder();
                    StringBuilder values = new StringBuilder();
                    DataTable id = local.ExecuteDataSet(string.Format("select * from CovidSample where perCertNo='{0}' and isInput<10 and isInput<>0", patient.UserCardNo)).Tables[0];
                    int count;
                    if (id == null || id.Rows.Count <= 0)
                        count = 0;
                    else
                        return 2;
                    if (count==0)
                    {
                        field.Append("insert into CovidSample(");
                        field.AppendFormat("typeName,");
                        values.AppendFormat("'{0}',", patient.UserCollectType);
                        field.AppendFormat("perName,");
                        values.AppendFormat("'{0}',", patient.UserName);
                        field.AppendFormat("Barcode,");
                        values.AppendFormat("'{0}',", patient.UserBarcode);
                        field.AppendFormat("age,");
                        values.AppendFormat("'{0}',", patient.UserAge);
                        field.AppendFormat("sex,");
                        values.AppendFormat("'{0}',", patient.UserSex);
                        field.AppendFormat("perCertTYpec,");
                        values.AppendFormat("'{0}',", patient.UserCardType);
                        field.AppendFormat("perCertNo,");
                        values.AppendFormat("'{0}',", patient.UserCardNo);
                        field.AppendFormat("perDel,");
                        values.AppendFormat("'{0}',", patient.UserPhone);
                        field.AppendFormat("sampTime,");
                        values.AppendFormat("'{0}',", patient.UserCollectTime);
                        field.AppendFormat("Colleter,");
                        values.AppendFormat("'{0}',", GetLoginUser());//patient.UserCollecter
                        field.AppendFormat("county,");
                        values.AppendFormat("'{0}',", patient.UserArea);
                        field.AppendFormat("Classification,");
                        values.AppendFormat("'{0}',", patient.UserJob);
                        field.AppendFormat("Subcategory,");
                        values.AppendFormat("'{0}',", patient.UserSubJob);
                        field.AppendFormat("principal,");
                        values.AppendFormat("'{0}',", patient.UserSendUnit);
                        field.AppendFormat("SampleName,");
                        values.AppendFormat("'{0}',", patient.UserSampleType);
                        field.AppendFormat("Unit,");
                        values.AppendFormat("'{0}',", patient.UserUnit);
                        field.AppendFormat("cost,");
                        values.AppendFormat("'{0}',", patient.Cost);
                        field.AppendFormat("note, ");
                        values.AppendFormat("'{0}',", patient.UserNote);
                        field.AppendFormat("CyAddress,");
                        values.AppendFormat("'{0}',", GetloginAddress());
                        field.AppendFormat("Email,");
                        values.AppendFormat("'{0}',", patient.Email);
                        field.AppendFormat("CreateTime,");
                        values.AppendFormat("'{0}',", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        field.AppendFormat("isCool,");
                        values.AppendFormat("'{0}',", patient.IsCool);
                        field.AppendFormat("isInput");
                        values.AppendFormat("{0}", 1);
                        String sql = field.ToString() + ") values (" + values.ToString() + ")";
                        local.ExecuteNonQuery(sql);
                        if (isSerch) {
                            dt = local.ExecuteDataSet("select * from CovidSample where isinput=1").Tables[0];
                        }
                        return 1;
                    }
                    else
                        return 2;

                }
            }
            catch (Exception e) {
                ZhiFang.Common.Log.Log.Error("WriteData:" + e.Message);
                return -1;
            }
        }

        /// <summary>
        /// Entity.Patient : 用户信息实体类
        /// Condition: 更新条件
        /// </summary>
        /// <param name="patient">基本信息</param>
        /// <param name="Condition">不包含where关键字条件</param>
        /// <returns>int 类型：1.更新成功，-1.插入失败，-2不存在</returns>
        public static int UpdateData(Entity.Patient patient, string Condition) {
            try
            {
                using (IDBConnection local = ZhiFang.DBUtility.DBFactory.CreateDB("SQLite"))
                {
                    StringBuilder sb = new StringBuilder();
                    string id = local.ExecuteScalar(string.Format("select id from CovidSample where {0}", Condition));
                    if (String.IsNullOrEmpty(id))
                    {
                        sb.AppendFormat("update CovidSample set ");
                        sb.AppendFormat("typeName='{0}',", patient.UserCollectType);
                        sb.AppendFormat("perName='{0}',", patient.UserName);
                        sb.AppendFormat("Barcode='{0}',", patient.UserBarcode);
                        sb.AppendFormat("age='{0}',", patient.UserAge);
                        sb.AppendFormat("sex='{0}',", patient.UserSex);
                        sb.AppendFormat("perCertTYpec='{0}',", patient.UserCardType);
                        sb.AppendFormat("perCertNo='{0}',", patient.UserCardNo);
                        sb.AppendFormat("sampTime='{0}',", patient.UserCollectTime);
                        sb.AppendFormat("Colleter='{0}',", patient.UserCollecter);
                        sb.AppendFormat("perDel='{0}',", patient.UserPhone);
                        sb.AppendFormat("county='{0}',", patient.UserArea);
                        sb.AppendFormat("Classification='{0}',", patient.UserJob);
                        sb.AppendFormat("Subcategory='{0}',", patient.UserSubJob);
                        sb.AppendFormat("Unit='{0}'", patient.UserUnit);
                        sb.AppendFormat("principal='{0}',", patient.UserSendUnit);
                        sb.AppendFormat("note='{0}',", patient.UserCommand);
                        sb.AppendFormat("CreateTime='{0}',", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sb.AppendFormat("SampleName='{0}'", patient.UserSampleType);
                        string sql = sb.ToString() + " where " + Condition;
                        local.ExecuteNonQuery(sql);
                        ZhiFang.Common.Log.Log.Info("UpdateData:" + sql);
                        return 1;
                    }
                    else
                        return -2;

                }
            }
            catch (Exception e)
            {
                ZhiFang.Common.Log.Log.Error("WriteData:" + e.Message);
                return -1;
            }
        }

        public static int UpdateData(string sql) {
            using (IDBConnection local = DBFactory.CreateDB("SQLite"))
            {
                try
                {
                    local.ExecuteNonQuery(sql);
                    ZhiFang.Common.Log.Log.Info("UpdateData:" + sql);
                    return 1;
                }
                catch (Exception e) {
                    return -2;
                }
            }

        }
        /// <summary>
        /// isinput: 表更新标记 1 新录入，2 已导入服务器
        /// Condition: 更新条件
        /// </summary>
        /// <returns>int 类型：1.更新成功,-1更新失败</returns>
        public static int SetFlag(int isinput, string Condition)
        {
            using (ZhiFang.DBUtility.IDBConnection local = DBFactory.CreateDB("SQLite"))
            {
                try
                {
                    String sql = String.Format("update CovidSample set isInput={0} where {1}", isinput, Condition);
                    local.ExecuteNonQuery(sql);
                    return 1;
                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error("UpdateData:" + e.Message);
                    return -1;
                }
            }
        }

        public static int SetFlagByMaster(int isinput, string Condition)
        {
            using (IDBConnection local = DBFactory.CreateDB("LISDB"))
            {
                try
                {
                    String sql = String.Format("update CovidSample set isReport={0} where {1}", isinput, Condition);
                    local.ExecuteNonQuery(sql);
                    return 1;
                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error("UpdateData:" + e.Message);
                    return -1;
                }
            }
        }

        public static DataTable GetDataBySQL(string sql) {
            using (IDBConnection local = DBFactory.CreateDB("SQLite"))
            {
                try
                {
                    DataTable dt = null;
                    dt = local.ExecuteDataSet(sql).Tables[0];
                    return dt;
                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error("GetDataBySQL:" + e.Message);
                    return null;
                }
            }
        }


        public static DataTable GetData(string Condition) {
            using (IDBConnection local = DBFactory.CreateDB("SQLite"))
            {
                try
                {
                    DataTable dt = null;
                    String sql = String.Format("select * from  CovidSample where {0}", Condition);
                    dt = local.ExecuteDataSet(sql).Tables[0];
                    return dt;
                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error("GetData:" + e.Message);
                    return null;
                }
            }
        }


        public static bool isEmptyByMaster(string Condition) {
            using (IDBConnection local = DBFactory.CreateDB("LISDB"))
            {
                try
                {
                    String sql = String.Format("select count(1) as counts from  CovidSample where {0}", Condition);
                    string counts = local.ExecuteScalar(sql);

                    return string.IsNullOrEmpty(counts)?true:counts.Trim().Equals("0")?true:false;
                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error("isEmpty:" + e.Message);
                    return false;
                }
            }
        }

        public static DataRow GetInfoByMaster(string Condition) {
            using (IDBConnection local = DBFactory.CreateDB("LISDB"))
            {
                try
                {
                    String sql = String.Format("select * from  CovidSample where {0}", Condition);
                    DataTable dt = local.ExecuteDataSet(sql).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                        return dt.Rows[0];
                    else
                        return null;
                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error(":" + e.Message);
                    return null;
                }
            }
        }

        public static DataTable GetDataByMaster(string Condition,string sqlstr="") {
            using (IDBConnection local = DBFactory.CreateDB("LISDB"))
            {
                try
                {
                    String sql;
                    if (sqlstr.Equals(""))
                        sql = String.Format("select * from  CovidSample where {0}", Condition);
                    else
                        sql = sqlstr;
                    DataTable dt = local.ExecuteDataSet(sql).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                        return dt;
                    else
                        return null;
                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error(":" + e.Message);
                    return null;
                }
            }
        }
        public static bool DeleteByID(string id) {
            using (IDBConnection local = ZhiFang.DBUtility.DBFactory.CreateDB("SQLite"))
            {
                try
                {
                    String sql = String.Format("delete From CovidSample where ID={0}", id);
                    int counts = local.ExecuteNonQuery(sql);
                    return counts > 0 ? true : false;
                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error("isEmpty:" + e.Message);
                    return false;
                }
            }
        }

        public static bool DeleteByConditon(string Conditon)
        {
            using (ZhiFang.DBUtility.IDBConnection local = ZhiFang.DBUtility.DBFactory.CreateDB("SQLite"))
            {
                try
                {
                    String sql = String.Format("delete From CovidSample where {0}", Conditon);
                    int counts = local.ExecuteNonQuery(sql);
                    return counts > 0 ? true : false;
                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error("isEmpty:" + e.Message);
                    return false;
                }
            }
        }


        public static DataTable ConvertTableToTable(DataTable srcTable, GridColumnCollection condition)
        {
            DataTable dt = new DataTable();
            foreach (GridColumn gridColumn in condition)
                dt.Columns.Add(gridColumn.Name);

            foreach (DataRow dr in srcTable.Rows)
            {
                DataRow newRow = dt.NewRow();
                foreach (GridColumn gridColumn in condition)
                {
                    newRow[gridColumn.Name] = dr[gridColumn.FieldName].ToString();
                }
                dt.Rows.Add(newRow);
            }
            return dt;
        }

        public static bool WriteToMasterTable(DataTable dt, out int inputCount, string TableName = "CovidSample")
        {
            inputCount = 0;
            if (dt == null)
                return false;

            //foreach (DataRow item in dt.Rows)
            //{
            //    foreach (DataColumn dc in dt.Columns) {
            //        item.BeginEdit();
            //        string value = string.IsNullOrEmpty(item[dc.ColumnName].ToString()) ? "" : item[dc.ColumnName].ToString().Trim();
            //        item[dc.ColumnName] = value;
            //        item.EndEdit();
            //        dt.AcceptChanges();
            //    }
            //}

            if (dt.Columns.Contains("Id")) { dt.Columns.Remove("Id"); }
            if (dt.Columns.Contains("isSend")) { dt.Columns.Remove("isSend"); }
            if (dt.Columns.Contains("isInput")) { dt.Columns.Remove("isInput"); }
            if (dt.Columns.Contains("orderNo")) { dt.Columns.Remove("orderNo"); }
            //if (dt.Columns.Contains("Email")) { dt.Columns.Remove("Email"); }
            if (dt.Columns.Contains("Cool")) { dt.Columns.Remove("Cool"); }
            using (SqlConnection con = new SqlConnection(DbHelperSQL.connectionString))
            {
                using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(DbHelperSQL.connectionString, SqlBulkCopyOptions.UseInternalTransaction))
                {
                    try
                    {
                        sqlbulkcopy.DestinationTableName = TableName;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (dt.Columns[i].ColumnName.Equals("perCertTYpec"))
                                sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, "perCertTypec");
                            else
                                sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                        }
                        sqlbulkcopy.WriteToServer(dt);
                        inputCount = dt.Rows.Count;
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return true;
        }


        public static string GetLoginUser() {
            using (IDBConnection local = DBFactory.CreateDB("SQLite"))
            {
                try
                {
                    String sql = String.Format("select value From SysParam where ParamNo=999");
                    return local.ExecuteScalar(sql);

                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error("isEmpty:" + e.Message);
                    return "";
                }
            }
        }
        
        public static string GetloginAddress() {

            using (IDBConnection local = DBFactory.CreateDB("SQLite"))
            {
                try
                {
                    String sql = String.Format("select value From SysParam where ParamNo=998");
                    return local.ExecuteScalar(sql);

                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error("isEmpty:" + e.Message);
                    return "";
                }
            }

        }

        public static bool WriteLogUser(string user)
    {
            using (IDBConnection local = DBFactory.CreateDB("SQLite"))
            {
                try
                {
                    String sql = String.Format("update SysParam set value='{0}' where ParamNo=999",user);
                    return local.ExecuteNonQuery(sql)>1?true:false;

                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error("isEmpty:" + e.Message);
                    return false;
                }
            }

    }

        public static bool WriteLogAddress(string address)
    {
            using (IDBConnection local = DBFactory.CreateDB("SQLite"))
            {
                try
                {
                    String sql = String.Format("update SysParam set value='{0}' where ParamNo=998", address);
                    return local.ExecuteNonQuery(sql) > 1 ? true : false;

                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error("isEmpty:" + e.Message);
                    return false;
                }
            }

        }


        public static bool WriteSQLListToMaster(ArrayList sqllIST)
        {
            using (IDBConnection local = DBFactory.CreateDB("LISDB"))
            {
                try
                {
                    local.BatchUpdateWithTransaction(sqllIST);
                    return true;

                }
                catch (Exception e)
                {
                    ZhiFang.Common.Log.Log.Error("WriteSQLListToMaster:" + e.Message);
                    return false;
                }
            }
        }


        public static bool UpdateCellValue(string sql) {
            using (IDBConnection local = DBFactory.CreateDB("LISDB"))
            {
                try
                {
                   return  local.ExecuteNonQuery(sql) > 0 ? true : false;
                }
                catch (Exception e)
                {                    
                    return false;
                }
            }
        }

        public static bool IsEmptyByTableFieldName(string tableName, string FieldName, bool isAdd = true,string ColumnTypeName="text") {
            //select name from sqlite_master where name = 'CovidSample' and sql like '%isCool%';
            using (IDBConnection local = DBFactory.CreateDB("SQLite")) {
                string sql = string.Format("select name from sqlite_master where name = '{0}' and sql like '%{1}%'",tableName,FieldName);
                try
                {
                    string rs = local.ExecuteScalar(sql);
                    if (string.IsNullOrEmpty(rs))
                    {
                        if (isAdd)
                        {
                            sql = string.Format("ALTER  TABLE {0} ADD COLUMN {1} {2}",tableName, FieldName, ColumnTypeName);
                            local.ExecuteNonQuery(sql);
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception e) {
                    return false;
                }
            }
        }

    }
}
