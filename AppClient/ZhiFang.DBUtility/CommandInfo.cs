// Decompiled with JetBrains decompiler
// Type: ZhiFang.DBUtility.CommandInfo
// Assembly: ZhiFang.DBUtility, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A64D088-E8A1-4CC0-BA12-6E7588D35C96
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\ZhiFang.DBUtility.dll

using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace ZhiFang.DBUtility
{
  public class CommandInfo
  {
    public object ShareObject = (object) null;
    public object OriginalData = (object) null;
    public EffentNextType EffentNextType = EffentNextType.None;
    public string CommandText;
    public DbParameter[] Parameters;

    private event EventHandler _solicitationEvent;

    public event EventHandler SolicitationEvent
    {
      add
      {
        this._solicitationEvent += value;
      }
      remove
      {
        this._solicitationEvent -= value;
      }
    }

    public CommandInfo()
    {
    }

    public CommandInfo(string sqlText, SqlParameter[] para)
    {
      this.CommandText = sqlText;
      this.Parameters = (DbParameter[]) para;
    }

    public CommandInfo(string sqlText, SqlParameter[] para, EffentNextType type)
    {
      this.CommandText = sqlText;
      this.Parameters = (DbParameter[]) para;
      this.EffentNextType = type;
    }

    public void OnSolicitationEvent()
    {
      if (this._solicitationEvent == null)
        return;
      this._solicitationEvent((object) this, new EventArgs());
    }
  }
}
