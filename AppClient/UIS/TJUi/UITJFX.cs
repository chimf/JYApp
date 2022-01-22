using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Apps.UIS.TJUi;

namespace AppClient.UIS.TJUi
{
    public partial class UITJFX : XtraUserControl
    {
        private StatisticsUI UI_Section1 = new StatisticsUI();
        private SXFX UI_Section2 = new SXFX();
        private XtraUserControl CurrentControl;
        
        public UITJFX()
        {
            InitializeComponent();
        }

        private void TJType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TJType.SelectedIndex)
            {
                case 0:
                    AddUIInit(UI_Section1);
                    break;
                case 1:
                    AddUIInit(UI_Section1);
                    break;
                case 2:
                    break;           
                default:
                    break;
            }
        }

        private void AddUIInit(XtraUserControl userControl)
        {
            if (userControl == null)
                return;
            foreach (Control item in FrmPanel.Controls)
                FrmPanel.Controls.Remove(item);
            FrmPanel.Visible = true;
            userControl.Size = this.FrmPanel.Size;
            userControl.Top = this.FrmPanel.Top;
            userControl.Left = this.FrmPanel.Left;
            userControl.Parent = this.FrmPanel;
            CurrentControl = userControl;

        }



    }
}
