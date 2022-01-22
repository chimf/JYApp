using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AppClient
{
    public partial class UILogin : Sunny.UI.UILoginForm
    {
        private DataTable dt;
        public FrmMain FrmMain;
        public UILogin()
        {
            InitializeComponent();
        }

        private bool UILogin_OnLogin(string userName, string password)
        {
            EntityDao.imp.CreateDB.CreateTable();

            if (LIS.DAL.DPuser.UserLogin(userName, password, ref dt) == false)
            {
                MessageBox.Show("账号密码错误，请重试！或联系管理员", "账号错误");
                return false;
            }
            //select CName,UserNo,IsManager,SectorTypeNo,Visible from PUser 
            string username = string.IsNullOrEmpty(dt.Rows[0]["CName"].ToString())?"": dt.Rows[0]["CName"].ToString();
            string UserNo = string.IsNullOrEmpty(dt.Rows[0]["UserNo"].ToString()) ? "" : dt.Rows[0]["UserNo"].ToString();
            string IsManager = string.IsNullOrEmpty(dt.Rows[0]["IsManager"].ToString()) ? "" : dt.Rows[0]["IsManager"].ToString();
            string SectorTypeNo = string.IsNullOrEmpty(dt.Rows[0]["SectorTypeNo"].ToString()) ? "" : dt.Rows[0]["SectorTypeNo"].ToString();
            string Visible = string.IsNullOrEmpty(dt.Rows[0]["Visible"].ToString()) ? "" : dt.Rows[0]["Visible"].ToString();
            if (!Visible.Trim().Equals("1")) {
                MessageBox.Show("当前账号已停止使用！请联系管理员","账号错误");
                return false;
            }
            if (IsManager.Trim().Equals("1"))
                FrmMain.Rolue = -1;
            else if (SectorTypeNo.Trim().Equals("1"))
                FrmMain.Rolue = 1;
            else if (SectorTypeNo.Trim().Equals("2"))
            {
                FrmMain.Rolue = 2;
                FrmMain.loginUserName = username.Trim();                
                if (LoginAddress.Text.Trim().Equals("")) {
                    MessageBox.Show("必须填写采样地点", "登录错误");
                    return false;
                }
                FrmMain.loginAddress = LoginAddress.Text.Trim();
            }
            EntityDao.imp.Covid.WriteLogUser(username.Trim());
            FrmMain.loginform = this;
            this.DialogResult = DialogResult.OK;
            return true;
        }

        private void UILogin_Shown(object sender, EventArgs e)
        {
            LoginAddress.Text = EntityDao.imp.Covid.GetloginAddress();            
        }

        private void LoginAddress_TextChanged(object sender, EventArgs e)
        {
            EntityDao.imp.Covid.WriteLogAddress(LoginAddress.Text.Trim());
        }
    }
}