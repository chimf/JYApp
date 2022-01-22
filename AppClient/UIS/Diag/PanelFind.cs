using System;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EntityDao.Entity;

namespace Apps.UIS.PcrPanel
{
    public partial class PanelFind : XtraForm
    {
        private DataTable DT;

        private Action<string> _SerchPanelDataFunction;

        public Action<string> SerchPanelDataFunction {set => _SerchPanelDataFunction = value; }

        public PanelFind()
        {
            InitializeComponent();
        }

        private void TimeChanged(object sender, EventArgs e)
        {
            string startTime = Start.Value.ToString("yyyy-MM-dd")+" 00:00:00";
            string endTime = EndTime.Value.ToString("yyyy-MM-dd")+" 23:59:00";
            DataTable dt = EntityDao.pcrpanel.PCRPanel.SerchPanelInfo(string.Format(" CreateTime>='{0}' and CreateTime<='{1}'",startTime,endTime));
            DataTable temp = new DataView(dt).ToTable(true,new string[] { "PanelNumber"});
            foreach (DataRow item in temp.Rows)
                this.ComboPh.Properties.Items.Add(item["PanelNumber"].ToString());
            this.PanelGridControl.DataSource = DT;
            PanelGridControl.DataSource = dt;

        }

        private void PanelGrid_DoubleClick(object sender, EventArgs e)
        {
            string pc = this.PanelGrid.GetRowCellValue(PanelGrid.FocusedRowHandle, PanelGrid.Columns["PanelNumber"]).ToString();
            if (pc.Trim().Equals("") == true)
                return;

            _SerchPanelDataFunction(string.Format(" PanelNumber='{0}' and CreateTime>='{1}' and CreateTime<='{2}'",pc, 
                Start.Value.ToString("yyyy-MM-dd") + " 00:00:00", 
                EndTime.Value.ToString("yyyy-MM-dd") + " 23:59:00"));
            Close();
        }

        private void PanelFind_Load(object sender, EventArgs e)
        {
            TimeChanged(sender, e);
        }

        private void btnserch_Click(object sender, EventArgs e)
        {
            string startTime = Start.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endTime = EndTime.Value.ToString("yyyy-MM-dd") + " 23:59:00";
            ComboBoxItemCollection list = ComboPh.Properties.Items;
            
            this.PanelGridControl.DataSource = DT;
        }
    }
}