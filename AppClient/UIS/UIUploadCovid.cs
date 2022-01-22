using System;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AppClient.Utiles;
using EntityDao.imp;

namespace AppClient.UIS
{
    public partial class UIUploadCovid : XtraUserControl
    {
        private int CurrentPage = 1;
        private int pageCount = 0, rowcunt = 0;
        public DataTable dataTable;
        public UIUploadCovid()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 重新发送单条记录上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReuploadDataReSend(object sender, EventArgs e)
        {
            DataRow myDataRow = UploadView.GetDataRow(UploadView.FocusedRowHandle);
            string msg;
            if (UploadUtiles.SendDatRow(myDataRow, out msg))
                MessageBox.Show("上报成功");
            else
                MessageBox.Show("上报失败:" + msg);
            UploadView.RefreshRow(UploadView.FocusedRowHandle);
        }


        private void UploadView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            if (e.Column.FieldName.ToUpper() == "SendMessage".ToUpper())
            {
                try
                {
                    string context = UploadView.GetRowCellValue(e.RowHandle, "SendMessage").ToString();

                    if (context.Equals("上传成功") || context.Contains("重复推送"))
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
                catch { }
            }
        }


        private void Page_Click(object sender, EventArgs e)
        {
            SetPageCobox(CurrentPage);
            switch ((sender as SimpleButton).Tag)
            {
                case "pv":
                    CurrentPage -= 1;
                    CurrentPage = CurrentPage <= 0 ? 1 : CurrentPage;
                    SerchData();
                    break;
                case "nt":
                    CurrentPage += 1;
                    CurrentPage = CurrentPage > pageCount ? pageCount : CurrentPage;
                    SerchData();
                    break;
                case "home":
                    CurrentPage = 1;
                    SerchData();
                    break;
                case "last":
                    CurrentPage = pageCount;
                    SerchData();
                    break;
                default:
                    break;
            }
        }

        public string GetCondition()
        {
            StringBuilder sb = new StringBuilder();
            if (!TimeTypeCheck.Checked)
                sb.AppendFormat(" isReport=3 and  CreateTime>='{0}' and CreateTime<='{1}'", StartDate.Value.ToString("yyyy-MM-dd ") + Starttime.Text,
                                           EndDate.Value.ToString("yyyy-MM-dd ") + "23:59:00");
            else
                sb.AppendFormat("  sampTime>= '{0}' and sampTime<= '{1}'", StartDate.Value.ToString("yyyy-MM-dd ") + Starttime.Text,
                                                           EndDate.Value.ToString("yyyy-MM-dd ") + "23:59:00");

            switch (RadioCheck.SelectedIndex)
            {
                case 0: break;
                case 1:
                    sb.AppendFormat(" AND isSendFalg= -1 ");
                    break;
                case 2:
                    sb.Append(" AND isSendFalg= 1 ");
                    break;
                case 3:
                    sb.AppendFormat(" AND isnull(isSendFalg,0)= 0 ");
                    break;
                default:
                    break;
            }

            if (!UserSendUnit.Text.Trim().Equals(""))
                sb.AppendFormat(" AND principal LIKE '{0}%'", UserSendUnit.Text.Trim());
            if (!editBarcode.Text.Trim().Equals(""))
                sb.AppendFormat(" ADN Barcode='{0}'", editBarcode.Text.Trim());
            if (!UserUnit.Text.Trim().Equals(""))
                sb.AppendFormat(" AND Unit like '{0}'", UserUnit.Text.Trim());
            if (!EditCname.Text.Trim().Equals(""))
                sb.AppendFormat(" AND perName like '{0}%'", EditCname.Text.Trim());
            if (!ComboboxCardType.Text.Trim().Equals(""))
                sb.AppendFormat(" AND perCertTypec='{0}'", ComboboxCardType.Text.Trim());
            if (!editAre.Text.Trim().Equals(""))
                sb.AppendFormat(" and county='{0}'", editAre.Text.Trim());
            if (!ComboxClassType.Text.Trim().Equals(""))
                sb.AppendFormat(" AND typeName='{0}'", ComboxClassType.Text.Trim());
            if (!editCardNo.Text.Trim().Equals(""))
                sb.AppendFormat(" AND perCertNo LIKE '{0}%'", editCardNo.Text.Trim());

            return sb.ToString();

        }

        private void SetPageCobox(int currentIndex)
        {
            PageCombox.Properties.Items.Clear();
            for (int i = 0; i < pageCount; i++)
                PageCombox.Properties.Items.Add("第 " + (i + 1) + " 页");
            PageCombox.SelectedIndex = currentIndex - 1;
        }

        private void btn_Serch_Click(object sender, EventArgs e)
        {
            SerchData();
        }

        public void SerchData()
        {
            UploadTabls uploadTabls = new UploadTabls();
            DataTable tmp = uploadTabls.GetPage(" where " + GetCondition(), CurrentPage, 100, out pageCount, out rowcunt);
            SetPageCobox(CurrentPage);
            dataTable = getUploadData(tmp);
            GridUploadControl.DataSource = dataTable;
            CountLabel.Text = string.Format("共 {0} 页 合计：{1} 条记录",pageCount,rowcunt);
            UploadView.BestFitColumns();
        }

        private void PageCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage = PageCombox.SelectedIndex + 1;
            SerchData();
        }

        public DataTable getUploadData(DataTable dt = null)
        {
            DataTable outdt = new DataTable();
           
            if (dt == null)
                return outdt;
            

            foreach (DataColumn dc in dt.Columns)
                outdt.Columns.Add(dc.ColumnName);

            foreach (DataRow item in dt.Rows)
                outdt.ImportRow(item);


            return outdt;
        }

        private void UploadView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //修改单元格后更新
            if (e.Value == null || e.Value.Equals(""))
                return;            
            string ColumnName = e.Column.Name;
            string FieldName = e.Column.FieldName;
            string Value = e.Value.ToString().Trim();
            string id = UploadView.GetFocusedRowCellValue(this.colid).ToString();
            DataRow dr = UploadView.GetDataRow(UploadView.FocusedRowHandle);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update CovidSample set {0}='{1}' where id={2}", FieldName, Value, id);
            if (Covid.UpdateCellValue(sb.ToString()) == false)
                MessageBox.Show("更新数据失败!","修改失败");
        }


    }
}
