namespace AppClient.UIS.TJUi
{
    partial class UITJFX
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TimeTypeLabel = new DevExpress.XtraEditors.LabelControl();
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.Starttime = new DevExpress.XtraEditors.TimeEdit();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.EndTime = new DevExpress.XtraEditors.TimeEdit();
            this.btn_Serch = new DevExpress.XtraEditors.SimpleButton();
            this.TJType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.BtnExport = new DevExpress.XtraEditors.SimpleButton();
            this.isInputerCheck = new System.Windows.Forms.CheckBox();
            this.FrmPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.PanelLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Starttime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TJType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PanelLayout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1222, 71);
            this.panel1.TabIndex = 0;
            // 
            // PanelLayout
            // 
            this.PanelLayout.ColumnCount = 7;
            this.PanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelLayout.Controls.Add(this.labelControl1, 0, 1);
            this.PanelLayout.Controls.Add(this.TimeTypeLabel, 0, 0);
            this.PanelLayout.Controls.Add(this.StartDate, 1, 0);
            this.PanelLayout.Controls.Add(this.Starttime, 2, 0);
            this.PanelLayout.Controls.Add(this.EndDate, 3, 0);
            this.PanelLayout.Controls.Add(this.EndTime, 4, 0);
            this.PanelLayout.Controls.Add(this.btn_Serch, 5, 0);
            this.PanelLayout.Controls.Add(this.TJType, 1, 1);
            this.PanelLayout.Controls.Add(this.BtnExport, 3, 1);
            this.PanelLayout.Controls.Add(this.isInputerCheck, 4, 1);
            this.PanelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelLayout.Location = new System.Drawing.Point(0, 0);
            this.PanelLayout.Name = "PanelLayout";
            this.PanelLayout.RowCount = 2;
            this.PanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelLayout.Size = new System.Drawing.Size(1222, 71);
            this.PanelLayout.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.Location = new System.Drawing.Point(3, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 31);
            this.labelControl1.TabIndex = 28;
            this.labelControl1.Text = "类型选择：";
            // 
            // TimeTypeLabel
            // 
            this.TimeTypeLabel.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeTypeLabel.Appearance.Options.UseFont = true;
            this.TimeTypeLabel.Appearance.Options.UseTextOptions = true;
            this.TimeTypeLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TimeTypeLabel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TimeTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeTypeLabel.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.TimeTypeLabel.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TimeTypeLabel.Location = new System.Drawing.Point(3, 3);
            this.TimeTypeLabel.Name = "TimeTypeLabel";
            this.TimeTypeLabel.Size = new System.Drawing.Size(70, 30);
            this.TimeTypeLabel.TabIndex = 20;
            this.TimeTypeLabel.Text = "导入时间：";
            // 
            // StartDate
            // 
            this.StartDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartDate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartDate.Location = new System.Drawing.Point(79, 3);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(148, 26);
            this.StartDate.TabIndex = 21;
            // 
            // Starttime
            // 
            this.Starttime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Starttime.EditValue = new System.DateTime(2021, 10, 12, 0, 0, 0, 0);
            this.Starttime.Location = new System.Drawing.Point(233, 3);
            this.Starttime.Name = "Starttime";
            this.Starttime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Starttime.Properties.Appearance.Options.UseFont = true;
            this.Starttime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Starttime.Size = new System.Drawing.Size(91, 26);
            this.Starttime.TabIndex = 25;
            // 
            // EndDate
            // 
            this.EndDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndDate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EndDate.Location = new System.Drawing.Point(330, 3);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(148, 26);
            this.EndDate.TabIndex = 24;
            // 
            // EndTime
            // 
            this.EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndTime.EditValue = new System.DateTime(2021, 10, 12, 0, 0, 0, 0);
            this.EndTime.Location = new System.Drawing.Point(484, 3);
            this.EndTime.Name = "EndTime";
            this.EndTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EndTime.Properties.Appearance.Options.UseFont = true;
            this.EndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EndTime.Size = new System.Drawing.Size(105, 26);
            this.EndTime.TabIndex = 22;
            // 
            // btn_Serch
            // 
            this.btn_Serch.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Serch.Appearance.Options.UseFont = true;
            this.btn_Serch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Serch.Location = new System.Drawing.Point(595, 3);
            this.btn_Serch.Name = "btn_Serch";
            this.btn_Serch.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Serch.Size = new System.Drawing.Size(96, 30);
            this.btn_Serch.TabIndex = 27;
            this.btn_Serch.Text = "查询";
            // 
            // TJType
            // 
            this.TJType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TJType.Location = new System.Drawing.Point(79, 39);
            this.TJType.Name = "TJType";
            this.TJType.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TJType.Properties.Appearance.Options.UseFont = true;
            this.TJType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TJType.Properties.Items.AddRange(new object[] {
            "综合统计",
            "时效分析",
            "核酸上报"});
            this.TJType.Size = new System.Drawing.Size(148, 26);
            this.TJType.TabIndex = 29;
            this.TJType.SelectedIndexChanged += new System.EventHandler(this.TJType_SelectedIndexChanged);
            // 
            // BtnExport
            // 
            this.BtnExport.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExport.Appearance.Options.UseFont = true;
            this.BtnExport.Location = new System.Drawing.Point(330, 39);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnExport.Size = new System.Drawing.Size(95, 31);
            this.BtnExport.TabIndex = 30;
            this.BtnExport.Text = "导出报表";
            // 
            // isInputerCheck
            // 
            this.isInputerCheck.AutoSize = true;
            this.isInputerCheck.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.isInputerCheck.Location = new System.Drawing.Point(484, 39);
            this.isInputerCheck.Name = "isInputerCheck";
            this.isInputerCheck.Size = new System.Drawing.Size(98, 24);
            this.isInputerCheck.TabIndex = 31;
            this.isInputerCheck.Text = "小程序导入";
            this.isInputerCheck.UseVisualStyleBackColor = true;
            // 
            // FrmPanel
            // 
            this.FrmPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrmPanel.Location = new System.Drawing.Point(0, 71);
            this.FrmPanel.Name = "FrmPanel";
            this.FrmPanel.Size = new System.Drawing.Size(1222, 587);
            this.FrmPanel.TabIndex = 1;
            // 
            // UITJFX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FrmPanel);
            this.Controls.Add(this.panel1);
            this.Name = "UITJFX";
            this.Size = new System.Drawing.Size(1222, 658);
            this.panel1.ResumeLayout(false);
            this.PanelLayout.ResumeLayout(false);
            this.PanelLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Starttime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TJType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel PanelLayout;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl TimeTypeLabel;
        private System.Windows.Forms.DateTimePicker StartDate;
        private DevExpress.XtraEditors.TimeEdit Starttime;
        private System.Windows.Forms.DateTimePicker EndDate;
        private DevExpress.XtraEditors.TimeEdit EndTime;
        private DevExpress.XtraEditors.SimpleButton btn_Serch;
        private DevExpress.XtraEditors.ComboBoxEdit TJType;
        private DevExpress.XtraEditors.SimpleButton BtnExport;
        private System.Windows.Forms.CheckBox isInputerCheck;
        private System.Windows.Forms.Panel FrmPanel;
    }
}
