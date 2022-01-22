namespace AppClient.UIS.DicUI
{
    partial class UIInputerCJ
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
            this.UploadBtn = new DevExpress.XtraEditors.SimpleButton();
            this.InputerFileBtn = new DevExpress.XtraEditors.SimpleButton();
            this.InputeContorl = new DevExpress.XtraGrid.GridControl();
            this.InputerGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputeContorl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.UploadBtn);
            this.panel1.Controls.Add(this.InputerFileBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1149, 34);
            this.panel1.TabIndex = 0;
            // 
            // UploadBtn
            // 
            this.UploadBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.UploadBtn.ImageOptions.Image = global::AppClient.Properties.Resources.publish_16x16;
            this.UploadBtn.Location = new System.Drawing.Point(89, 0);
            this.UploadBtn.Name = "UploadBtn";
            this.UploadBtn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.UploadBtn.Size = new System.Drawing.Size(89, 34);
            this.UploadBtn.TabIndex = 1;
            this.UploadBtn.Text = "上传数据";
            // 
            // InputerFileBtn
            // 
            this.InputerFileBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.InputerFileBtn.ImageOptions.Image = global::AppClient.Properties.Resources.right_16x16;
            this.InputerFileBtn.Location = new System.Drawing.Point(0, 0);
            this.InputerFileBtn.Name = "InputerFileBtn";
            this.InputerFileBtn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.InputerFileBtn.Size = new System.Drawing.Size(89, 34);
            this.InputerFileBtn.TabIndex = 0;
            this.InputerFileBtn.Text = "导入表格";
            this.InputerFileBtn.Click += new System.EventHandler(this.InputerFileBtn_Click);
            // 
            // InputeContorl
            // 
            this.InputeContorl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputeContorl.Location = new System.Drawing.Point(0, 34);
            this.InputeContorl.MainView = this.InputerGridView;
            this.InputeContorl.Name = "InputeContorl";
            this.InputeContorl.Size = new System.Drawing.Size(1149, 641);
            this.InputeContorl.TabIndex = 1;
            this.InputeContorl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.InputerGridView});
            // 
            // InputerGridView
            // 
            this.InputerGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn1,
            this.gridColumn9,
            this.gridColumn7,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18});
            this.InputerGridView.GridControl = this.InputeContorl;
            this.InputerGridView.Name = "InputerGridView";
            this.InputerGridView.OptionsView.ColumnAutoWidth = false;
            this.InputerGridView.OptionsView.ShowGroupPanel = false;
            this.InputerGridView.OptionsView.ShowIndicator = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "条形码";
            this.gridColumn6.FieldName = "Barcode";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 80;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "姓名";
            this.gridColumn2.FieldName = "perName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 115;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "证件号";
            this.gridColumn3.FieldName = "perCertNo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 177;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "证件类别";
            this.gridColumn4.FieldNameSortGroup = "perCertTypec";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 116;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "联系方式";
            this.gridColumn5.FieldNameSortGroup = "perDel";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 92;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "性别";
            this.gridColumn8.FieldName = "sex";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 62;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "单位";
            this.gridColumn1.FieldName = "unit";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 117;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "年龄";
            this.gridColumn9.FieldName = "age";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            this.gridColumn9.Width = 63;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "采样时间";
            this.gridColumn7.FieldName = "sampTime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 88;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "职业分类";
            this.gridColumn10.FieldName = "Classification";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            this.gridColumn10.Width = 147;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "职业子分类";
            this.gridColumn11.FieldName = "Subcategory";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 11;
            this.gridColumn11.Width = 153;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "委托方";
            this.gridColumn12.FieldName = "principal";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 130;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "是否冷库";
            this.gridColumn13.FieldName = "Cool";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 12;
            this.gridColumn13.Width = 66;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "采样人";
            this.gridColumn14.FieldName = "Colleter";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 13;
            this.gridColumn14.Width = 87;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "采样地点";
            this.gridColumn15.FieldName = "CyAddress";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 14;
            this.gridColumn15.Width = 91;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "费用";
            this.gridColumn16.FieldName = "cost";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 15;
            this.gridColumn16.Width = 67;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "备注";
            this.gridColumn17.FieldName = "note";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 16;
            this.gridColumn17.Width = 133;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "电子邮箱";
            this.gridColumn18.FieldName = "Email";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 17;
            this.gridColumn18.Width = 137;
            // 
            // UIInputerCJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InputeContorl);
            this.Controls.Add(this.panel1);
            this.Name = "UIInputerCJ";
            this.Size = new System.Drawing.Size(1149, 675);
            this.Load += new System.EventHandler(this.UIInputerCJ_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputeContorl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputerGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl InputeContorl;
        private DevExpress.XtraGrid.Views.Grid.GridView InputerGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.SimpleButton InputerFileBtn;
        private DevExpress.XtraEditors.SimpleButton UploadBtn;
    }
}
