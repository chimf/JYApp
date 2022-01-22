
using System.Data;
using ZhiFang.DBUtility;

namespace LIS.Model
{
  public class RequestForm : IModel
  {
    public static DataSet GetRequestFormData(string querycolumns, string WhereClause)
    {
      using (IDBConnection lisDb = DataConn.CreateLisDB())
      {
        if (querycolumns == null || querycolumns == "")
          querycolumns = " * ";
        if (WhereClause == null || WhereClause == "")
          WhereClause = " 2>1 ";
        string strSql = string.Format("select {0} from RequestForm where {1}", (object) querycolumns, (object) WhereClause);
        ZhiFang.Common.Log.Log.Info(string.Format("执行查询语句：{0}", (object) strSql));
        return lisDb.ExecuteDataSet(strSql);
      }
    }

    public static DataSet GetRequestFormData(string receivedate, string testtypeno, string sectionno, string serialno, int sicktypeno)
    {
      string WhereClause = "  2>1 ";
      if (receivedate != "")
        WhereClause = WhereClause + " and receivedate ='" + receivedate + "'";
      if (testtypeno != "")
        WhereClause = WhereClause + " and testtypeno =" + testtypeno;
      if (sectionno != "")
        WhereClause = WhereClause + " and sectionno =" + sectionno;
      if (serialno != "")
        WhereClause = WhereClause + " and serialno ='" + serialno + "'";
      if (sicktypeno != -1)
        WhereClause = WhereClause + " and sicktypeno =" + (object) sicktypeno;
      return RequestForm.GetRequestFormData((string) null, WhereClause);
    }

    public static DataSet GetRequestFormData(string receivedate, string sectionno, string testtypeno, string sampleno)
    {
      string WhereClause = "  2>1 ";
      if (receivedate != "")
        WhereClause = WhereClause + " and receivedate ='" + receivedate + "'";
      if (testtypeno != "")
        WhereClause = WhereClause + " and testtypeno =" + testtypeno;
      if (sectionno != "")
        WhereClause = WhereClause + " and sectionno =" + sectionno;
      if (sampleno != "")
        WhereClause = WhereClause + " and sampleno ='" + sampleno + "'";
      return RequestForm.GetRequestFormData((string) null, WhereClause);
    }

    public static bool CheckRequestForm(string SectionNo, string TestTypeNo, string ReceiveDate, string SampleNo)
    {
      return IModel.CheckDataSet(RequestForm.GetRequestFormData(ReceiveDate, SectionNo, TestTypeNo, SampleNo));
    }


    public static int UpdateNameColor(string ReceiveDate, string SectionNo, string TestTypeNo, string SampleNo, string CountNodesFormSource)
    {
      if (SectionNo == null || SectionNo == "")
        return 1;
      int num = 0;
      using (IDBConnection lisDb = DataConn.CreateLisDB())
      {
        string strSql = string.Format("update RequestForm set CountNodesFormSource='{0}' where ReceiveDate='{1}' and  SectionNo={2} and TestTypeNo='{3}' and SampleNo='{4}'", (object) CountNodesFormSource, (object) ReceiveDate, (object) SectionNo, (object) TestTypeNo, (object) SampleNo);
        num = lisDb.ExecuteNonQuery(strSql);
        ZhiFang.Common.Log.Log.Info("打计费颜色标志，执行更新语句:" + strSql);
      }
      return num;
    }

    public static int UpdateNameColor(string ReceiveDate, string SectionNo, string TestTypeNo, string SampleNo, string CountNodesFormSource, int charge)
    {
      if (SectionNo == null || SectionNo == "")
        return 1;
      int num = 0;
      using (IDBConnection lisDb = DataConn.CreateLisDB())
      {
        string strSql = string.Format("update RequestForm set CountNodesFormSource='{0}',charge={5} where ReceiveDate='{1}' and  SectionNo={2} and TestTypeNo='{3}' and SampleNo='{4}'", (object) CountNodesFormSource, (object) ReceiveDate, (object) SectionNo, (object) TestTypeNo, (object) SampleNo, (object) charge);
        num = lisDb.ExecuteNonQuery(strSql);
        ZhiFang.Common.Log.Log.Info("打计费颜色标志，执行更新语句:" + strSql);
      }
      return num;
    }

    public static int UpdateCharge(string ReceiveDate, string SectionNo, string TestTypeNo, string SampleNo, float charge)
    {
      if (SectionNo == null || SectionNo == "")
        return 1;
      int num = 0;
      using (IDBConnection lisDb = DataConn.CreateLisDB())
      {
        string strSql = string.Format("update RequestForm set charge={0} where ReceiveDate='{1}' and  SectionNo={2} and TestTypeNo='{3}' and SampleNo='{4}'", (object) charge, (object) ReceiveDate, (object) SectionNo, (object) TestTypeNo, (object) SampleNo);
        num = lisDb.ExecuteNonQuery(strSql);
        ZhiFang.Common.Log.Log.Info("更新费用，执行更新语句:" + strSql);
      }
      return num;
    }

    public static int Updateitem_received_over(string ReceiveDate, string SectionNo, string TestTypeNo, string SampleNo)
    {
      if (SectionNo == null || SectionNo == "")
        return 1;
      int num = 0;
      using (IDBConnection lisDb = DataConn.CreateLisDB())
      {
        string strSql1 = string.Format("select * from RequestForm where 2<1");
        if (lisDb.ExecuteDataSet(strSql1).Tables[0].Columns.Contains("item_received_over"))
        {
          string strSql2 = string.Format("update RequestForm set item_received_over='{0}' where ReceiveDate='{1}' and  SectionNo={2} and TestTypeNo='{3}' and SampleNo='{4}'", (object) 1, (object) ReceiveDate, (object) SectionNo, (object) TestTypeNo, (object) SampleNo);
          num = lisDb.ExecuteNonQuery(strSql2);
          ZhiFang.Common.Log.Log.Info("执行更新语句:" + strSql2);
        }
      }
      return num;
    }

    public static int DeleteRequestForm(string ReceiveDate, string SectionNo, string TestTypeNo, string SampleNo)
    {
      int num = 0;
      using (IDBConnection lisDb = DataConn.CreateLisDB())
      {
        string strSql = string.Format("delete from requestform where ReceiveDate='{0}' and  SectionNo={1} and TestTypeNo='{2}' and SampleNo='{3}'", (object) ReceiveDate, (object) SectionNo, (object) TestTypeNo, (object) SampleNo);
        num = lisDb.ExecuteNonQuery(strSql);
        ZhiFang.Common.Log.Log.Info("计费失败，删除语句:" + strSql);
      }
      return num;
    }
  }
}
