// Decompiled with JetBrains decompiler
// Type: LIS.DAL.DRequestForm
// Assembly: LIS.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3C3145E9-0DCB-4480-8ABE-4B46074D1269
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\LIS.DAL.dll

using LIS.Model.Entity;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ZhiFang.DBUtility;

namespace LIS.DAL
{
  public class DRequestForm
  {
    public int GetMaxId()
    {
      return DbHelperSQL.GetMaxID("SectionNo", "RequestForm");
    }

    public bool Exists(string ReceiveDate, int SectionNo, int TestTypeNo, string SampleNo)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("select count(1) from RequestForm");
      stringBuilder.Append(" where ReceiveDate=@ReceiveDate and SectionNo=@SectionNo and TestTypeNo=@TestTypeNo and SampleNo=@SampleNo ");
      SqlParameter[] sqlParameterArray = new SqlParameter[4]
      {
        new SqlParameter("@ReceiveDate", SqlDbType.VarChar, 20),
        new SqlParameter("@SectionNo", SqlDbType.Int, 4),
        new SqlParameter("@TestTypeNo", SqlDbType.Int, 4),
        new SqlParameter("@SampleNo", SqlDbType.VarChar, 20)
      };
      sqlParameterArray[0].Value = (object) ReceiveDate;
      sqlParameterArray[1].Value = (object) SectionNo;
      sqlParameterArray[2].Value = (object) TestTypeNo;
      sqlParameterArray[3].Value = (object) SampleNo;
      return DbHelperSQL.Exists(stringBuilder.ToString(), sqlParameterArray);
    }

    public string Add(RequestForm model)
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
      if (model.StatusNo.HasValue)
      {
        stringBuilder2.Append("StatusNo,");
        stringBuilder3.Append(model.StatusNo.ToString() + ",");
      }
      if (model.SampleTypeNo.HasValue)
      {
        stringBuilder2.Append("SampleTypeNo,");
        stringBuilder3.Append(model.SampleTypeNo.ToString() + ",");
      }
      if (model.PatNo != null)
      {
        stringBuilder2.Append("PatNo,");
        stringBuilder3.Append("'" + model.PatNo + "',");
      }
      if (model.CName != null)
      {
        stringBuilder2.Append("CName,");
        stringBuilder3.Append("'" + model.CName + "',");
      }
      if (model.GenderNo.HasValue)
      {
        stringBuilder2.Append("GenderNo,");
        stringBuilder3.Append(model.GenderNo.ToString() + ",");
      }
      if (model.Birthday.HasValue)
      {
        stringBuilder2.Append("Birthday,");
        stringBuilder3.Append("'" + (object) model.Birthday + "',");
      }
      if (model.Age.HasValue)
      {
        stringBuilder2.Append("Age,");
        stringBuilder3.Append(model.Age.ToString() + ",");
      }
      if (model.AgeUnitNo.HasValue)
      {
        stringBuilder2.Append("AgeUnitNo,");
        stringBuilder3.Append(model.AgeUnitNo.ToString() + ",");
      }
      if (model.FolkNo.HasValue)
      {
        stringBuilder2.Append("FolkNo,");
        stringBuilder3.Append(model.FolkNo.ToString() + ",");
      }
      if (model.DistrictNo.HasValue)
      {
        stringBuilder2.Append("DistrictNo,");
        stringBuilder3.Append(model.DistrictNo.ToString() + ",");
      }
      if (model.WardNo.HasValue)
      {
        stringBuilder2.Append("WardNo,");
        stringBuilder3.Append(model.WardNo.ToString() + ",");
      }
      if (model.Bed != null)
      {
        stringBuilder2.Append("Bed,");
        stringBuilder3.Append("'" + model.Bed + "',");
      }
      if (model.DeptNo.HasValue)
      {
        stringBuilder2.Append("DeptNo,");
        stringBuilder3.Append(model.DeptNo.ToString() + ",");
      }
      if (model.Doctor != null)
      {
        stringBuilder2.Append("Doctor,");
        stringBuilder3.Append("'" + model.Doctor + "',");
      }
      if (model.ChargeNo.HasValue)
      {
        stringBuilder2.Append("ChargeNo,");
        stringBuilder3.Append(model.ChargeNo.ToString() + ",");
      }
      if (model.Charge.HasValue)
      {
        stringBuilder2.Append("Charge,");
        stringBuilder3.Append(model.Charge.ToString() + ",");
      }
      if (model.Collecter != null)
      {
        stringBuilder2.Append("Collecter,");
        stringBuilder3.Append("'" + model.Collecter + "',");
      }
      if (model.CollectDate.HasValue)
      {
        stringBuilder2.Append("CollectDate,");
        stringBuilder3.Append("'" + (object) model.CollectDate + "',");
      }
      if (model.CollectTime.HasValue)
      {
        stringBuilder2.Append("CollectTime,");
        stringBuilder3.Append("'" + (object) model.CollectTime + "',");
      }
      if (model.incepter != null)
      {
        stringBuilder2.Append("incepter,");
        stringBuilder3.Append("'" + model.incepter + "',");
      }
      if (model.inceptdate.HasValue)
      {
        stringBuilder2.Append("inceptdate,");
        stringBuilder3.Append("'" + (object) model.inceptdate + "',");
      }
      if (model.incepttime.HasValue)
      {
        stringBuilder2.Append("incepttime,");
        stringBuilder3.Append("'" + (object) model.incepttime + "',");
      }
      if (model.SerialNo != null)
      {
        stringBuilder2.Append("SerialNo,");
        stringBuilder3.Append("'" + model.SerialNo + "',");
      }
      if (model.RequestSource != null)
      {
        stringBuilder2.Append("RequestSource,");
        stringBuilder3.Append("'" + model.RequestSource + "',");
      }
      if (model.DiagNo.HasValue)
      {
        stringBuilder2.Append("DiagNo,");
        stringBuilder3.Append(model.DiagNo.ToString() + ",");
      }
      if (model.SickTypeNo.HasValue)
      {
        stringBuilder2.Append("SickTypeNo,");
        stringBuilder3.Append(model.SickTypeNo.ToString() + ",");
      }
      if (model.Chargeflag != null)
      {
        stringBuilder2.Append("Chargeflag,");
        stringBuilder3.Append("'" + model.Chargeflag + "',");
      }
      if (model.clientno.HasValue)
      {
        stringBuilder2.Append("clientno,");
        stringBuilder3.Append(model.clientno.ToString() + ",");
      }
      if (model.isReceive.HasValue)
      {
        stringBuilder2.Append("isReceive,");
        stringBuilder3.Append(model.isReceive.ToString() + ",");
      }
      if (model.ReceiveMan != null)
      {
        stringBuilder2.Append("ReceiveMan,");
        stringBuilder3.Append("'" + model.ReceiveMan + "',");
      }
      if (model.ReceiveTime.HasValue)
      {
        stringBuilder2.Append("ReceiveTime,");
        stringBuilder3.Append("'" + (object) model.ReceiveTime + "',");
      }
      if (model.CountNodesFormSource != null)
      {
        stringBuilder2.Append("CountNodesFormSource,");
        stringBuilder3.Append("'" + model.CountNodesFormSource + "',");
      }
      if (model.UrgentState != null)
      {
        stringBuilder2.Append("UrgentState,");
        stringBuilder3.Append("'" + model.UrgentState + "',");
      }
      if (model.phoneCode != null)
      {
        stringBuilder2.Append("phoneCode,");
        stringBuilder3.Append("'" + model.phoneCode + "',");
      }
      if (model.zdy1 != null)
      {
        stringBuilder2.Append("zdy1,");
        stringBuilder3.Append("'" + model.zdy1 + "',");
      }
      if (model.zdy2 != null)
      {
        stringBuilder2.Append("zdy2,");
        stringBuilder3.Append("'" + model.zdy2 + "',");
      }
      if (model.zdy3 != null)
      {
        stringBuilder2.Append("zdy3,");
        stringBuilder3.Append("'" + model.zdy3 + "',");
      }
      if (model.zdy4 != null)
      {
        stringBuilder2.Append("zdy4,");
        stringBuilder3.Append("'" + model.zdy4 + "',");
      }
      if (model.zdy5 != null)
      {
        stringBuilder2.Append("zdy5,");
        stringBuilder3.Append("'" + model.zdy5 + "',");
      }
      if (model.zdy6 != null)
      {
        stringBuilder2.Append("zdy6,");
        stringBuilder3.Append("'" + model.zdy6 + "',");
      }
      if (model.zdy7 != null)
      {
        stringBuilder2.Append("zdy7,");
        stringBuilder3.Append("'" + model.zdy7 + "',");
      }
      if (model.zdy8 != null)
      {
        stringBuilder2.Append("zdy8,");
        stringBuilder3.Append("'" + model.zdy8 + "',");
      }
      if (model.zdy9 != null)
      {
        stringBuilder2.Append("zdy9,");
        stringBuilder3.Append("'" + model.zdy9 + "',");
      }
      if (model.zdy10 != null)
      {
        stringBuilder2.Append("zdy10,");
        stringBuilder3.Append("'" + model.zdy10 + "',");
      }
      if (model.zdy11 != null)
      {
        stringBuilder2.Append("zdy11,");
        stringBuilder3.Append("'" + model.zdy11 + "',");
      }
      if (model.zdy12 != null)
      {
        stringBuilder2.Append("zdy12,");
        stringBuilder3.Append("'" + model.zdy12 + "',");
      }
      if (model.zdy13 != null)
      {
        stringBuilder2.Append("zdy13,");
        stringBuilder3.Append("'" + model.zdy13 + "',");
      }
      if (model.zdy14 != null)
      {
        stringBuilder2.Append("zdy14,");
        stringBuilder3.Append("'" + model.zdy14 + "',");
      }
      if (model.zdy15 != null)
      {
        stringBuilder2.Append("zdy15,");
        stringBuilder3.Append("'" + model.zdy15 + "',");
      }
      if (model.zdy16 != null)
      {
        stringBuilder2.Append("zdy16,");
        stringBuilder3.Append("'" + model.zdy16 + "',");
      }
      if (model.zdy17 != null)
      {
        stringBuilder2.Append("zdy17,");
        stringBuilder3.Append("'" + model.zdy17 + "',");
      }
      if (model.zdy18 != null)
      {
        stringBuilder2.Append("zdy18,");
        stringBuilder3.Append("'" + model.zdy18 + "',");
      }
      if (model.zdy19 != null)
      {
        stringBuilder2.Append("zdy19,");
        stringBuilder3.Append("'" + model.zdy19 + "',");
      }
      if (model.zdy20 != null)
      {
        stringBuilder2.Append("zdy20,");
        stringBuilder3.Append("'" + model.zdy20 + "',");
      }
      stringBuilder1.Append("insert into RequestForm(");
      stringBuilder1.Append(stringBuilder2.ToString().Remove(stringBuilder2.Length - 1));
      stringBuilder1.Append(")");
      stringBuilder1.Append(" values (");
      stringBuilder1.Append(stringBuilder3.ToString().Remove(stringBuilder3.Length - 1));
      stringBuilder1.Append(")");
      return stringBuilder1.ToString();
    }

    public bool Save(RequestForm model)
    {
      SqlParameter[] sqlParameterArray = new SqlParameter[7]
      {
        new SqlParameter("@ReceiveDate", SqlDbType.DateTime),
        new SqlParameter("@SectionNo", SqlDbType.Int),
        new SqlParameter("@TestTypeNo", SqlDbType.Int),
        new SqlParameter("@SampleNo", SqlDbType.VarChar, 20),
        new SqlParameter("@SampleTypeNo", SqlDbType.Int),
        new SqlParameter("@SerialNo", SqlDbType.VarChar, 20),
        new SqlParameter("@Operator", SqlDbType.VarChar, 20)
      };
      sqlParameterArray[0].Value = (object) model.ReceiveDate;
      sqlParameterArray[1].Value = (object) model.SectionNo;
      sqlParameterArray[2].Value = (object) model.TestTypeNo;
      sqlParameterArray[3].Value = (object) model.SampleNo;
      sqlParameterArray[4].Value = (object) model.SampleTypeNo;
      sqlParameterArray[5].Value = (object) model.SerialNo;
      sqlParameterArray[6].Value = (object) model.Operator;
      ZhiFang.Common.Log.Log.Debug("调用存储过程SaveRequestForm");
      ZhiFang.Common.Log.Log.Debug("@ReceiveDate=" + (object) model.ReceiveDate);
      ZhiFang.Common.Log.Log.Debug("@SectionNo=" + (object) model.SectionNo);
      ZhiFang.Common.Log.Log.Debug("@TestTypeNo=" + (object) model.TestTypeNo);
      ZhiFang.Common.Log.Log.Debug("@SampleNo=" + model.SampleNo);
      ZhiFang.Common.Log.Log.Debug("@SampleTypeNo=" + (object) model.SampleTypeNo);
      ZhiFang.Common.Log.Log.Debug("@SerialNo=" + model.SerialNo);
      ZhiFang.Common.Log.Log.Debug("@Operator=" + model.Operator);
      int rowsAffected = 0;
      int num = DbHelperSQL.RunProcedure("SaveRequestForm", (IDataParameter[]) sqlParameterArray, out rowsAffected);
      ZhiFang.Common.Log.Log.Debug("存储过程返回值:" + (object) num);
      return num > 0 ? true : true;
    }

    public string Update(RequestForm model)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("update RequestForm set ");
      if (model.StatusNo.HasValue)
        stringBuilder.Append("StatusNo=" + (object) model.StatusNo + ",");
      else
        stringBuilder.Append("StatusNo= null ,");
      if (model.SampleTypeNo.HasValue)
        stringBuilder.Append("SampleTypeNo=" + (object) model.SampleTypeNo + ",");
      else
        stringBuilder.Append("SampleTypeNo= null ,");
      if (model.PatNo != null)
        stringBuilder.Append("PatNo='" + model.PatNo + "',");
      else
        stringBuilder.Append("PatNo= null ,");
      if (model.CName != null)
        stringBuilder.Append("CName='" + model.CName + "',");
      else
        stringBuilder.Append("CName= null ,");
      if (model.GenderNo.HasValue)
        stringBuilder.Append("GenderNo=" + (object) model.GenderNo + ",");
      else
        stringBuilder.Append("GenderNo= null ,");
      if (model.Birthday.HasValue)
        stringBuilder.Append("Birthday='" + (object) model.Birthday + "',");
      else
        stringBuilder.Append("Birthday= null ,");
      if (model.Age.HasValue)
        stringBuilder.Append("Age=" + (object) model.Age + ",");
      else
        stringBuilder.Append("Age= null ,");
      if (model.AgeUnitNo.HasValue)
        stringBuilder.Append("AgeUnitNo=" + (object) model.AgeUnitNo + ",");
      else
        stringBuilder.Append("AgeUnitNo= null ,");
      if (model.FolkNo.HasValue)
        stringBuilder.Append("FolkNo=" + (object) model.FolkNo + ",");
      else
        stringBuilder.Append("FolkNo= null ,");
      if (model.DistrictNo.HasValue)
        stringBuilder.Append("DistrictNo=" + (object) model.DistrictNo + ",");
      else
        stringBuilder.Append("DistrictNo= null ,");
      if (model.WardNo.HasValue)
        stringBuilder.Append("WardNo=" + (object) model.WardNo + ",");
      else
        stringBuilder.Append("WardNo= null ,");
      if (model.Bed != null)
        stringBuilder.Append("Bed='" + model.Bed + "',");
      else
        stringBuilder.Append("Bed= null ,");
      if (model.DeptNo.HasValue)
        stringBuilder.Append("DeptNo=" + (object) model.DeptNo + ",");
      else
        stringBuilder.Append("DeptNo= null ,");
      if (model.Doctor != null)
        stringBuilder.Append("Doctor='" + model.Doctor + "',");
      else
        stringBuilder.Append("Doctor= null ,");
      if (model.ChargeNo.HasValue)
        stringBuilder.Append("ChargeNo=" + (object) model.ChargeNo + ",");
      else
        stringBuilder.Append("ChargeNo= null ,");
      if (model.Charge.HasValue)
        stringBuilder.Append("Charge=" + (object) model.Charge + ",");
      else
        stringBuilder.Append("Charge= null ,");
      if (model.Collecter != null)
        stringBuilder.Append("Collecter='" + model.Collecter + "',");
      else
        stringBuilder.Append("Collecter= null ,");
      if (model.CollectDate.HasValue)
        stringBuilder.Append("CollectDate='" + (object) model.CollectDate + "',");
      else
        stringBuilder.Append("CollectDate= null ,");
      if (model.CollectTime.HasValue)
        stringBuilder.Append("CollectTime='" + (object) model.CollectTime + "',");
      else
        stringBuilder.Append("CollectTime= null ,");
      if (model.inceptdate.HasValue)
        stringBuilder.Append("inceptdate='" + (object) model.inceptdate + "',");
      else
        stringBuilder.Append("inceptdate= null ,");
      if (model.incepttime.HasValue)
        stringBuilder.Append("incepttime='" + (object) model.incepttime + "',");
      else
        stringBuilder.Append("incepttime= null ,");
      if (model.incepter != null)
        stringBuilder.Append("incepter='" + model.incepter + "',");
      else
        stringBuilder.Append("incepter= null ,");
      if (model.SerialNo != null)
        stringBuilder.Append("SerialNo='" + model.SerialNo + "',");
      else
        stringBuilder.Append("SerialNo= null ,");
      if (model.RequestSource != null)
        stringBuilder.Append("RequestSource='" + model.RequestSource + "',");
      else
        stringBuilder.Append("RequestSource= null ,");
      if (model.DiagNo.HasValue)
        stringBuilder.Append("DiagNo=" + (object) model.DiagNo + ",");
      else
        stringBuilder.Append("DiagNo= null ,");
      if (model.Chargeflag != null)
        stringBuilder.Append("Chargeflag='" + model.Chargeflag + "',");
      else
        stringBuilder.Append("Chargeflag= null ,");
      if (model.SickTypeNo.HasValue)
        stringBuilder.Append("SickTypeNo=" + (object) model.SickTypeNo + ",");
      else
        stringBuilder.Append("SickTypeNo= null ,");
      if (model.clientno.HasValue)
        stringBuilder.Append("clientno=" + (object) model.clientno + ",");
      else
        stringBuilder.Append("clientno= null ,");
      if (model.isReceive.HasValue)
        stringBuilder.Append("isReceive=" + (object) model.isReceive + ",");
      else
        stringBuilder.Append("isReceive= null ,");
      if (model.ReceiveMan != null)
        stringBuilder.Append("ReceiveMan='" + model.ReceiveMan + "',");
      else
        stringBuilder.Append("ReceiveMan= null ,");
      if (model.ReceiveTime.HasValue)
        stringBuilder.Append("ReceiveTime='" + (object) model.ReceiveTime + "',");
      else
        stringBuilder.Append("ReceiveTime= null ,");
      if (model.CountNodesFormSource != null)
        stringBuilder.Append("CountNodesFormSource='" + model.CountNodesFormSource + "',");
      else
        stringBuilder.Append("CountNodesFormSource= null ,");
      if (model.UrgentState != null)
        stringBuilder.Append("UrgentState='" + model.UrgentState + "',");
      else
        stringBuilder.Append("UrgentState= null ,");
      if (model.phoneCode != null)
        stringBuilder.Append("phoneCode='" + model.phoneCode + "',");
      else
        stringBuilder.Append("phoneCode= null ,");
      if (model.Technician != null)
        stringBuilder.Append("Technician='" + model.Technician + "',");
      DateTime testDate = model.TestDate;
      bool flag = false;
      stringBuilder.Append("TestDate='" + (object) model.TestDate + "',");
      DateTime testTime = model.TestTime;
      flag = false;
      stringBuilder.Append("TestTime='" + (object) model.TestTime + "',");
      //if (model.Checker != null)
      //  stringBuilder.Append("Checker='" + model.Checker + "',");
      //DateTime checkDate = model.CheckDate;
      //flag = false;
      //stringBuilder.Append("CheckDate='" + (object) model.CheckDate + "',");
      //DateTime checkTime = model.CheckTime;
      //flag = false;
      //stringBuilder.Append("CheckTime='" + (object) model.CheckTime + "',");
      if (model.FormMemo != null)
        stringBuilder.Append("FormMemo='" + model.FormMemo + "',");
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
      if (model.zdy6 != null)
        stringBuilder.Append("zdy6='" + model.zdy6 + "',");
      else
        stringBuilder.Append("zdy6= null ,");
      if (model.zdy7 != null)
        stringBuilder.Append("zdy7='" + model.zdy7 + "',");
      else
        stringBuilder.Append("zdy7= null ,");
      if (model.zdy8 != null)
        stringBuilder.Append("zdy8='" + model.zdy8 + "',");
      else
        stringBuilder.Append("zdy8= null ,");
      if (model.zdy9 != null)
        stringBuilder.Append("zdy9='" + model.zdy9 + "',");
      else
        stringBuilder.Append("zdy9= null ,");
      if (model.zdy10 != null)
        stringBuilder.Append("zdy10='" + model.zdy10 + "',");
      else
        stringBuilder.Append("zdy10= null ,");
      if (model.zdy11 != null)
        stringBuilder.Append("zdy11='" + model.zdy11 + "',");
      else
        stringBuilder.Append("zdy11= null ,");
      if (model.zdy12 != null)
        stringBuilder.Append("zdy12='" + model.zdy12 + "',");
      else
        stringBuilder.Append("zdy12= null ,");
      if (model.zdy13 != null)
        stringBuilder.Append("zdy13='" + model.zdy13 + "',");
      else
        stringBuilder.Append("zdy13= null ,");
      if (model.zdy14 != null)
        stringBuilder.Append("zdy14='" + model.zdy14 + "',");
      else
        stringBuilder.Append("zdy14= null ,");
      if (model.zdy15 != null)
        stringBuilder.Append("zdy15='" + model.zdy15 + "',");
      else
        stringBuilder.Append("zdy15= null ,");
      if (model.zdy16 != null)
        stringBuilder.Append("zdy16='" + model.zdy16 + "',");
      else
        stringBuilder.Append("zdy16= null ,");
      if (model.zdy17 != null)
        stringBuilder.Append("zdy17='" + model.zdy17 + "',");
      else
        stringBuilder.Append("zdy17= null ,");
      if (model.zdy18 != null)
        stringBuilder.Append("zdy18='" + model.zdy18 + "',");
      else
        stringBuilder.Append("zdy18= null ,");
      if (model.zdy19 != null)
        stringBuilder.Append("zdy19='" + model.zdy19 + "',");
      else
        stringBuilder.Append("zdy19= null ,");
      if (model.zdy20 != null)
        stringBuilder.Append("zdy20='" + model.zdy20 + "',");
      else
        stringBuilder.Append("zdy20= null ,");
      int startIndex = stringBuilder.ToString().LastIndexOf(",");
      stringBuilder.Remove(startIndex, 1);
      stringBuilder.Append(" where ReceiveDate='" + (object) model.ReceiveDate + "' and SectionNo=" + (object) model.SectionNo + " and TestTypeNo=" + (object) model.TestTypeNo + " and SampleNo='" + model.SampleNo + "' ");
            return stringBuilder.ToString();
    }

    public bool Delete(DateTime ReceiveDate, int SectionNo, int TestTypeNo, string SampleNo)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("delete from RequestForm ");
      stringBuilder.Append(" where ReceiveDate=@ReceiveDate and SectionNo=@SectionNo and TestTypeNo=@TestTypeNo and SampleNo=@SampleNo ");
      SqlParameter[] sqlParameterArray = new SqlParameter[4]
      {
        new SqlParameter("@ReceiveDate", SqlDbType.DateTime),
        new SqlParameter("@SectionNo", SqlDbType.Int, 4),
        new SqlParameter("@TestTypeNo", SqlDbType.Int, 4),
        new SqlParameter("@SampleNo", SqlDbType.VarChar, 20)
      };
      sqlParameterArray[0].Value = (object) ReceiveDate;
      sqlParameterArray[1].Value = (object) SectionNo;
      sqlParameterArray[2].Value = (object) TestTypeNo;
      sqlParameterArray[3].Value = (object) SampleNo;
      return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), sqlParameterArray) > 0;
    }

    public RequestForm GetModel(DateTime ReceiveDate, int SectionNo, int TestTypeNo, string SampleNo)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("select  top 1 * from RequestForm ");
      stringBuilder.Append(" where ReceiveDate=@ReceiveDate and SectionNo=@SectionNo and TestTypeNo=@TestTypeNo and SampleNo=@SampleNo ");
      SqlParameter[] sqlParameterArray = new SqlParameter[4]
      {
        new SqlParameter("@ReceiveDate", SqlDbType.DateTime),
        new SqlParameter("@SectionNo", SqlDbType.Int, 4),
        new SqlParameter("@TestTypeNo", SqlDbType.Int, 4),
        new SqlParameter("@SampleNo", SqlDbType.VarChar, 20)
      };
      sqlParameterArray[0].Value = (object) ReceiveDate;
      sqlParameterArray[1].Value = (object) SectionNo;
      sqlParameterArray[2].Value = (object) TestTypeNo;
      sqlParameterArray[3].Value = (object) SampleNo;
      RequestForm requestForm = new RequestForm();
      DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), sqlParameterArray);
      if (dataSet.Tables[0].Rows.Count <= 0)
        return (RequestForm) null;
      if (dataSet.Tables[0].Rows[0]["ReceiveDate"] != null && dataSet.Tables[0].Rows[0]["ReceiveDate"].ToString() != "")
        requestForm.ReceiveDate = DateTime.Parse(dataSet.Tables[0].Rows[0]["ReceiveDate"].ToString());
      if (dataSet.Tables[0].Rows[0]["SectionNo"] != null && dataSet.Tables[0].Rows[0]["SectionNo"].ToString() != "")
        requestForm.SectionNo = int.Parse(dataSet.Tables[0].Rows[0]["SectionNo"].ToString());
      if (dataSet.Tables[0].Rows[0]["TestTypeNo"] != null && dataSet.Tables[0].Rows[0]["TestTypeNo"].ToString() != "")
        requestForm.TestTypeNo = int.Parse(dataSet.Tables[0].Rows[0]["TestTypeNo"].ToString());
      if (dataSet.Tables[0].Rows[0]["SampleNo"] != null && dataSet.Tables[0].Rows[0]["SampleNo"].ToString() != "")
        requestForm.SampleNo = dataSet.Tables[0].Rows[0]["SampleNo"].ToString();
      if (dataSet.Tables[0].Rows[0]["StatusNo"] != null && dataSet.Tables[0].Rows[0]["StatusNo"].ToString() != "")
        requestForm.StatusNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["StatusNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["SampleTypeNo"] != null && dataSet.Tables[0].Rows[0]["SampleTypeNo"].ToString() != "")
        requestForm.SampleTypeNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["SampleTypeNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["PatNo"] != null && dataSet.Tables[0].Rows[0]["PatNo"].ToString() != "")
        requestForm.PatNo = dataSet.Tables[0].Rows[0]["PatNo"].ToString();
      if (dataSet.Tables[0].Rows[0]["CName"] != null && dataSet.Tables[0].Rows[0]["CName"].ToString() != "")
        requestForm.CName = dataSet.Tables[0].Rows[0]["CName"].ToString();
      if (dataSet.Tables[0].Rows[0]["GenderNo"] != null && dataSet.Tables[0].Rows[0]["GenderNo"].ToString() != "")
        requestForm.GenderNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["GenderNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Birthday"] != null && dataSet.Tables[0].Rows[0]["Birthday"].ToString() != "")
        requestForm.Birthday = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["Birthday"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Age"] != null && dataSet.Tables[0].Rows[0]["Age"].ToString() != "")
        requestForm.Age = new Decimal?(Decimal.Parse(dataSet.Tables[0].Rows[0]["Age"].ToString()));
      if (dataSet.Tables[0].Rows[0]["AgeUnitNo"] != null && dataSet.Tables[0].Rows[0]["AgeUnitNo"].ToString() != "")
        requestForm.AgeUnitNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["AgeUnitNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["FolkNo"] != null && dataSet.Tables[0].Rows[0]["FolkNo"].ToString() != "")
        requestForm.FolkNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["FolkNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["DistrictNo"] != null && dataSet.Tables[0].Rows[0]["DistrictNo"].ToString() != "")
        requestForm.DistrictNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DistrictNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["WardNo"] != null && dataSet.Tables[0].Rows[0]["WardNo"].ToString() != "")
        requestForm.WardNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["WardNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Bed"] != null && dataSet.Tables[0].Rows[0]["Bed"].ToString() != "")
        requestForm.Bed = dataSet.Tables[0].Rows[0]["Bed"].ToString();
      if (dataSet.Tables[0].Rows[0]["DeptNo"] != null && dataSet.Tables[0].Rows[0]["DeptNo"].ToString() != "")
        requestForm.DeptNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Doctor"] != null && dataSet.Tables[0].Rows[0]["Doctor"].ToString() != "")
        requestForm.Doctor = dataSet.Tables[0].Rows[0]["Doctor"].ToString();
      if (dataSet.Tables[0].Rows[0]["ChargeNo"] != null && dataSet.Tables[0].Rows[0]["ChargeNo"].ToString() != "")
        requestForm.ChargeNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ChargeNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Charge"] != null && dataSet.Tables[0].Rows[0]["Charge"].ToString() != "")
        requestForm.Charge = new Decimal?(Decimal.Parse(dataSet.Tables[0].Rows[0]["Charge"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Collecter"] != null && dataSet.Tables[0].Rows[0]["Collecter"].ToString() != "")
        requestForm.Collecter = dataSet.Tables[0].Rows[0]["Collecter"].ToString();
      if (dataSet.Tables[0].Rows[0]["CollectDate"] != null && dataSet.Tables[0].Rows[0]["CollectDate"].ToString() != "")
        requestForm.CollectDate = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["CollectDate"].ToString()));
      if (dataSet.Tables[0].Rows[0]["CollectTime"] != null && dataSet.Tables[0].Rows[0]["CollectTime"].ToString() != "")
        requestForm.CollectTime = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["CollectTime"].ToString()));
      if (dataSet.Tables[0].Rows[0]["FormMemo"] != null && dataSet.Tables[0].Rows[0]["FormMemo"].ToString() != "")
        requestForm.FormMemo = dataSet.Tables[0].Rows[0]["FormMemo"].ToString();
      if (dataSet.Tables[0].Rows[0]["SerialNo"] != null && dataSet.Tables[0].Rows[0]["SerialNo"].ToString() != "")
        requestForm.SerialNo = dataSet.Tables[0].Rows[0]["SerialNo"].ToString();
      if (dataSet.Tables[0].Rows[0]["RequestSource"] != null && dataSet.Tables[0].Rows[0]["RequestSource"].ToString() != "")
        requestForm.RequestSource = dataSet.Tables[0].Rows[0]["RequestSource"].ToString();
      if (dataSet.Tables[0].Rows[0]["DiagNo"] != null && dataSet.Tables[0].Rows[0]["DiagNo"].ToString() != "")
        requestForm.DiagNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DiagNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Chargeflag"] != null && dataSet.Tables[0].Rows[0]["Chargeflag"].ToString() != "")
        requestForm.Chargeflag = dataSet.Tables[0].Rows[0]["Chargeflag"].ToString();
      if (dataSet.Tables[0].Rows[0]["zdy1"] != null && dataSet.Tables[0].Rows[0]["zdy1"].ToString() != "")
        requestForm.zdy1 = dataSet.Tables[0].Rows[0]["zdy1"].ToString();
      if (dataSet.Tables[0].Rows[0]["zdy2"] != null && dataSet.Tables[0].Rows[0]["zdy2"].ToString() != "")
        requestForm.zdy2 = dataSet.Tables[0].Rows[0]["zdy2"].ToString();
      if (dataSet.Tables[0].Rows[0]["zdy3"] != null && dataSet.Tables[0].Rows[0]["zdy3"].ToString() != "")
        requestForm.zdy3 = dataSet.Tables[0].Rows[0]["zdy3"].ToString();
      if (dataSet.Tables[0].Rows[0]["zdy4"] != null && dataSet.Tables[0].Rows[0]["zdy4"].ToString() != "")
        requestForm.zdy4 = dataSet.Tables[0].Rows[0]["zdy4"].ToString();
      if (dataSet.Tables[0].Rows[0]["zdy5"] != null && dataSet.Tables[0].Rows[0]["zdy5"].ToString() != "")
        requestForm.zdy5 = dataSet.Tables[0].Rows[0]["zdy5"].ToString();
      if (dataSet.Tables[0].Rows[0]["SickTypeNo"] != null && dataSet.Tables[0].Rows[0]["SickTypeNo"].ToString() != "")
        requestForm.SickTypeNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["SickTypeNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["inceptdate"] != null && dataSet.Tables[0].Rows[0]["inceptdate"].ToString() != "")
        requestForm.inceptdate = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["inceptdate"].ToString()));
      if (dataSet.Tables[0].Rows[0]["incepttime"] != null && dataSet.Tables[0].Rows[0]["incepttime"].ToString() != "")
        requestForm.incepttime = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["incepttime"].ToString()));
      if (dataSet.Tables[0].Rows[0]["incepter"] != null && dataSet.Tables[0].Rows[0]["incepter"].ToString() != "")
        requestForm.incepter = dataSet.Tables[0].Rows[0]["incepter"].ToString();
      if (dataSet.Tables[0].Rows[0]["clientno"] != null && dataSet.Tables[0].Rows[0]["clientno"].ToString() != "")
        requestForm.clientno = new int?(int.Parse(dataSet.Tables[0].Rows[0]["clientno"].ToString()));
      if (dataSet.Tables[0].Rows[0]["isReceive"] != null && dataSet.Tables[0].Rows[0]["isReceive"].ToString() != "")
        requestForm.isReceive = new int?(int.Parse(dataSet.Tables[0].Rows[0]["isReceive"].ToString()));
      if (dataSet.Tables[0].Rows[0]["ReceiveMan"] != null && dataSet.Tables[0].Rows[0]["ReceiveMan"].ToString() != "")
        requestForm.ReceiveMan = dataSet.Tables[0].Rows[0]["ReceiveMan"].ToString();
      if (dataSet.Tables[0].Rows[0]["ReceiveTime"] != null && dataSet.Tables[0].Rows[0]["ReceiveTime"].ToString() != "")
        requestForm.ReceiveTime = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["ReceiveTime"].ToString()));
      if (dataSet.Tables[0].Rows[0]["CountNodesFormSource"] != null && dataSet.Tables[0].Rows[0]["CountNodesFormSource"].ToString() != "")
        requestForm.CountNodesFormSource = dataSet.Tables[0].Rows[0]["CountNodesFormSource"].ToString();
      if (dataSet.Tables[0].Rows[0]["UrgentState"] != null && dataSet.Tables[0].Rows[0]["UrgentState"].ToString() != "")
        requestForm.UrgentState = dataSet.Tables[0].Rows[0]["UrgentState"].ToString();
      if (dataSet.Tables[0].Rows[0]["ZDY6"] != null && dataSet.Tables[0].Rows[0]["ZDY6"].ToString() != "")
        requestForm.zdy6 = dataSet.Tables[0].Rows[0]["ZDY6"].ToString();
      if (dataSet.Tables[0].Rows[0]["ZDY7"] != null && dataSet.Tables[0].Rows[0]["ZDY7"].ToString() != "")
        requestForm.zdy7 = dataSet.Tables[0].Rows[0]["ZDY7"].ToString();
      if (dataSet.Tables[0].Rows[0]["ZDY8"] != null && dataSet.Tables[0].Rows[0]["ZDY8"].ToString() != "")
        requestForm.zdy8 = dataSet.Tables[0].Rows[0]["ZDY8"].ToString();
      if (dataSet.Tables[0].Rows[0]["ZDY9"] != null && dataSet.Tables[0].Rows[0]["ZDY9"].ToString() != "")
        requestForm.zdy9 = dataSet.Tables[0].Rows[0]["ZDY9"].ToString();
      if (dataSet.Tables[0].Rows[0]["ZDY10"] != null && dataSet.Tables[0].Rows[0]["ZDY10"].ToString() != "")
        requestForm.zdy10 = dataSet.Tables[0].Rows[0]["ZDY10"].ToString();
      if (dataSet.Tables[0].Rows[0]["phoneCode"] != null && dataSet.Tables[0].Rows[0]["phoneCode"].ToString() != "")
        requestForm.phoneCode = dataSet.Tables[0].Rows[0]["phoneCode"].ToString();
      if (dataSet.Tables[0].Rows[0]["Technician"] != null && dataSet.Tables[0].Rows[0]["Technician"].ToString() != "")
        requestForm.Technician = dataSet.Tables[0].Rows[0]["Technician"].ToString();
      if (dataSet.Tables[0].Rows[0]["TestDate"] != null && dataSet.Tables[0].Rows[0]["TestDate"].ToString() != "")
        requestForm.TestDate = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["TestDate"].ToString());
      if (dataSet.Tables[0].Rows[0]["TestTime"] != null && dataSet.Tables[0].Rows[0]["TestTime"].ToString() != "")
        requestForm.TestTime = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["TestTime"].ToString());
      if (dataSet.Tables[0].Rows[0]["Checker"] != null && dataSet.Tables[0].Rows[0]["Checker"].ToString() != "")
        requestForm.Checker = dataSet.Tables[0].Rows[0]["Checker"].ToString();
      if (dataSet.Tables[0].Rows[0]["CheckDate"] != null && dataSet.Tables[0].Rows[0]["CheckDate"].ToString() != "")
        requestForm.CheckDate = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["CheckDate"].ToString());
      if (dataSet.Tables[0].Rows[0]["CheckTime"] != null && dataSet.Tables[0].Rows[0]["CheckTime"].ToString() != "")
        requestForm.CheckTime = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["CheckTime"].ToString());
      return requestForm;
    }

    public RequestForm GetModel(string SerialNo)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("select  top 1 * from RequestForm ");
      stringBuilder.Append(" where SerialNo=@SerialNo ");
      SqlParameter[] sqlParameterArray = new SqlParameter[1]
      {
        new SqlParameter("@SerialNo", SqlDbType.VarChar, 100)
      };
      sqlParameterArray[0].Value = (object) SerialNo;
      RequestForm requestForm = new RequestForm();
      DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), sqlParameterArray);
      if (dataSet.Tables[0].Rows.Count <= 0)
        return (RequestForm) null;
      if (dataSet.Tables[0].Rows[0]["ReceiveDate"] != null && dataSet.Tables[0].Rows[0]["ReceiveDate"].ToString() != "")
        requestForm.ReceiveDate = DateTime.Parse(dataSet.Tables[0].Rows[0]["ReceiveDate"].ToString());
      if (dataSet.Tables[0].Rows[0]["SectionNo"] != null && dataSet.Tables[0].Rows[0]["SectionNo"].ToString() != "")
        requestForm.SectionNo = int.Parse(dataSet.Tables[0].Rows[0]["SectionNo"].ToString());
      if (dataSet.Tables[0].Rows[0]["TestTypeNo"] != null && dataSet.Tables[0].Rows[0]["TestTypeNo"].ToString() != "")
        requestForm.TestTypeNo = int.Parse(dataSet.Tables[0].Rows[0]["TestTypeNo"].ToString());
      if (dataSet.Tables[0].Rows[0]["SampleNo"] != null && dataSet.Tables[0].Rows[0]["SampleNo"].ToString() != "")
        requestForm.SampleNo = dataSet.Tables[0].Rows[0]["SampleNo"].ToString();
      if (dataSet.Tables[0].Rows[0]["StatusNo"] != null && dataSet.Tables[0].Rows[0]["StatusNo"].ToString() != "")
        requestForm.StatusNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["StatusNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["SampleTypeNo"] != null && dataSet.Tables[0].Rows[0]["SampleTypeNo"].ToString() != "")
        requestForm.SampleTypeNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["SampleTypeNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["PatNo"] != null && dataSet.Tables[0].Rows[0]["PatNo"].ToString() != "")
        requestForm.PatNo = dataSet.Tables[0].Rows[0]["PatNo"].ToString();
      if (dataSet.Tables[0].Rows[0]["CName"] != null && dataSet.Tables[0].Rows[0]["CName"].ToString() != "")
        requestForm.CName = dataSet.Tables[0].Rows[0]["CName"].ToString();
      if (dataSet.Tables[0].Rows[0]["GenderNo"] != null && dataSet.Tables[0].Rows[0]["GenderNo"].ToString() != "")
        requestForm.GenderNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["GenderNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Birthday"] != null && dataSet.Tables[0].Rows[0]["Birthday"].ToString() != "")
        requestForm.Birthday = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["Birthday"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Age"] != null && dataSet.Tables[0].Rows[0]["Age"].ToString() != "")
        requestForm.Age = new Decimal?(Decimal.Parse(dataSet.Tables[0].Rows[0]["Age"].ToString()));
      if (dataSet.Tables[0].Rows[0]["AgeUnitNo"] != null && dataSet.Tables[0].Rows[0]["AgeUnitNo"].ToString() != "")
        requestForm.AgeUnitNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["AgeUnitNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["FolkNo"] != null && dataSet.Tables[0].Rows[0]["FolkNo"].ToString() != "")
        requestForm.FolkNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["FolkNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["DistrictNo"] != null && dataSet.Tables[0].Rows[0]["DistrictNo"].ToString() != "")
        requestForm.DistrictNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DistrictNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["WardNo"] != null && dataSet.Tables[0].Rows[0]["WardNo"].ToString() != "")
        requestForm.WardNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["WardNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Bed"] != null && dataSet.Tables[0].Rows[0]["Bed"].ToString() != "")
        requestForm.Bed = dataSet.Tables[0].Rows[0]["Bed"].ToString();
      if (dataSet.Tables[0].Rows[0]["DeptNo"] != null && dataSet.Tables[0].Rows[0]["DeptNo"].ToString() != "")
        requestForm.DeptNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Doctor"] != null && dataSet.Tables[0].Rows[0]["Doctor"].ToString() != "")
        requestForm.Doctor = dataSet.Tables[0].Rows[0]["Doctor"].ToString();
      if (dataSet.Tables[0].Rows[0]["ChargeNo"] != null && dataSet.Tables[0].Rows[0]["ChargeNo"].ToString() != "")
        requestForm.ChargeNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ChargeNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Charge"] != null && dataSet.Tables[0].Rows[0]["Charge"].ToString() != "")
        requestForm.Charge = new Decimal?(Decimal.Parse(dataSet.Tables[0].Rows[0]["Charge"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Collecter"] != null && dataSet.Tables[0].Rows[0]["Collecter"].ToString() != "")
        requestForm.Collecter = dataSet.Tables[0].Rows[0]["Collecter"].ToString();
      if (dataSet.Tables[0].Rows[0]["CollectDate"] != null && dataSet.Tables[0].Rows[0]["CollectDate"].ToString() != "")
        requestForm.CollectDate = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["CollectDate"].ToString()));
      if (dataSet.Tables[0].Rows[0]["CollectTime"] != null && dataSet.Tables[0].Rows[0]["CollectTime"].ToString() != "")
        requestForm.CollectTime = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["CollectTime"].ToString()));
      if (dataSet.Tables[0].Rows[0]["FormMemo"] != null && dataSet.Tables[0].Rows[0]["FormMemo"].ToString() != "")
        requestForm.FormMemo = dataSet.Tables[0].Rows[0]["FormMemo"].ToString();
      if (dataSet.Tables[0].Rows[0]["SerialNo"] != null && dataSet.Tables[0].Rows[0]["SerialNo"].ToString() != "")
        requestForm.SerialNo = dataSet.Tables[0].Rows[0]["SerialNo"].ToString();
      if (dataSet.Tables[0].Rows[0]["RequestSource"] != null && dataSet.Tables[0].Rows[0]["RequestSource"].ToString() != "")
        requestForm.RequestSource = dataSet.Tables[0].Rows[0]["RequestSource"].ToString();
      if (dataSet.Tables[0].Rows[0]["DiagNo"] != null && dataSet.Tables[0].Rows[0]["DiagNo"].ToString() != "")
        requestForm.DiagNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DiagNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["Chargeflag"] != null && dataSet.Tables[0].Rows[0]["Chargeflag"].ToString() != "")
        requestForm.Chargeflag = dataSet.Tables[0].Rows[0]["Chargeflag"].ToString();
      if (dataSet.Tables[0].Rows[0]["zdy1"] != null && dataSet.Tables[0].Rows[0]["zdy1"].ToString() != "")
        requestForm.zdy1 = dataSet.Tables[0].Rows[0]["zdy1"].ToString();
      if (dataSet.Tables[0].Rows[0]["zdy2"] != null && dataSet.Tables[0].Rows[0]["zdy2"].ToString() != "")
        requestForm.zdy2 = dataSet.Tables[0].Rows[0]["zdy2"].ToString();
      if (dataSet.Tables[0].Rows[0]["zdy3"] != null && dataSet.Tables[0].Rows[0]["zdy3"].ToString() != "")
        requestForm.zdy3 = dataSet.Tables[0].Rows[0]["zdy3"].ToString();
      if (dataSet.Tables[0].Rows[0]["zdy4"] != null && dataSet.Tables[0].Rows[0]["zdy4"].ToString() != "")
        requestForm.zdy4 = dataSet.Tables[0].Rows[0]["zdy4"].ToString();
      if (dataSet.Tables[0].Rows[0]["zdy5"] != null && dataSet.Tables[0].Rows[0]["zdy5"].ToString() != "")
        requestForm.zdy5 = dataSet.Tables[0].Rows[0]["zdy5"].ToString();
      if (dataSet.Tables[0].Rows[0]["SickTypeNo"] != null && dataSet.Tables[0].Rows[0]["SickTypeNo"].ToString() != "")
        requestForm.SickTypeNo = new int?(int.Parse(dataSet.Tables[0].Rows[0]["SickTypeNo"].ToString()));
      if (dataSet.Tables[0].Rows[0]["inceptdate"] != null && dataSet.Tables[0].Rows[0]["inceptdate"].ToString() != "")
        requestForm.inceptdate = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["inceptdate"].ToString()));
      if (dataSet.Tables[0].Rows[0]["incepttime"] != null && dataSet.Tables[0].Rows[0]["incepttime"].ToString() != "")
        requestForm.incepttime = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["incepttime"].ToString()));
      if (dataSet.Tables[0].Rows[0]["incepter"] != null && dataSet.Tables[0].Rows[0]["incepter"].ToString() != "")
        requestForm.incepter = dataSet.Tables[0].Rows[0]["incepter"].ToString();
      if (dataSet.Tables[0].Rows[0]["clientno"] != null && dataSet.Tables[0].Rows[0]["clientno"].ToString() != "")
        requestForm.clientno = new int?(int.Parse(dataSet.Tables[0].Rows[0]["clientno"].ToString()));
      if (dataSet.Tables[0].Rows[0]["isReceive"] != null && dataSet.Tables[0].Rows[0]["isReceive"].ToString() != "")
        requestForm.isReceive = new int?(int.Parse(dataSet.Tables[0].Rows[0]["isReceive"].ToString()));
      if (dataSet.Tables[0].Rows[0]["ReceiveMan"] != null && dataSet.Tables[0].Rows[0]["ReceiveMan"].ToString() != "")
        requestForm.ReceiveMan = dataSet.Tables[0].Rows[0]["ReceiveMan"].ToString();
      if (dataSet.Tables[0].Rows[0]["ReceiveTime"] != null && dataSet.Tables[0].Rows[0]["ReceiveTime"].ToString() != "")
        requestForm.ReceiveTime = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["ReceiveTime"].ToString()));
      if (dataSet.Tables[0].Rows[0]["CountNodesFormSource"] != null && dataSet.Tables[0].Rows[0]["CountNodesFormSource"].ToString() != "")
        requestForm.CountNodesFormSource = dataSet.Tables[0].Rows[0]["CountNodesFormSource"].ToString();
      if (dataSet.Tables[0].Rows[0]["UrgentState"] != null && dataSet.Tables[0].Rows[0]["UrgentState"].ToString() != "")
        requestForm.UrgentState = dataSet.Tables[0].Rows[0]["UrgentState"].ToString();
      if (dataSet.Tables[0].Rows[0]["ZDY6"] != null && dataSet.Tables[0].Rows[0]["ZDY6"].ToString() != "")
        requestForm.zdy6 = dataSet.Tables[0].Rows[0]["ZDY6"].ToString();
      if (dataSet.Tables[0].Rows[0]["ZDY7"] != null && dataSet.Tables[0].Rows[0]["ZDY7"].ToString() != "")
        requestForm.zdy7 = dataSet.Tables[0].Rows[0]["ZDY7"].ToString();
      if (dataSet.Tables[0].Rows[0]["ZDY8"] != null && dataSet.Tables[0].Rows[0]["ZDY8"].ToString() != "")
        requestForm.zdy8 = dataSet.Tables[0].Rows[0]["ZDY8"].ToString();
      if (dataSet.Tables[0].Rows[0]["ZDY9"] != null && dataSet.Tables[0].Rows[0]["ZDY9"].ToString() != "")
        requestForm.zdy9 = dataSet.Tables[0].Rows[0]["ZDY9"].ToString();
      if (dataSet.Tables[0].Rows[0]["ZDY10"] != null && dataSet.Tables[0].Rows[0]["ZDY10"].ToString() != "")
        requestForm.zdy10 = dataSet.Tables[0].Rows[0]["ZDY10"].ToString();
      if (dataSet.Tables[0].Rows[0]["phoneCode"] != null && dataSet.Tables[0].Rows[0]["phoneCode"].ToString() != "")
        requestForm.phoneCode = dataSet.Tables[0].Rows[0]["phoneCode"].ToString();
      return requestForm;
    }

    public DataSet GetList(string strWhere)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("select * ");
      stringBuilder.Append(" FROM RequestForm ");
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
      stringBuilder.Append(" FROM RequestForm ");
      if (strWhere.Trim() != "")
        stringBuilder.Append(" where " + strWhere);
      stringBuilder.Append(" order by " + filedOrder);
      return DbHelperSQL.Query(stringBuilder.ToString());
    }

    public static DataSet GetRequestFormData(string receivedate, string sectionno, string testtypeno, string sampleno)
    {
      string str = "  2>1 ";
      if (receivedate != "")
        str = str + " and receivedate ='" + receivedate + "'";
      if (testtypeno != "")
        str = str + " and testtypeno =" + testtypeno;
      if (sectionno != "")
        str = str + " and sectionno =" + sectionno;
      if (sampleno != "")
        str = str + " and sampleno ='" + sampleno + "'";
      return DbHelperSQL.Query(string.Format("select * from RequestForm where {0}", (object) str));
    }
    public static string GetMaxSampleNo(string ReceiveDate, int SectionNo, int TestTypeNo)
    {
      try
      {
        DataSet dataSet = DbHelperSQL.Query(string.Format(" select SampleNo, len(SampleNo) as SampleIndex from RequestForm where ReceiveDate='{2}' and  TestTypeNo={1} and SectionNo={0} union  select SampleNo, len(SampleNo) as SampleIndex from ReportForm where ReceiveDate='{2}' and TestTypeNo={1} and SectionNo={0} order by SampleIndex desc, SampleNo desc", (object) SectionNo, (object) TestTypeNo, (object) ReceiveDate));
        if (dataSet == null || dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0)
          return "0";
        return dataSet.Tables[0].Rows[0]["SampleNo"].ToString();
      }
      catch
      {
        return "0";
      }
    }

    public static DataTable GetOrderInfoFromREAndRF(string SerialNo)
    {
      try
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("select SerialNo,RequestForm.SectionNo,SampleNo,PGroup.CName as SectionName from RequestForm ");
        stringBuilder.Append("left join PGroup on RequestForm.SectionNo=PGroup.SectionNo ");
        stringBuilder.Append(string.Format("where SerialNo='{0}' ", (object) SerialNo));
        stringBuilder.Append("union ");
        stringBuilder.Append("select SerialNo,ReportForm.SectionNo,SampleNo,PGroup.CName as SectionName from ReportForm ");
        stringBuilder.Append("left join PGroup on ReportForm.SectionNo=PGroup.SectionNo ");
        stringBuilder.Append(string.Format("where SerialNo='{0}' ", (object) SerialNo));
        DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString());
        ZhiFang.Common.Log.Log.Info("查询条码是否存在于RequestForm和ReportForm表：" + stringBuilder.ToString());
        if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
          return dataSet.Tables[0];
      }
      catch
      {
      }
      return (DataTable) null;
    }


    public int UpdateColorFlag(string ReceiveDate, string SectionNo, string TestTypeNo, string SampleNo, string CountNodesFormSource)
    {
      string SQLString = string.Format("update RequestForm set CountNodesFormSource='{0}' where ReceiveDate='{1}' and  SectionNo={2} and TestTypeNo='{3}' and SampleNo='{4}'", (object) CountNodesFormSource, (object) ReceiveDate, (object) SectionNo, (object) TestTypeNo, (object) SampleNo);
      int num = DbHelperSQL.ExecuteSql(SQLString);
      ZhiFang.Common.Log.Log.Info("打计费颜色标志，执行更新语句:" + SQLString);
      return num;
    }
  }
}
