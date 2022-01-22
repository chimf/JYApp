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
using DevExpress.XtraGrid;

namespace Apps.UIS.TJUi
{
    public partial class StatisticsUI : XtraUserControl
    {
        public StatisticsUI()
        {
            InitializeComponent();
        }

        public GridControl ShowGridControl => this.TJControl;
        public DevExpress.XtraGrid.Views.BandedGrid.BandedGridView ShowGridView => this.TJBandGridView;

        private void TJBandGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            string value = TJBandGridView.GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString();
            if (value == null)
                return;
            if (value.Equals("0"))
                e.Appearance.BackColor = Color.Tomato;
            else
            {
                e.Appearance.BackColor = Color.YellowGreen;
                e.Appearance.ForeColor = Color.Blue;
            }
        }
    }
}
