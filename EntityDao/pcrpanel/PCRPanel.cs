using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using ZhiFang.DBUtility;
using System.Collections;
using System.Text;
using NPOI.HSSF.UserModel;

namespace EntityDao.pcrpanel
{

    public class PCRPanel
    {
        private static IDBConnection online = ZhiFang.DBUtility.DBFactory.CreateDB("LISDB");
        private static string path = Application.StartupPath + "\\PanelXML\\";
        public static bool WriteToDisk(DataTable dt)
        {
            try
            {
                if (Directory.Exists(path) == false)
                    Directory.CreateDirectory(path);
                path = path + "Temp.xml";
                if (File.Exists(path))
                    File.Delete(path);
                dt.TableName = "import";
                dt.WriteXml(path, XmlWriteMode.WriteSchema);
                return true;
            }
            catch (Exception e)
            {
                ZhiFang.Common.Log.Log.Error("ImportTable::WriteToTable:" + e.Message);
                return false;
            }
        }
        public static DataTable InitPanel() {
            DataTable PosiontTable = new DataTable("PCRPanel");
            PosiontTable.Columns.Add("title");
            for (int i = 1; i < 13; i++)
                if (!PosiontTable.Columns.Contains("C" + i))
                    PosiontTable.Columns.Add(new DataColumn("C" + i));

            for (int i = 65; i < 73; i++)
            {
                DataRow dr = PosiontTable.NewRow();
                foreach (DataColumn dc in PosiontTable.Columns)
                {
                    if (dc.ColumnName.Equals("title"))
                        dr[dc.ColumnName] = Convert.ToString(Convert.ToChar(i));                    
                }
                PosiontTable.Rows.Add(dr);
            }
            return PosiontTable;
        }

        public static bool FullCombox(ComboBoxItemCollection items,Entity.EnumType.ComboBoxSQLType sqlType) {
            string SQL="";
            switch (sqlType)
            {
                case Entity.EnumType.ComboBoxSQLType.Puser:
                    SQL = "select UserNo as Keys,CName from PUser where  SectorTypeNo=1 AND Visible=1 order by DispOrder ASC";
                    break;
                case Entity.EnumType.ComboBoxSQLType.Equipment:
                    SQL = "select EquipNo as Keys,CName from Equipment where Visible=1 order by EquipNo asc";
                    break;
                case Entity.EnumType.ComboBoxSQLType.TestItem:
                    SQL = "select ItemNo as Keys,CName from TestItem where Visible = 1 order by DispOrder asc";
                    break;
                case Entity.EnumType.ComboBoxSQLType.Group:
                    SQL = "select SectionNo as Keys,CName from PGroup where   Visible=1 order by DispOrder ASC";
                    break;
                default:                   
                    break;
            }
            try {
               DataTable dt = online.ExecuteDataSet(SQL).Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    Entity.ControlModelItem ComboboxObj = new Entity.ControlModelItem(item["Keys"].ToString(),item["Cname"].ToString());
                    items.Add(ComboboxObj);
                }
                return true;
            } catch (Exception e) {
                ZhiFang.Common.Log.Log.Error(e.Message);
                return false;
            }
        }

        public static bool InsertToPanel(DataTable dt,DataTable lefTable,string SerialNo,string PanelNumber, out string desc) {
            desc = "";
            DataTable sampledt;
            try {
                sampledt = online.ExecuteDataSet(
                    string.Format("select * from CovidSample where Barcode='{0}' and isnull(isReport,0)=0",SerialNo)).Tables[0];
                if (sampledt==null || sampledt.Rows.Count<=0){
                    desc = "条码号: "+SerialNo+" 不存在，请确定输入的条码号是否正确！";
                    return false;
                } 
                string sql = string.Format("select Count(1) as counts from Pcr_Panel where CreateTime>='{0}' AND CreateTime<='{1}' And PanelNumber='{2}'",
                                          DateTime.Now.ToString("yyyy-MM-dd")+" 00:00:00",DateTime.Now.ToString("yyyy-MM-dd")+" 23:59:00",PanelNumber);
                int count = Convert.ToInt32(online.ExecuteScalar(sql));
                if (count != 0) {
                    desc = "试验批次已经重复，请更换试验批次后再尝试";
                    return false;
                }

            } catch (Exception e) {
                desc = e.Message;
                return false;
            }
            DataRow[] drs = lefTable.Select(string.Format("Barcode='{0}'",SerialNo));
            if (drs.Length >= 0) 
                foreach (DataRow item in drs)
                    lefTable.Rows.Remove(item);
            foreach (DataColumn item in sampledt.Columns)
                if (!lefTable.Columns.Contains(item.ColumnName))
                    lefTable.Columns.Add(item.ColumnName);

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                   string info = dt.Rows[j][i].ToString();
                    if (info.Trim().ToUpper().Equals(SerialNo.ToUpper())) {
                        desc = SerialNo+" 已排版，请重新更换条码号";
                        return false;
                    }
                    if (info.Trim().Equals("")) {
                        dt.Rows[j][i] = SerialNo;
                        int count = 1;
                        
                        foreach (DataRow item in sampledt.Rows)
                        {                                                      
                            DataRow dr = lefTable.NewRow();
                            foreach (DataColumn dc in sampledt.Columns)
                            {
                                if (dc.DataType.Name.ToUpper().Equals("DateTime".ToUpper()))
                                    continue;
                                dr[dc.ColumnName] = item[dc.ColumnName].ToString();
                            }
                            dr["SampleNo"] = dt.Rows[j][0].ToString()+dt.Columns[i].ColumnName.Replace("C","")+"#"+ PanelNumber+"_"+ count.ToString();
                            dr["isReport"] = "已签收";
                            dr["perName"] = item["perName"].ToString();
                            dr["perCertNo"] = item["perCertNo"].ToString();
                            dr["Barcode"] = SerialNo;                            
                            count += 1;                            
                            lefTable.Rows.Add(dr);
                        }
                        WriteToDisk(dt);
                        return true;
                    }
                }
            }
            desc = "当前面板已经满,无法再次排版样本!";
            return false;
        }

        public static bool WriteToPCRPanelTable(DataTable dt) {
            int inputCount;           
            using (SqlConnection con = new SqlConnection(DbHelperSQL.connectionString))
            {
                using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(DbHelperSQL.connectionString, SqlBulkCopyOptions.UseInternalTransaction))
                {
                    try
                    {
                        sqlbulkcopy.DestinationTableName = "Pcr_Panel";
                        for (int i = 0; i < dt.Columns.Count; i++)
                            sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                        sqlbulkcopy.WriteToServer(dt);
                        inputCount = dt.Rows.Count;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public static DataTable CreateLeftTable() {
            
            DataTable dt = new DataTable();
            DataTable Fields = online.ExecuteDataSet(string.Format("Select  '' as SampleNo,'' as isReport,'' as perName,'' as Barcode,'' as perCertNo ")).Tables[0];
            foreach (DataColumn dc in Fields.Columns)
            {
               if (!dt.Columns.Contains(dc.ColumnName.ToString()))
                   dt.Columns.Add(dc.ColumnName.ToString());
            }
              
            return dt;
        }

        private static string insertRequestForm(DataRow dr,DateTime ReceiveDate,int sectionno)
        {
            LIS.Model.Entity.RequestForm requestForm = new LIS.Model.Entity.RequestForm();
            LIS.DAL.DRequestForm dRequestForm = new LIS.DAL.DRequestForm();
            requestForm.ReceiveDate = ReceiveDate;
            requestForm.SectionNo = sectionno;
            requestForm.SampleNo = dr["SampleNo"].ToString(); ;
            requestForm.TestTypeNo = 1;
            requestForm.CName = dr["perName"].ToString();
            requestForm.PatNo = dr["barcode"].ToString();
            requestForm.incepter = dr["Incepter"].ToString();
            DateTime datetime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            requestForm.inceptdate = datetime;
            requestForm.ReceiveTime = datetime;
            requestForm.incepttime = datetime;
            requestForm.isReceive = 1;
            requestForm.phoneCode = dr["perDel"].ToString();
            int age;
            if (Int32.TryParse(dr["age"].ToString(), out age))
                requestForm.Age = age;
            requestForm.GenderNo = string.IsNullOrEmpty(dr["sex"].ToString()) ? 3 : dr["sex"].ToString().Equals("男") ? 1 : dr["sex"].ToString().Equals("女") ? 2 : 3;
            requestForm.SickTypeNo = 3;
            requestForm.Technician = "";
            requestForm.TestDate = datetime;
            requestForm.TestTime = datetime;
            requestForm.StatusNo = 1;
            requestForm.SerialNo = dr["id"].ToString();
            requestForm.Collecter = dr["Colleter"].ToString();

            DateTime Time;
            if (DateTime.TryParse(dr["sampTime"].ToString(), out Time))
                requestForm.CollectDate = Time;
            if (DateTime.TryParse(dr["sampTime"].ToString(), out Time))
                requestForm.CollectTime = Time;
            requestForm.zdy1 = dr["perCertNo"].ToString();
            requestForm.zdy2 = dr["Classification"].ToString();
            requestForm.zdy3 = dr["principal"].ToString();
            requestForm.zdy4 = dr["unit"].ToString();
            requestForm.zdy5 = dr["perCertTypec"].ToString();

            string SQL = dRequestForm.Exists(requestForm.ReceiveDate.ToString("yyyy-MM-dd"), requestForm.SectionNo,
                requestForm.TestTypeNo, requestForm.SampleNo) ? dRequestForm.Update(requestForm) : dRequestForm.Add(requestForm);
            return SQL;

        }
        private static string insertRequestItem(DataRow dr, DateTime ReceiveDate, int sectionnoo)
        {
            LIS.Model.Entity.RequestItem item = new LIS.Model.Entity.RequestItem();
            LIS.DAL.DRequestItem dRequestItem = new LIS.DAL.DRequestItem();
           
            item.ReceiveDate = ReceiveDate;
            item.SectionNo = sectionnoo;
            item.SampleNo = dr["SampleNo"].ToString();
            item.TestTypeNo = 1;
            item.ParItemNo = 100;
            item.ItemNo = 100;
            item.ItemTime = DateTime.Now;
            item.ItemDate = DateTime.Now;
            item.isReceive = 1;
            item.RefRange = "阴性";
            item.ReportDesc = "阴性";
            item.SerialNo = dr["barcode"].ToString();
            return dRequestItem.Exists(item.ReceiveDate, item.SectionNo, item.TestTypeNo, item.SampleNo, item.ItemNo) ? dRequestItem.Update(item) : dRequestItem.Add(item);
        }

        public static bool WriteToRequest(DataTable dt, DateTime ReceiveDate, int SectionNo) {
            try
            {
                ArrayList sqllist = new ArrayList();
                ArrayList itemlist = new ArrayList();
                if (dt == null || dt.Rows.Count <= 0)
                    return false;                              
                foreach (DataRow item in dt.Rows)
                {
                    sqllist.Add(insertRequestForm(item, ReceiveDate, SectionNo));
                    itemlist.Add(insertRequestItem(item, ReceiveDate, SectionNo));
                }
                if (sqllist.Count > 0)
                {
                    online.BatchUpdateWithTransaction(sqllist);
                    online.BatchUpdateWithTransaction(itemlist);
                }
                else
                    return false;
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static bool DeletePCRPanel(string pcrNumber) {
            try
            {
                string SQLlist = string.Format("delete from pcr_panel where PanelNumber='{0}'",pcrNumber);
                online.ExecuteNonQuery(SQLlist);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public static bool OutExcelToEq(string FilePathName, DataTable infoTable, DataTable panelTable, bool FX = false)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("上机表");
            //填充表头
            HSSFRow dataRow = (HSSFRow)sheet.CreateRow(0);
            dataRow.CreateCell(0).SetCellValue("index");
            dataRow.CreateCell(1).SetCellValue("Well");
            dataRow.CreateCell(2).SetCellValue("Sample Name");
            dataRow.CreateCell(3).SetCellValue("Remarks");
            int count = 0;
            //开始填充内容
            if (FX == false)
            {
                for (int i = 0; i < panelTable.Rows.Count; i++)
                {
                    for (int j = 0; j < panelTable.Columns.Count; j++)
                    {
                        if (j == 0)
                            continue;
                        count += 1;
                        dataRow = (HSSFRow)sheet.CreateRow(count);
                        dataRow.CreateCell(0).SetCellValue(count);

                        string A = panelTable.Rows[i][0].ToString();
                        string B = panelTable.Columns[j].ToString().Replace("C", "");
                        A = A + B;
                        dataRow.CreateCell(1).SetCellValue(A);

                        string barcode = panelTable.Rows[i][panelTable.Columns[j].ColumnName].ToString();

                        DataRow[] rds = infoTable.Select(string.Format("Barcode='{0}'", barcode));
                        StringBuilder namesb = new StringBuilder();
                        StringBuilder cardsb = new StringBuilder();
                        if (rds.Length > 0)
                        {
                            foreach (DataRow item in rds)
                            {
                                namesb.Append(item["perName"].ToString() + ",");
                                cardsb.Append(item["perCertNo"].ToString() + ",");
                            }
                            dataRow.CreateCell(2).SetCellValue(barcode + "[" + namesb.ToString().TrimEnd(',') + "]");
                        }
                        else
                            dataRow.CreateCell(2).SetCellValue(barcode);
                    }
                }
                using (FileStream fs = new FileStream(FilePathName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }
                return true;
            }
            else
            {
                for (int i = 0; i < panelTable.Columns.Count; i++)
                {
                    if (i == 0)
                        continue;
                    for (int j = 0; j < panelTable.Rows.Count; j++)
                    {
                        count += 1;
                        dataRow = (HSSFRow)sheet.CreateRow(count);
                        dataRow.CreateCell(0).SetCellValue(count);


                        string C = panelTable.Columns[i].ToString().Replace("C", "");
                        string A = panelTable.Rows[j][0].ToString();
                        A = A + C;
                        dataRow.CreateCell(1).SetCellValue(A);

                        string barcode = panelTable.Rows[j][panelTable.Columns[i].ColumnName].ToString();
                        DataRow[] rds = infoTable.Select(string.Format("Barcode='{0}'", barcode));
                        StringBuilder namesb = new StringBuilder();
                        StringBuilder cardsb = new StringBuilder();
                        if (rds.Length > 0)
                        {
                            foreach (DataRow item in rds)
                            {
                                namesb.Append(item["perName"].ToString() + ",");
                                cardsb.Append(item["perCertNo"].ToString() + ",");
                            }
                            dataRow.CreateCell(2).SetCellValue(barcode + "[" + namesb.ToString().TrimEnd(',') + "]");
                        }
                        else
                            dataRow.CreateCell(2).SetCellValue(barcode);
                    }
                }
                using (FileStream fs = new FileStream(FilePathName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }
                return true;
            }
        }

        public static bool WritePanelInfo(Entity.PanelInfo info) {
            try
            {
                online.ExecuteNonQuery(info.ToString());
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool UpdatePanelInfo(Entity.PanelInfo info) {
            try
            {
                online.ExecuteNonQuery(info.ToUpdate());
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public static bool ExsitsPanelInfo(string PanelNumber,string CreateTime,string endTime) {
            try
            {
                if (online.ExecCount("Pcr_PanelInfo", string.Format("PanelNumber='{0}' and CreateTime>='{1}' and CreateTime<='{2}'", PanelNumber,CreateTime, endTime)) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {

                return false;
            }

        }

        public static DataTable SerchPanelInfo(string where) {
            try
            {
               return online.ExecuteDataSet("select * from Pcr_PanelInfo where "+where).Tables[0];
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static Entity.PanelInfo SerchPanelInfoBy(string where) {
            try
            {
                DataTable dt = online.ExecuteDataSet("select top 1 * from Pcr_PanelInfo where " + where).Tables[0];
                if (dt == null || dt.Rows.Count <= 0)
                    return null;
                Entity.PanelInfo info = new Entity.PanelInfo();
                info.BatchNumber = dt.Rows[0][""].ToString();
                info.PanelMode = dt.Rows[0]["PanelMode"].ToString();
                info.TestTime = dt.Rows[0]["TestTime"].ToString();
                info.BatchRate = dt.Rows[0]["BatchRate"].ToString();
                info.BatchNumber = dt.Rows[0]["BatchNumber"].ToString();
                info.EqName = dt.Rows[0]["EqName"].ToString();
                info.Tester = dt.Rows[0]["Tester"].ToString();
                info.Checker = dt.Rows[0]["Checker"].ToString();
                info.Reagent = dt.Rows[0]["reagent"].ToString();
                info.RStartDateTime = dt.Rows[0]["RStartDateTime"].ToString();
                info.REenDateTime = dt.Rows[0]["REenDateTime"].ToString();
                info.CreateTime = dt.Rows[0]["CreateTime"].ToString();
                return info;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataTable SerchPCRPanel(string where ) {
            try
            {
                return online.ExecuteDataSet("select * from Pcr_Panel where " + where).Tables[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataTable GetDataByCovidSample(string conditon) {
           DataTable dt =  imp.Covid.GetDataByMaster(conditon);
            return dt;
        }

    }
}
