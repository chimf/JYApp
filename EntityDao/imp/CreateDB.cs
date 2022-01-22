using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ZhiFang.DBUtility;

namespace EntityDao.imp
{
    public class CreateDB
    {
        private static string CovidSample = "CREATE TABLE [CovidSample] ( [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL " +
                                            ", [typeName] text NOT NULL, [perName] text NOT NULL, [Barcode] text NOT NULL, [age] bigint NULL" +
                                            ", [sex] text NULL, [perCertTYpec] text NOT NULL, [perCertNo] text NOT NULL, [sampTime] text NOT NULL" +
                                            ", [Colleter] text NULL, [perDel] text NULL, [county] text NULL, [Classification] text NULL" +
                                            ", [Subcategory] text NULL, [principal] text NULL, [note] text NULL, [CreateTime] text NOT NULL, [SampleName] text NULL, [Email] text NULL, [unit] text NULL, [isSend] bigint DEFAULT (0) NULL, [isInput] bigint DEFAULT (0) NULL" +
                                            ", [orderNo] bigint NULL, [CyAddress] text NULL, [cost] text NULL)";

        private static string Jobs = "CREATE TABLE [Jobs] ( [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [JobName] text NOT NULL, [SubJobName] text NOT NULL)";
        private static string SysParam = "CREATE TABLE[SysParam] ( " +
                                            " [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL" +
                                            ", [ParamNo] bigint NOT NULL" +
                                            ", [value] text NULL" +
                                            ", [Desc] text NOT NULL)";

        public static void CreateTable() {
            using (IDBConnection local = DBFactory.CreateDB("SQLite")) {

                if (isEmptyTable("CovidSample"))
                    local.ExecuteNonQuery(CovidSample);
                if (isEmptyTable("Jobs"))
                {
                    local.ExecuteNonQuery(Jobs);
                    DataTable jobtable;
                    try
                    {
                        jobtable = CovidSampleStore.GetMasterJobs();
                        CovidSampleStore.WriteToJob(jobtable);

                    }
                    catch (Exception xe)
                    {
                       
                    }

                }
                if (isEmptyTable("SysParam"))
                {
                    local.ExecuteNonQuery(SysParam);
                    local.ExecuteNonQuery(string.Format("insert into SysParam(ParamNo,value,Desc) values(999,'','desc')"));
                    local.ExecuteNonQuery(string.Format("insert into SysParam(ParamNo,value,Desc) values(998,'','desc')"));
                }
            }
        }


        public static bool isNoEmpty(string tableName,string FieldName, bool isAdd = true,string ColumnTypeName = "text") {

            using (IDBConnection local = DBFactory.CreateDB("SQLite"))
            {
                string sql = string.Format("select name from sqlite_master where name = '{0}' and sql like '%{1}%'", tableName, FieldName);
                try
                {
                    string rs = local.ExecuteScalar(sql);
                    if (string.IsNullOrEmpty(rs))
                    {
                        if (isAdd)
                        {
                            sql = string.Format("ALTER  TABLE {0} ADD COLUMN {1} {2}", tableName, FieldName, ColumnTypeName);
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
                catch (Exception e)
                {
                    return false;
                }
            }
        }


        public static bool isEmptyTable(string tableName) {
            string sql = string.Format("select count(*) count from sqlite_master where type = 'table' and name = '{0}'", tableName);
            using (IDBConnection local = DBFactory.CreateDB("SQLite")) {
                string rs = local.ExecuteScalar(sql);
                if (string.IsNullOrEmpty(rs))
                    return true;
                else if (rs.Equals("0"))
                    return true;
                else
                    return false;
            }
        }


    }
}
