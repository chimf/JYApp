using DevExpress.XtraEditors.Repository;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AppClient.UIS
{
    public partial class UISendSample : DevExpress.XtraEditors.XtraUserControl
    {
        private DataTable RendTable;
        public bool isMananger;
        public UISendSample()
        {
            InitializeComponent();
        }

        public void FullAddress() {
          DataTable address =  EntityDao.imp.Covid.GetDataByMaster("", "select CyAddress from CovidSample where CreateTime>=GETDATE()-1 group by CyAddress ");
            if (address == null)
                return;
            foreach (DataRow item in address.Rows)
            {
                EntityDao.Entity.ControlModelItem citem = new EntityDao.Entity.ControlModelItem(item["CyAddress"].ToString(),item["CyAddress"].ToString());
                textAddress.Properties.Items.Add(citem);
            }
        }

        private DataTable SetTableValue(DataTable dt){
            dt.Columns.Add("cool");
            foreach (DataRow item in dt.Rows)
            {
                string value = item["isCool"].ToString();                
                item.BeginEdit();
                if (value.Equals("1"))
                    item["cool"] = "冷库";
                else
                    item["cool"] = "";
                item.EndEdit();
                dt.AcceptChanges();
            }
            return dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RendTable = EntityDao.imp.Covid.GetData(GetCondition());            
            GridSendControl.DataSource = SetTableValue(RendTable);
            gridColumn4.FieldName = "perCertTYpec";
            cool.FieldName = "cool";
        }

        private string GetCondition(bool isLine=false) {
            StringBuilder sb = new StringBuilder();
            sb.Append(" 2>1 ");
            if (!EditBarCode.Text.Trim().Equals(""))
                sb.AppendFormat(" and Barcode='{0}'", EditBarCode.Text.Trim());
            if (!ComboxCardType.Text.Trim().Equals(""))
                sb.AppendFormat(" and perCertTypec='{0}'", ComboxCardType.Text.Trim());
            if (!ComboxUserType.Text.Trim().Equals(""))
                sb.AppendFormat(" and typeName = '{0}'", ComboxUserType.Text.Trim());
            if (!ComboxUserUnit.Text.Trim().Equals(""))
                sb.AppendFormat(" and unit like '{0}'%", ComboxUserUnit.Text.Trim());
            if (!ComboxWTUnit.Text.Trim().Equals(""))
                sb.AppendFormat(" and principal like '{0}%'", ComboxWTUnit.Text.Trim());
            if (isLine == false)
            {
                if (isNoSend.Checked)
                    sb.Append(" and (isInput=9 or isInput=8)");
               
            }
            return sb.ToString();

        }

        private void initTable() {
            cool.FieldName = "cool";
            RendTable= EntityDao.imp.Covid.GetData(" isInput=9");
            GridSendControl.DataSource = SetTableValue(RendTable);
            GridSendView.BestFitColumns();
            timeEND.EditValue = "23:59:00";
            timeStart.EditValue = "00:00:00";
           
        }

        private void UISendSample_Load(object sender, EventArgs e)
        {
            initTable();
            if (isMananger)
            {
                FullAddress();
                textAddress.Text = EntityDao.imp.Covid.GetloginAddress();
                textAddress.Enabled = true;
            }
            else {
                textAddress.Text = EntityDao.imp.Covid.GetloginAddress();
                textAddress.Enabled = false;
            }
        }

        private void BtnPackage_Click(object sender, EventArgs e)
        {
            if (RendTable == null)
                return;
            DataRow[] rows = RendTable.Select("isInput=9");
            if (rows.Length <= 0)
                return;
            DataTable uploadTable = new DataTable();
            foreach (DataColumn dataColumn in RendTable.Columns)   
                uploadTable.Columns.Add(dataColumn.ColumnName);
            foreach (DataRow item in rows)
            {
                if (string.IsNullOrEmpty(item["isCool"].ToString()))
                    item["isCool"] = 0;
                uploadTable.ImportRow(item);
            }
            int info;
            try
            {
                if (EntityDao.imp.Covid.WriteToMasterTable(uploadTable, out info))
                {
                    foreach (DataRow item in uploadTable.Rows)
                        EntityDao.imp.Covid.SetFlag(10, string.Format("perCertNo='{0}'", item["perCertNo"].ToString()));
                    MessageBox.Show("上传成功,当前上报记录数：【" + info + "】 人份");
                    EntityDao.imp.Covid.DeleteByConditon(string.Format(" isInput=10"));
                    RendTable = EntityDao.imp.Covid.GetData(" isInput=9");
                    GridSendControl.DataSource = RendTable;
                    GridSendView.BestFitColumns();
                }
            }
            catch (Exception er) {
                MessageBox.Show("\n\n"+ er.Message,"上传失败",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }



        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if(RendTable!=null || RendTable.Rows.Count>0)
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
                        GridSendView.ExportToXlsx(exportFilePath);
                        break;
                    case ".xlsx":
                        GridSendView.ExportToXlsx(exportFilePath);
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridColumn4.FieldName = "perCertTypec";
            cool.FieldName = "isCool";
            StringBuilder sb = new StringBuilder();
            if(isMananger)
                sb.Append(string.Format("select * from CovidSample where "));
            else
                sb.Append(string.Format("select * from CovidSample where Colleter='{0}' AND ", EntityDao.imp.Covid.GetLoginUser()));
            sb.AppendFormat(" CreateTime>='{0}' and CreateTime<='{1}'",
                            startTime.Value.ToString("yyyy-MM-dd") + " " + timeStart.Text.Trim(),
                            edntime.Value.ToString("yyyy-MM-dd") + " " + timeEND.Text.Trim());
            if (textAddress.Text.Trim().Equals(""))
                sb.AppendFormat(" and CyAddress='{0}'", EntityDao.imp.Covid.GetloginAddress());
            else
                sb.AppendFormat(" and CyAddress like '%{0}'", textAddress.Text.Trim());
            sb.AppendFormat(" And {0}",GetCondition(true));

            try
            {
                RendTable = EntityDao.imp.CovidSampleStore.GetDataOnline(sb.ToString());               
                GridSendControl.DataSource = RendTable;
                GridSendView.BestFitColumns();
            }
            catch (Exception er) {
                MessageBox.Show(er.Message);
            }
            
        }

        private void ItemCombox_Click(object sender, EventArgs e)
        {
            RepositoryItemComboBox checkBox = (sender as RepositoryItemComboBox);
            switch (checkBox.Tag.ToString())
            {
                case "cardtype":
                    break;
                case "jobtype":
                    //3.下拉框选中值改变事件
                    checkBox.SelectedIndexChanged += new EventHandler(SelectedIndexChanged);
                    //4.解决IConvertible问题
                    checkBox.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(repositoryItem_ParseEditValue);
                    break;
                case "subjobtype":
                    break;
                case "area":
                    break;
                default:
                    break;
            }

        }

        private void SelectedIndexChanged(object sender, EventArgs e) {
            EntityDao.Entity.ControlModelItem editItem =  (EntityDao.Entity.ControlModelItem )(sender as DevExpress.XtraEditors.ComboBoxEdit).SelectedItem;

        }
        private void repositoryItem_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e) {
            e.Value = e.Value.ToString(); e.Handled = true;
        }

        private void btnUploadOne_Click(object sender, EventArgs e)
        {

        }
    }
}
