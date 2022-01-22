namespace Apps.UIS.PcrPanel
{
    partial class PanelFind
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
            this.ToolsPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Start = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.EndTime = new System.Windows.Forms.DateTimePicker();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.ComboPh = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnserch = new DevExpress.XtraEditors.SimpleButton();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.PanelGridControl = new DevExpress.XtraGrid.GridControl();
            this.PanelGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BatchNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TestTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tester = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Checker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Reagent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EqName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BatchRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RStartDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REenDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ToolsPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComboPh.Properties)).BeginInit();
            this.ContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.Controls.Add(this.tableLayoutPanel1);
            this.ToolsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolsPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolsPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolsPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(1133, 35);
            this.ToolsPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.Start, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EndTime, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ComboPh, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnserch, 7, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 14, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1133, 35);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Start
            // 
            this.Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Start.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Start.Location = new System.Drawing.Point(72, 4);
            this.Start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(172, 26);
            this.Start.TabIndex = 6;
            this.Start.ValueChanged += new System.EventHandler(this.TimeChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.ImageOptions.Image = global::AppClient.Properties.Resources.time2_16x16;
            this.labelControl1.Location = new System.Drawing.Point(3, 4);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 27);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "日期：";
            // 
            // EndTime
            // 
            this.EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EndTime.Location = new System.Drawing.Point(250, 4);
            this.EndTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(172, 26);
            this.EndTime.TabIndex = 3;
            this.EndTime.ValueChanged += new System.EventHandler(this.TimeChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl3.Location = new System.Drawing.Point(428, 4);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 27);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "批号：";
            // 
            // ComboPh
            // 
            this.ComboPh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboPh.Location = new System.Drawing.Point(476, 4);
            this.ComboPh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboPh.Name = "ComboPh";
            this.ComboPh.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboPh.Properties.Appearance.Options.UseFont = true;
            this.ComboPh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboPh.Size = new System.Drawing.Size(199, 26);
            this.ComboPh.TabIndex = 4;
            // 
            // btnserch
            // 
            this.btnserch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnserch.ImageOptions.Image = global::AppClient.Properties.Resources.find_16x161;
            this.btnserch.Location = new System.Drawing.Point(681, 4);
            this.btnserch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnserch.Name = "btnserch";
            this.btnserch.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnserch.Size = new System.Drawing.Size(80, 27);
            this.btnserch.TabIndex = 5;
            this.btnserch.Text = "查找信息";
            this.btnserch.Click += new System.EventHandler(this.btnserch_Click);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.PanelGridControl);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ContentPanel.Location = new System.Drawing.Point(0, 35);
            this.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(1133, 540);
            this.ContentPanel.TabIndex = 1;
            // 
            // PanelGridControl
            // 
            this.PanelGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PanelGridControl.Location = new System.Drawing.Point(0, 0);
            this.PanelGridControl.MainView = this.PanelGrid;
            this.PanelGridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PanelGridControl.Name = "PanelGridControl";
            this.PanelGridControl.Size = new System.Drawing.Size(1133, 540);
            this.PanelGridControl.TabIndex = 0;
            this.PanelGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PanelGrid});
            // 
            // PanelGrid
            // 
            this.PanelGrid.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.PanelGrid.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PanelGrid.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.PanelGrid.Appearance.HeaderPanel.Options.UseFont = true;
            this.PanelGrid.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.PanelGrid.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PanelGrid.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PanelGrid.Appearance.Row.Options.UseFont = true;
            this.PanelGrid.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.PanelGrid.Appearance.SelectedRow.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PanelGrid.Appearance.SelectedRow.Options.UseBackColor = true;
            this.PanelGrid.Appearance.SelectedRow.Options.UseFont = true;
            this.PanelGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BatchNumber,
            this.TestTime,
            this.Tester,
            this.Checker,
            this.Reagent,
            this.EqName,
            this.BatchRate,
            this.RStartDateTime,
            this.REenDateTime,
            this.CreateTime});
            this.PanelGrid.DetailHeight = 500;
            this.PanelGrid.FixedLineWidth = 3;
            this.PanelGrid.GridControl = this.PanelGridControl;
            this.PanelGrid.Name = "PanelGrid";
            this.PanelGrid.OptionsBehavior.Editable = false;
            this.PanelGrid.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.PanelGrid.OptionsBehavior.ReadOnly = true;
            this.PanelGrid.OptionsFilter.AllowFilterEditor = false;
            this.PanelGrid.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.PanelGrid.OptionsMenu.EnableColumnMenu = false;
            this.PanelGrid.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.True;
            this.PanelGrid.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.PanelGrid.OptionsSelection.UseIndicatorForSelection = false;
            this.PanelGrid.OptionsView.AutoCalcPreviewLineCount = true;
            this.PanelGrid.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.PanelGrid.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.PanelGrid.OptionsView.RowAutoHeight = true;
            this.PanelGrid.OptionsView.ShowFooter = true;
            this.PanelGrid.OptionsView.ShowGroupPanel = false;
            this.PanelGrid.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.PanelGrid.OptionsView.ShowIndicator = false;
            this.PanelGrid.DoubleClick += new System.EventHandler(this.PanelGrid_DoubleClick);
            // 
            // BatchNumber
            // 
            this.BatchNumber.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatchNumber.AppearanceCell.Options.UseFont = true;
            this.BatchNumber.Caption = "批次";
            this.BatchNumber.FieldName = "PanelNumber";
            this.BatchNumber.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.BatchNumber.Name = "BatchNumber";
            this.BatchNumber.Visible = true;
            this.BatchNumber.VisibleIndex = 0;
            this.BatchNumber.Width = 112;
            // 
            // TestTime
            // 
            this.TestTime.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestTime.AppearanceCell.Options.UseFont = true;
            this.TestTime.Caption = "试验时间";
            this.TestTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.TestTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TestTime.FieldName = "TestTime";
            this.TestTime.Name = "TestTime";
            this.TestTime.Visible = true;
            this.TestTime.VisibleIndex = 1;
            // 
            // Tester
            // 
            this.Tester.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tester.AppearanceCell.Options.UseFont = true;
            this.Tester.Caption = "试验人";
            this.Tester.FieldName = "Tester";
            this.Tester.Name = "Tester";
            this.Tester.Visible = true;
            this.Tester.VisibleIndex = 2;
            // 
            // Checker
            // 
            this.Checker.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Checker.AppearanceCell.Options.UseFont = true;
            this.Checker.Caption = "校对人";
            this.Checker.FieldName = "Checker";
            this.Checker.Name = "Checker";
            this.Checker.Visible = true;
            this.Checker.VisibleIndex = 3;
            // 
            // Reagent
            // 
            this.Reagent.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reagent.AppearanceCell.Options.UseFont = true;
            this.Reagent.Caption = "试剂";
            this.Reagent.FieldName = "Reagent";
            this.Reagent.Name = "Reagent";
            this.Reagent.Visible = true;
            this.Reagent.VisibleIndex = 4;
            // 
            // EqName
            // 
            this.EqName.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EqName.AppearanceCell.Options.UseFont = true;
            this.EqName.Caption = "设备";
            this.EqName.FieldName = "EqName";
            this.EqName.Name = "EqName";
            this.EqName.Visible = true;
            this.EqName.VisibleIndex = 5;
            // 
            // BatchRate
            // 
            this.BatchRate.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatchRate.AppearanceCell.Options.UseFont = true;
            this.BatchRate.Caption = "批号";
            this.BatchRate.FieldName = "BatchRate";
            this.BatchRate.Name = "BatchRate";
            this.BatchRate.Visible = true;
            this.BatchRate.VisibleIndex = 6;
            // 
            // RStartDateTime
            // 
            this.RStartDateTime.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RStartDateTime.AppearanceCell.Options.UseFont = true;
            this.RStartDateTime.Caption = "有效时间";
            this.RStartDateTime.Name = "RStartDateTime";
            this.RStartDateTime.Visible = true;
            this.RStartDateTime.VisibleIndex = 7;
            // 
            // REenDateTime
            // 
            this.REenDateTime.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REenDateTime.AppearanceCell.Options.UseFont = true;
            this.REenDateTime.Caption = "时效时间";
            this.REenDateTime.FieldName = "REenDateTime";
            this.REenDateTime.Name = "REenDateTime";
            this.REenDateTime.Visible = true;
            this.REenDateTime.VisibleIndex = 8;
            // 
            // CreateTime
            // 
            this.CreateTime.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTime.AppearanceCell.Options.UseFont = true;
            this.CreateTime.Caption = "归档时间";
            this.CreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.CreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateTime.FieldName = "CreateTime";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.Visible = true;
            this.CreateTime.VisibleIndex = 9;
            // 
            // PanelFind
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 575);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.ToolsPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PanelFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "存档试验版";
            this.Load += new System.EventHandler(this.PanelFind_Load);
            this.ToolsPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComboPh.Properties)).EndInit();
            this.ContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ToolsPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DateTimePicker EndTime;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit ComboPh;
        private DevExpress.XtraEditors.SimpleButton btnserch;
        private System.Windows.Forms.Panel ContentPanel;
        private DevExpress.XtraGrid.GridControl PanelGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView PanelGrid;
        private DevExpress.XtraGrid.Columns.GridColumn BatchNumber;
        private DevExpress.XtraGrid.Columns.GridColumn TestTime;
        private DevExpress.XtraGrid.Columns.GridColumn Tester;
        private DevExpress.XtraGrid.Columns.GridColumn Checker;
        private DevExpress.XtraGrid.Columns.GridColumn Reagent;
        private DevExpress.XtraGrid.Columns.GridColumn EqName;
        private DevExpress.XtraGrid.Columns.GridColumn BatchRate;
        private DevExpress.XtraGrid.Columns.GridColumn RStartDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn REenDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime;
        private System.Windows.Forms.DateTimePicker Start;
    }
}