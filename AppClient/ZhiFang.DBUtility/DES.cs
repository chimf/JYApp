// Decompiled with JetBrains decompiler
// Type: ZhiFang.DBUtility.DES
// Assembly: ZhiFang.DBUtility, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A64D088-E8A1-4CC0-BA12-6E7588D35C96
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\ZhiFang.DBUtility.dll

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ZhiFang.DBUtility
{
  internal class DES
  {
    private static byte[] Keys = new byte[8]
    {
      (byte) 18,
      (byte) 52,
      (byte) 86,
      (byte) 120,
      (byte) 144,
      (byte) 171,
      (byte) 205,
      (byte) 239
    };
    private static string encryptKey = "systemio";

    public static string EncryptDES(string encryptString)
    {
      return DES.EncryptDES(encryptString, DES.encryptKey);
    }

    public static string DecryptDES(string decryptString)
    {
      return DES.DecryptDES(decryptString, DES.encryptKey);
    }

    private static string EncryptDES(string encryptString, string encryptKey)
    {
      try
      {
        byte[] bytes1 = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
        byte[] keys = DES.Keys;
        byte[] bytes2 = Encoding.UTF8.GetBytes(encryptString);
        DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, cryptoServiceProvider.CreateEncryptor(bytes1, keys), CryptoStreamMode.Write);
        cryptoStream.Write(bytes2, 0, bytes2.Length);
        cryptoStream.FlushFinalBlock();
        return Convert.ToBase64String(memoryStream.ToArray());
      }
      catch
      {
        return encryptString;
      }
    }

    private static string DecryptDES(string decryptString, string decryptKey)
    {
      try
      {
        byte[] bytes = Encoding.UTF8.GetBytes(decryptKey);
        byte[] keys = DES.Keys;
        byte[] buffer = Convert.FromBase64String(decryptString);
        DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, cryptoServiceProvider.CreateDecryptor(bytes, keys), CryptoStreamMode.Write);
        cryptoStream.Write(buffer, 0, buffer.Length);
        cryptoStream.FlushFinalBlock();
        return Encoding.UTF8.GetString(memoryStream.ToArray());
      }
      catch (Exception ex)
      {
        return decryptString;
      }
    }
  }
}
