using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDao.Entity
{
   public class PanelInfo
    {
        //PanelNumber,PanelMode,TestTime,BatchRate,BatchNumber,EqName,Tester,Checker,reagent,RStartDateTime,REenDateTime,CreateTime
        private string _PanelNumber;
        private string _PanelMode;
        private string _TestTime;
        private string _BatchRate;
        private string _BatchNumber;
        private string _EqName;
        private string _Tester;
        private string _Checker;
        private string _Reagent;
        private string _RStartDateTime;
        private string _REenDateTime;
        private string _CreateTime;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Pcr_PanelInfo(PanelNumber,PanelMode,TestTime,BatchRate,BatchNumber,EqName,Tester,Checker,reagent,RStartDateTime,REenDateTime,CreateTime) values(");
            sb.AppendFormat("'{0}',", _PanelNumber);
            sb.AppendFormat("'{0}',", _PanelMode);
            sb.AppendFormat("'{0}',", _TestTime);
            sb.AppendFormat("'{0}',", _BatchRate);
            sb.AppendFormat("'{0}',", _BatchNumber);
            sb.AppendFormat("'{0}',", _EqName);
            sb.AppendFormat("'{0}',", _Tester);
            sb.AppendFormat("'{0}',", _Checker);
            sb.AppendFormat("'{0}',", _Reagent);
            sb.AppendFormat("'{0}',", _RStartDateTime);
            sb.AppendFormat("'{0}',", _REenDateTime);
            sb.AppendFormat("'{0}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            return sb.Append(")").ToString();

        }

        public string ToUpdate() {
            StringBuilder sb = new StringBuilder();
            sb.Append("update Pcr_PanelInfo set ");
            sb.AppendFormat("PanelNumber='{0}',",_PanelNumber);
            sb.AppendFormat("PanelNumber='{0}',", _PanelMode);
            sb.AppendFormat("PanelNumber='{0}',", _TestTime);
            sb.AppendFormat("PanelNumber='{0}',", _BatchRate);
            sb.AppendFormat("PanelNumber='{0}',", _BatchNumber);
            sb.AppendFormat("PanelNumber='{0}',", _EqName);
            sb.AppendFormat("PanelNumber='{0}',", _Tester);
            sb.AppendFormat("PanelNumber='{0}',", _Checker);
            sb.AppendFormat("PanelNumber='{0}',", _Reagent);
            sb.AppendFormat("PanelNumber='{0}',", _RStartDateTime);
            sb.AppendFormat("PanelNumber='{0}',", _REenDateTime);
            sb.AppendFormat("PanelNumber='{0}'", _CreateTime);
            sb.AppendFormat(" where PanelNumber='{0}' and CreateTime>='{1}' and CreateTime<='{2}'", 
                PanelNumber,
                DateTime.Now.ToString("yyyy-MM-dd")+" 00:00:00", DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:00"
                );
            return sb.ToString();
        }

        public string PanelNumber { get => _PanelNumber; set => _PanelNumber = value; }
        public string PanelMode { get => _PanelMode; set => _PanelMode = value; }
        public string TestTime { get => _TestTime; set => _TestTime = value; }
        public string BatchRate { get => _BatchRate; set => _BatchRate = value; }
        public string BatchNumber { get => _BatchNumber; set => _BatchNumber = value; }
        public string EqName { get => _EqName; set => _EqName = value; }
        public string Tester { get => _Tester; set => _Tester = value; }
        public string Checker { get => _Checker; set => _Checker = value; }
        public string Reagent { get => _Reagent; set => _Reagent = value; }
        public string RStartDateTime { get => _RStartDateTime; set => _RStartDateTime = value; }
        public string REenDateTime { get => _REenDateTime; set => _REenDateTime = value; }
        public string CreateTime { get => _CreateTime; set => _CreateTime = value; }
    }
}
