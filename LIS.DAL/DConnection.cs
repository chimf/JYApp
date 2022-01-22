using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhiFang.DBUtility;

namespace LIS.DAL
{
    public class DConnection
    {
        public static string GetConnectStr() {
            return DbHelperSQL.connectionString;
        }
    }
}
