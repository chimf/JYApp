
using System.Data;
using ZhiFang.DBUtility;

namespace LIS.Model
{
  public class RequestItem : IModel
  {
    public static DataSet GetRequestItemData(string querycolumns, string WhereClause)
    {
      using (IDBConnection lisDb = DataConn.CreateLisDB())
      {
        if (querycolumns == null || querycolumns == "")
          querycolumns = " * ";
        if (WhereClause == null || WhereClause == "")
          WhereClause = " 2>1 ";
        string strSql = string.Format("select {0} from RequestItem where {1}", (object) querycolumns, (object) WhereClause);
        ZhiFang.Common.Log.Log.Info(string.Format("执行查询语句：{0}", (object) strSql));
        return lisDb.ExecuteDataSet(strSql);
      }
    }

    public static DataSet ReturnRequestItemInfo(string receivedate, string sectionno, string testtypeno, string sampleno, string WhereClause)
    {
      string WhereClause1 = "  2>1 ";
      if (receivedate != "")
        WhereClause1 = WhereClause1 + " and receivedate ='" + receivedate + "'";
      if (testtypeno != "")
        WhereClause1 = WhereClause1 + " and testtypeno =" + testtypeno;
      if (sectionno != "")
        WhereClause1 = WhereClause1 + " and sectionno =" + sectionno;
      if (sampleno != "")
        WhereClause1 = WhereClause1 + " and sampleno ='" + sampleno + "'";
      if (WhereClause != "")
        WhereClause1 = WhereClause1 + " and " + WhereClause;
      DataSet requestItemData = RequestItem.GetRequestItemData((string) null, WhereClause1);
      if (requestItemData.Tables[0].Columns.Contains("zdy1") && requestItemData.Tables[0].Columns.Contains("zdy2") && (requestItemData.Tables[0].Columns.Contains("zdy3") && requestItemData.Tables[0].Columns.Contains("zdy4")) && requestItemData.Tables[0].Columns.Contains("zdy5"))
        return requestItemData;
      ZhiFang.Common.Log.Log.Error("RequestItem表中不存在zdy1、zdy2、zdy3、zdy4、zdy5,可以手动加入。");
      return (DataSet) null;
    }

    public static DataSet ReturnRequestItemInfo(string receivedate, string sectionno, string testtypeno, string sampleno)
    {
      return RequestItem.ReturnRequestItemInfo(receivedate, sectionno, testtypeno, sampleno, "");
    }

    public static bool CheckRequestItem(string SectionNo, string TestTypeNo, string ReceiveDate, string SampleNo, string ItemNo)
    {
      return IModel.CheckDataSet(RequestItem.ReturnRequestItemInfo(ReceiveDate, SectionNo, TestTypeNo, SampleNo, string.Format("  ItemNo={0}", (object) ItemNo)));
    }

    public static int UpdateFlag(string SectionNo, string TestTypeNo, string ReceiveDate, string SampleNo, string ParitemNo, string CountNodesItemSource)
    {
      if (SectionNo == null || SectionNo == "")
        return 1;
      int num = 0;
      using (IDBConnection lisDb = DataConn.CreateLisDB())
      {
        string strSql;
        if (ParitemNo == null || ParitemNo.Trim() == "")
          strSql = string.Format("update RequestItem set CountNodesItemSource='{0}' where ReceiveDate='{1}' and  SectionNo={2} and TestTypeNo='{3}'and SampleNo='{4}'", (object) CountNodesItemSource, (object) ReceiveDate, (object) SectionNo, (object) TestTypeNo, (object) SampleNo);
        else
          strSql = string.Format("update RequestItem set CountNodesItemSource='{0}' where ReceiveDate='{1}' and  SectionNo={2} and TestTypeNo='{3}'and SampleNo='{4}' and  paritemno='{5}'", (object) CountNodesItemSource, (object) ReceiveDate, (object) SectionNo, (object) TestTypeNo, (object) SampleNo, (object) ParitemNo);
        num = lisDb.ExecuteNonQuery(strSql);
        ZhiFang.Common.Log.Log.Info(string.Format("更新RequestItem表的CountNodesItemSource标志:{0},影响数据库{1}行", (object) strSql, (object) num));
      }
      return num;
    }

    public static int DeleteRequestItem(string ReceiveDate, string SectionNo, string TestTypeNo, string SampleNo)
    {
      int num = 0;
      using (IDBConnection lisDb = DataConn.CreateLisDB())
      {
        string strSql = string.Format("delete from requestitem where ReceiveDate='{0}' and  SectionNo={1} and TestTypeNo='{2}' and SampleNo='{3}'", (object) ReceiveDate, (object) SectionNo, (object) TestTypeNo, (object) SampleNo);
        num = lisDb.ExecuteNonQuery(strSql);
        ZhiFang.Common.Log.Log.Info("计费失败，删除语句:" + strSql);
      }
      return num;
    }

    public static int DeleteRequestItembychargeflag(string ReceiveDate, string SectionNo, string TestTypeNo, string SampleNo, string CountNodesItemSource)
    {
      int num = 0;
      using (IDBConnection lisDb = DataConn.CreateLisDB())
      {
        string strSql = string.Format("delete from requestitem where ReceiveDate='{0}' and  SectionNo={1} and TestTypeNo='{2}' and SampleNo='{3}' and CountNodesItemSource='{4}'", (object) ReceiveDate, (object) SectionNo, (object) TestTypeNo, (object) SampleNo, (object) CountNodesItemSource);
        num = lisDb.ExecuteNonQuery(strSql);
        ZhiFang.Common.Log.Log.Info("计费失败，删除语句:" + strSql);
      }
      return num;
    }

    public static bool GetRequestItemInfo(string ReceiveDate, string SectionNo, string TestTypeNo, string SampleNo)
    {
      using (IDBConnection lisDb = DataConn.CreateLisDB())
      {
        string strSql = string.Format("select * from requestitem where ReceiveDate='{0}' and  SectionNo={1} and TestTypeNo='{2}' and SampleNo='{3}' ", (object) ReceiveDate, (object) SectionNo, (object) TestTypeNo, (object) SampleNo);
        ZhiFang.Common.Log.Log.Info("查询requestitem语句:" + strSql);
        DataSet dataSet = lisDb.ExecuteDataSet(strSql);
        return dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0;
      }
    }

    public static bool CheckRequestItemInfo(string ReceiveDate, string SectionNo, string TestTypeNo, string SampleNo)
    {
      using (IDBConnection lisDb = DataConn.CreateLisDB())
      {
        string strSql = string.Format("select * from requestitem where ReceiveDate='{0}' and  SectionNo={1} and TestTypeNo='{2}' and SampleNo='{3}'", (object) ReceiveDate, (object) SectionNo, (object) TestTypeNo, (object) SampleNo);
        ZhiFang.Common.Log.Log.Info("查询requestitem语句:" + strSql);
        DataSet dataSet = lisDb.ExecuteDataSet(strSql);
        return dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0;
      }
    }

    public static DataSet GetRequestItemSchema(string receivedate, string sectionno, string testtypeno, string sampleno, string WhereClause)
    {
      string str = "  1>2 ";
      if (receivedate != "")
        str = str + " and receivedate ='" + receivedate + "'";
      if (testtypeno != "")
        str = str + " and testtypeno =" + testtypeno;
      if (sectionno != "")
        str = str + " and sectionno =" + sectionno;
      if (sampleno != "")
        str = str + " and sampleno ='" + sampleno + "'";
      if (WhereClause != "")
        str = str + " and " + WhereClause;
      DataSet dataSet = (DataSet) null;
      using (IDBConnection lisDb = DataConn.CreateLisDB())
      {
        string strSql = string.Format("select {0} from RequestItem where {1}", (object) "*", (object) str);
        ZhiFang.Common.Log.Log.Info(string.Format("获取表结构执行查询语句：{0}", (object) strSql));
        dataSet = lisDb.GetDataTableSchema(strSql);
      }
      if (dataSet.Tables[0].Columns.Contains("zdy1") && dataSet.Tables[0].Columns.Contains("zdy2") && (dataSet.Tables[0].Columns.Contains("zdy3") && dataSet.Tables[0].Columns.Contains("zdy4")) && dataSet.Tables[0].Columns.Contains("zdy5"))
        return dataSet;
      ZhiFang.Common.Log.Log.Error("RequestItem表中不存在zdy1、zdy2、zdy3、zdy4、zdy5,可以手动加入。");
      return (DataSet) null;
    }
  }
}
