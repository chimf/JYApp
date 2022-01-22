// Decompiled with JetBrains decompiler
// Type: ZhiFang.DBUtility.DbHelperSQL
// Assembly: ZhiFang.DBUtility, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A64D088-E8A1-4CC0-BA12-6E7588D35C96
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\ZhiFang.DBUtility.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ZhiFang.DBUtility
{
  public abstract class DbHelperSQL
  {
    public static string connectionString = PubConstant.ConnectionString;

    public static bool ColumnExists(string tableName, string columnName)
    {
      object single = DbHelperSQL.GetSingle("select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'");
      if (single == null)
        return false;
      return Convert.ToInt32(single) > 0;
    }

    public static int GetMaxID(string FieldName, string TableName)
    {
      object single = DbHelperSQL.GetSingle("select max(" + FieldName + ")+1 from " + TableName);
      if (single == null)
        return 1;
      return int.Parse(single.ToString());
    }

    public static bool Exists(string strSql)
    {
      object single = DbHelperSQL.GetSingle(strSql);
      return (!object.Equals(single, (object) null) && !object.Equals(single, (object) DBNull.Value) ? int.Parse(single.ToString()) : 0) != 0;
    }

    public static bool TabExists(string TableName)
    {
      object single = DbHelperSQL.GetSingle("select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1");
      return (!object.Equals(single, (object) null) && !object.Equals(single, (object) DBNull.Value) ? int.Parse(single.ToString()) : 0) != 0;
    }

    public static bool Exists(string strSql, params SqlParameter[] cmdParms)
    {
      object single = DbHelperSQL.GetSingle(strSql, cmdParms);
      return (!object.Equals(single, (object) null) && !object.Equals(single, (object) DBNull.Value) ? int.Parse(single.ToString()) : 0) != 0;
    }

    public static int ExecuteSql(string SQLString)
    {
      using (SqlConnection connection = new SqlConnection(DbHelperSQL.connectionString))
      {
        using (SqlCommand sqlCommand = new SqlCommand(SQLString, connection))
        {
          try
          {
            connection.Open();
            return sqlCommand.ExecuteNonQuery();
          }
          catch (SqlException ex)
          {
            connection.Close();
            throw ex;
          }
        }
      }
    }

    public static int ExecuteSqlByTime(string SQLString, int Times)
    {
      using (SqlConnection connection = new SqlConnection(DbHelperSQL.connectionString))
      {
        using (SqlCommand sqlCommand = new SqlCommand(SQLString, connection))
        {
          try
          {
            connection.Open();
            sqlCommand.CommandTimeout = Times;
            return sqlCommand.ExecuteNonQuery();
          }
          catch (SqlException ex)
          {
            connection.Close();
            throw ex;
          }
        }
      }
    }

    public static int ExecuteSqlTran(List<string> SQLStringList)
    {
      using (SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString))
      {
        sqlConnection.Open();
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
        sqlCommand.Transaction = sqlTransaction;
        try
        {
          int num = 0;
          for (int index = 0; index < SQLStringList.Count; ++index)
          {
            string sqlString = SQLStringList[index];
            if (sqlString.Trim().Length > 1)
            {
              sqlCommand.CommandText = sqlString;
              num += sqlCommand.ExecuteNonQuery();
            }
          }
          sqlTransaction.Commit();
          return num;
        }
        catch
        {
          sqlTransaction.Rollback();
          return 0;
        }
      }
    }

    public static int ExecuteSql(string SQLString, string content)
    {
      using (SqlConnection connection = new SqlConnection(DbHelperSQL.connectionString))
      {
        SqlCommand sqlCommand = new SqlCommand(SQLString, connection);
        SqlParameter sqlParameter = new SqlParameter("@content", SqlDbType.NText);
        sqlParameter.Value = (object) content;
        sqlCommand.Parameters.Add(sqlParameter);
        try
        {
          connection.Open();
          return sqlCommand.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        finally
        {
          sqlCommand.Dispose();
          connection.Close();
        }
      }
    }

    public static object ExecuteSqlGet(string SQLString, string content)
    {
      using (SqlConnection connection = new SqlConnection(DbHelperSQL.connectionString))
      {
        SqlCommand sqlCommand = new SqlCommand(SQLString, connection);
        SqlParameter sqlParameter = new SqlParameter("@content", SqlDbType.NText);
        sqlParameter.Value = (object) content;
        sqlCommand.Parameters.Add(sqlParameter);
        try
        {
          connection.Open();
          object objA = sqlCommand.ExecuteScalar();
          if (object.Equals(objA, (object) null) || object.Equals(objA, (object) DBNull.Value))
            return (object) null;
          return objA;
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        finally
        {
          sqlCommand.Dispose();
          connection.Close();
        }
      }
    }

    public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
    {
      using (SqlConnection connection = new SqlConnection(DbHelperSQL.connectionString))
      {
        SqlCommand sqlCommand = new SqlCommand(strSQL, connection);
        SqlParameter sqlParameter = new SqlParameter("@fs", SqlDbType.Image);
        sqlParameter.Value = (object) fs;
        sqlCommand.Parameters.Add(sqlParameter);
        try
        {
          connection.Open();
          return sqlCommand.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        finally
        {
          sqlCommand.Dispose();
          connection.Close();
        }
      }
    }

    public static object GetSingle(string SQLString)
    {
      using (SqlConnection connection = new SqlConnection(DbHelperSQL.connectionString))
      {
        using (SqlCommand sqlCommand = new SqlCommand(SQLString, connection))
        {
          try
          {
            connection.Open();
            object objA = sqlCommand.ExecuteScalar();
            if (object.Equals(objA, (object) null) || object.Equals(objA, (object) DBNull.Value))
              return (object) null;
            return objA;
          }
          catch (SqlException ex)
          {
            connection.Close();
            throw ex;
          }
        }
      }
    }

    public static object GetSingle(string SQLString, int Times)
    {
      using (SqlConnection connection = new SqlConnection(DbHelperSQL.connectionString))
      {
        using (SqlCommand sqlCommand = new SqlCommand(SQLString, connection))
        {
          try
          {
            connection.Open();
            sqlCommand.CommandTimeout = Times;
            object objA = sqlCommand.ExecuteScalar();
            if (object.Equals(objA, (object) null) || object.Equals(objA, (object) DBNull.Value))
              return (object) null;
            return objA;
          }
          catch (SqlException ex)
          {
            connection.Close();
            throw ex;
          }
        }
      }
    }

    public static SqlDataReader ExecuteReader(string strSQL)
    {
      SqlConnection connection = new SqlConnection(DbHelperSQL.connectionString);
      SqlCommand sqlCommand = new SqlCommand(strSQL, connection);
      try
      {
        connection.Open();
        return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
      }
      catch (SqlException ex)
      {
        throw ex;
      }
    }

    public static DataSet Query(string SQLString)
    {
      using (SqlConnection selectConnection = new SqlConnection(DbHelperSQL.connectionString))
      {
        DataSet dataSet = new DataSet();
        try
        {
          selectConnection.Open();
          new SqlDataAdapter(SQLString, selectConnection).Fill(dataSet, "ds");
        }
        catch (SqlException ex)
        {
          throw new Exception(ex.Message);
        }
        return dataSet;
      }
    }

    public static DataSet Query(string SQLString, int Times)
    {
      using (SqlConnection selectConnection = new SqlConnection(DbHelperSQL.connectionString))
      {
        DataSet dataSet = new DataSet();
        try
        {
          selectConnection.Open();
          SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQLString, selectConnection);
          sqlDataAdapter.SelectCommand.CommandTimeout = Times;
          sqlDataAdapter.Fill(dataSet, "ds");
        }
        catch (SqlException ex)
        {
          throw new Exception(ex.Message);
        }
        return dataSet;
      }
    }

    public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
    {
      using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
      {
        using (SqlCommand cmd = new SqlCommand())
        {
          try
          {
            DbHelperSQL.PrepareCommand(cmd, conn, (SqlTransaction) null, SQLString, cmdParms);
            int num = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return num;
          }
          catch (SqlException ex)
          {
            throw ex;
          }
        }
      }
    }

    public static void ExecuteSqlTran(Hashtable SQLStringList)
    {
      using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
      {
        conn.Open();
        using (SqlTransaction trans = conn.BeginTransaction())
        {
          SqlCommand cmd = new SqlCommand();
          try
          {
            foreach (DictionaryEntry sqlString in SQLStringList)
            {
              string cmdText = sqlString.Key.ToString();
              SqlParameter[] cmdParms = (SqlParameter[]) sqlString.Value;
              DbHelperSQL.PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
              cmd.ExecuteNonQuery();
              cmd.Parameters.Clear();
            }
            trans.Commit();
          }
          catch
          {
            trans.Rollback();
            throw;
          }
        }
      }
    }

    public static int ExecuteSqlTran(List<CommandInfo> cmdList)
    {
      using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
      {
        conn.Open();
        using (SqlTransaction trans = conn.BeginTransaction())
        {
          SqlCommand cmd1 = new SqlCommand();
          try
          {
            int num1 = 0;
            foreach (CommandInfo cmd2 in cmdList)
            {
              string commandText = cmd2.CommandText;
              SqlParameter[] parameters = (SqlParameter[]) cmd2.Parameters;
              DbHelperSQL.PrepareCommand(cmd1, conn, trans, commandText, parameters);
              if (cmd2.EffentNextType == EffentNextType.WhenHaveContine || cmd2.EffentNextType == EffentNextType.WhenNoHaveContine)
              {
                if (cmd2.CommandText.ToLower().IndexOf("count(") == -1)
                {
                  trans.Rollback();
                  return 0;
                }
                object obj = cmd1.ExecuteScalar();
                bool flag1 = false;
                if (obj == null && obj == DBNull.Value)
                  flag1 = false;
                bool flag2 = Convert.ToInt32(obj) > 0;
                if (cmd2.EffentNextType == EffentNextType.WhenHaveContine && !flag2)
                {
                  trans.Rollback();
                  return 0;
                }
                if (cmd2.EffentNextType == EffentNextType.WhenNoHaveContine && flag2)
                {
                  trans.Rollback();
                  return 0;
                }
              }
              else
              {
                int num2 = cmd1.ExecuteNonQuery();
                num1 += num2;
                if (cmd2.EffentNextType == EffentNextType.ExcuteEffectRows && num2 == 0)
                {
                  trans.Rollback();
                  return 0;
                }
                cmd1.Parameters.Clear();
              }
            }
            trans.Commit();
            return num1;
          }
          catch
          {
            trans.Rollback();
            throw;
          }
        }
      }
    }

    public static void ExecuteSqlTranWithIndentity(List<CommandInfo> SQLStringList)
    {
      using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
      {
        conn.Open();
        using (SqlTransaction trans = conn.BeginTransaction())
        {
          SqlCommand cmd = new SqlCommand();
          try
          {
            int num = 0;
            foreach (CommandInfo sqlString in SQLStringList)
            {
              string commandText = sqlString.CommandText;
              SqlParameter[] parameters = (SqlParameter[]) sqlString.Parameters;
              foreach (SqlParameter sqlParameter in parameters)
              {
                if (sqlParameter.Direction == ParameterDirection.InputOutput)
                  sqlParameter.Value = (object) num;
              }
              DbHelperSQL.PrepareCommand(cmd, conn, trans, commandText, parameters);
              cmd.ExecuteNonQuery();
              foreach (SqlParameter sqlParameter in parameters)
              {
                if (sqlParameter.Direction == ParameterDirection.Output)
                  num = Convert.ToInt32(sqlParameter.Value);
              }
              cmd.Parameters.Clear();
            }
            trans.Commit();
          }
          catch
          {
            trans.Rollback();
            throw;
          }
        }
      }
    }

    public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
    {
      using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
      {
        conn.Open();
        using (SqlTransaction trans = conn.BeginTransaction())
        {
          SqlCommand cmd = new SqlCommand();
          try
          {
            int num = 0;
            foreach (DictionaryEntry sqlString in SQLStringList)
            {
              string cmdText = sqlString.Key.ToString();
              SqlParameter[] cmdParms = (SqlParameter[]) sqlString.Value;
              foreach (SqlParameter sqlParameter in cmdParms)
              {
                if (sqlParameter.Direction == ParameterDirection.InputOutput)
                  sqlParameter.Value = (object) num;
              }
              DbHelperSQL.PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
              cmd.ExecuteNonQuery();
              foreach (SqlParameter sqlParameter in cmdParms)
              {
                if (sqlParameter.Direction == ParameterDirection.Output)
                  num = Convert.ToInt32(sqlParameter.Value);
              }
              cmd.Parameters.Clear();
            }
            trans.Commit();
          }
          catch
          {
            trans.Rollback();
            throw;
          }
        }
      }
    }

    public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
    {
      using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
      {
        using (SqlCommand cmd = new SqlCommand())
        {
          try
          {
            DbHelperSQL.PrepareCommand(cmd, conn, (SqlTransaction) null, SQLString, cmdParms);
            object objA = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            if (object.Equals(objA, (object) null) || object.Equals(objA, (object) DBNull.Value))
              return (object) null;
            return objA;
          }
          catch (SqlException ex)
          {
            throw ex;
          }
        }
      }
    }

    public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
    {
      SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
      SqlCommand cmd = new SqlCommand();
      try
      {
        DbHelperSQL.PrepareCommand(cmd, conn, (SqlTransaction) null, SQLString, cmdParms);
        SqlDataReader sqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        cmd.Parameters.Clear();
        return sqlDataReader;
      }
      catch (SqlException ex)
      {
        throw ex;
      }
    }

    public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
    {
      using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
      {
        SqlCommand sqlCommand = new SqlCommand();
        DbHelperSQL.PrepareCommand(sqlCommand, conn, (SqlTransaction) null, SQLString, cmdParms);
        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
        {
          DataSet dataSet = new DataSet();
          try
          {
            sqlDataAdapter.Fill(dataSet, "ds");
            sqlCommand.Parameters.Clear();
          }
          catch (SqlException ex)
          {
            throw new Exception(ex.Message);
          }
          return dataSet;
        }
      }
    }

    private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
    {
      if (conn.State != ConnectionState.Open)
        conn.Open();
      cmd.Connection = conn;
      cmd.CommandText = cmdText;
      if (trans != null)
        cmd.Transaction = trans;
      cmd.CommandType = CommandType.Text;
      if (cmdParms == null)
        return;
      foreach (SqlParameter cmdParm in cmdParms)
      {
        if ((cmdParm.Direction == ParameterDirection.InputOutput || cmdParm.Direction == ParameterDirection.Input) && cmdParm.Value == null)
          cmdParm.Value = (object) DBNull.Value;
        cmd.Parameters.Add(cmdParm);
      }
    }

    public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
    {
      SqlConnection connection = new SqlConnection(DbHelperSQL.connectionString);
      connection.Open();
      SqlCommand sqlCommand = DbHelperSQL.BuildQueryCommand(connection, storedProcName, parameters);
      sqlCommand.CommandType = CommandType.StoredProcedure;
      return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
    }

    public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
    {
      using (SqlConnection connection = new SqlConnection(DbHelperSQL.connectionString))
      {
        DataSet dataSet = new DataSet();
        connection.Open();
        new SqlDataAdapter()
        {
          SelectCommand = DbHelperSQL.BuildQueryCommand(connection, storedProcName, parameters)
        }.Fill(dataSet, tableName);
        connection.Close();
        return dataSet;
      }
    }

    public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
    {
      using (SqlConnection connection = new SqlConnection(DbHelperSQL.connectionString))
      {
        DataSet dataSet = new DataSet();
        connection.Open();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        sqlDataAdapter.SelectCommand = DbHelperSQL.BuildQueryCommand(connection, storedProcName, parameters);
        sqlDataAdapter.SelectCommand.CommandTimeout = Times;
        sqlDataAdapter.Fill(dataSet, tableName);
        connection.Close();
        return dataSet;
      }
    }

    private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
    {
      SqlCommand sqlCommand = new SqlCommand(storedProcName, connection);
      sqlCommand.CommandType = CommandType.StoredProcedure;
      foreach (SqlParameter parameter in parameters)
      {
        if (parameter != null)
        {
          if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && parameter.Value == null)
            parameter.Value = (object) DBNull.Value;
          sqlCommand.Parameters.Add(parameter);
        }
      }
      return sqlCommand;
    }

    public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
    {
      using (SqlConnection connection = new SqlConnection(DbHelperSQL.connectionString))
      {
        connection.Open();
        SqlCommand sqlCommand = DbHelperSQL.BuildIntCommand(connection, storedProcName, parameters);
        rowsAffected = sqlCommand.ExecuteNonQuery();
        return (int) sqlCommand.Parameters["ReturnValue"].Value;
      }
    }

    private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
    {
      SqlCommand sqlCommand = DbHelperSQL.BuildQueryCommand(connection, storedProcName, parameters);
      sqlCommand.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, (byte) 0, (byte) 0, string.Empty, DataRowVersion.Default, (object) null));
      return sqlCommand;
    }
  }
}
