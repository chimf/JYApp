// Decompiled with JetBrains decompiler
// Type: ZhiFang.DBUtility.DBFactory
// Assembly: ZhiFang.DBUtility, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A64D088-E8A1-4CC0-BA12-6E7588D35C96
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\ZhiFang.DBUtility.dll

using System;
using System.Configuration;
using System.Data.SQLite;
using System.Web;
using System.Web.Configuration;
using ZhiFang.DBUtility.Enums;
using ZhiFang.DBUtility.ExceptionManage;

namespace ZhiFang.DBUtility
{
  public class DBFactory
  {
    public static IDBConnection CreateDB(string connString, DBDriverType dbDriverType)
    {
      return DBFactory.CreateDB(connString, dbDriverType, false);
    }

    public static IDBConnection CreateDB(string connString, DBDriverType dbDriverType, bool isEncrypt)
    {
      if (connString == null || connString == "")
        throw new SQLErrorException("ConnectionString参数为空,请修改配置");
      IDBConnection idbConnection = null;
      if (isEncrypt)
        connString = DES.DecryptDES(connString);
      switch (dbDriverType)
      {
        case DBDriverType.MSSql:
          idbConnection = (IDBConnection) new SQLHelper(connString);
           break;
        case DBDriverType.OleDB:
          idbConnection = (IDBConnection) new OleDbHelper(connString);
          break;
         case DBDriverType.Odbc:
          idbConnection = (IDBConnection) new OdbcHelper(connString);
          break;
        case DBDriverType.SyBase:
          return idbConnection;
        case DBDriverType.MySql:
          idbConnection = (IDBConnection) new MySqlHelper(connString);
          break;
        case DBDriverType.Oracle:
          idbConnection = (IDBConnection) new OracleHelper(connString);
          break;
        case DBDriverType.SQLite:
          idbConnection = (IDBConnection)new SqliteHelper(connString);
          break;
        default:
          idbConnection = (IDBConnection) new OleDbHelper(connString);
          break;
      }
      return idbConnection;
    }

    public static IDBConnection CreateDB(string connName, bool isEncrypt)
    {
      ConnectionStringSettings connectionString = (HttpContext.Current == null ? ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) : WebConfigurationManager.OpenWebConfiguration("~")).ConnectionStrings.ConnectionStrings[connName];
      if (connectionString == null)
        throw new ConfigErrorException("config文件connectionStrings节点中不存在数据连接名称" + connName);
      IDBConnection db;
      if (connectionString.ProviderName.Split('|').Length > 1)
      {
        DBDriverType dbDriverType = (DBDriverType) Enum.Parse(typeof (DBDriverType), connectionString.ProviderName.Split('|')[1].ToString().Trim());
        db = DBFactory.CreateDB(connectionString.ConnectionString, dbDriverType, isEncrypt);
      }
      else
        db = DBFactory.CreateDB(connectionString.ConnectionString, DBDriverType.MSSql, isEncrypt);
      return db;
    }

    public static IDBConnection CreateDB(string connName)
    {
      return DBFactory.CreateDB(connName, false);
    }

    public static bool CheckConn(string connName)
    {
      return DBFactory.CreateDB(connName).TestConnection();
    }
  }
}
