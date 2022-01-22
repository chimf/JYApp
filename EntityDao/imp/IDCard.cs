using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntityDao.imp
{
    public class IDCard
    {
        /// <summary>
        /// 加权因子
        /// </summary>
        private static int[] wi = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
        /// <summary>
        /// 检验位数值
        /// </summary>
        private static char[] result = new char[] { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };
        /// <summary>
        /// 省份代码
        /// </summary>
        private static string[] provinces = new string[] { "11", "22", "35", "44", "53", "12", "23", "36", "45", "54", "13", "31", "37", "46", "61", "14", "32", "41", "50", "62", "15", "33", "42", "51", "63", "21", "34", "43", "52", "64", "65", "71", "81", "82", "91" };


        #region
        /// <summary>
        /// 省代码
        /// </summary>
        public string provinceCode
        {
            get
            {
                return _id.Substring(0, 2);
            }
        }
        /// <summary>
        /// 市代码
        /// </summary>
        public string cityCode
        {
            get
            {
                return _id.Substring(2, 2);
            }
        }
        /// <summary>
        /// 区代码
        /// </summary>
        public string districtCode
        {
            get
            {
                return _id.Substring(4, 2);
            }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime brithDay
        {
            get
            {
                if (_is18)
                {
                    string brithday = _id.Substring(6, 8);
                    return DateTime.ParseExact(brithday, "yyyyMMdd", null);
                }
                else
                {
                    return DateTime.ParseExact(_id.Substring(6, 6), "yyMMdd", null);
                }
            }
        }
        /// <summary>
        /// 性别
        /// 1. 男
        /// 2. 女
        /// </summary>
        public string sex
        {
            get
            {
                char temp;
                if (_is18)
                {
                    temp = _id[16];
                }
                else
                {
                    temp = _id[14];
                }
                return (((temp - 48) % 2) == 0 ? "2" : "1");
            }
        }
        #endregion
        private string _id = string.Empty;
        private bool _is18 = false;
        private IDCard(string id)
        {
            _id = id;
        }

        /// <summary>
        /// 解析身份证号码
        /// </summary>
        /// <param name="id">号码</param>
        /// <returns>解析成功返回身份证对象,否则返回空</returns>
        public static IDCard Parse(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            IDCard idCard = new IDCard(id);
            if (idCard.ParseId())
            {
                return idCard;
            }
            return null;
        }


        /// <summary>
        /// 解析身份证号码
        /// </summary>
        /// <returns>成功返回真,否则返回假</returns>
        private bool ParseId()
        {
            if (Regex.IsMatch(_id, @"\A\d{17}[0123456789xX]{1}\z"))
            {
                _is18 = true;
                return Parse18();
            }
            else if (Regex.IsMatch(_id, @"\A\d{15}\z"))
            {
                _is18 = false;
                return Parse15();
            }
            return false;
        }

        /// <summary>
        /// 解析18位身份证
        /// 主要检验规则和省份
        /// </summary>
        /// <returns>成功返回真,否则返回假</returns>
        private bool Parse18()
        {
            if (!IsValidRule())
            {
                return false;
            }
            return IsValidProvince();
        }

        /// <summary>
        /// 根据18位身份证规则检验是否有效
        /// </summary>
        /// <returns>成功返回真,否则返回假</returns>
        private bool IsValidRule()
        {
            char[] ids = _id.ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += (wi[i] * (ids[i] - 48));
            }
            int y = sum % 11;
            return result[y] == ids[17];
        }
        /// <summary>
        /// 解析15位身份证
        /// </summary>
        /// <returns>成功返回真,否则返回假</returns>
        private bool Parse15()
        {
            return IsValidProvince();
        }

        /// <summary>
        /// 检验是否是有效省份
        /// </summary>
        /// <returns>成功返回真,否则返回假</returns>
        private bool IsValidProvince()
        {
            string province = _id.Substring(0, 2);
            return (Array.Exists<string>(provinces, delegate (string s)
            {
                return (province == s);
            }
            ));
        }

        public int GetAge()
        {
            DateTime now = DateTime.Now;
            int age = now.Year - this.brithDay.Year;
            if (now.Month < brithDay.Month || (now.Month == brithDay.Month && now.Day < brithDay.Day))
            {
                age--;
            }
            return age < 0 ? 0 : age;
        }

        public static String isHKCard(string card)
        {
            //// 港澳居民来往内地通行证
            //// 规则： H/M + 10位或6位数字
            //// 样本： H1234567890
            //var reg =@"[A-Z]\d{6,10}";
            //Match m =Regex.Match(card, reg);
            //if (m.Success)
            //    return "港澳居民来往内地通行证";
            //else
            //    return "";
            //if (card.Trim().Length == 9 || card.Trim().Length == 11)
            //{
            //    string str = card.Trim().Substring(0, 1);
            //    if (str.Equals("H".ToUpper()) || str.Equals("M".ToUpper()))
            //        return "港澳居民来往内地通行证";
            //    else
            //        return "";
            //}
            //else
            //    return "";
            try
            {
                var reg = "(^[HMmh]\\d{8}$)|(^[HMmh]\\d{10}$)";
                Match m = Regex.Match(card, reg, RegexOptions.IgnoreCase);

                if (m.Success)
                    return "港澳居民来往内地通行证";
                else
                    return "";
            }
            catch
            {
                return "";
            }

        }

        public static string isTWCard(string card)
        {
            //// 台湾居民来往大陆通行证
            //// 规则： 新版8位或18位数字， 旧版10位数字 + 英文字母
            //// 样本： 12345678 或 1234567890B
            //var reg = @"\d{8}|[a-zA-Z0-9]{10}|^\d{18}$";
            //Match m = Regex.Match(card, reg);
            //if (m.Success)
            //    return "台湾居民来往内地通行证";
            //else
            //    return "";
            //try
            //{
            //    if (card.Trim().Length == 8)
            //    {
            //        Convert.ToInt32(card.Trim());
            //        return "台湾居民来往内地通行证";
            //    }
            //    else
            //    {
            //        return "";
            //    }
            //}
            //catch
            //{
            //    return "";
            //}

            try
            {
                var reg = "^\\d{8}$";
                Match m = Regex.Match(card, reg, RegexOptions.IgnoreCase);

                if (m.Success)
                    return "台湾居民来往内地通行证";
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }

        public static string isPassportCard(string card)
        {
            //// 护照
            //// 规则： 14/15开头 + 7位数字, G + 8位数字, P + 7位数字, S/D + 7或8位数字,等
            //// 样本： 141234567, G12345678, P1234567
            /// 1、G/E/C/W/L/T + 8位数字
            ///2、8位数字
            ///3、P/S/D/DE/SE/PE/EA + 7位数
            ///4、H/M + 10位数字
            try
            {
                var reg = "(^[EeKkGgDdHh]\\d{8}$)|(^(([Ee][a-zA-Z])|([DdSsPp][Ee])|([Kk][Jj])|([Mm][Aa])|(1[45]))\\d{7}$)";
                //var reg = "(^[GECWLTgecwlt]\\d{8}$)|(^\\d{8}$)|(^PpSsDdDEdeSEseEAea\\d{7}$)|(^HhMm)\\d{10}$)";
                reg = "^[GECWLTgecwlt]\\d{8}$";
                reg = "(^[PSD]|DE|SE|KJ|MA|([Ee][a-zA-Z])\\d{7}$)|(^[GECWLT]\\d{8}$)";
                Match m = Regex.Match(card, reg,RegexOptions.IgnoreCase);
                
                if (m.Success)
                    return "中国护照";
                else
                    return "非中国护照";
            }
            catch
            {
                return "";
            }
            //card.matches("(^[EeKkGgDdHh]\\d{8}$)|(^(([Ee][a-zA-Z])|([DdSsPp][Ee])|([Kk][Jj])|([Mm][Aa])|(1[45]))\\d{7}$)|(^([PpSs])\\d{7}$)")
        }

        /// <summary>
        /// 判断输入的字符串是否是一个合法的手机号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsMobilePhone(string input)
        {
            Regex regex = new Regex("^1[34578]\\d{9}$");
            return regex.IsMatch(input);
        }

        #region IsTel(是否中国电话)
        /// <summary>
        /// 是否中国电话，格式：010-85849685
        /// </summary>
        /// <param name="value">电话</param>
        /// <returns></returns>
        public static bool IsTel(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            Regex regex = new Regex(@"^\d{3,4}-?\d{6,8}$", RegexOptions.IgnoreCase);
            return regex.IsMatch(value);
        }
        #endregion

        /// <summary>
        /// 是否邮箱
        /// </summary>
        /// <param name="value">邮箱地址</param>
        /// <param name="isRestrict">是否按严格模式验证</param>
        /// <returns></returns>
        public static bool IsEmail(string value, bool isRestrict = false)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            string pattern = isRestrict
                ? @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"
                : @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(value);
        }

    }
}
