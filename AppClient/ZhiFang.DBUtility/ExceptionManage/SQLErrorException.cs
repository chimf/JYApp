// Decompiled with JetBrains decompiler
// Type: ZhiFang.DBUtility.ExceptionManage.SQLErrorException
// Assembly: ZhiFang.DBUtility, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A64D088-E8A1-4CC0-BA12-6E7588D35C96
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\ZhiFang.DBUtility.dll

using System;
using System.Runtime.Serialization;

namespace ZhiFang.DBUtility.ExceptionManage
{
  [Serializable]
  public class SQLErrorException : ApplicationException
  {
    public SQLErrorException()
    {
    }

    public SQLErrorException(string message)
      : base(message)
    {
    }

    public SQLErrorException(string message, Exception inner)
      : base(message, inner)
    {
    }

    protected SQLErrorException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
