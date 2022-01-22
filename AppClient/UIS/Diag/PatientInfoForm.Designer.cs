namespace AppClient.UIS.Diag
{
    partial class PatientInfoFormDialg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.GridStoreController = new DevExpress.XtraGrid.GridControl();
            this.GridStoreView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CardNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SendUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.JobName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SubJob = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OldCollectTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.isCool = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridStoreController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridStoreView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 202);
            this.panel1.TabIndex = 0;
            // 
            // GridStoreController
            // 
            this.GridStoreController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridStoreController.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.GridStoreController.Location = new System.Drawing.Point(0, 0);
            this.GridStoreController.MainView = this.GridStoreView;
            this.GridStoreController.Name = "GridStoreController";
            this.GridStoreController.Size = new System.Drawing.Size(696, 202);
            this.GridStoreController.TabIndex = 1;
            this.GridStoreController.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridStoreView});
            // 
            // GridStoreView
            // 
            this.GridStoreView.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.GridStoreView.Appearance.HeaderPanel.Options.UseFont = true;
            this.GridStoreView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CName,
            this.CardNo,
            this.Phone,
            this.SendUnit,
            this.JobName,
            this.SubJob,
            this.Unit,
            this.OldCollectTime,
            this.isCool});
            this.GridStoreView.GridControl = this.GridStoreController;
            this.GridStoreView.Name = "GridStoreView";
            this.GridStoreView.OptionsBehavior.Editable = false;
            this.GridStoreView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridStoreView.OptionsView.ColumnAutoWidth = false;
            this.GridStoreView.OptionsView.RowAutoHeight = true;
            this.GridStoreView.OptionsView.ShowGroupPanel = false;
            this.GridStoreView.OptionsView.ShowIndicator = false;
            this.GridStoreView.DoubleClick += new System.EventHandler(this.GridStore_DoubleClick);
            // 
            // CName
            // 
            this.CName.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.CName.AppearanceCell.Options.UseFont = true;
            this.CName.Caption = "姓名";
            this.CName.FieldName = "perName";
            this.CName.Name = "CName";
            this.CName.Visible = true;
            this.CName.VisibleIndex = 2;
            this.CName.Width = 90;
            // 
            // CardNo
            // 
            this.CardNo.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.CardNo.AppearanceCell.Options.UseFont = true;
            this.CardNo.Caption = "证件号";
            this.CardNo.FieldName = "perCertNo";
            this.CardNo.Name = "CardNo";
            this.CardNo.Visible = true;
            this.CardNo.VisibleIndex = 3;
            this.CardNo.Width = 198;
            // 
            // Phone
            // 
            this.Phone.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.Phone.AppearanceCell.Options.UseFont = true;
            this.Phone.Caption = "电话号码";
            this.Phone.FieldName = "perDel";
            this.Phone.Name = "Phone";
            this.Phone.Visible = true;
            this.Phone.VisibleIndex = 4;
            this.Phone.Width = 139;
            // 
            // SendUnit
            // 
            this.SendUnit.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.SendUnit.AppearanceCell.Options.UseFont = true;
            this.SendUnit.Caption = "委托单位";
            this.SendUnit.FieldName = "principal";
            this.SendUnit.Name = "SendUnit";
            this.SendUnit.Visible = true;
            this.SendUnit.VisibleIndex = 1;
            this.SendUnit.Width = 236;
            // 
            // JobName
            // 
            this.JobName.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.JobName.AppearanceCell.Options.UseFont = true;
            this.JobName.Caption = "职业分类";
            this.JobName.FieldName = "Classification";
            this.JobName.Name = "JobName";
            this.JobName.Visible = true;
            this.JobName.VisibleIndex = 5;
            this.JobName.Width = 187;
            // 
            // SubJob
            // 
            this.SubJob.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.SubJob.AppearanceCell.Options.UseFont = true;
            this.SubJob.Caption = "职业子分类";
            this.SubJob.FieldName = "Subcategory";
            this.SubJob.Name = "SubJob";
            this.SubJob.Visible = true;
            this.SubJob.VisibleIndex = 6;
            this.SubJob.Width = 153;
            // 
            // Unit
            // 
            this.Unit.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.Unit.AppearanceCell.Options.UseFont = true;
            this.Unit.Caption = "单位";
            this.Unit.FieldName = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.Visible = true;
            this.Unit.VisibleIndex = 0;
            this.Unit.Width = 169;
            // 
            // OldCollectTime
            // 
            this.OldCollectTime.Caption = "上次采集时间";
            this.OldCollectTime.FieldName = "OldCollectTime";
            this.OldCollectTime.Name = "OldCollectTime";
            this.OldCollectTime.Visible = true;
            this.OldCollectTime.VisibleIndex = 7;
            // 
            // isCool
            // 
            this.isCool.Caption = "是否冷库";
            this.isCool.FieldName = "isCool";
            this.isCool.Name = "isCool";
            this.isCool.Visible = true;
            this.isCool.VisibleIndex = 8;
            // 
            // PatientInfoFormDialg
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 202);
            this.Controls.Add(this.GridStoreController);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.Image = global::AppClient.Properties.Resources.newgroup_16x16;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PatientInfoFormDialg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "被采集者信息";
            this.Load += new System.EventHandler(this.PatientInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridStoreController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridStoreView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl GridStoreController;
        private DevExpress.XtraGrid.Views.Grid.GridView GridStoreView;
        private DevExpress.XtraGrid.Columns.GridColumn CName;
        private DevExpress.XtraGrid.Columns.GridColumn CardNo;
        private DevExpress.XtraGrid.Columns.GridColumn Phone;
        private DevExpress.XtraGrid.Columns.GridColumn SendUnit;
        private DevExpress.XtraGrid.Columns.GridColumn JobName;
        private DevExpress.XtraGrid.Columns.GridColumn SubJob;
        private DevExpress.XtraGrid.Columns.GridColumn Unit;
        private DevExpress.XtraGrid.Columns.GridColumn OldCollectTime;
        private DevExpress.XtraGrid.Columns.GridColumn isCool;
    }
}