// Decompiled with JetBrains decompiler
// Type: ZhiFang.DBUtility.IDBConnection
// Assembly: ZhiFang.DBUtility, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A64D088-E8A1-4CC0-BA12-6E7588D35C96
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\ZhiFang.DBUtility.dll

using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace ZhiFang.DBUtility
{
  public abstract class IDBConnection : IDisposable
  {
    public abstract string ConnectionString { get; }

    public abstract ConnectionState ConnectionState { get; }

    public abstract bool TestConnection(out string strErr);

    public abstract bool TestConnection();

    public abstract void BeginTransaction();

    public abstract void CommitTransaction();

    public abstract void RollbackTransaction();

    public abstract IDataReader ExecuteReader(string strSql);

    public abstract DataSet ExecuteDataSet(string strSql);

    public abstract int ExecuteNonQuery(string strSql);

    public abstract int ExecCount(string tableName, string whereClause);

    public abstract string ExecuteScalar(string strSql);

    public abstract DataSet GetDataTableSchema(string strSql);

    public abstract DataSet ExecSQLToMultiPages(string strSql, int nowPageNum, int nowPageSize, out int realRowNum);

    public abstract void BatchUpdateWithoutTransaction(ArrayList arrSql);

    public abstract void BatchUpdateWithTransaction(ArrayList arrSql);

    public abstract int ExecStoredProcedure(string cmdText, DbParameter[] cmdParms);

    public abstract DbParameterCollection ExecStoredProcedure(string cmdText, DbParameterCollection dbc);

    public abstract DataSet ExecDataSetStoredProcedure(string cmdText, DbParameter[] cmdParms);

    public abstract DbParameterCollection DeriveParameters(string cmdText);

    public abstract DataSet ExecDataSetStoredProcedure(string cmdText, DbParameterCollection dbc);

    public void Dispose()
    {
      GC.SuppressFinalize((object) this);
    }

        public static explicit operator IDBConnection(SQLiteConnection v)
        {
            throw new NotImplementedException();
        }
    }
}
