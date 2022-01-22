// Decompiled with JetBrains decompiler
// Type: LIS.Model.Entity.RequestForm
// Assembly: LIS.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E5DBE903-696A-4217-96C9-751E663D78F1
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\LIS.Model.dll

using System;

namespace LIS.Model.Entity
{
  [Serializable]
  public class RequestForm
  {
    public DateTime ReceiveDate { get; set; }

    public int SectionNo { get; set; }

    public int TestTypeNo { get; set; }

    public string SampleNo { get; set; }

    public int? StatusNo { get; set; }

    public int? SampleTypeNo { get; set; }

    public string PatNo { get; set; }

    public string CName { get; set; }

    public int? GenderNo { get; set; }

    public DateTime? Birthday { get; set; }

    public Decimal? Age { get; set; }

    public int? AgeUnitNo { get; set; }

    public int? FolkNo { get; set; }

    public int? DistrictNo { get; set; }

    public int? WardNo { get; set; }

    public string Bed { get; set; }

    public int? DeptNo { get; set; }

    public string Doctor { get; set; }

    public int? ChargeNo { get; set; }

    public Decimal? Charge { get; set; }

    public string Collecter { get; set; }

    public DateTime? CollectDate { get; set; }

    public DateTime? CollectTime { get; set; }

    public string FormMemo { get; set; }

    public int? SickTypeNo { get; set; }

    public string SerialNo { get; set; }

    public string RequestSource { get; set; }

    public int? DiagNo { get; set; }

    public string Chargeflag { get; set; }

    public DateTime? inceptdate { get; set; }

    public DateTime? incepttime { get; set; }

    public string incepter { get; set; }

    public int? clientno { get; set; }

    public int? isReceive { get; set; }

    public string ReceiveMan { get; set; }

    public DateTime? ReceiveTime { get; set; }

    public string CountNodesFormSource { get; set; }

    public string UrgentState { get; set; }

    public string zdy1 { get; set; }

    public string zdy2 { get; set; }

    public string zdy3 { get; set; }

    public string zdy4 { get; set; }

    public string zdy5 { get; set; }

    public string zdy6 { get; set; }

    public string zdy7 { get; set; }

    public string zdy8 { get; set; }

    public string zdy9 { get; set; }

    public string zdy10 { get; set; }

    public string zdy11 { get; set; }

    public string zdy12 { get; set; }

    public string zdy13 { get; set; }

    public string zdy14 { get; set; }

    public string zdy15 { get; set; }

    public string zdy16 { get; set; }

    public string zdy17 { get; set; }

    public string zdy18 { get; set; }

    public string zdy19 { get; set; }

    public string zdy20 { get; set; }

    public string phoneCode { get; set; }

    public string Operator { get; set; }

    public string Technician { get; set; }

    public string Checker { get; set; }

    public DateTime TestTime { get; set; }

    public DateTime TestDate { get; set; }

    public DateTime CheckTime { get; set; }

    public DateTime CheckDate { get; set; }

    public string ZDY6 { get; set; }

    public string ZDY7 { get; set; }

    public string ZDY8 { get; set; }

    public string ZDY9 { get; set; }

    public string ZDY10 { get; set; }
  }
}
