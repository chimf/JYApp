using System;
using System.Data;
using EntityDao.imp;
using FastReport;
using FastReport.Export.Pdf;

namespace AppClient.UIS
{
    public class UIReportProcess
    {
        public static int GetDataAndPageCount(ref DataTable dt ,string Condition,int CurrentPage=1) {
            int totallPages,rows;
            UploadTabls uploadTabls = new UploadTabls();
            dt = uploadTabls.GetPage(" where " + Condition, CurrentPage, 100, out totallPages, out rows);
            return totallPages;
        }

        public static bool PrintReport(DataTable dt, string ReportModel,out string desc,string FilePath="", Report report=null) {
            if(report==null)
               report = new Report();
            report.RegisterData(dt, "CovidSample");
            report.Load(ReportModel);
            try
            {
                report.Prepare(false);   //准备               
                if (!FilePath.Equals(""))
                {
                    PDFExport pdf = new PDFExport();                   
                    report.Export(pdf, FilePath);
                }else
                    report.ShowPrepared();  //显示
                desc = "";
                return true;
            }
            catch (Exception e) {
                desc = e.Message;
                return false;
            }           
        }
    }
}
