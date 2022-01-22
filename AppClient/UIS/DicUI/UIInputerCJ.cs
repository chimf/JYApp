using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;

namespace AppClient.UIS.DicUI
{
    public partial class UIInputerCJ : XtraUserControl
    {
        public string InputerFileName;
        private List<string> ExcelTitleNameList;
        private DataTable InputeTable;
        public UIInputerCJ()
        {
            InitializeComponent();
        }

        private void InputerFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK) {
                String FileNames = openFile.FileName;
                String errinfo;
                DataTable exceTable = Utiles.ExcelUtiles.ExcelToDataTable(FileNames, out errinfo, true, 0);
                if (!errinfo.Equals("") && exceTable == null)
                {
                    MessageBox.Show("读取文件发生错误:" + errinfo, "导入表格错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               DataColumnCollection dcc =  exceTable.Columns;
                foreach (DataColumn item in dcc)
                    if (!ExcelTitleNameList.Contains(item.ColumnName)) {
                        MessageBox.Show("校验表格是否合格发生错误!,\n 不合格列名为:"+item.ColumnName,"列校验错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                foreach (DataRow dr in exceTable.Rows) {
                    DataRow currentDR = InputeTable.NewRow();
                    foreach (DataColumn dc in exceTable.Columns)
                    {
                        foreach (GridColumn item in InputerGridView.Columns)
                        {
                            string value = string.IsNullOrEmpty(dr[dc.ColumnName].ToString()) ? "" : dr[dc.ColumnName].ToString();
                            if (dc.ColumnName.ToUpper().Equals(item.Caption.ToUpper())) {
                                currentDR[item.FieldName] = value;
                            }
                        }
                    }
                    InputeTable.Rows.Add(currentDR);
                }
                InputeContorl.DataSource = InputeTable;
                InputerGridView.BestFitColumns();
            }
        }

        private void UIInputerCJ_Load(object sender, EventArgs e)
        {
            ExcelTitleNameList = new List<string>();
            InputeTable = new DataTable();
            foreach (GridColumn item in InputerGridView.Columns)
            {
                ExcelTitleNameList.Add(item.Caption);
                DataColumn dc = new DataColumn(item.FieldName);
                InputeTable.Columns.Add(dc);
            }
        }
    }
}
