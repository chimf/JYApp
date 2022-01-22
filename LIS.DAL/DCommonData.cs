// Decompiled with JetBrains decompiler
// Type: LIS.DAL.DCommonData
// Assembly: LIS.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3C3145E9-0DCB-4480-8ABE-4B46074D1269
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\LIS.DAL.dll

using System;
using System.Data;
using System.Text;
using ZhiFang.DBUtility;

namespace LIS.DAL
{
  public class DCommonData
  {
    public DataSet GetDataList(string tableName, string fields, string strWhere)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (fields == "")
        stringBuilder.Append("SELECT * FROM " + tableName);
      else
        stringBuilder.Append("SELECT " + fields + " FROM " + tableName);
      if (!string.IsNullOrEmpty(strWhere.Trim()))
        stringBuilder.Append(" WHERE " + strWhere);
      ZhiFang.Common.Log.Log.Info("查询语句:" + stringBuilder.ToString());
      return DbHelperSQL.Query(stringBuilder.ToString());
    }

    public DataSet GetListByPage(string tableName, string strWhere, string orderby, int startIndex, int endIndex)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("SELECT * FROM ( ");
      stringBuilder.Append(" SELECT ROW_NUMBER() OVER (");
      if (!string.IsNullOrEmpty(orderby.Trim()))
        stringBuilder.Append("order by " + orderby);
      else
        stringBuilder.Append("order by ReceiveDate desc");
      stringBuilder.Append(")AS Row, *  from " + tableName);
      if (!string.IsNullOrEmpty(strWhere.Trim()))
        stringBuilder.Append(" WHERE " + strWhere);
      stringBuilder.Append(" ) T");
      stringBuilder.AppendFormat(" WHERE T.Row between {0} and {1}", (object) startIndex, (object) endIndex);
      ZhiFang.Common.Log.Log.Info("查询语句:" + stringBuilder.ToString());
      return DbHelperSQL.Query(stringBuilder.ToString());
    }

    public int GetRecordCount(string tableName, string strWhere)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("select count(1) FROM  " + tableName);
      if (strWhere.Trim() != "")
        stringBuilder.Append(" where " + strWhere);
      object single = DbHelperSQL.GetSingle(stringBuilder.ToString());
      if (single == null)
        return 0;
      return Convert.ToInt32(single);
    }

    public string ExecuteScalar(string strSql)
    {
      return DbHelperSQL.GetSingle(strSql).ToString();
    }
  }
}
