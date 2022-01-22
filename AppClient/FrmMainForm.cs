using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AppClient
{

    public partial class FrmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private UIS.HCUICollect HCContorl = new UIS.HCUICollect();
        private UIS.UISingleCollect SingleContorl = new UIS.UISingleCollect();
        private UIS.UISendSample SendSample = new UIS.UISendSample();
        private XtraUserControl CurrentUIControl = null;
        private UIS.UISPanelTest UISPanelTest = new UIS.UISPanelTest();

        public UILogin loginform;
        public int Rolue = 0;
        public string loginUserName;
        public string loginAddress;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void AddUIInit(XtraUserControl userControl) {
            if (userControl == null)
                return;
            foreach (Control item in MainPanel.Controls)            
                MainPanel.Controls.Remove(item);
            MainImage.Visible = true;
            userControl.Size = this.MainPanel.Size;
            userControl.Top = this.MainPanel.Top;
            userControl.Left = this.MainPanel.Left;
            userControl.Parent = this.MainPanel;      
            CurrentUIControl = userControl;            
            MainImage.Visible = false;

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.McSkin);
            
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            
            AddUIInit(CurrentUIControl);
        }

        private void MenuCollectHH_Click(object sender, EventArgs e)
        {
            AccordionControlElement element = (sender as AccordionControlElement);
            switch (Convert.ToInt32(element.Tag))
            {
                case 1: AddUIInit(HCContorl); break;
                case 2: AddUIInit(SingleContorl);break;
                case 3:
                    if (Rolue==-1)
                        SendSample.isMananger = true;
                    AddUIInit(SendSample);
                    break;
                case 11:
                   
                    AddUIInit(UISPanelTest); break;
                case 12:
                    UIS.UIUploadCovid uploadcovid = new UIS.UIUploadCovid();
                    AddUIInit(uploadcovid); break;
                case 13:
                    UIS.UIReport UIReport = new UIS.UIReport();
                    AddUIInit(UIReport); break;
                case 14:
                    UIS.TJUi.UITJFX UITJFX = new UIS.TJUi.UITJFX();
                    AddUIInit(UITJFX); break;
                case 333:
                    UIS.TJUi.CollectTotallUI collectTotallUI = new UIS.TJUi.CollectTotallUI();
                    if (Rolue == -1)
                        collectTotallUI.isManager = true;
                    AddUIInit(collectTotallUI);
                    break;
                case 1001:
                    UIS.DicUI.UIInputerCJ ui = new UIS.DicUI.UIInputerCJ();
                    AddUIInit(ui);
                    break;
                case 1002:

                    break;
                    default:
                    break;
            }           
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams bcp = base.CreateParams;
                bcp.ExStyle |= 0x02000000;
                return bcp;
            }

        }
        private int resizeCount = 1;
        private void MenuLeftMain_ClientSizeChanged(object sender, EventArgs e)
        {
            resizeCount += 1;
            if((resizeCount%2)==0)
                AddUIInit(CurrentUIControl);
        }

        private void MenuDonloadData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("将开始下载服务器上基础信息表，请耐心等待程序处理完成!是否开始执行？", "下载基础数据提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            DataTable dt,jobtable;
            try
            {
                //dt = EntityDao.imp.CovidSampleStore.GetDataByMasterDB();
                jobtable = EntityDao.imp.CovidSampleStore.GetMasterJobs();
                if (EntityDao.imp.CovidSampleStore.WriteToJob(jobtable))
                    MessageBox.Show("导入数据完成!" + " 已导入数据数: " + jobtable.Rows.Count + " 条");
                else
                    MessageBox.Show("导入服务器基础信息字典到本地发生错误，请重新尝试下载数据");
                //if (dt != null && dt.Rows.Count > 0)
                //    EntityDao.imp.CovidSampleStore.ClearTable();
                //else {
                //    MessageBox.Show("Server Data is Empty!");
                //    return;
                //}

            }
            catch (Exception xe)
            {
                MessageBox.Show("查询基础信息库发生错误:" + xe.Message);
                return;
            }            

            //if (EntityDao.imp.CovidSampleStore.WriteToTable(dt))
            //    MessageBox.Show("导入数据完成!"+" 已导入数据数: "+dt.Rows.Count+" 条");
            //else
            //    MessageBox.Show("导入服务器基础信息字典到本地发生错误，请重新尝试下载数据");
        }

        private void OpenNet_Tick(object sender, EventArgs e)
        {
            //NetworkInterface[] nfaces = NetworkInterface.GetAllNetworkInterfaces();
            //var nface = nfaces.First(x => x.Name.Contains("本地连接") || x.Name.Contains("以太网"));
            //if (nface == null)
            //    return;
            //var ipProperties = nface.GetIPProperties();
            //// 获取默认网关
            //var defualtGateway = ipProperties.GatewayAddresses[0];
            //Ping ping = new Ping();
            //var treplay = ping.SendPingAsync(defualtGateway.Address);
            //var replay = treplay.Result;
            //ConnectNet.Caption = (replay?.Status == IPStatus.Success? "Wifi已连接": "Wifi未连接");
            //ConnectNet.Checked = (replay?.Status == IPStatus.Success ? true : false);

        }

        private void MenuInputTable_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenExcelFile = new OpenFileDialog();
            if (OpenExcelFile.ShowDialog() == DialogResult.OK)
            {
                
                String FileNames = OpenExcelFile.FileName;
                String errinfo;
                DataTable InputTable = Utiles.ExcelUtiles.ExcelToDataTable(FileNames, out errinfo, true, 0);
                if (InputTable == null && !errinfo.Equals(""))
                {
                    MessageBox.Show("读取文件发生错误:" + errinfo, "导入表格错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable writeTB = new DataTable();
                writeTB.Columns.Add("perName"); writeTB.Columns.Add("perCertNo");
                writeTB.Columns.Add("perDel"); writeTB.Columns.Add("principal");
                writeTB.Columns.Add("Unit");
                writeTB.Columns.Add("Classification"); writeTB.Columns.Add("Subcategory");
                writeTB.Columns.Add("OldCollectTime");

                StringBuilder sb = new StringBuilder();
                if (!InputTable.Columns.Contains("姓名")) 
                    sb.Append("表格中列：[姓名] 不存在");
                if (!InputTable.Columns.Contains("证件号"))
                    sb.Append("表格中列：[证件号] 不存在");
                if (!InputTable.Columns.Contains("联系电话"))
                    sb.Append("表格中列：[联系电话] 不存在");
                if (!InputTable.Columns.Contains("委托单位"))
                    sb.Append("表格中列：[委托单位] 不存在");
                if (!InputTable.Columns.Contains("受检者单位"))
                    sb.Append("表格中列：[单位] 不存在");
                if (sb.Length > 0)
                {
                    MessageBox.Show("表格中以下错误:\n"+sb.ToString()+"\n");
                    return;
                }

                foreach (DataRow item in InputTable.Rows)
                {
                    try
                    {
                        DataRow dr = writeTB.NewRow();
                        dr["perName"] = item["姓名"].ToString().Trim();
                        dr["perCertNo"] = item["证件号"].ToString().Trim();
                        dr["perDel"] = item["联系电话"].ToString().Trim();
                        dr["principal"] = item["委托单位"].ToString().Trim();
                        dr["Unit"] = item["受检者单位"].ToString().Trim();
                        if(InputTable.Columns.Contains("职业分类"))
                            dr["Classification"] = item["受检者单位"].ToString().Trim();
                        if (InputTable.Columns.Contains("职业子分类"))
                            dr["Subcategory"] = item["职业子分类"].ToString().Trim();
                        if (InputTable.Columns.Contains("采集时间"))
                            dr["OldCollectTime"] = item["采集时间"].ToString().Trim();
                        writeTB.Rows.Add(dr);
                    }
                    catch (Exception eee) {
                        MessageBox.Show("处理过程发生错误:"+ eee.Message);
                        continue;
                    }
                }

                if (EntityDao.imp.CovidSampleStore.WriteToTable(writeTB))
                    MessageBox.Show("导入成功:"+writeTB.Rows.Count+" 条记录");
                else
                    MessageBox.Show("导入失败");
            }
        }

       
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            switch (this.Rolue)
            {
                case 1:
                    LabTest.Enabled = true;
                    LabTest.Expanded = true;
                    LogUserName.Caption = this.loginUserName;
                    LocalAddress.Caption = "实验室";
                    break;
                case 2:
                    CollectMenu.Enabled = true;
                    CollectMenu.Expanded = true;
                    LogUserName.Caption = this.loginUserName;
                    LocalAddress.Caption = this.loginAddress;
                    break;
                case -1:
                    CollectMenu.Enabled = true;
                    CollectMenu.Expanded = true;
                    LabTest.Enabled = true;
                    LabTest.Expanded = true;
                    localData.Enabled = true;
                    localData.Expanded = true;
                    SystemParam.Enabled = true;
                    SystemParam.Expanded = true;
                    LogUserName.Caption = this.loginUserName;
                    LocalAddress.Caption ="实验室";
                    break;
                default:
                    break;
            }
        }

        private void accordionControlElement12_Click(object sender, EventArgs e)
        {
            FastReport.Report report = new FastReport.Report();
            //string reportFile = "Report/PDFReport.frx";
            //report.Load(reportFile);
            report.Design();

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (loginform == null)
            {
                loginform = new UILogin();
                loginform.FrmMain = this;
                if (loginform.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                }
            }
            else
            {
                this.Hide();
                if (loginform.ShowDialog() == DialogResult.OK)
                {
                    loginform.Hide();
                    this.Show();
                }
            }

        }
    }
}
