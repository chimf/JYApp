// Decompiled with JetBrains decompiler
// Type: LIS.Model.IModel
// Assembly: LIS.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E5DBE903-696A-4217-96C9-751E663D78F1
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\LIS.Model.dll

using System;
using System.Data;

namespace LIS.Model
{
  public class IModel : IDisposable
  {
    internal static string lisdbname = "LISDB";

    public static bool CheckDataSet(DataSet ds)
    {
      return ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0;
    }

    public void Dispose()
    {
      GC.SuppressFinalize((object) this);
    }
  }
}
