namespace AppClient.UIS.Diag
{
    partial class DUIModify
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.GridShowInfoControl = new DevExpress.XtraGrid.GridControl();
            this.GridShowInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.typeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.perName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.perCertTYpec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.perCertNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sampTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.perDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Classification = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Subcategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.principal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SampleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnOP = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridShowInfoControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridShowInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOP)).BeginInit();
            this.SuspendLayout();
            // 
            // GridShowInfoControl
            // 
            this.GridShowInfoControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridShowInfoControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GridShowInfoControl.Location = new System.Drawing.Point(0, 0);
            this.GridShowInfoControl.MainView = this.GridShowInfo;
            this.GridShowInfoControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridShowInfoControl.Name = "GridShowInfoControl";
            this.GridShowInfoControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnOP});
            this.GridShowInfoControl.Size = new System.Drawing.Size(1066, 321);
            this.GridShowInfoControl.TabIndex = 0;
            this.GridShowInfoControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridShowInfo});
            // 
            // GridShowInfo
            // 
            this.GridShowInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.typeName,
            this.perName,
            this.perCertTYpec,
            this.perCertNo,
            this.sampTime,
            this.perDel,
            this.Classification,
            this.Subcategory,
            this.principal,
            this.note,
            this.unit,
            this.SampleName,
            this.gridColumn1,
            this.Id,
            this.gridColumn2,
            this.gridColumn3});
            this.GridShowInfo.DetailHeight = 425;
            this.GridShowInfo.GridControl = this.GridShowInfoControl;
            this.GridShowInfo.Name = "GridShowInfo";
            this.GridShowInfo.OptionsView.ColumnAutoWidth = false;
            this.GridShowInfo.OptionsView.ShowGroupPanel = false;
            this.GridShowInfo.PreviewIndent = 30;
            this.GridShowInfo.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.GridShowInfo_CustomDrawRowIndicator);
            this.GridShowInfo.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridShowInfo_CellValueChanged);
            // 
            // typeName
            // 
            this.typeName.Caption = "受检者类型";
            this.typeName.FieldName = "typeName";
            this.typeName.Name = "typeName";
            this.typeName.Visible = true;
            this.typeName.VisibleIndex = 8;
            this.typeName.Width = 135;
            // 
            // perName
            // 
            this.perName.Caption = "姓名";
            this.perName.FieldName = "perName";
            this.perName.Name = "perName";
            this.perName.Visible = true;
            this.perName.VisibleIndex = 2;
            this.perName.Width = 74;
            // 
            // perCertTYpec
            // 
            this.perCertTYpec.Caption = "证件类型";
            this.perCertTYpec.FieldName = "perCertTYpec";
            this.perCertTYpec.Name = "perCertTYpec";
            this.perCertTYpec.Visible = true;
            this.perCertTYpec.VisibleIndex = 3;
            this.perCertTYpec.Width = 134;
            // 
            // perCertNo
            // 
            this.perCertNo.Caption = "证件号";
            this.perCertNo.FieldName = "perCertNo";
            this.perCertNo.Name = "perCertNo";
            this.perCertNo.Visible = true;
            this.perCertNo.VisibleIndex = 4;
            this.perCertNo.Width = 187;
            // 
            // sampTime
            // 
            this.sampTime.Caption = "采样时间";
            this.sampTime.FieldName = "sampTime";
            this.sampTime.Name = "sampTime";
            this.sampTime.Visible = true;
            this.sampTime.VisibleIndex = 10;
            this.sampTime.Width = 129;
            // 
            // perDel
            // 
            this.perDel.Caption = "联系方式";
            this.perDel.FieldName = "perDel";
            this.perDel.Name = "perDel";
            this.perDel.Visible = true;
            this.perDel.VisibleIndex = 5;
            this.perDel.Width = 107;
            // 
            // Classification
            // 
            this.Classification.Caption = "职业分类";
            this.Classification.FieldName = "Classification";
            this.Classification.Name = "Classification";
            this.Classification.Visible = true;
            this.Classification.VisibleIndex = 6;
            this.Classification.Width = 131;
            // 
            // Subcategory
            // 
            this.Subcategory.Caption = "职业子分类";
            this.Subcategory.FieldName = "Subcategory";
            this.Subcategory.Name = "Subcategory";
            this.Subcategory.Visible = true;
            this.Subcategory.VisibleIndex = 9;
            this.Subcategory.Width = 109;
            // 
            // principal
            // 
            this.principal.Caption = "委托单位";
            this.principal.FieldName = "principal";
            this.principal.Name = "principal";
            this.principal.Visible = true;
            this.principal.VisibleIndex = 7;
            this.principal.Width = 141;
            // 
            // note
            // 
            this.note.Caption = "备注";
            this.note.FieldName = "note";
            this.note.Name = "note";
            this.note.Visible = true;
            this.note.VisibleIndex = 12;
            this.note.Width = 170;
            // 
            // unit
            // 
            this.unit.Caption = "受检者单位";
            this.unit.FieldName = "unit";
            this.unit.Name = "unit";
            this.unit.Visible = true;
            this.unit.VisibleIndex = 1;
            this.unit.Width = 185;
            // 
            // SampleName
            // 
            this.SampleName.Caption = "样本类型";
            this.SampleName.FieldName = "SampleName";
            this.SampleName.Name = "SampleName";
            this.SampleName.Visible = true;
            this.SampleName.VisibleIndex = 13;
            this.SampleName.Width = 141;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "操作";
            this.gridColumn1.ColumnEdit = this.btnOP;
            this.gridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 15;
            // 
            // btnOP
            // 
            this.btnOP.AutoHeight = false;
            this.btnOP.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            editorButtonImageOptions2.Image = global::AppClient.Properties.Resources.iconsetredtoblack4_16x16;
            editorButtonImageOptions2.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            serializableAppearanceObject5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            serializableAppearanceObject5.Options.UseFont = true;
            this.btnOP.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "删除", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnOP.Name = "btnOP";
            this.btnOP.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnOP.Click += new System.EventHandler(this.btnOP_Click);
            // 
            // Id
            // 
            this.Id.Caption = "ID";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = true;
            this.Id.VisibleIndex = 14;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "是否冷库";
            this.gridColumn2.FieldName = "isCool";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 64;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "费用";
            this.gridColumn3.FieldName = "cost";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 11;
            // 
            // DUIModify
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 321);
            this.Controls.Add(this.GridShowInfoControl);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.Image = global::AppClient.Properties.Resources.customer_16x16;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DUIModify";
            this.Text = "混管受采集者信息";
            ((System.ComponentModel.ISupportInitialize)(this.GridShowInfoControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridShowInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridShowInfoControl;
        private DevExpress.XtraGrid.Views.Grid.GridView GridShowInfo;
        private DevExpress.XtraGrid.Columns.GridColumn typeName;
        private DevExpress.XtraGrid.Columns.GridColumn perName;
        private DevExpress.XtraGrid.Columns.GridColumn perCertTYpec;
        private DevExpress.XtraGrid.Columns.GridColumn perCertNo;
        private DevExpress.XtraGrid.Columns.GridColumn sampTime;
        private DevExpress.XtraGrid.Columns.GridColumn perDel;
        private DevExpress.XtraGrid.Columns.GridColumn Classification;
        private DevExpress.XtraGrid.Columns.GridColumn Subcategory;
        private DevExpress.XtraGrid.Columns.GridColumn principal;
        private DevExpress.XtraGrid.Columns.GridColumn note;
        private DevExpress.XtraGrid.Columns.GridColumn unit;
        private DevExpress.XtraGrid.Columns.GridColumn SampleName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnOP;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}