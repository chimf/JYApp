// Decompiled with JetBrains decompiler
// Type: ZhiFang.DBUtility.OleDbHelper
// Assembly: ZhiFang.DBUtility, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A64D088-E8A1-4CC0-BA12-6E7588D35C96
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\ZhiFang.DBUtility.dll

using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using ZhiFang.DBUtility.ExceptionManage;

namespace ZhiFang.DBUtility
{
  internal class OleDbHelper : IDBConnection
  {
    private OleDbConnection DBConn;
    private OleDbTransaction DBTran;
    private bool inTransaction;
    private string ConnectionStr;

    public override string ConnectionString
    {
      get
      {
        return this.ConnectionStr;
      }
    }

    public override ConnectionState ConnectionState
    {
      get
      {
        return this.DBConn.State;
      }
    }

    public OleDbConnection getConnection
    {
      get
      {
        return this.DBConn;
      }
    }

    public OleDbHelper(string connStr)
    {
      this.ConnectionStr = connStr;
      this.DBConn = new OleDbConnection(connStr);
    }

    protected void Open()
    {
      try
      {
        if (this.DBConn.State == ConnectionState.Open)
          return;
        this.DBConn.Open();
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("打开数据库连接失败，连接字符串" + this.ConnectionStr + ",错误：" + (object) ex);
      }
    }

    protected void Close()
    {
      try
      {
        if (this.DBConn.State == ConnectionState.Closed)
          return;
        this.DBConn.Close();
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("关闭数据库连接失败," + (object) ex);
      }
    }

    public override bool TestConnection(out string strErr)
    {
      strErr = string.Empty;
      try
      {
        if (this.DBConn.State != ConnectionState.Open)
          this.DBConn.Open();
        return true;
      }
      catch (Exception ex)
      {
        strErr = ex.Message;
        return false;
      }
      finally
      {
        if (this.DBConn.State != ConnectionState.Closed)
          this.DBConn.Close();
      }
    }

    public override bool TestConnection()
    {
      try
      {
        if (this.DBConn.State != ConnectionState.Open)
          this.DBConn.Open();
        return true;
      }
      catch (Exception ex)
      {
        throw new DBErrorException("OleDbHelper.cs->TestConnection()->数据库连接失败，连接参数为" + this.DBConn.ConnectionString + ",错误信息：" + ex.Message, ex);
      }
      finally
      {
        if (this.DBConn.State != ConnectionState.Closed)
          this.DBConn.Close();
      }
    }

    public override void BeginTransaction()
    {
      try
      {
        this.DBTran = this.DBConn.BeginTransaction();
        this.inTransaction = true;
      }
      catch (Exception ex)
      {
        this.inTransaction = false;
        throw new SQLErrorException("开始事务失败," + (object) ex);
      }
    }

    public override void CommitTransaction()
    {
      try
      {
        if (!this.inTransaction)
          return;
        this.DBTran.Commit();
        this.inTransaction = false;
      }
      catch (Exception ex)
      {
        this.inTransaction = false;
        throw new SQLErrorException("提交事务失败," + (object) ex);
      }
    }

    public override void RollbackTransaction()
    {
      try
      {
        if (!this.inTransaction)
          return;
        this.DBTran.Rollback();
        this.inTransaction = false;
      }
      catch (Exception ex)
      {
        this.inTransaction = false;
        throw new SQLErrorException("回滚事务失败," + (object) ex);
      }
    }

    public override IDataReader ExecuteReader(string strSql)
    {
      IDataReader dataReader = (IDataReader) null;
      try
      {
        OleDbCommand oleDbCommand = new OleDbCommand(strSql, this.DBConn);
        this.Open();
        dataReader = (IDataReader) oleDbCommand.ExecuteReader();
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("OleDbHelper.cs->ExecuteReader()->执行sql语句错误，Sql语句：" + strSql + ",错误：" + ex.Message, ex);
      }
      finally
      {
        this.Close();
      }
      return dataReader;
    }

    public override DataSet ExecuteDataSet(string strSql)
    {
      DataSet dataSet = new DataSet();
      try
      {
        this.Open();
        new OleDbDataAdapter(strSql, this.DBConn).Fill(dataSet, "ds");
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("OleDbHelper.cs->ExecuteDataSet()->执行sql语句错误，Sql语句：" + strSql + ",错误：" + ex.Message, ex);
      }
      finally
      {
        this.Close();
      }
      return dataSet;
    }

    public override int ExecuteNonQuery(string strSql)
    {
      int num = 0;
      try
      {
        this.Open();
        num = new OleDbCommand(strSql, this.DBConn).ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("OleDbHelper.cs->ExecuteNonQuery()->执行sql语句错误，Sql语句：" + strSql + ",错误：" + ex.Message, ex);
      }
      finally
      {
        this.Close();
      }
      return num;
    }

    public override int ExecCount(string tableName, string whereClause)
    {
      int num = 0;
      if (whereClause.Trim().Length != 0)
        whereClause = " where " + whereClause;
      string cmdText = "select count(*) from " + tableName + whereClause;
      try
      {
        this.Open();
        object objA = new OleDbCommand(cmdText, this.DBConn).ExecuteScalar();
        if (object.Equals(objA, (object) null) || object.Equals(objA, (object) DBNull.Value))
          return 0;
        num = (int) objA;
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("OleDbHelper.cs->ExecuteDataSet()->执行sql语句错误，Sql语句：" + cmdText + ",错误：" + ex.Message, ex);
      }
      finally
      {
        this.Close();
      }
      return num;
    }

    public override string ExecuteScalar(string strSql)
    {
      DataSet dataSet = new DataSet();
      try
      {
        this.Open();
        object objA = new OleDbCommand(strSql, this.DBConn).ExecuteScalar();
        if (object.Equals(objA, (object) null) || object.Equals(objA, (object) DBNull.Value))
          return (string) null;
        return objA.ToString();
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("OleDbHelper.cs->ExecuteScalar()->执行sql语句错误，Sql语句：" + strSql + ",错误：" + ex.Message, ex);
      }
      finally
      {
        this.Close();
      }
    }

    public override DataSet GetDataTableSchema(string strSql)
    {
      if (strSql == null || strSql.Trim().Equals(""))
        return (DataSet) null;
      DataSet dataSet = new DataSet();
      try
      {
        this.Open();
        new OleDbDataAdapter(strSql, this.DBConn).FillSchema(dataSet, SchemaType.Mapped);
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("OleDbHelper.cs->GetDataTableSchema()->获取表结构信息出错，Sql语句：" + strSql + ",错误：" + ex.Message, ex);
      }
      finally
      {
        this.Close();
      }
      return dataSet;
    }

    public override DataSet ExecSQLToMultiPages(string strSql, int nowPageNum, int nowPageSize, out int realRowNum)
    {
      DataSet dataSet = (DataSet) null;
      if (nowPageNum < 1)
        nowPageNum = 1;
      realRowNum = 0;
      try
      {
        this.Open();
        OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(strSql, this.DBConn);
        dataSet = new DataSet();
        realRowNum = oleDbDataAdapter.Fill(dataSet);
        if (realRowNum < nowPageNum * nowPageSize)
          nowPageNum = Convert.ToInt32((realRowNum - 1) / nowPageSize) + 1;
        dataSet = new DataSet();
        oleDbDataAdapter.Fill(dataSet, (nowPageNum - 1) * nowPageSize, nowPageSize, "Table1");
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("OleDbHelper.cs->ExecSQLToMultiPages()->分页获取数据集出错，Sql语句：" + strSql + ",错误：" + ex.Message, ex);
      }
      finally
      {
        this.Close();
      }
      return dataSet;
    }

    public override void BatchUpdateWithoutTransaction(ArrayList alSQL)
    {
      if (alSQL == null)
        return;
      try
      {
        this.Open();
        OleDbCommand oleDbCommand = new OleDbCommand();
        oleDbCommand.Connection = this.DBConn;
        for (int index = 0; index < alSQL.Count; ++index)
        {
          try
          {
            oleDbCommand.CommandText = alSQL[index].ToString();
            oleDbCommand.ExecuteNonQuery();
          }
          catch (Exception ex)
          {
            throw new SQLErrorException("OleDbHelper.cs->BatchUpdateWithoutTransaction()->批量执行Sql出错：" + ex.Message, ex);
          }
        }
      }
      finally
      {
        this.Close();
      }
    }

    public override void BatchUpdateWithTransaction(ArrayList alSQL)
    {
      if (alSQL == null)
        return;
      this.Open();
      this.BeginTransaction();
      OleDbCommand oleDbCommand = new OleDbCommand();
      oleDbCommand.Connection = this.DBConn;
      oleDbCommand.Transaction = this.DBTran;
      for (int index = 0; index < alSQL.Count; ++index)
      {
        try
        {
          oleDbCommand.CommandText = alSQL[index].ToString();
          oleDbCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          this.RollbackTransaction();
          this.Close();
          throw new SQLErrorException("OleDbHelper.cs->BatchUpdateWithTransaction()->批量执行Sql出错：" + ex.Message, ex);
        }
      }
      this.CommitTransaction();
      this.Close();
    }

    public override int ExecStoredProcedure(string cmdText, DbParameter[] cmdParms)
    {
      this.Open();
      OleDbCommand oleDbCommand = new OleDbCommand();
      oleDbCommand.Connection = this.DBConn;
      try
      {
        oleDbCommand.CommandType = CommandType.StoredProcedure;
        oleDbCommand.CommandText = cmdText;
        if (cmdParms != null)
        {
          foreach (OleDbParameter cmdParm in cmdParms)
            oleDbCommand.Parameters.Add(cmdParm);
        }
        oleDbCommand.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("OleDbHelper.cs->ExecStoredProcedure()->执行存储过程错误，名称：" + cmdText + ",错误：" + ex.Message, ex);
      }
      finally
      {
        this.Close();
      }
      return 0;
    }

    public override DataSet ExecDataSetStoredProcedure(string cmdText, DbParameter[] cmdParms)
    {
      this.Open();
      DataSet dataSet = new DataSet();
      OleDbCommand selectCommand = new OleDbCommand();
      selectCommand.Connection = this.DBConn;
      try
      {
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.CommandText = cmdText;
        if (cmdParms != null)
        {
          foreach (OleDbParameter cmdParm in cmdParms)
            selectCommand.Parameters.Add(cmdParm);
        }
        new OleDbDataAdapter(selectCommand).Fill(dataSet, "ds");
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("OleDbHelper.cs->ExecDataSetStoredProcedure()->执行存储过程错误，名称：" + cmdText + ",错误：" + ex.Message, ex);
      }
      finally
      {
        this.Close();
      }
      return dataSet;
    }

    public override DbParameterCollection DeriveParameters(string cmdText)
    {
      this.Open();
      OleDbCommand command = new OleDbCommand();
      command.Connection = this.DBConn;
      command.CommandType = CommandType.StoredProcedure;
      command.CommandText = cmdText;
      OleDbCommandBuilder.DeriveParameters(command);
      DbParameterCollection parameters = (DbParameterCollection) command.Parameters;
      this.Close();
      return parameters;
    }

    public override DataSet ExecDataSetStoredProcedure(string cmdText, DbParameterCollection dbc)
    {
      this.Open();
      DataSet dataSet = new DataSet();
      OleDbCommand oleDbCommand = new OleDbCommand();
      oleDbCommand.Connection = this.DBConn;
      oleDbCommand.CommandTimeout = 120;
      try
      {
        oleDbCommand.CommandType = CommandType.StoredProcedure;
        oleDbCommand.CommandText = cmdText;
        OleDbCommandBuilder.DeriveParameters(oleDbCommand);
        for (int index = 0; index < oleDbCommand.Parameters.Count; ++index)
          oleDbCommand.Parameters[index].Value = dbc[oleDbCommand.Parameters[index].ParameterName].Value;
        new OleDbDataAdapter(oleDbCommand).Fill(dataSet, "ds");
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("OleDbHelper.cs->ExecDataSetStoredProcedure()->执行存储过程错误，名称：" + cmdText + ",错误：" + ex.Message, ex);
      }
      finally
      {
        this.Close();
      }
      return dataSet;
    }

    public override DbParameterCollection ExecStoredProcedure(string cmdText, DbParameterCollection dbc)
    {
      this.Open();
      OleDbCommand command = new OleDbCommand();
      command.Connection = this.DBConn;
      try
      {
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = cmdText;
        OleDbCommandBuilder.DeriveParameters(command);
        for (int index = 0; index < command.Parameters.Count; ++index)
          command.Parameters[index].Value = dbc[command.Parameters[index].ParameterName].Value;
        command.ExecuteNonQuery();
        dbc = (DbParameterCollection) command.Parameters;
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("OleDbHelper.cs->ExecStoredProcedure()->执行存储过程错误，名称：" + cmdText + ",错误：" + ex.Message, ex);
      }
      finally
      {
        this.Close();
      }
      return dbc;
    }
  }
}
