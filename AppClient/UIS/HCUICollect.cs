using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Diagnostics;
using EntityDao.Entity;
using System.Text;
using DevExpress.XtraGrid.Columns;
using System.Collections.Generic;

namespace AppClient.UIS
{
    public partial class HCUICollect : XtraUserControl
    {
        private DataTable CollectTable=new DataTable("CollectTable");
        private DataTable PackageTable = null;
        private DataTable InputTable=null;
        private DataTable jobTable;
        private String Title;
        private string inputCaption;
        private List<GridColumn> InitGridColumns;
        public HCUICollect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 校验用户输入合法性
        /// </summary>
        /// <returns></returns>
        private Boolean Checkinput(Patient patient) {

            if (EditCardNo.Text.Trim().Equals(""))
            {
                MessageBox.Show("必须输入证件号");
                return false;
            }
            else
            {
                string usercard = EditCardNo.Text.Trim().ToUpper();                
                patient.UserCardNo = usercard;
                if (ComboxCardType.Text.Trim().Equals("居民身份证")) {
                    if (usercard.Length == 18 || usercard.Length == 15)
                    {
                        if (EntityDao.imp.IDCard.Parse(usercard) == null)
                        {
                            MessageBox.Show("当前选择的是 居民身份证 当前证件号不匹配，请确保是否输入正确证件号，或选择的证件类型是错误的");
                            return false;
                        }
                    }
                    else {
                        MessageBox.Show("当前选择的是 居民身份证 当前证件号不匹配，请确保是否输入正确证件号，或选择的证件类型是错误的");
                        return false;
                    }
                }
            }

            //if (ComboxUserType.Text.Trim().Equals("")) {
            //    MessageBox.Show("必须选择采集类型");
            //    return false;
            //} else
            //    patient.UserCollectType = ComboxUserType.Text.Trim(); 

            if (ComboxCardType.Text.Trim().Equals(""))
            {
                MessageBox.Show("必须选择证件类型");
                return false;
            }
            else
                patient.UserCardType = ComboxCardType.Text.Trim();

            if (EditBarCode.Text.Trim().Equals(""))
            {
                MessageBox.Show("必须输入预制条码号");
                return false;
            }
            else
                patient.UserBarcode = EditBarCode.Text.Trim();
            if (ComboxSampleType.Text.Trim().Equals(""))
            {
                MessageBox.Show("必须指定样本类型：默认--【咽拭子】");
                return false;
            }
            else
                patient.UserSampleType = ComboxSampleType.Text.Trim();
            if (EditName.Text.Trim().Equals(""))
            {
                MessageBox.Show("必须输入被采集者姓名");
                return false;
            }
            else
                patient.UserName = EditName.Text.Trim();
            if (EditTphone.Text.Trim().Equals(""))
            {
                MessageBox.Show("必须输入被采集者电话");
                return false;
            }
            else
            {
                patient.UserPhone = EditTphone.Text.Trim();
                if (EntityDao.imp.IDCard.IsMobilePhone(patient.UserPhone) == false) {
                    if (EntityDao.imp.IDCard.IsTel(patient.UserPhone) == false) {
                        MessageBox.Show("联系方式错误，请确认如果是固定电话请按照格式: 010-888999881 填写");
                        return false;
                    }
                }
                   
            }
            if (ComboxJob.Text.Trim().Equals(""))
            {
                MessageBox.Show("必须指定职业分类-如果为个人请指定职业分类为：其他分类");
                return false;
            }
            else
                patient.UserJob = ComboxJob.Text.Trim();

            if (ComboxWTUnit.Text.Trim().Equals(""))
            {
                MessageBox.Show("必须指定委托单位：如果为个人采集-委托单位请选择个人");
                return false;
            }
            else
                patient.UserSendUnit = ComboxWTUnit.Text.Trim();

            patient.UserSubJob = ComboxSubJob.Text.Trim();
            try
            {
                patient.UserAge = Convert.ToInt32(EditAge.Text.Trim());
            }
            catch {
                patient.UserAge = 0;
            }

            patient.IsCool = IsCoollSwitch.IsOn ? 1 : 0;
            patient.UserCollectType = "重点人群核酸";           
            patient.UserSex = ComboxSex.Text.Trim();
            patient.UserUnit = ComboxUserUnit.Text.Trim();
            patient.UserArea = "思明区";
            patient.UserCommand = EditCommand.Text.Trim();
            patient.UserCollectTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            patient.IsInput = 1;
            patient.Cost = editmony.Text.Trim();
            patient.UserCollecter = EntityDao.imp.Covid.GetLoginUser();
            patient.Email = EditEmail.Text.Trim();
            return true;               
        }

        private void ClearCompents(bool Packaged=false,bool isAll=false) {
            EditCardNo.Text = ""; 
            EditName.Text = "";
            EditTphone.Text = "";
            EditAge.Text = "";
            ComboxSex.Text = "";
            EditEmail.Text = "";
            editmony.Text = "0";
            if (isAll)
            {
                ComboxJob.Text = "";
                ComboxWTUnit.Text = "";
                ComboxSubJob.Text = ""; ;
                ComboxUserUnit.Text = "";
            }
            EditCommand.Text = "";
            if (Packaged) {
               EditBarCode.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isSingle = false;
            DataTable dt = EntityDao.imp.Covid.GetDataBySQL(string.Format("select count(1) Counts from CovidSample where isInput<>1 and Barcode='{0}'", EditBarCode.Text.Trim()));
            int counts = Convert.ToInt32(dt.Rows[0]["Counts"].ToString());
            if (CollectTable != null && CollectTable.Rows.Count > 0) {
               DataRow[] r = CollectTable.Select(string.Format("Barcode='{0}'", EditBarCode.Text.Trim()));
                if (r != null && r.Length > 0) 
                    counts += r.Length;
            }
            if (counts >= 10)
            {
                MessageBox.Show("当前条码已满，请重新选择条码，如果是追加样本，请打包", "条码号错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EditBarCode.Text = "";
                EditBarCode.Focus();
                return;
            }          
            //判断是否存在不同条码号的采集
            foreach (DataRow item in CollectTable.Rows)
                if (!item["Barcode"].ToString().ToUpper().Contains(EditBarCode.Text.Trim().ToUpper()))
                {
                    isSingle = true;
                    break;
                }
            if (isSingle)
            {
                MessageBox.Show("当前条码与已采集条码不同，请重新选择条码","条码号错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EditBarCode.Text = "";
                EditBarCode.Focus();
                return;
            }
            bool isfull = CollectTable != null && CollectTable.Select(String.Format("Barcode='{0}'", EditBarCode.Text.Trim())).Length >=10 ? true : false;
            if (isfull)
            {
                MessageBox.Show("当前条码已经达到10管", "混管数量达到10人次", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Patient patient = new Patient();
            if (!Checkinput(patient))
                return;
            if (HCUIConllectPorcess.WriteToTable(patient, CollectTable) == 1)
            {
                CollectGroupPanel.Text = string.Format("{0} 已录入 {1} 人", Title, CollectTable.Rows.Count);
                SetInputDataFlag(patient, "1");
                ClearCompents();
                GridCollectView.BestFitColumns();
                isfull = CollectTable != null && CollectTable.Select(String.Format("Barcode='{0}'", EditBarCode.Text.Trim())).Length == 10 ? true : false;
                if (isfull)
                {
                    if (MessageBox.Show("当前条码已经达到10管，是否打包？", "混管数量达到10人次", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        BtnPackage_Click(sender, e);
                        return;
                    }
                    else
                        return;
                }
            }
            else
                MessageBox.Show("当前样本已采集");
            IsCoollSwitch.IsOn = false;

        }

        public void SetInputDataFlag(Patient patient, string flag = "0") {
            string CardNo = patient.UserCardNo.Trim();
            //if (InputTable == null || InputTable.Rows.Count <= 0)
            //    return;
            //DataRow[] dr =  InputTable.Select(string.Format("证件号='{0}'",CardNo));
            //if (dr.Length > 0)
            //{
            //    dr[0].BeginEdit();
            //    dr[0]["isCollect"] = 1;
            //    dr[0].EndEdit();
            //    InputTable.AcceptChanges();               
            //}
            
        }

        private void HCUICollect_Load(object sender, EventArgs e)
        {
            HCUIConllectPorcess.InitTables(GridCollectView.Columns,CollectTable);
            GridCollectController.DataSource = this.CollectTable;
            Title = CollectGroupPanel.Text;
            InitGridColumns = new List<GridColumn>();
            initTables();
        }


        private void BtnPackage_Click(object sender, EventArgs e)
        {
            GridPackageContorller.DataSource =  HCUIConllectPorcess.PackageAction(CollectTable);
            EntityDao.imp.CovidSampleStore.UploadByLis(CollectTable);
            EntityDao.imp.CovidSampleStore.WriteToTable(CollectTable);           
            CollectTable.Clear();
            EntityDao.imp.CovidSampleStore.UploadByLis(CollectTable);
            ClearCompents(true);
            CollectGroupPanel.Text = string.Format("{0} 已录入 {1} 人", Title, CollectTable.Rows.Count);
        }

        private void GridPackView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void GridCollectView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String FileNames = openFileDialog1.FileName;
                String errinfo;
                DataTable exceTable = Utiles.ExcelUtiles.ExcelToDataTable(FileNames, out errinfo, true, 0);
                if (!errinfo.Equals("") && exceTable == null)
                {
                    MessageBox.Show("读取文件发生错误:" + errinfo, "导入表格错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Utiles.UtileCompont.ImportTable(InitGridColumns,ImporGridView.Columns, InputTable, exceTable,Path.GetFileName(FileNames)))
                {                    
                    importControl.DataSource = InputTable;
                    ImporGridView.RefreshData();
                    ImporGridView.BestFitColumns();
                    Utiles.UtileCompont.CopyExcelFile(FileNames);
                    InputPanel.Text = inputCaption + " 【导入总数】：" + InputTable.Rows.Count+" 条记录 -  文件位置:【"+FileNames+"】";
                }
            }
        }

        private void btnExportToFile_Click(object sender, EventArgs e)
        {
            if (InputTable != null)
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
                        importControl.ExportToXlsx(exportFilePath);
                        break;
                    case ".xlsx":
                        importControl.ExportToXlsx(exportFilePath);
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

        private void RowOpBtn_Click(object sender, EventArgs e)
        {
            DataRow myDataRow = GridCollectView.GetDataRow(GridCollectView.FocusedRowHandle);
            //perCertNo,perName,ID
            if (myDataRow != null && !string.IsNullOrEmpty(myDataRow["perCertNo"].ToString()))
            {
                DialogResult rs = MessageBox.Show("确定是否删除【" + myDataRow["perName"].ToString() + "】信息?", "删除信息警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if ( rs== DialogResult.Yes)
                {
                    if (EntityDao.imp.Covid.DeleteByConditon(string.Format("perCertNo='{0}' and perName='{1}'", myDataRow["perCertNo"].ToString(), myDataRow["perName"].ToString()))) 
                        this.CollectTable.Rows.Remove(myDataRow);
                }
            }
        }


        private void initTables() {
            if (EntityDao.imp.Covid.IsEmptyByTableFieldName("CovidSample", "isCool", true, "int")==false) {
                MessageBox.Show("初始化表结构发生错误！请联系管理员,程序将退出","系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();

            }
            this.CollectTable = EntityDao.imp.Covid.GetData("IsInput=1");
            this.PackageTable = EntityDao.imp.Covid.GetDataBySQL(string.Format("select * from (select orderNo as No,BarCode,count(1) Counts from CovidSample where isInput<>1  Group by BarCode) a order by a.No desc"));
            GridPackageContorller.DataSource = PackageTable;
            GridCollectController.DataSource = CollectTable;
            GridCollectView.BestFitColumns();
            GridPackView.BestFitColumns();

            jobTable =  EntityDao.imp.CovidSampleStore.GetJobs();
            if (jobTable != null) {
                DataView dv = new DataView(jobTable);
                DataTable job = dv.ToTable(true, "JobName");
                foreach (DataRow item in job.Rows)
                    ComboxJob.Properties.Items.Add(item[0]);                
            }

            foreach (GridColumn item in ImporGridView.Columns)
            {
                item.Visible = true;
                InitGridColumns.Add(item);
            }
                
            ReLoadDataFormDisk();

        }

        private void ReLoadDataFormDisk() {
            //初始化加载导入数据预处理
            InputTable = Utiles.UtileCompont.LoadDataFormDiskData(ImporGridView.Columns);
            if (InputTable != null)
            {
                importControl.DataSource = InputTable;
                ImporGridView.BestFitColumns();
            }
            else
                InputTable = new DataTable();

            inputCaption = InputPanel.Text;
        }

        private void EditCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            Patient info = new Patient();
            string CardID = EditCardNo.Text.Trim().ToUpper();
            EntityDao.imp.IDCard card = EntityDao.imp.IDCard.Parse(CardID);
            if (EditCardNo.Text.Trim().Length == 18 && card==null)
            {
                MessageBox.Show("证件号验证失败，证件号不是有效身份证号码");
                return;
            }
            DataTable dt = null;
            try
            {
                string sql = string.Format(" perCertNo='{0}' and CreateTime>='{1}' and  CreateTime>='{2}'", CardID,
                    DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00",
                    DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:00"
                    );
                if (EntityDao.imp.Covid.isEmptyByMaster(sql)) {
                    DataRow dr = EntityDao.imp.Covid.GetInfoByMaster(sql);
                    string message = "受检人当天已采集过！确认再次采集吗！";
                    //perName,CyAddress,Barcode,sampTime

                    if (dr != null && dr.ItemArray.Length>0) {
                        message = string.Format("【{0} 】 当天已在 【 {1} 】 采集过样本，采集的条码号为【{2}】 采集时间：【{3}】",
                            dr["perName"].ToString(), dr["CyAddress"].ToString(), dr["Barcode"].ToString(), dr["sampTime"].ToString()
                            );
                        if (MessageBox.Show(message, "采集提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                            return;
                    }                          
                   
                }                   
                dt = EntityDao.imp.CovidSampleStore.SerchDataByLis(string.Format("perCertNo like '%{0}'", CardID));
                if (dt == null || dt.Rows.Count <= 0)
                    MessageBox.Show("当前无匹配信息，请手工输入其它信息！", "服务端提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       
            }
            catch (Exception er) {
                if (MessageBox.Show(er.Message + "\n\n确定是否手工录入数据？", "访问错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                    return;
            }
            //           
            info.UserCardNo = EditCardNo.Text.Trim();            
            if(dt!=null && dt.Rows.Count>=1){
                Diag.PatientInfoFormDialg winfo = new Diag.PatientInfoFormDialg();
                winfo.StartPosition = FormStartPosition.Manual;
                winfo.Location = MousePosition;
                winfo.infodata = dt;
                winfo.ShowDialog();
                FullCompoent(info,winfo.outRow);
                return;
            }                                
            if (card != null)
            {
                info.UserAge = card.GetAge();
                info.UserSex = card.sex;
                info.UserCardType = "居民身份证";
                FullCompoent(info, null);
            }
            else {
                
                if (!EntityDao.imp.IDCard.isHKCard(CardID).Equals(""))
                    info.UserCardType = EntityDao.imp.IDCard.isHKCard(CardID);
                else if (!EntityDao.imp.IDCard.isTWCard(CardID).Equals(""))
                    info.UserCardType = EntityDao.imp.IDCard.isTWCard(CardID);
                else
                    info.UserCardType = EntityDao.imp.IDCard.isPassportCard(CardID);
                FullCompoent(info, null); 
            }
                
        }

        private void FullCompoent(Patient info, DataRow StoreRow) {
            if (StoreRow != null && StoreRow.ItemArray.Length > 0) {
                info.UserPhone = StoreRow["perDel"].ToString();
                info.UserSendUnit = StoreRow["principal"].ToString();
                info.UserUnit = StoreRow["Unit"].ToString();
                info.UserCardNo = StoreRow["perCertNo"].ToString();
                info.UserName = StoreRow["perName"].ToString();
                info.UserPhone = StoreRow["perDel"].ToString();
                OldCollectTime.Text = StoreRow["OldCollectTime"].ToString();
                if(StoreRow.Table.Columns.Contains("isCool"))
                    info.IsCool = Convert.ToInt32(StoreRow["isCool"].ToString());
                   
            }
            EditCardNo.Text = info.UserCardNo;
            ComboxCardType.Text = info.UserCardType;
            EditAge.Text = info.UserAge.ToString();
            ComboxSex.Text = info.UserSex;
            ComboxWTUnit.Text = info.UserSendUnit;
            ComboxJob.Text = string.IsNullOrEmpty(info.UserJob)? ComboxJob.Text.Trim():info.UserJob;
            ComboxSubJob.Text = string.IsNullOrEmpty(info.UserSubJob)?ComboxSubJob.Text.Trim():info.UserSubJob;
            ComboxUserUnit.Text = info.UserUnit;
            EditName.Text = info.UserName;
            EditCommand.Text = info.UserNote;
            EditTphone.Text = info.UserPhone;
            IsCoollSwitch.IsOn = info.IsCool==1?true:false;
        }

        private void SerchSubJob(string jobname) {
            if (jobTable != null) {
              DataRow[] dr = jobTable.Select(string.Format("JobName='{0}'",jobname));
              ComboxSubJob.Text = "";               
              ComboxSubJob.Properties.Items.Clear();
                if (dr.Length <= 0)
                {
                    ComboxSubJob.Properties.ReadOnly = true;
                    return;
                }
                else
                {
                    if (dr.Length == 1)
                        ComboxSubJob.Properties.ReadOnly = string.IsNullOrEmpty(dr[0]["SubJobName"].ToString()) ? true : false;
                    else
                        ComboxSubJob.Properties.ReadOnly = false;
                }
              foreach (DataRow item in dr)
                ComboxSubJob.Properties.Items.Add(item["SubJobName"].ToString());
              ComboxSubJob.ShowPopup();
                ComboxSubJob.SelectedIndex = 0;
            }
        }

        private void ComboxJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            SerchSubJob(ComboxJob.Text.Trim());
        }


        private void GridPackView_DoubleClick(object sender, EventArgs e)
        {
            String Barcode = (String)GridPackView.GetFocusedRowCellValue(BarCode);
            Diag.DUIModify dUIModify = new Diag.DUIModify(Barcode);
            dUIModify.StartPosition = FormStartPosition.Manual;
            dUIModify.Location = MousePosition;
            dUIModify.PackTable = this.PackageTable;
            dUIModify.RowNum = GridPackView.GetRowHandle(GridPackView.GetFocusedDataSourceRowIndex());
            dUIModify.ShowDialog();
            dUIModify.Dispose();
        }

        private void ImporGridView_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = ImporGridView.GetFocusedDataRow();
            if (dr == null)
                return;
            Patient p = new Patient();
            p.UserCardNo = dr["证件号"].ToString().ToUpper();
            p.UserName = dr["姓名"].ToString();           
            p.UserSendUnit = string.IsNullOrEmpty(dr["委托方"].ToString())?ComboxWTUnit.Text.Trim(): dr["委托方"].ToString();
            p.UserUnit = string.IsNullOrEmpty(dr["单位"].ToString())?ComboxUserUnit.Text.Trim(): dr["单位"].ToString();
            if (p.UserCardNo.Length == 18 || p.UserCardNo.Length == 15) {
                if (EntityDao.imp.IDCard.Parse(p.UserCardNo) == null)               
                  MessageBox.Show("证件并非身份证，请手工选择正确的证件类型", "未知身份证件");
            }
            EntityDao.imp.IDCard card = EntityDao.imp.IDCard.Parse(p.UserCardNo);
            if (card != null)
                p.UserCardType = "居民身份证";
            else {
               string typename = EntityDao.imp.IDCard.isHKCard(p.UserCardNo);
                if (typename.Equals(""))
                    typename= EntityDao.imp.IDCard.isTWCard(p.UserCardNo);
                if (typename.Equals(""))
                    typename = EntityDao.imp.IDCard.isPassportCard(p.UserCardNo);
                p.UserCardType = typename;
            }
            //p.UserCardType = dr["证件类别"].ToString();
            p.UserPhone = dr["联系方式"].ToString();            
            p.UserJob = string.IsNullOrEmpty(dr["职业分类"].ToString()) ? ComboxJob.Text.Trim() : dr["职业分类"].ToString();
            //职业子分类
            p.UserSubJob = string.IsNullOrEmpty(dr["职业子分类"].ToString()) ? ComboxSubJob.Text.Trim() : dr["职业子分类"].ToString();
            string value = string.IsNullOrEmpty(dr["是否冷库"].ToString()) ?"": dr["是否冷库"].ToString();
            if (value.Contains("冷库") || value.Equals("是"))
                p.IsCool = 1;
            else
                p.IsCool = 0;
            FullCompoent(p,null);
            
        }

        private void importEdit_TextChanged(object sender, EventArgs e)
        {
         TextBox textbox = (sender as TextBox);
         StringBuilder  where = new StringBuilder();                      
            if (InputTable == null || InputTable.Rows.Count <= 0)
                return;
            TextBox tb = sender as TextBox;
            switch (Convert.ToInt32(tb.Tag))
            {
                case 0: where.AppendFormat("证件号 like'%{0}'",tb.Text.Trim()); break;
                case 1: where.AppendFormat("姓名 like '{0}%'", tb.Text.Trim()); break;
                case 2: where.AppendFormat("联系方式 like '%{0}'", tb.Text.Trim()); break;
                default:
                    break;
            }
            
           DataRow[] drs = InputTable.Select(where.ToString());
           DataTable dt = new DataTable();
            foreach (DataColumn dc in InputTable.Columns)
                dt.Columns.Add(dc.ColumnName);
            foreach (DataRow item in drs)
                dt.ImportRow(item);
            importControl.DataSource = dt;
        }

        private void importCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable dt = importControl.DataSource as DataTable;
                if (dt == null || dt.Rows.Count <= 0)
                    return;
                if (dt.Rows.Count == 1)
                {
                    ImporGridView_DoubleClick(sender, e);
                    importCardNo.Text = "";
                    importname.Text = "";
                    importtel.Text = "";
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch ((sender as ToolStripMenuItem).Tag)
            {
                case 0:
                   
                    ReLoadDataFormDisk();
                    break;
                case 1: btnImportExcel_Click(sender,e); break;
                case 2: Export();
                    break;
                default:break;
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dr = ImporGridView.GetFocusedDataRow();
            if (dr == null)
                return;
            switch ((sender as ToolStripMenuItem).Tag)
            {
                case 0: Clipboard.SetDataObject(string.IsNullOrEmpty(dr["证件号"].ToString())?"": dr["证件号"].ToString().Trim()); break;
                case 1: Clipboard.SetDataObject(string.IsNullOrEmpty(dr["姓名"].ToString()) ? "" : dr["姓名"].ToString().Trim()); break;
                case 2: Clipboard.SetDataObject(string.IsNullOrEmpty(dr["联系方式"].ToString()) ? "" : dr["联系方式"].ToString().Trim()); break;
                default: break;
            }
        }

        private void EditSerchBarCode_TextChanged(object sender, EventArgs e)
        {
            if (PackageTable == null)
                return;
           DataRow[] drs = PackageTable.Select(string.Format("BarCode like '%{0}'",EditSerchBarCode.Text.Trim()));
            if (drs.Length <= 0)
                return;
            DataTable dt = new DataTable();
            foreach (DataColumn item in PackageTable.Columns)
                dt.Columns.Add(item.ColumnName);
            foreach (DataRow item in drs)
                dt.ImportRow(item);
            GridPackageContorller.DataSource = dt;
        }

        private void GridCollectView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //int iHandle = e.RowHandle;
            //DataRow dr_gridView = GridCollectView.GetDataRow(iHandle);
            //if (dr_gridView == null) { return; }
            //string Conts = dr_gridView["Conts"] == null ? "" : dr_gridView["Conts"].ToString();
            //if (string.IsNullOrWhiteSpace(Conts))
            //    return;
            //else
            //{
            //    Color appNotPassDefault = e.Appearance.BackColor;
            //    if (10<Convert.ToInt32(Counts))
            //    {
            //        e.Appearance.BackColor = Color.Gray;
                    
            //        this.GridCollectView.OptionsView.EnableAppearanceEvenRow = false;
            //        this.GridCollectView.OptionsView.EnableAppearanceOddRow = false;
            //    }
            //    else
            //    {
            //        this.GridCollectView.OptionsView.EnableAppearanceEvenRow = true;
            //        this.GridCollectView.OptionsView.EnableAppearanceOddRow = true;
            //    }
            //}

        }

        private void radioall_Click(object sender, EventArgs e)
        {
            importEdit_TextChanged(sender, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ClearCompents(true,true);
        }

        private void ComboxWTUnit_TextChanged(object sender, EventArgs e)
        {
            if (ComboxWTUnit.Text.Trim().Equals(""))
                return;

            DataTable dt = EntityDao.imp.CovidSampleStore.GetSendUnit(ComboxWTUnit.Text.Trim());
            if (dt == null || dt.Rows.Count <= 0)
                return;
           
            ComboxWTUnit.Properties.Items.Clear();
            foreach (DataRow item in dt.Rows)
                ComboxWTUnit.Properties.Items.Add(item[0].ToString());
            ComboxWTUnit.ShowPopup();
            
        }

        private void btnLoadExceStore_Click(object sender, EventArgs e)
        {
            ImporGridView.Columns.Clear();
            foreach (GridColumn item in InitGridColumns)
            {
                item.Visible = true;
                ImporGridView.Columns.Add(item);
            }
            DataTable DT = importControl.DataSource as DataTable;
            if (DT == null || DT.Rows.Count <= 0)
                return;
            if (MessageBox.Show("确定将清除当前导入的数据内容?", "清除数据", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;
            DT.Clear();
            if (InputTable != null && InputTable.Rows.Count >= 0)
                InputTable.Clear();
            string Path = Application.StartupPath + "\\TempXML\\Temp.xml";
            if(File.Exists(Path))
              File.Delete(Path);
            
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EntityDao.imp.PackSamples packSamples = new EntityDao.imp.PackSamples();
            this.PackageTable = packSamples.GetPackSampleCount();
            GridPackageContorller.DataSource = PackageTable;
        }

        private void 复制条码号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dr = GridPackView.GetFocusedDataRow();
            if (dr == null)
                return;
            Clipboard.SetDataObject(string.IsNullOrEmpty(dr["BarCode"].ToString()) ? "" : dr["BarCode"].ToString().Trim());
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            Utiles.ReadCard readCard = new Utiles.ReadCard();
            Patient patient = new Patient();
            string desc;
            if (readCard.Read(patient,out desc) == false) {
                MessageBox.Show(desc,"读卡错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            EditCardNo.Text= patient.UserCardNo;           
            DataTable dt = null;
            try
            {
                string sql = string.Format(" perCertNo='{0}' and CreateTime>='{1}' and  CreateTime>='{2}'", patient.UserCardNo,
                    DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00",
                    DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:00"
                    );
                if (EntityDao.imp.Covid.isEmptyByMaster(sql))
                {
                    DataRow dr = EntityDao.imp.Covid.GetInfoByMaster(sql);
                    string message = "受检人当天已采集过！确认再次采集吗！";
                    if (dr != null && dr.ItemArray.Length > 0)
                    {
                        message = string.Format("【{0} 】 当天已在 【 {1} 】 采集过样本，采集的条码号为【{2}】 采集时间：【{3}】",
                            dr["perName"].ToString(), dr["CyAddress"].ToString(), dr["Barcode"].ToString(), dr["sampTime"].ToString()
                            );
                        if (MessageBox.Show(message, "采集提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                            return;
                    }

                }
                dt = EntityDao.imp.CovidSampleStore.SerchDataByLis(string.Format("perCertNo like '%{0}'", patient.UserCardNo));
                if (dt == null || dt.Rows.Count <= 0)
                    MessageBox.Show("当前无匹配信息，请手工输入其它信息！", "服务端提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception er)
            {
                if (MessageBox.Show(er.Message + "\n\n确定是否手工录入数据？", "访问错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                    return;
            }
            if (dt != null && dt.Rows.Count >= 1)
            {
                Diag.PatientInfoFormDialg winfo = new Diag.PatientInfoFormDialg();
                winfo.StartPosition = FormStartPosition.Manual;
                winfo.Location = MousePosition;
                winfo.infodata = dt;
                winfo.ShowDialog();
                FullCompoent(patient, winfo.outRow);
                return;
            }
            FullCompoent(patient, null);
        }

        private void openExceFilebtn_Click(object sender, EventArgs e)
        {
            string v_OpenFolderPath = Application.StartupPath+ "\\ExcelStore";
            Process.Start("explorer.exe", v_OpenFolderPath);
        }
    }
}
