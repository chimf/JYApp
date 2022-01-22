using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiFang.DBUtility;

namespace EntityDao.imp
{
    public class UploadTabls
    {
        public DataTable GetPage(string where, int currentPage, int pageSize, out int PageCount, out int RowSize,string tablename = "CovidSample", string ProceName = "GetPageData", string keyFieldName = "id")
        {
            PageCount = 0;
            RowSize = 0;
            SqlParameter TableName = new SqlParameter("@TableName", tablename);
            SqlParameter IDName = new SqlParameter("@IDName", keyFieldName);
            SqlParameter Where = new SqlParameter("@Where", where);
            SqlParameter PageIndex = new SqlParameter("@PageIndex", currentPage);
            SqlParameter PageSize = new SqlParameter("@PageSize", pageSize);
            SqlParameter pageCount = new SqlParameter("@PageCount", SqlDbType.Int);
            SqlParameter RowCount = new SqlParameter("@RowCount", SqlDbType.Int);
            pageCount.Direction = ParameterDirection.Output;
            RowCount.Direction = ParameterDirection.Output;
            SqlParameter[] sqlParameters = new SqlParameter[] { TableName, IDName, Where, PageIndex, PageSize, pageCount, RowCount };
            DataSet ds;
            try
            {
                ds = DbHelperSQL.RunProcedure(ProceName, sqlParameters, tablename);
            }
            catch
            {
                return null;
            }
            if (ds == null)
                return null;
            PageCount = Int32.Parse(pageCount.Value.ToString());
            RowSize = Int32.Parse(RowCount.Value.ToString());
            return ds.Tables[tablename];

        }

        public bool FullCompontenToGridComBox(RepositoryItemComboBox item,string typeName) {
            string sql = "";
            switch (item.Tag.ToString())
            {
                case "cardtype":
                    item.Items.Clear();
                    item.Items.Add("居民身份证");
                    item.Items.Add("监护人身份证");
                    item.Items.Add("港澳居民来往内地通行证");
                    item.Items.Add("台湾居民来往内地通行证");
                    item.Items.Add("中国护照");
                    item.Items.Add("非中国护照");
                    return true;
                case "jobtype":
                    sql = "select id,ClassName from JobClass order by orderNo asc";
                    try
                    {
                      DataTable  ds = DbHelperSQL.Query(sql).Tables[0];
                        if (ds != null || ds.Rows.Count > 0) {
                            item.Items.Clear();
                            foreach (DataRow dr in ds.Rows)
                            {
                                Entity.ControlModelItem citem = new Entity.ControlModelItem(dr["id"].ToString(),dr[""].ToString());
                                item.Items.Add(citem);
                            }
                            return true;                           
                        }
                    }
                    catch
                    {
                        return false;
                    }
                    break;
                case "area":
                    item.Items.Clear();
                    item.Items.Add("思明区");
                    item.Items.Add("湖里区");
                    item.Items.Add("集美区");
                    item.Items.Add("翔安区");
                    item.Items.Add("同安区");
                    item.Items.Add("海沧区");
                    return true;
                default:
                    return false;
            }
            return false;
        }
    }
}
