using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apps.UIS.PcrPanel;
using DevExpress.XtraEditors;
using EntityDao.Entity;
namespace AppClient.UIS
{
    public partial class UISPanelTest : XtraUserControl
    {
        private DataTable PcrPanelTable;
        private DataTable LeftInfoTable;
        private ArrayList formlistsql = new ArrayList();
        private ArrayList itemlistsql = new ArrayList();
        public UISPanelTest()
        {
            InitializeComponent();
            InitComponet();
        }

        public void InitComponet() {
            PcrPanelTable = EntityDao.pcrpanel.PCRPanel.InitPanel();
            PCRPanel.DataSource = PcrPanelTable;
            GridPCRPanel.BestFitColumns();
            TestTime.Value = DateTime.Now;
            ReagentStartTime.Value = DateTime.Now;
            ReagentEndTime.Value = DateTime.Now;
           
            EntityDao.pcrpanel.PCRPanel.FullCombox(ComboxTestName.Properties.Items, EnumType.ComboBoxSQLType.Puser);
            EntityDao.pcrpanel.PCRPanel.FullCombox(ComboxCheckerName.Properties.Items, EnumType.ComboBoxSQLType.Puser);
            EntityDao.pcrpanel.PCRPanel.FullCombox(ComboxGroup.Properties.Items, EnumType.ComboBoxSQLType.Group);
            EntityDao.pcrpanel.PCRPanel.FullCombox(ComboxEquipmentName.Properties.Items, EnumType.ComboBoxSQLType.Equipment);
            LeftInfoTable = EntityDao.pcrpanel.PCRPanel.CreateLeftTable();
            LeftControl.DataSource = LeftInfoTable;
            LeftGridView.Columns["Barcode"].GroupIndex = 0;
            LeftGridView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "总数");
            LeftGridView.GroupFormat = "{1} {2}";  //默认"{0}: [#image]{1} {2}"; 字段名称：数据 计数=？
            LeftGridView.OptionsBehavior.AutoExpandAllGroups = true;
        }

        private void ScanBarocde_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            string desc;

            if (CheckInput() == false) {
                return;
            }
            formlistsql.Clear();itemlistsql.Clear();
            if (EntityDao.pcrpanel.PCRPanel.InsertToPanel(PcrPanelTable, LeftInfoTable, ScanBarocde.Text.Trim(), EditTestbatch.Text.Trim(), out desc) == false)
            {
                MessageBox.Show(this, desc, "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ScanBarocde.Focus();
                return;
            }
            else {
                ScanBarocde.Text = "";
                ScanBarocde.Focus();
                TestTime.Value = DateTime.Now;
            }
        }


        private bool CheckInput()
        {
            if (!EntityDao.imp.Covid.isEmptyByMaster(string.Format(" BarCode='{0}' and isReport=2", ScanBarocde.Text.Trim())))
            {
                MessageBox.Show(this, "当前条码号已经上机试验，不可再次排版", "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ScanBarocde.Text = "";
                ScanBarocde.Focus();
                return false;
            }else  if (ComboxGroup.SelectedIndex == -1 || ComboxGroup.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "必须选择试验小组", "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ComboxGroup.ShowPopup();
                return false;
            }
            else if (EditTestbatch.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "必须输入试验批次", "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EditTestbatch.Focus();
                return false;
            }
            else if (ComboxTestName.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "必须输入试验人员", "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ComboxTestName.ShowPopup();
                return false;
            }
            else if (ComboxCheckerName.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "必须选择校准人员", "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ComboxCheckerName.ShowPopup();
                return false;
            }
            else if (ComboxEquipmentName.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "请选择仪器", "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ComboxEquipmentName.ShowPopup();
                return false;
            } 
            else
                return true;


        }

        private bool SaveHeader() {
            //select PanelNumber, PanelMode, TestTime, BatchRate, BatchNumber, EqName, Tester, Checker, Reagent, RStartDateTime, REenDateTime, CreateTime from Pcr_PanelInfo
            PanelInfo info = new PanelInfo();
            info.PanelNumber = EditTestbatch.Text.Trim();
            info.PanelMode = "0";
            info.TestTime = TestTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            info.BatchRate = EditTestBatchNumber.Text.Trim();
            info.EqName = ComboxEquipmentName.Text.Trim();
            info.Tester = ComboxTestName.Text.Trim();
            info.Checker = ComboxCheckerName.Text.Trim();
            info.Reagent = EditReagentName.Text.Trim();
            info.RStartDateTime = ReagentStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            info.REenDateTime = ReagentEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            return EntityDao.pcrpanel.PCRPanel.WritePanelInfo(info);
        }

        private bool SavePanelInfo() {
            if (!PcrPanelTable.Columns.Contains("CreateTime"))
                PcrPanelTable.Columns.Add("CreateTime");
            if (!PcrPanelTable.Columns.Contains("Memo"))
                PcrPanelTable.Columns.Add("Memo");
            if (!PcrPanelTable.Columns.Contains("PanelNumber"))
                PcrPanelTable.Columns.Add("PanelNumber");
            if (PcrPanelTable.Columns.Contains("title"))
                PcrPanelTable.Columns.Remove("title");
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            foreach (DataRow item in PcrPanelTable.Rows)
            {
                item.BeginEdit();
                item["CreateTime"] = datetime;
                item["Memo"] = "";
                item["PanelNumber"] = EditTestbatch.Text.Trim();
                item.EndEdit();
                PcrPanelTable.AcceptChanges();
            }
            try
            {
                if (SaveHeader() == false)
                {
                    MessageBox.Show(this, "入库失败", "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (EntityDao.pcrpanel.PCRPanel.WriteToPCRPanelTable(PcrPanelTable))
                {
                    int sectionno = Convert.ToInt32((ComboxGroup.SelectedItem as ControlModelItem).Key);
                    if (EntityDao.pcrpanel.PCRPanel.WriteToRequest(LeftInfoTable, DateTime.Parse(TestTime.Value.ToString("yyyy-MM-dd") + " 00:00:00"), sectionno) == false)
                    {
                        EntityDao.pcrpanel.PCRPanel.DeletePCRPanel(EditTestbatch.Text.Trim());
                        MessageBox.Show(this, "入库失败", "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        //成功修改主表记录标记改为2 已上机检验状态
                        DataTable temp = new DataView(LeftInfoTable).ToTable(true, new string[] { "BarCode" });
                        if (temp != null && temp.Rows.Count > 0)
                        {
                            ArrayList sqllist = new ArrayList();
                            foreach (DataRow item in temp.Rows)
                                sqllist.Add(String.Format("update CovidSample set isReport={0} where BarCode='{1}'", 2, item["Barcode"].ToString()));
                            EntityDao.imp.Covid.WriteSQLListToMaster(sqllist);
                        }
                        PcrPanelTable = EntityDao.pcrpanel.PCRPanel.InitPanel();
                        PCRPanel.DataSource = PcrPanelTable;
                        LeftInfoTable.Clear();
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show(this, "入库发生错误！请重新尝试", "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(this, ee.Message, "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void SavePanel_Click(object sender, EventArgs e)
        {
            SavePanelInfo();
        }

        private void AllNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuitem = sender as ToolStripMenuItem;
            switch (Convert.ToInt32(menuitem.Tag))
            {
                case 0: LeftGridView.OptionsBehavior.AutoExpandAllGroups = true; break;
                case 1: LeftGridView.OptionsBehavior.AutoExpandAllGroups = false; break;
                default:
                    break;
            }
        }

        private void SaveToPanel_Click(object sender, EventArgs e)
        {
            PanelFind find = new PanelFind();
            find.SerchPanelDataFunction = SerchPanel;
            find.ShowInTaskbar = false;           
            find.ShowDialog();
        }

        private void btnCleanPanel_Click(object sender, EventArgs e)
        {
            PcrPanelTable = EntityDao.pcrpanel.PCRPanel.InitPanel();
            PCRPanel.DataSource = PcrPanelTable;
            LeftInfoTable.Clear();
        }

        private void EditTestbatch_Validated(object sender, EventArgs e)
        {
            bool flag = EntityDao.pcrpanel.PCRPanel.ExsitsPanelInfo(EditTestbatch.Text.Trim(),
                                                           DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00",
                                                           DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:00");
            if (flag)
            {
                MessageBox.Show(this, "试验批次已经存在", "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EditTestbatch.Focus();
                return;
            }
        }

        private void OutToExcel_Click(object sender, EventArgs e)
        {
            if (checkPanelisEmpty())
                return;
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.FileName = this.TestTime.Value.ToString("yyyy_MM_dd_" + this.ComboxEquipmentName.Text.Trim()) + "_" + EditTestbatch.Text.Trim() + ".xlsx";
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                string filename = SaveFile.FileName;
                if (Utiles.ExcelUtiles.OutExcelToEq(filename, LeftInfoTable, PcrPanelTable, !CheckHX.Checked))
                {
                    //需要在保存前确认是否需要再次保存至检验系统-调阅出来的数据处理-增加判断是否已经插入
                    if (SavePanelInfo()) 
                        initPanel(true);
                }
            }
        }
        private bool checkPanelisEmpty()
        {
            for (int i = 0; i < PcrPanelTable.Rows.Count; i++)
            {
                for (int j = 0; j < PcrPanelTable.Columns.Count; j++)
                {
                    if (j == 0)
                        continue;
                    string temp = PcrPanelTable.Rows[i][j].ToString();
                    if (!string.IsNullOrEmpty(PcrPanelTable.Rows[i][j].ToString()))
                        return false;
                }
            }
            return true;
        }
        public bool initPanel(bool isClean = false, bool locakQC = false)
        {
            if (isClean && locakQC == false)
            {
                PcrPanelTable.Rows.Clear();
                LeftInfoTable.Rows.Clear();
                this.EditTestbatch.Text = "";
            }

            if (!PcrPanelTable.Columns.Contains("title"))
                PcrPanelTable.Columns.Add(new DataColumn("title"));

            for (int i = 1; i < 13; i++)
                if (!PcrPanelTable.Columns.Contains("C" + i))
                    PcrPanelTable.Columns.Add(new DataColumn("C" + i));

            for (int i = 65; i < 73; i++)
            {
                DataRow dr = PcrPanelTable.NewRow();
                foreach (DataColumn dc in PcrPanelTable.Columns)
                {
                    if (dc.ColumnName.Equals("title"))
                        dr[dc.ColumnName] = Convert.ToString(Convert.ToChar(i));
                    else
                    {
                        if (locakQC == false)
                            dr[dc.ColumnName] = "";
                        else
                        {
                            String str = String.IsNullOrEmpty(dr[dc.ColumnName].ToString()) ? "" : dr[dc.ColumnName].ToString();
                            if (str.Equals("-") || str.Equals("+") || str.Equals("zk") || str.Equals("ZK"))
                                continue;
                        }
                    }
                }
                PcrPanelTable.Rows.Add(dr);
            }
            PCRPanel.DataSource = PcrPanelTable;
            return true;
        }

        public void SerchPanel(string conditon) {
            PcrPanelTable = EntityDao.pcrpanel.PCRPanel.SerchPCRPanel(conditon);            
            if (PcrPanelTable == null || PcrPanelTable.Rows.Count<=0) {
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(" Barcode in (");
            foreach (DataRow data in PcrPanelTable.Rows)
            {
                foreach (DataColumn dc in PcrPanelTable.Columns)
                {
                    if (dc.ColumnName.Equals("Memo") || dc.ColumnName.Equals("CreateTime") || dc.ColumnName.Equals("PanelNumber"))
                        continue;
                    else
                    {
                        if (string.IsNullOrEmpty(data[dc.ColumnName].ToString()))
                            continue;
                        sb.AppendFormat("'{0}',", data[dc.ColumnName].ToString());
                    }                    
                }
            }
            string sql = sb.ToString().TrimEnd(',')+")";
            LeftInfoTable = EntityDao.pcrpanel.PCRPanel.GetDataByCovidSample(sql);
            PCRPanel.DataSource = PcrPanelTable;
            LeftControl.DataSource = LeftInfoTable;


        }
    }
}
