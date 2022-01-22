using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AppClient.UIS.Diag
{
    public partial class DUIModify : XtraForm
    {
        private string barcode;
        private DataTable current;
        public DataTable PackTable;
        public int RowNum;
        public DUIModify(String Barcode)
        {
            InitializeComponent();
            barcode = Barcode;
            GridShowInfoControl.DataSource = current = EntityDao.imp.Covid.GetData(string.Format("Barcode='{0}'",Barcode));
            GridShowInfo.BestFitColumns();
        }

        private void GridShowInfo_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        private void btnOP_Click(object sender, EventArgs e)
        {
            if (current == null || current.Rows.Count <= 0)
                return;
            String CertNo = (String)GridShowInfo.GetFocusedRowCellValue(this.perCertNo);
            DataRow dr = GridShowInfo.GetFocusedDataRow();
            if (!string.IsNullOrEmpty(CertNo)) {
                if (MessageBox.Show("是否删除记录?", "删除提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;
                if (EntityDao.imp.Covid.DeleteByConditon(string.Format("perCertNo='{0}'", CertNo)))
                {
                    DataRow pdr = PackTable.Rows[RowNum];
                    try
                    {
                        pdr.BeginEdit();
                        pdr["Counts"] = Convert.ToInt32(pdr["Counts"].ToString()) - 1;
                        if (pdr["Counts"].ToString().Equals("0"))
                            PackTable.Rows.Remove(pdr);
                        current.Rows.Remove(dr);
                    }
                    finally
                    {
                        pdr.EndEdit();
                        PackTable.AcceptChanges();

                    }
                }
                else
                    MessageBox.Show("当前信息已删除!");
            }
           
        }

        private void GridShowInfo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //修改单元格后更新
            if (e.Value == null)
                return;
            if (e.Value.Equals(""))
                return;
            string FieldName = e.Column.FieldName;
            string Value = e.Value.ToString().Trim();
            string id = GridShowInfo.GetFocusedRowCellValue(this.Id).ToString();
            DataRow dr = GridShowInfo.GetDataRow(GridShowInfo.FocusedRowHandle);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update CovidSample set {0}='{1}' where Id='{2}'", FieldName, Value, id);
            if (EntityDao.imp.Covid.UpdateData(sb.ToString()) != 1)
                MessageBox.Show("修改值失败");
        }
    }
}