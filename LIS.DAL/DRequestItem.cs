// Decompiled with JetBrains decompiler
// Type: LIS.DAL.DRequestItem
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
  public class DRequestItem
  {
    public int GetMaxId()
    {
      return DbHelperSQL.GetMaxID("SectionNo", "RequestItem");
    }

    public bool Exists(DateTime ReceiveDate, int SectionNo, int TestTypeNo, string SampleNo, int ItemNo)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("select count(1) from RequestItem");
      stringBuilder.Append(" where ReceiveDate=@ReceiveDate and SectionNo=@SectionNo and TestTypeNo=@TestTypeNo and SampleNo=@SampleNo and ItemNo=@ItemNo ");
      SqlParameter[] sqlParameterArray = new SqlParameter[5]
      {
        new SqlParameter("@ReceiveDate", SqlDbType.DateTime),
        new SqlParameter("@SectionNo", SqlDbType.Int, 4),
        new SqlParameter("@TestTypeNo", SqlDbType.Int, 4),
        new SqlParameter("@SampleNo", SqlDbType.VarChar, 20),
        new SqlParameter("@ItemNo", SqlDbType.Int, 4)
      };
      sqlParameterArray[0].Value = (object) ReceiveDate;
      sqlParameterArray[1].Value = (object) SectionNo;
      sqlParameterArray[2].Value = (object) TestTypeNo;
      sqlParameterArray[3].Value = (object) SampleNo;
      sqlParameterArray[4].Value = (object) ItemNo;
      return DbHelperSQL.Exists(stringBuilder.ToString(), sqlParameterArray);
    }

    public string Add(RequestItem model)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      DateTime receiveDate = model.ReceiveDate;
      bool flag = false;
      stringBuilder2.Append("ReceiveDate,");
      stringBuilder3.Append("'" + (object) model.ReceiveDate + "',");
      int sectionNo = model.SectionNo;
      flag = false;
      stringBuilder2.Append("SectionNo,");
      stringBuilder3.Append(model.SectionNo.ToString() + ",");
      int testTypeNo = model.TestTypeNo;
      flag = false;
      stringBuilder2.Append("TestTypeNo,");
      stringBuilder3.Append(model.TestTypeNo.ToString() + ",");
      if (model.SampleNo != null)
      {
        stringBuilder2.Append("SampleNo,");
        stringBuilder3.Append("'" + model.SampleNo + "',");
      }
      int parItemNo = model.ParItemNo;
      flag = false;
      stringBuilder2.Append("ParItemNo,");
      stringBuilder3.Append(model.ParItemNo.ToString() + ",");
      int itemNo = model.ItemNo;
      flag = false;
      stringBuilder2.Append("ItemNo,");
      stringBuilder3.Append(model.ItemNo.ToString() + ",");
      if (model.serialnoparent != null)
      {
        stringBuilder2.Append("serialnoparent,");
        stringBuilder3.Append("'" + model.serialnoparent + "',");
      }
      if (model.Mergeno != null)
      {
        stringBuilder2.Append("Mergeno,");
        stringBuilder3.Append("'" + model.Mergeno + "',");
      }
      if (model.OldParItemno != null)
      {
        stringBuilder2.Append("OldParItemno,");
        stringBuilder3.Append("'" + model.OldParItemno + "',");
      }
      if (model.ReportValue.HasValue)
      {
        stringBuilder2.Append("ReportValue,");
        stringBuilder3.Append(model.ReportValue.ToString() + ",");
      }
      if (model.ReportDesc != null)
      {
        stringBuilder2.Append("ReportDesc,");
        stringBuilder3.Append("'" + model.ReportDesc + "',");
      }
      if (model.isReceive.HasValue)
      {
        stringBuilder2.Append("isReceive,");
        stringBuilder3.Append(model.isReceive.ToString() + ",");
      }
      if (model.CountNodesItemSource != null)
      {
        stringBuilder2.Append("CountNodesItemSource,");
        stringBuilder3.Append("'" + model.CountNodesItemSource + "',");
      }
      if (model.Unit != null)
      {
        stringBuilder2.Append("Unit,");
        stringBuilder3.Append("'" + model.Unit + "',");
      }
      if (model.RefRange != null)
      {
        stringBuilder2.Append("RefRange,");
        stringBuilder3.Append("'" + model.RefRange + "',");
      }
      if (model.ResultStatus != null)
      {
        stringBuilder2.Append("ResultStatus,");
        stringBuilder3.Append("'" + model.ResultStatus + "',");
      }
      if (model.ItemDate.HasValue)
      {
        stringBuilder2.Append("ItemDate,");
        stringBuilder3.Append("'" + (object) model.ItemDate + "',");
      }
      if (model.ItemTime.HasValue)
      {
        stringBuilder2.Append("ItemTime,");
        stringBuilder3.Append("'" + (object) model.ItemTime + "',");
      }
      if (model.zdy1 != null)
      {
        stringBuilder2.Append("zdy1,");
        stringBuilder3.Append("'" + model.zdy1 + "',");
      }
      else
      {
        stringBuilder2.Append("zdy1,");
        stringBuilder3.Append("null,");
      }
      if (model.zdy2 != null)
      {
        stringBuilder2.Append("zdy2,");
        stringBuilder3.Append("'" + model.zdy2 + "',");
      }
      else
      {
        stringBuilder2.Append("zdy2,");
        stringBuilder3.Append("null,");
      }
      if (model.zdy3 != null)
      {
        stringBuilder2.Append("zdy3,");
        stringBuilder3.Append("'" + model.zdy3 + "',");
      }
      else
      {
        stringBuilder2.Append("zdy3,");
        stringBuilder3.Append("null,");
      }
      if (model.zdy4 != null)
      {
        stringBuilder2.Append("zdy4,");
        stringBuilder3.Append("'" + model.zdy4 + "',");
      }
      else
      {
        stringBuilder2.Append("zdy4,");
        stringBuilder3.Append("null,");
      }
      if (model.zdy5 != null)
      {
        stringBuilder2.Append("zdy5,");
        stringBuilder3.Append("'" + model.zdy5 + "',");
      }
      else
      {
        stringBuilder2.Append("zdy5,");
        stringBuilder3.Append("null,");
      }
      stringBuilder1.Append("insert into RequestItem(");
      stringBuilder1.Append(stringBuilder2.ToString().Remove(stringBuilder2.Length - 1));
      stringBuilder1.Append(")");
      stringBuilder1.Append(" values (");
      stringBuilder1.Append(stringBuilder3.ToString().Remove(stringBuilder3.Length - 1));
      stringBuilder1.Append(")");
            return stringBuilder1.ToString();
    }

    public bool Save(RequestItem model)
    {
      SqlParameter[] sqlParameterArray = new SqlParameter[6]
      {
        new SqlParameter("@ReceiveDate", SqlDbType.DateTime),
        new SqlParameter("@SectionNo", SqlDbType.Int),
        new SqlParameter("@TestTypeNo", SqlDbType.Int),
        new SqlParameter("@SampleNo", SqlDbType.VarChar, 20),
        new SqlParameter("@SerialNo", SqlDbType.VarChar, 20),
        new SqlParameter("@ParItemNo", SqlDbType.Int)
      };
      sqlParameterArray[0].Value = (object) model.ReceiveDate;
      sqlParameterArray[1].Value = (object) model.SectionNo;
      sqlParameterArray[2].Value = (object) model.TestTypeNo;
      sqlParameterArray[3].Value = (object) model.SampleNo;
      sqlParameterArray[4].Value = (object) model.SerialNo;
      sqlParameterArray[5].Value = (object) model.ParItemNo;
      ZhiFang.Common.Log.Log.Debug("调用存储过程SaveRequestItem");
      ZhiFang.Common.Log.Log.Debug("@ReceiveDate=" + (object) model.ReceiveDate);
      ZhiFang.Common.Log.Log.Debug("@SectionNo=" + (object) model.SectionNo);
      ZhiFang.Common.Log.Log.Debug("@TestTypeNo=" + (object) model.TestTypeNo);
      ZhiFang.Common.Log.Log.Debug("@SampleNo=" + model.SampleNo);
      ZhiFang.Common.Log.Log.Debug("@SerialNo=" + model.SerialNo);
      ZhiFang.Common.Log.Log.Debug("@ParItemNo=" + (object) model.ParItemNo);
      int rowsAffected = 0;
      int num = DbHelperSQL.RunProcedure("SaveRequestItem", (IDataParameter[]) sqlParameterArray, out rowsAffected);
      ZhiFang.Common.Log.Log.Debug("存储过程返回值:" + (object) num);
      return num > 0 ? true : true;
    }

    public string Update(RequestItem model)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("update RequestItem set ");
      int parItemNo = model.ParItemNo;
      bool flag = false;
      stringBuilder.Append("ParItemNo=" + (object) model.ParItemNo + ",");
      int itemNo = model.ItemNo;
      flag = false;
      stringBuilder.Append("ItemNo=" + (object) model.ItemNo + ",");
      if (model.ReportDesc != null)
        stringBuilder.Append("ReportDesc='" + model.ReportDesc + "',");
      else
        stringBuilder.Append("ReportDesc= null ,");
      if (model.isReceive.HasValue)
        stringBuilder.Append("isReceive=" + (object) model.isReceive + ",");
      else
        stringBuilder.Append("isReceive= null ,");
      if (model.CountNodesItemSource != null)
        stringBuilder.Append("CountNodesItemSource='" + model.CountNodesItemSource + "',");
      else
        stringBuilder.Append("CountNodesItemSource= null ,");
      if (model.serialnoparent != null)
        stringBuilder.Append("serialnoparent='" + model.serialnoparent + "',");
      else
        stringBuilder.Append("serialnoparent= null ,");
      if (model.Mergeno != null)
        stringBuilder.Append("Mergeno='" + model.Mergeno + "',");
      else
        stringBuilder.Append("Mergeno= null ,");
      if (model.OldParItemno != null)
        stringBuilder.Append("OldParItemno='" + model.OldParItemno + "',");
      else
        stringBuilder.Append("OldParItemno= null ,");
      if (model.ReportValue.HasValue)
        stringBuilder.Append("ReportValue=" + (object) model.ReportValue + ",");
      if (model.RefRange != null)
        stringBuilder.Append("RefRange='" + model.RefRange + "',");
      if (model.Unit != null)
        stringBuilder.Append("Unit='" + model.Unit + "',");
      if (model.ResultStatus != null)
        stringBuilder.Append("ResultStatus='" + model.ResultStatus + "',");
      if (model.ItemDate.HasValue)
        stringBuilder.Append("ItemDate='" + (object) model.ItemDate + "',");
      if (model.ItemTime.HasValue)
        stringBuilder.Append("ItemTime='" + (object) model.ItemTime + "',");
      if (model.zdy1 != null)
        stringBuilder.Append("zdy1='" + model.zdy1 + "',");
      else
        stringBuilder.Append("zdy1= null ,");
      if (model.zdy2 != null)
        stringBuilder.Append("zdy2='" + model.zdy2 + "',");
      else
        stringBuilder.Append("zdy2= null ,");
      if (model.zdy3 != null)
        stringBuilder.Append("zdy3='" + model.zdy3 + "',");
      else
        stringBuilder.Append("zdy3= null ,");
      if (model.zdy4 != null)
        stringBuilder.Append("zdy4='" + model.zdy4 + "',");
      else
        stringBuilder.Append("zdy4= null ,");
      if (model.zdy5 != null)
        stringBuilder.Append("zdy5='" + model.zdy5 + "',");
      else
        stringBuilder.Append("zdy5= null ,");
      int startIndex = stringBuilder.ToString().LastIndexOf(",");
      stringBuilder.Remove(startIndex, 1);
      stringBuilder.Append(" where ReceiveDate='" + (object) model.ReceiveDate + "' and SectionNo=" + (object) model.SectionNo + " and TestTypeNo=" + (object) model.TestTypeNo + " and SampleNo='" + model.SampleNo + "' and ItemNo=" + (object) model.ItemNo + " ");
      return stringBuilder.ToString();
    }

    public bool Delete(DateTime ReceiveDate, int SectionNo, int TestTypeNo, string SampleNo, int ItemNo)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("delete from RequestItem ");
      stringBuilder.Append(" where ReceiveDate=@ReceiveDate and SectionNo=@SectionNo and TestTypeNo=@TestTypeNo and SampleNo=@SampleNo and ItemNo=@ItemNo ");
      SqlParameter[] sqlParameterArray = new SqlParameter[5]
      {
        new SqlParameter("@ReceiveDate", SqlDbType.DateTime),
        new SqlParameter("@SectionNo", SqlDbType.Int, 4),
        new SqlParameter("@TestTypeNo", SqlDbType.Int, 4),
        new SqlParameter("@SampleNo", SqlDbType.VarChar, 20),
        new SqlParameter("@ItemNo", SqlDbType.Int, 4)
      };
      sqlParameterArray[0].Value = (object) ReceiveDate;
      sqlParameterArray[1].Value = (object) SectionNo;
      sqlParameterArray[2].Value = (object) TestTypeNo;
      sqlParameterArray[3].Value = (object) SampleNo;
      sqlParameterArray[4].Value = (object) ItemNo;
      return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), sqlParameterArray) > 0;
    }

    public RequestItem GetModel(DateTime ReceiveDate, int SectionNo, int TestTypeNo, string SampleNo, int ItemNo)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("select  top 1 * from RequestItem ");
      stringBuilder.Append(" where ReceiveDate=@ReceiveDate and SectionNo=@SectionNo and TestTypeNo=@TestTypeNo and SampleNo=@SampleNo and ItemNo=@ItemNo ");
      SqlParameter[] sqlParameterArray = new SqlParameter[5]
      {
        new SqlParameter("@ReceiveDate", SqlDbType.DateTime),
        new SqlParameter("@SectionNo", SqlDbType.Int, 4),
        new SqlParameter("@TestTypeNo", SqlDbType.Int, 4),
        new SqlParameter("@SampleNo", SqlDbType.VarChar, 20),
        new SqlParameter("@ItemNo", SqlDbType.Int, 4)
      };
      sqlParameterArray[0].Value = (object) ReceiveDate;
      sqlParameterArray[1].Value = (object) SectionNo;
      sqlParameterArray[2].Value = (object) TestTypeNo;
      sqlParameterArray[3].Value = (object) SampleNo;
      sqlParameterArray[4].Value = (object) ItemNo;
      RequestItem requestItem = new RequestItem();
      DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), sqlParameterArray);
      if (dataSet.Tables[0].Rows.Count <= 0)
        return (RequestItem) null;
      if (dataSet.Tables[0].Rows[0]["ReceiveDate"] != null && dataSet.Tables[0].Rows[0]["ReceiveDate"].ToString() != "")
        requestItem.ReceiveDate = DateTime.Parse(dataSet.Tables[0].Rows[0]["ReceiveDate"].ToString());
      if (dataSet.Tables[0].Rows[0]["SectionNo"] != null && dataSet.Tables[0].Rows[0]["SectionNo"].ToString() != "")
        requestItem.SectionNo = int.Parse(dataSet.Tables[0].Rows[0]["SectionNo"].ToString());
      if (dataSet.Tables[0].Rows[0]["TestTypeNo"] != null && dataSet.Tables[0].Rows[0]["TestTypeNo"].ToString() != "")
        requestItem.TestTypeNo = int.Parse(dataSet.Tables[0].Rows[0]["TestTypeNo"].ToString());
      if (dataSet.Tables[0].Rows[0]["SampleNo"] != null && dataSet.Tables[0].Rows[0]["SampleNo"].ToString() != "")
        requestItem.SampleNo = dataSet.Tables[0].Rows[0]["SampleNo"].ToString();
      if (dataSet.Tables[0].Rows[0]["ParItemNo"] != null && dataSet.Tables[0].Rows[0]["ParItemNo"].ToString() != "")
        requestItem.ParItemNo = int.Parse(dataSet.Tables[0].Rows[0]["ParItemNo"].ToString());
      if (dataSet.Tables[0].Rows[0]["ItemNo"] != null && dataSet.Tables[0].Rows[0]["ItemNo"].ToString() != "")
        requestItem.ItemNo = int.Parse(dataSet.Tables[0].Rows[0]["ItemNo"].ToString());
      if (dataSet.Tables[0].Rows[0]["ReportDesc"] != null && dataSet.Tables[0].Rows[0]["ReportDesc"].ToString() != "")
        requestItem.ReportDesc = dataSet.Tables[0].Rows[0]["ReportDesc"].ToString();
      if (dataSet.Tables[0].Rows[0]["isReceive"] != null && dataSet.Tables[0].Rows[0]["isReceive"].ToString() != "")
        requestItem.isReceive = new int?(int.Parse(dataSet.Tables[0].Rows[0]["isReceive"].ToString()));
      if (dataSet.Tables[0].Rows[0]["CountNodesItemSource"] != null && dataSet.Tables[0].Rows[0]["CountNodesItemSource"].ToString() != "")
        requestItem.CountNodesItemSource = dataSet.Tables[0].Rows[0]["CountNodesItemSource"].ToString();
      if (dataSet.Tables[0].Rows[0]["Zdy1"] != null && dataSet.Tables[0].Rows[0]["Zdy1"].ToString() != "")
        requestItem.zdy1 = dataSet.Tables[0].Rows[0]["Zdy1"].ToString();
      if (dataSet.Tables[0].Rows[0]["Zdy2"] != null && dataSet.Tables[0].Rows[0]["Zdy2"].ToString() != "")
        requestItem.zdy2 = dataSet.Tables[0].Rows[0]["Zdy2"].ToString();
      if (dataSet.Tables[0].Rows[0]["Zdy3"] != null && dataSet.Tables[0].Rows[0]["Zdy3"].ToString() != "")
        requestItem.zdy3 = dataSet.Tables[0].Rows[0]["Zdy3"].ToString();
      if (dataSet.Tables[0].Rows[0]["serialnoparent"] != null && dataSet.Tables[0].Rows[0]["serialnoparent"].ToString() != "")
        requestItem.serialnoparent = dataSet.Tables[0].Rows[0]["serialnoparent"].ToString();
      if (dataSet.Tables[0].Rows[0]["Mergeno"] != null && dataSet.Tables[0].Rows[0]["Mergeno"].ToString() != "")
        requestItem.Mergeno = dataSet.Tables[0].Rows[0]["Mergeno"].ToString();
      if (dataSet.Tables[0].Rows[0]["OldParItemno"] != null && dataSet.Tables[0].Rows[0]["OldParItemno"].ToString() != "")
        requestItem.OldParItemno = dataSet.Tables[0].Rows[0]["OldParItemno"].ToString();
      return requestItem;
    }

    public DataSet GetList(string strWhere)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("select * ");
      stringBuilder.Append(" FROM RequestItem ");
      if (strWhere.Trim() != "")
        stringBuilder.Append(" where " + strWhere);
      return DbHelperSQL.Query(stringBuilder.ToString());
    }

    public DataSet GetList(string tableName, string strWhere)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("select * ");
      stringBuilder.Append(" FROM  " + tableName);
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
      stringBuilder.Append(" FROM RequestItem ");
      if (strWhere.Trim() != "")
        stringBuilder.Append(" where " + strWhere);
      stringBuilder.Append(" order by " + filedOrder);
      return DbHelperSQL.Query(stringBuilder.ToString());
    }

    public int UpdateColorFlag(string ReceiveDate, string SectionNo, string TestTypeNo, string SampleNo, string CountNodesItemSource)
    {
      string SQLString = string.Format("update RequestItem set CountNodesItemSource='{0}' where ReceiveDate='{1}' and  SectionNo={2} and TestTypeNo='{3}'and SampleNo='{4}'", (object) CountNodesItemSource, (object) ReceiveDate, (object) SectionNo, (object) TestTypeNo, (object) SampleNo);
      int num = DbHelperSQL.ExecuteSql(SQLString);
      ZhiFang.Common.Log.Log.Info(string.Format("更新RequestItem表的CountNodesItemSource标志:{0},影响数据库{1}行", (object) SQLString, (object) num));
      return num;
    }
  }
}
