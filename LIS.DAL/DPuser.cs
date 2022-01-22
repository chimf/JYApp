using LIS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ZhiFang.DBUtility;

namespace LIS.DAL
{
    public class DPuser
    {
        private static object uid;
        
        public static string GetUserName(string userno)
        {
            return DbHelperSQL.ExecuteReader(" select CName from  PUser where UserNo=" + userno).GetValue(0).ToString();
        }

        public static List<String> GetAllUserName() {
            DataTable dt = DbHelperSQL.Query(" select CName from  PUser where visible=1 and UserNo>=0").Tables[0];
            List<string> list = new List<string>();
            foreach (DataRow item in dt.Rows)
                list.Add(item["Cname"].ToString());
            return list;
        }

        public static bool UserLogin(string uid, string pwd,ref DataTable dt) {
            string password = ConvertPassword(pwd);
            dt = DbHelperSQL.Query(string.Format("select * from puser  where shortcode='{0}' and password='{1}'", uid, password)).Tables[0];
            if (dt == null || dt.Rows.Count <= 0)
                return false;
            else
                return true;
        }

        private static string ConvertPassword(string pwd)
        {
            if (pwd.Equals(string.Empty))
                return "=";
            StringBuilder sbResult = new StringBuilder();
            int length = pwd.Length;
            int num1 = pwd.Length / 3;
            int num2 = pwd.Length % 3;
            for (; num1 > 0; --num1)
            {
                Get64Str(3, length, pwd, sbResult);
                length -= 3;
            }
            switch (num2)
            {
                case 1:
                    Get64Str(1, length, pwd, sbResult);
                    break;
                case 2:
                    Get64Str(2, length, pwd, sbResult);
                    break;
            }
            return sbResult.ToString();
        }
        private static void Get64Str(int i1, int iLength, string str, StringBuilder sbResult)
        {
            string str1 = "=qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890+";
            int num1 = 0;
            for (int index = 0; index < i1; ++index)
            {
                int num2 = (int)str[iLength - i1 + index];
                num1 = num1 * 256 + num2;
            }
            for (int index = 0; index < 4; ++index)
            {
                if (num1 == 0)
                {
                    sbResult.Insert(0, "=");
                }
                else
                {
                    int num2 = num1 % 64 + 1;
                    num1 /= 64;
                    char ch = str1[num2 - 1];
                    sbResult.Insert(0, ch);
                }
            }
        }


        public static bool CheckDataSet(DataSet ds)
        {
            return ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0;
        }

        public static List<String> GetUserUnits(DateTime startTime,DateTime endTime,string FieldName) {
            List<string> UnitList = new List<string>();
            DataTable dt= DbHelperSQL.Query(string.Format("select distinct {2} from CovidSample where CreateTime>='{0}' and CreateTime<='{1}'",
                startTime.ToString("yyyy-MM-dd")+" 00:00:00", endTime.ToString("yyyy-MM-dd"+" 23:59:00"),FieldName
                )).Tables[0];

            foreach (DataRow item in dt.Rows)
            {
                UnitList.Add(item[FieldName].ToString());
            }
            return UnitList;
        }

    }
}
