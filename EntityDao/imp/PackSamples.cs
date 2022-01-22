using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiFang.DBUtility;
namespace EntityDao.imp
{
   
    public class PackSamples
    {
        private IDBConnection local;
        private int OrderNo = 1;
        public PackSamples() {
            local = DBFactory.CreateDB("SQLite");
            string ord = local.ExecuteScalar("select max(OrderNo) as OrderNo From CovidSample where isInput=9");
            if (!string.IsNullOrEmpty(ord))
                OrderNo = Convert.ToInt32(ord);
        }
        public DataTable GetPackSamplesAndPackage(DataTable srcTable)
        {
            try
            {
                DataView dv = new DataView(srcTable);
                DataTable ds = dv.ToTable(true,new string[]{ "Barcode"});                
                foreach (DataRow item in ds.Rows)
                {
                    OrderNo += 1;
                    local.ExecuteNonQuery(string.Format("update CovidSample set isInput=9,orderNo={1} where BarCode='{0}'", item["Barcode"].ToString(), OrderNo));                  
                }                
                string sql = string.Format("select * from (select orderNo as No,BarCode,count(1) Counts from CovidSample where isInput<>1  Group by BarCode) a order by a.No desc");
                DataTable dt = local.ExecuteDataSet(sql).Tables[0];              
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public DataTable GetPackSampleCount() {
            string sql = string.Format("select * from (select orderNo as No,BarCode,count(1) Counts from CovidSample where isInput<>1  Group by BarCode) a order by a.No desc");
            DataTable dt = local.ExecuteDataSet(sql).Tables[0];
            return dt;
        }

    }
}
