// Decompiled with JetBrains decompiler
// Type: LIS.DAL.DataConn
// Assembly: LIS.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3C3145E9-0DCB-4480-8ABE-4B46074D1269
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\LIS.DAL.dll

using ZhiFang.DBUtility;

namespace LIS.DAL
{
  public class DataConn
  {
    public static string DefaultConnName
    {
      get
      {
        return "LISDB";
      }
    }

    public static IDBConnection CreateDB(string connname)
    {
      return DBFactory.CreateDB(connname);
    }

    public static IDBConnection CreateLisDB()
    {
      return DataConn.CreateDB(DataConn.DefaultConnName);
    }

    public static IDBConnection CreateHisDB(string connname)
    {
      return DataConn.CreateDB(connname);
    }

    public static bool CheckConn(string connname)
    {
      return DBFactory.CheckConn(connname);
    }

    public static bool CheckLisConn()
    {
      return DBFactory.CheckConn(DataConn.DefaultConnName);
    }
  }
}
