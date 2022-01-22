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

namespace AppClient.UIS.Diag
{
    public partial class PatientInfoFormDialg : XtraForm
    {
        public DataTable infodata;
        public DataRow outRow=null;

        public PatientInfoFormDialg()
        {
            InitializeComponent();
        }

        private void PatientInfoForm_Load(object sender, EventArgs e)
        {
            GridStoreController.DataSource = infodata;
            GridStoreView.BestFitColumns();
        }

        private void GridStore_DoubleClick(object sender, EventArgs e)
        {
            outRow = GridStoreView.GetDataRow(GridStoreView.FocusedRowHandle);
            Close();
        }
    }
}