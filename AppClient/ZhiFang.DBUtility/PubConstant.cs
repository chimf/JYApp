// Decompiled with JetBrains decompiler
// Type: ZhiFang.DBUtility.PubConstant
// Assembly: ZhiFang.DBUtility, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A64D088-E8A1-4CC0-BA12-6E7588D35C96
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\ZhiFang.DBUtility.dll

using System.Configuration;
using System.Web;
using System.Web.Configuration;

namespace ZhiFang.DBUtility
{
  public class PubConstant
  {
    public static string ConnectionString
    {
      get
      {
        return PubConstant.GetConnectionString("LISDB");
      }
    }

    public static string GetConnectionString(string configName)
    {
      string str = "";
      ConnectionStringSettings connectionString = (HttpContext.Current == null ? ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) : WebConfigurationManager.OpenWebConfiguration("~")).ConnectionStrings.ConnectionStrings["LISDB"];
      if (connectionString != null)
        str = connectionString.ConnectionString;
      return str;
    }
  }
}
