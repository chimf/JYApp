namespace AppClient
{
    partial class UILogin
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.LoginAddress = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(35, 33);
            this.lblTitle.Size = new System.Drawing.Size(253, 32);
            this.lblTitle.Text = "基源基因";
            // 
            // lblSubText
            // 
            this.lblSubText.Text = "";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(327, 381);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 21);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "采样地点：";
            // 
            // LoginAddress
            // 
            this.LoginAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.LoginAddress.BackgroundImage = global::AppClient.Properties.Resources.about_16x16;
            this.LoginAddress.ButtonSymbol = 61761;
            this.LoginAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LoginAddress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginAddress.IsScaled = false;
            this.LoginAddress.Location = new System.Drawing.Point(414, 381);
            this.LoginAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LoginAddress.Maximum = 2147483647D;
            this.LoginAddress.Minimum = -2147483648D;
            this.LoginAddress.MinimumSize = new System.Drawing.Size(1, 16);
            this.LoginAddress.Name = "LoginAddress";
            this.LoginAddress.Size = new System.Drawing.Size(230, 29);
            this.LoginAddress.TabIndex = 11;
            this.LoginAddress.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoginAddress.TextChanged += new System.EventHandler(this.LoginAddress_TextChanged);
            // 
            // UILogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.LoginAddress);
            this.Controls.Add(this.labelControl1);
            this.Name = "UILogin";
            this.SubText = "";
            this.Title = "基源基因";
            this.OnLogin += new Sunny.UI.UILoginForm.OnLoginHandle(this.UILogin_OnLogin);
            this.Shown += new System.EventHandler(this.UILogin_Shown);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.lblSubText, 0);
            this.Controls.SetChildIndex(this.uiPanel1, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.LoginAddress, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Sunny.UI.UITextBox LoginAddress;
    }
}