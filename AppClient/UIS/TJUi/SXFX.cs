using System;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;

namespace Apps.UIS.TJUi
{
    public partial class SXFX : XtraUserControl
    {
        public SXFX()
        {
            InitializeComponent();
        }


            
        public String GetSQL(string where) {
            return string.Format("with allinfo as (select * from CovidSample where 2>1 {0}),"+
                                   " Totall as (select unit, count(1) as totall from allinfo group by unit),"+
                                   " test as (select unit, count(1) as totall from allinfo where isnull(isReport, 0) = 1 group by unit),"+
                                   " report as (select unit, count(1) as totall from allinfo where isnull(isReport, 0) >= 3 group by unit),"+
                                   " fb as (select unit, count(1) as totall from allinfo where isnull(isReport, 0) >= 4 group by unit),"+
                                   " sb as (select unit, count(1) as totall from allinfo where isnull(isSendFalg, 0) <> 0 group by unit),"+
                                   " ssbs as (select unit, count(1) as totall from allinfo where isnull(isSendFalg, 0) =-1 group by unit)," +
                                   " scgs as (select unit, count(1) as totall from allinfo where isnull(isSendFalg, 0) =1 group by unit)," +
                                   " cc as (select a.unit,a.times from(select unit, max(times) as times from(select unit, datediff(n, sampTime, CreateTime) as times  from allinfo) a group by unit) a group by unit, times)," +
                                   " dd as (select a.unit,a.times from(select unit, max(times) as times from(select unit, datediff(n, CreateTime, InceptTime) as times  from allinfo) a group by unit) a group by unit, times),"+
                                   " ff as (select a.unit,a.times from(select unit, max(times) as times from(select unit, datediff(n, InceptTime, rptDate) as times  from allinfo) a group by unit) a group by unit, times)"+
                                   " select a.unit,a.totall,isnull(t.totall, 0) testcount,isnull(r.totall, 0) reportcount,isnull(f.totall, 0) pdfcount,isnull(s.totall, 0) sendcount,"+
                                   " isnull(ss.totall,0) as cgs,isnull(sb.totall,0) as sbs,"+
                                   " isnull(c.times, 0) sctime,ISNULL(d.times, 0) cictime,ISNULL(af.times, 0) irtime"+
                                   "     from Totall a left join test t on a.unit = t.unit"+
                                   " left join report r on a.unit = r.unit"+
                                   " left join fb f on a.unit = f.unit"+
                                   " left join sb s on s.unit = a.unit"+
                                   " left join cc c on a.unit = c.unit"+
                                   " left join dd d on d.unit = a.unit"+
                                   " left join ff af on a.unit = af.unit"+
                                   " left join scgs ss on a.unit=ss.unit"+
                                   " left join ssbs sb on a.unit=sb.unit"
                                   ,where);
        }

        public DevExpress.XtraGrid.GridControl GridControl => TestControl;

        private void TestView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {          
            //if ((sender is DevExpress.XtraEditors.Repository.RepositoryItemProgressBar))
            //{
            //    GridColumn col = e.Column;
            //    if (col.ColumnEdit.Name.Equals("cjdaoru")) {
            //        (col.ColumnEdit as RepositoryItemProgressBar).Maximum =10;
            //        (col.ColumnEdit as RepositoryItemProgressBar).Step = 9;                   
            //    }

            //    (sender as DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).Maximum = 100;
            //    (sender as RepositoryItemProgressBar).Step = 1;
            //}
        }
    }
}
