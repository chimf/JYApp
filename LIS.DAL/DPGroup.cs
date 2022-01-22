// Decompiled with JetBrains decompiler
// Type: LIS.DAL.DPGroup
// Assembly: LIS.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3C3145E9-0DCB-4480-8ABE-4B46074D1269
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\LIS.DAL.dll

using LIS.Model.Entity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ZhiFang.DBUtility;

namespace LIS.DAL
{
  public class DPGroup
  {
    public int GetMaxId()
    {
      return DbHelperSQL.GetMaxID("SectionNo", "PGroup");
    }

    public bool Exists(int SectionNo)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("select count(1) from PGroup");
      stringBuilder.Append(" where SectionNo=@SectionNo ");
      SqlParameter[] sqlParameterArray = new SqlParameter[1]
      {
        new SqlParameter("@SectionNo", SqlDbType.Int, 4)
      };
      sqlParameterArray[0].Value = (object) SectionNo;
      return DbHelperSQL.Exists(stringBuilder.ToString(), sqlParameterArray);
    }

    public bool Delete(int SectionNo)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("delete from PGroup ");
      stringBuilder.Append(" where SectionNo=@SectionNo ");
      SqlParameter[] sqlParameterArray = new SqlParameter[1]
      {
        new SqlParameter("@SectionNo", SqlDbType.Int, 4)
      };
      sqlParameterArray[0].Value = (object) SectionNo;
      return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), sqlParameterArray) > 0;
    }

    public bool DeleteList(string SectionNolist)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("delete from PGroup ");
      stringBuilder.Append(" where SectionNo in (" + SectionNolist + ")  ");
      return DbHelperSQL.ExecuteSql(stringBuilder.ToString()) > 0;
    }

    public DataSet GetList(string strWhere)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("select * ");
      stringBuilder.Append(" FROM PGroup ");
      if (strWhere.Trim() != "")
        stringBuilder.Append(" where " + strWhere);
      return DbHelperSQL.Query(stringBuilder.ToString());
    }

    public DataSet GetList(int Top, string strWhere, string filedOrder)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("select ");
      if (Top > 0)
        stringBuilder.Append(" top " + Top.ToString());
      stringBuilder.Append(" * ");
      stringBuilder.Append(" FROM PGroup ");
      if (strWhere.Trim() != "")
        stringBuilder.Append(" where " + strWhere);
      stringBuilder.Append(" order by " + filedOrder);
      return DbHelperSQL.Query(stringBuilder.ToString());
    }

    public string GetSectionType(string SectionNo)
    {
      string str = "";
      string SQLString = string.Format("select SectionType from PGroup where Visible=1 and SectionNo={0}", (object) SectionNo);
      try
      {
        DataSet dataSet = DbHelperSQL.Query(SQLString);
        if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
          str = dataSet.Tables[0].Rows[0][0].ToString();
      }
      catch (Exception ex)
      {
      }
      return str;
    }
  }
}
