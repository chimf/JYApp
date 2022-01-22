using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraGrid.Columns;

namespace AppClient.UIS.TJUi
{
    public partial class CollectTotallUI : XtraUserControl
    {
        private DataTable InputTable;
        private DataTable OnlineTable;
        private List<GridColumn> initColums = new List<GridColumn>();
        public bool isManager;
        public CollectTotallUI()
        {
            InitializeComponent();
        }
        private void LoadXMData_Click(object sender, EventArgs e)
        {
            ReLoadXML();
        }
        private void ReLoadXML() {
            //初始化加载导入数据预处理
            InputTable = Utiles.UtileCompont.LoadDataFormDiskData(LocalDataView.Columns);
            if (InputTable != null)
               LocalDataContorl.DataSource = InputTable;
            else
                InputTable = new DataTable();
            if (!InputTable.Columns.Contains("status"))
                InputTable.Columns.Add("status");
            //LocalDataView.BestFitColumns();
        }

        private string GetCodtion() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" CreateTime>='{0}' and CreateTime<='{1}'",
                StartDate.Value.ToString("yyyy-MM-dd")+" "+StartTime.EditValue,
                EndDate.Value.ToString("yyyy-MM-dd") + " " + EndTime.EditValue
                );
            sb.AppendFormat(" And CyAddress='{0}'",comboxcyaddress.Text.Trim());
            return sb.ToString();
        }

        private void SerchButton_Click(object sender, EventArgs e)
        {
            string where = GetCodtion();
            OnlineTable = EntityDao.imp.Covid.GetDataByMaster(where);
            if (OnlineTable == null || OnlineTable.Rows.Count <= 0) return;
            this.OnlineDataContorl.DataSource = OnlineTable;
            OnlineDataView.BestFitColumns();
        }

        public void FullAddress()
        {
            DataTable address = EntityDao.imp.Covid.GetDataByMaster("", "select CyAddress from CovidSample where CreateTime>=GETDATE()-1 group by CyAddress ");
            if (address == null)
                return;
            foreach (DataRow item in address.Rows)
            {
                EntityDao.Entity.ControlModelItem citem = new EntityDao.Entity.ControlModelItem(item["CyAddress"].ToString(), item["CyAddress"].ToString());
                comboxcyaddress.Properties.Items.Add(citem);
            }
        }

        private void CollectTotallUI_Load(object sender, EventArgs e)
        {
            StartDate.Value = DateTime.Now;
            EndDate.Value = DateTime.Now;
            StartTime.EditValue = "00:00:00";
            EndTime.EditValue = "23:59:00";
            foreach (GridColumn item in LocalDataView.Columns)
                initColums.Add(item);
            ReLoadXML();
            SerchButton_Click(sender,e);
            if (isManager)
                FullAddress();
            else
            {
                comboxcyaddress.Text = EntityDao.imp.Covid.GetloginAddress();
                comboxcyaddress.Enabled = false;
            }

            //LocalDataView.Columns["姓名"].GroupIndex = 0;
            //LocalDataView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "总数");
            //LocalDataView.GroupFormat = "{1} {2}";  //默认"{0}: [#image]{1} {2}"; 字段名称：数据 计数=？
            //LocalDataView.OptionsBehavior.AutoExpandAllGroups = true;
        }

        private void CompButton_Click(object sender, EventArgs e)
        {
            if (InputTable == null || InputTable.Rows.Count <= 0)
                return;
            if (OnlineTable == null || OnlineTable.Rows.Count <= 0)
                return;
            List<DataRow> newRows = new List<DataRow>();
            string barcode = "";
            string sampltime = "";
            if(!InputTable.Columns.Contains("Barcode"))
                InputTable.Columns.Add("Barcode");
            if (!InputTable.Columns.Contains("sampTime"))
                InputTable.Columns.Add("sampTime");
            GridColumn gridbarcode = new GridColumn();
            gridbarcode.Caption = "条码号";
            gridbarcode.FieldName = "Barcode";
            gridbarcode.Visible = true;
            gridbarcode.VisibleIndex = 0;
            if (!LocalDataView.Columns.Contains(gridbarcode))
                LocalDataView.Columns.Add(gridbarcode);
            GridColumn column = new GridColumn();
            column.Caption = "采样时间";
            column.FieldName = "sampTime";
            column.Visible = true;
            column.VisibleIndex = 1;
            if (!LocalDataView.Columns.Contains(column))
                LocalDataView.Columns.Add(column);

            foreach (DataRow OnlineRow in OnlineTable.Rows)
            {
                string CardNo = OnlineRow["perCertNo"].ToString();
                DataRow[] localdrs = InputTable.Select(string.Format("证件号='{0}'",CardNo));
                barcode = OnlineRow["Barcode"].ToString();
                sampltime = OnlineRow["sampTime"].ToString();
                string status = "未处理";
                if (localdrs.Length > 0)                    
                    status = "已采集";
                else
                    newRows.Add(OnlineRow);

                foreach (DataRow filterRow in localdrs)
                {
                    filterRow.BeginEdit();
                    filterRow["status"] = status;
                    filterRow["Barcode"] = barcode;
                    filterRow["sampTime"] = sampltime;
                    filterRow.EndEdit();
                    InputTable.AcceptChanges();                    
                }
            }

            if (newRows.Count > 0) {
                
                foreach (DataRow item in newRows)
                {
                   DataRow dr = InputTable.NewRow();
                    dr["证件类别"] = string.IsNullOrEmpty(item["perCertTypec"].ToString())?"": item["perCertTypec"].ToString().Trim();
                    dr["委托方"] = string.IsNullOrEmpty(item["principal"].ToString()) ? "" : item["principal"].ToString().Trim();
                    dr["单位"] = string.IsNullOrEmpty(item["Unit"].ToString()) ? "" : item["Unit"].ToString().Trim();
                    dr["联系方式"] = string.IsNullOrEmpty(item["perDel"].ToString()) ? "" : item["perDel"].ToString().Trim();
                    dr["证件号"] = string.IsNullOrEmpty(item["perCertNo"].ToString()) ? "" : item["perCertNo"].ToString().Trim();
                    dr["姓名"] = string.IsNullOrEmpty(item["perName"].ToString()) ? "" : item["perName"].ToString().Trim();
                    dr["Barcode"] = string.IsNullOrEmpty(item["Barcode"].ToString()) ? "" : item["Barcode"].ToString().Trim();
                    dr["sampTime"] = string.IsNullOrEmpty(item["sampTime"].ToString()) ? "" : item["sampTime"].ToString().Trim();
                    dr["status"] = "新增";
                    InputTable.Rows.Add(dr);
                }                
            }
        }

        private void LocalDataView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
           object obj = OnlineDataView.GetRowCellValue(e.RowHandle, this.GridStatusRow);
            if (obj == null) return;
            string value = obj.ToString();
            if (string.IsNullOrEmpty(value))
                e.Appearance.BackColor = Color.YellowGreen;            
            else if (value.Trim().Equals("新增"))
                e.Appearance.BackColor = Color.Turquoise;
            else if (value.Trim().Equals("已采集"))
                e.Appearance.BackColor = Color.LawnGreen;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            InputTable.Clear();           
        }

        private void LocalDataView_Click(object sender, EventArgs e)
        {
            DataTable localTable = LocalDataContorl.DataSource as DataTable;
            if (localTable == null || localTable.Rows.Count <= 0)
                return;
            if (OnlineTable == null || OnlineTable.Rows.Count <= 0)
                return;
            //DataRow DR = LocalDataView.GetFocusedDataRow();

            //DataRow[] RR = OnlineTable.Select(string.Format("perCertNo='{0}'", DR["证件号"].ToString()));
           
            //OnlineDataView.ActiveFilterString = string.Format("perCertNo='{0}'", DR["证件号"].ToString());
            //OnlineDataView.ActiveFilterEnabled = true;
           // OnlineDataView.FocusedRowHandle = OnlineDataView.FocusedRowHandle

        }

        private void BtnInputer_Click(object sender, EventArgs e)
        {
            ImportFunc();           
        }

        private void ImportFunc(bool appent=false) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String FileNames = openFileDialog1.FileName;
                String errinfo;
                if (InputTable != null)
                {
                    InputTable.Columns.Clear();
                    InputTable.Rows.Clear();
                }
                DataTable exceTable = Utiles.ExcelUtiles.ExcelToDataTable(FileNames, out errinfo, true, 0);
                if (!errinfo.Equals("") && exceTable == null)
                {
                    MessageBox.Show("读取文件发生错误:" + errinfo, "导入表格错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Utiles.UtileCompont.ImportTable(initColums,LocalDataView.Columns, InputTable, exceTable, Path.GetFileName(FileNames)))
                {
                    LocalDataContorl.DataSource = InputTable;
                    //LocalDataView.BestFitColumns();
                    LocalDataView.RefreshData();
                    Utiles.UtileCompont.CopyExcelFile(FileNames);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ImportFunc(true);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Export();
        }

        public void Export()
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel文件|*.xlsx|Excel-2003|*.xls";
                if (saveDialog.ShowDialog() == DialogResult.Cancel) return;
                var exportFilePath = saveDialog.FileName;
                var fileExtenstion = new FileInfo(exportFilePath).Extension;
                switch (fileExtenstion)
                {
                    case ".xls":
                        LocalDataContorl.ExportToXlsx(exportFilePath);
                        break;
                    case ".xlsx":
                        LocalDataContorl.ExportToXlsx(exportFilePath);
                        break;
                }

                if (File.Exists(exportFilePath))
                {
                    try
                    {
                        Process.Start(exportFilePath);
                    }
                    catch
                    {
                        var msg = "当前文件无法打开" + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var msg = "保存当前文件错误" + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                    MessageBox.Show(msg, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
