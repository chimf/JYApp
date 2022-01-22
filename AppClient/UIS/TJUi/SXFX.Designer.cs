namespace Apps.UIS.TJUi
{
    partial class SXFX
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SXFX));
            this.TestControl = new DevExpress.XtraGrid.GridControl();
            this.TestView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cgs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cjdaoru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ImportToOverProgress = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar3 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.TestControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImportToOverProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar3)).BeginInit();
            this.SuspendLayout();
            // 
            // TestControl
            // 
            this.TestControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestControl.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestControl.Location = new System.Drawing.Point(0, 0);
            this.TestControl.MainView = this.TestView;
            this.TestControl.Name = "TestControl";
            this.TestControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ImportToOverProgress,
            this.repositoryItemProgressBar2,
            this.repositoryItemProgressBar3});
            this.TestControl.Size = new System.Drawing.Size(1583, 762);
            this.TestControl.TabIndex = 0;
            this.TestControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.TestView});
            // 
            // TestView
            // 
            this.TestView.Appearance.FocusedRow.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.TestView.Appearance.FocusedRow.Options.UseFont = true;
            this.TestView.Appearance.FooterPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TestView.Appearance.FooterPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.TestView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.TestView.Appearance.FooterPanel.Options.UseFont = true;
            this.TestView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.TestView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TestView.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TestView.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.TestView.Appearance.HeaderPanel.Options.UseFont = true;
            this.TestView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.TestView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TestView.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.TestView.Appearance.Row.Options.UseFont = true;
            this.TestView.Appearance.SelectedRow.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.TestView.Appearance.SelectedRow.Options.UseFont = true;
            this.TestView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.cgs,
            this.sbs,
            this.gridColumn6,
            this.gridColumn10,
            this.cjdaoru,
            this.gridColumn11,
            this.gridColumn8,
            this.gridColumn12,
            this.gridColumn9});
            this.TestView.GridControl = this.TestControl;
            this.TestView.Name = "TestView";
            this.TestView.OptionsMenu.EnableColumnMenu = false;
            this.TestView.OptionsSelection.MultiSelect = true;
            this.TestView.OptionsView.ColumnAutoWidth = false;
            this.TestView.OptionsView.ShowDetailButtons = false;
            this.TestView.OptionsView.ShowFooter = true;
            this.TestView.OptionsView.ShowGroupPanel = false;
            this.TestView.OptionsView.ShowIndicator = false;
            this.TestView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.TestView_CustomDrawCell);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.Caption = "单位";
            this.gridColumn1.FieldName = "unit";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "unit", "总单位数: {0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 360;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.Caption = "采集数量";
            this.gridColumn2.FieldName = "totall";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "totall", "总采集量:{0:0.##}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 95;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.Caption = "试验中";
            this.gridColumn3.FieldName = "testcount";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "testcount", "总数:{0:0.##}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 88;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.Caption = "已完成试验";
            this.gridColumn4.FieldName = "reportcount";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reportcount", "完成: {0:0.##}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 103;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.Caption = "已发布报告数";
            this.gridColumn5.FieldName = "pdfcount";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pdfcount", "发布: {0:0.##}")});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 114;
            // 
            // cgs
            // 
            this.cgs.Caption = "成功数";
            this.cgs.FieldName = "cgs";
            this.cgs.Name = "cgs";
            this.cgs.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cgs", "成功：{0}")});
            this.cgs.Visible = true;
            this.cgs.VisibleIndex = 6;
            // 
            // sbs
            // 
            this.sbs.Caption = "失败数";
            this.sbs.FieldName = "sbs";
            this.sbs.Name = "sbs";
            this.sbs.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sbs", "失败：{0}")});
            this.sbs.Visible = true;
            this.sbs.VisibleIndex = 7;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.Caption = "上报总数";
            this.gridColumn6.FieldName = "sendcount";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sendcount", "总报:  {0:0.##}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 93;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "最大时效(采集至导入)";
            this.gridColumn10.FieldName = "sctime";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "sctime", "总平均: {0:0.##}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 154;
            // 
            // cjdaoru
            // 
            this.cjdaoru.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cjdaoru.AppearanceCell.Options.UseFont = true;
            this.cjdaoru.Caption = "采集至导入完成度";
            this.cjdaoru.ColumnEdit = this.ImportToOverProgress;
            this.cjdaoru.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cjdaoru.ImageOptions.Image")));
            this.cjdaoru.Name = "cjdaoru";
            this.cjdaoru.Visible = true;
            this.cjdaoru.VisibleIndex = 8;
            this.cjdaoru.Width = 135;
            // 
            // ImportToOverProgress
            // 
            this.ImportToOverProgress.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImportToOverProgress.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ImportToOverProgress.Maximum = 240;
            this.ImportToOverProgress.Name = "ImportToOverProgress";
            this.ImportToOverProgress.ReadOnly = true;
            this.ImportToOverProgress.ShowTitle = true;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "最大时效(导入至上机)";
            this.gridColumn11.FieldName = "cictime";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "cictime", "总平均数: {0:0.##}")});
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 11;
            this.gridColumn11.Width = 151;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.Caption = "导入至上机完成度";
            this.gridColumn8.ColumnEdit = this.repositoryItemProgressBar2;
            this.gridColumn8.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn8.ImageOptions.Image")));
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 10;
            this.gridColumn8.Width = 154;
            // 
            // repositoryItemProgressBar2
            // 
            this.repositoryItemProgressBar2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemProgressBar2.Maximum = 120;
            this.repositoryItemProgressBar2.Name = "repositoryItemProgressBar2";
            this.repositoryItemProgressBar2.NullText = "0";
            this.repositoryItemProgressBar2.ReadOnly = true;
            this.repositoryItemProgressBar2.ShowTitle = true;
            this.repositoryItemProgressBar2.Step = 1;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "最大时效(上机至报告)";
            this.gridColumn12.FieldName = "irtime";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "irtime", "总平均数: {0:0.##}")});
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 13;
            this.gridColumn12.Width = 98;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.Caption = "上机至报告完成度";
            this.gridColumn9.ColumnEdit = this.repositoryItemProgressBar3;
            this.gridColumn9.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn9.ImageOptions.Image")));
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 12;
            this.gridColumn9.Width = 138;
            // 
            // repositoryItemProgressBar3
            // 
            this.repositoryItemProgressBar3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemProgressBar3.Maximum = 90;
            this.repositoryItemProgressBar3.Name = "repositoryItemProgressBar3";
            this.repositoryItemProgressBar3.NullText = "0";
            this.repositoryItemProgressBar3.ReadOnly = true;
            this.repositoryItemProgressBar3.ShowTitle = true;
            this.repositoryItemProgressBar3.Step = 1;
            // 
            // SXFX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TestControl);
            this.Name = "SXFX";
            this.Size = new System.Drawing.Size(1583, 762);
            ((System.ComponentModel.ISupportInitialize)(this.TestControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImportToOverProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl TestControl;
        private DevExpress.XtraGrid.Views.Grid.GridView TestView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn cjdaoru;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar ImportToOverProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar2;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn cgs;
        private DevExpress.XtraGrid.Columns.GridColumn sbs;
    }
}
