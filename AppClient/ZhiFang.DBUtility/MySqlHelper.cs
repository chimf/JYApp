﻿// Decompiled with JetBrains decompiler
// Type: ZhiFang.DBUtility.MySqlHelper
// Assembly: ZhiFang.DBUtility, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A64D088-E8A1-4CC0-BA12-6E7588D35C96
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\ZhiFang.DBUtility.dll

using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using ZhiFang.DBUtility.ExceptionManage;

namespace ZhiFang.DBUtility
{
    internal class MySqlHelper : IDBConnection
  {
    private MySqlConnection DBConn;
    private MySqlTransaction DBTran;
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
        return ((DbConnection) this.DBConn).State;
      }
    }

    public MySqlConnection getConnection
    {
      get
      {
        return this.DBConn;
      }
    }

    public MySqlHelper(string connStr)
    {
      this.ConnectionStr = connStr;
      this.DBConn = new MySqlConnection(connStr);
    }

    protected void Open()
    {
      try
      {
        if (((DbConnection) this.DBConn).State == ConnectionState.Open)
          return;
        ((DbConnection) this.DBConn).Open();
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
        if (((DbConnection) this.DBConn).State == ConnectionState.Closed)
          return;
        ((DbConnection) this.DBConn).Close();
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
        if (((DbConnection) this.DBConn).State != ConnectionState.Open)
          ((DbConnection) this.DBConn).Open();
        return true;
      }
      catch (Exception ex)
      {
        strErr = ex.Message;
        return false;
      }
      finally
      {
        if (((DbConnection) this.DBConn).State != ConnectionState.Closed)
          ((DbConnection) this.DBConn).Close();
      }
    }

    public override bool TestConnection()
    {
      try
      {
        if (((DbConnection) this.DBConn).State != ConnectionState.Open)
          ((DbConnection) this.DBConn).Open();
        return true;
      }
      catch (Exception ex)
      {
        throw new DBErrorException("MysqlHelper.cs->TestConnection()->数据库连接失败，连接参数为" + ((DbConnection) this.DBConn).ConnectionString + ",错误信息：" + ex.Message, ex);
      }
      finally
      {
        if (((DbConnection) this.DBConn).State != ConnectionState.Closed)
          ((DbConnection) this.DBConn).Close();
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
        ((DbTransaction) this.DBTran).Commit();
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
        ((DbTransaction) this.DBTran).Rollback();
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
        MySqlCommand mySqlCommand = new MySqlCommand(strSql, this.DBConn);
        this.Open();
        dataReader = (IDataReader) mySqlCommand.ExecuteReader();
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("MysqlHelper.cs->ExecuteReader()->执行sql语句错误，Sql语句：" + strSql + ",错误：" + ex.Message, ex);
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
        ((DbDataAdapter) new MySqlDataAdapter(strSql, this.DBConn)).Fill(dataSet, "ds");
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("MysqlHelper.cs->ExecuteDataSet()->执行sql语句错误，Sql语句：" + strSql + ",错误：" + ex.Message, ex);
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
        num = ((DbCommand) new MySqlCommand(strSql, this.DBConn)).ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("MysqlHelper.cs->ExecuteNonQuery()->执行sql语句错误，Sql语句：" + strSql + ",错误：" + ex.Message, ex);
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
      string str = "select count(*) from " + tableName + whereClause;
      try
      {
        this.Open();
        object objA = ((DbCommand) new MySqlCommand(str, this.DBConn)).ExecuteScalar();
        if (object.Equals(objA, (object) null) || object.Equals(objA, (object) DBNull.Value))
          return 0;
        num = (int) objA;
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("MysqlHelper.cs->ExecuteDataSet()->执行sql语句错误，Sql语句：" + str + ",错误：" + ex.Message, ex);
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
        object objA = ((DbCommand) new MySqlCommand(strSql, this.DBConn)).ExecuteScalar();
        if (object.Equals(objA, (object) null) || object.Equals(objA, (object) DBNull.Value))
          return (string) null;
        return objA.ToString();
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("MysqlHelper.cs->ExecuteScalar()->执行sql语句错误，Sql语句：" + strSql + ",错误：" + ex.Message, ex);
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
        ((DataAdapter) new MySqlDataAdapter(strSql, this.DBConn)).FillSchema(dataSet, SchemaType.Mapped);
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("MysqlHelper.cs->GetDataTableSchema()->获取表结构信息出错，Sql语句：" + strSql + ",错误：" + ex.Message, ex);
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
        MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(strSql, this.DBConn);
        dataSet = new DataSet();
        realRowNum = ((DataAdapter) mySqlDataAdapter).Fill(dataSet);
        if (realRowNum < nowPageNum * nowPageSize)
          nowPageNum = Convert.ToInt32((realRowNum - 1) / nowPageSize) + 1;
        dataSet = new DataSet();
        ((DbDataAdapter) mySqlDataAdapter).Fill(dataSet, (nowPageNum - 1) * nowPageSize, nowPageSize, "Table1");
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("MysqlHelper.cs->ExecSQLToMultiPages()->分页获取数据集出错，Sql语句：" + strSql + ",错误：" + ex.Message, ex);
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
        MySqlCommand mySqlCommand = new MySqlCommand();
        mySqlCommand.Connection=(this.DBConn);
        for (int index = 0; index < alSQL.Count; ++index)
        {
          try
          {
            ((DbCommand) mySqlCommand).CommandText = alSQL[index].ToString();
            ((DbCommand) mySqlCommand).ExecuteNonQuery();
          }
          catch (Exception ex)
          {
            throw new SQLErrorException("MysqlHelper.cs->BatchUpdateWithoutTransaction()->批量执行Sql出错：" + ex.Message, ex);
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
      MySqlCommand mySqlCommand = new MySqlCommand();
      mySqlCommand.Connection = (this.DBConn);
      mySqlCommand.Transaction = (this.DBTran);
      for (int index = 0; index < alSQL.Count; ++index)
      {
        try
        {
          ((DbCommand) mySqlCommand).CommandText = alSQL[index].ToString();
          ((DbCommand) mySqlCommand).ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          this.RollbackTransaction();
          this.Close();
          throw new SQLErrorException("MysqlHelper.cs->BatchUpdateWithTransaction()->批量执行Sql出错：" + ex.Message, ex);
        }
      }
      this.CommitTransaction();
      this.Close();
    }

    public override int ExecStoredProcedure(string cmdText, DbParameter[] cmdParms)
    {
      this.Open();
      MySqlCommand mySqlCommand = new MySqlCommand();
      mySqlCommand.Connection=(this.DBConn);
      try
      {
        ((DbCommand) mySqlCommand).CommandType = CommandType.StoredProcedure;
        ((DbCommand) mySqlCommand).CommandText = cmdText;
        if (cmdParms != null)
        {
          foreach (MySqlParameter cmdParm in cmdParms)
            mySqlCommand.Parameters.Add(cmdParm);
        }
        ((DbCommand) mySqlCommand).ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("MysqlHelper.cs->ExecStoredProcedure()->执行存储过程错误，名称：" + cmdText + ",错误：" + ex.Message, ex);
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
      MySqlCommand mySqlCommand = new MySqlCommand();
      mySqlCommand.Connection=(this.DBConn);
      try
      {
        ((DbCommand) mySqlCommand).CommandType = CommandType.StoredProcedure;
        ((DbCommand) mySqlCommand).CommandText = cmdText;
        if (cmdParms != null)
        {
          foreach (MySqlParameter cmdParm in cmdParms)
            mySqlCommand.Parameters.Add(cmdParm);
        }
        ((DbDataAdapter) new MySqlDataAdapter(mySqlCommand)).Fill(dataSet, "ds");
      }
      catch (Exception ex)
      {
        throw new SQLErrorException("MysqlHelper.cs->ExecDataSetStoredProcedure()->执行存储过程错误，名称：" + cmdText + ",错误：" + ex.Message, ex);
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
      MySqlCommand mySqlCommand = new MySqlCommand();
      mySqlCommand.Connection=(this.DBConn);
      ((DbCommand) mySqlCommand).CommandType = CommandType.StoredProcedure;
      ((DbCommand) mySqlCommand).CommandText = cmdText;
      MySqlCommandBuilder.DeriveParameters(mySqlCommand);
      DbParameterCollection parameters = (DbParameterCollection) mySqlCommand.Parameters;
      this.Close();
      return parameters;
    }

        public override DataSet ExecDataSetStoredProcedure(string cmdText, DbParameterCollection dbc)
        {
            this.Open();
            DataSet dataSet = new DataSet();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = this.DBConn;
            mySqlCommand.CommandTimeout = 120;
            try
            {
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.CommandText = cmdText;
                MySqlCommandBuilder.DeriveParameters(mySqlCommand);
                for (int index = 0; index < mySqlCommand.Parameters.Count; ++index)
                    mySqlCommand.Parameters[index].Value = dbc[mySqlCommand.Parameters[index].ParameterName].Value;
                new MySqlDataAdapter(mySqlCommand).Fill(dataSet, "ds");
            }
            catch (Exception ex)
            {
                throw new SQLErrorException("MysqlHelper.cs->ExecDataSetStoredProcedure()->执行存储过程错误，名称：" + cmdText + ",错误：" + ex.Message, ex);
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
            MySqlCommand command = new MySqlCommand();
            command.Connection = this.DBConn;
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = cmdText;
                MySqlCommandBuilder.DeriveParameters(command);
                for (int index = 0; index < command.Parameters.Count; ++index)
                    command.Parameters[index].Value = dbc[command.Parameters[index].ParameterName].Value;
                command.ExecuteNonQuery();
                dbc = (DbParameterCollection)command.Parameters;
            }
            catch (Exception ex)
            {
                throw new SQLErrorException("MysqlHelper.cs->ExecStoredProcedure()->执行存储过程错误，名称：" + cmdText + ",错误：" + ex.Message, ex);
            }
            finally
            {
                this.Close();
            }
            return dbc;
        }
  }
}
