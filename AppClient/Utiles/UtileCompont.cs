using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace AppClient.Utiles
{
    public static class UtileCompont
    {
        private static string path = Application.StartupPath + "\\ExcelStore\\";        
        public static GridColumnCollection Columns()
        {
            DataTable dt = EntityDao.imp.Covid.GetDataBySQL("PRAGMA table_info(CovidSample)");
            if (dt == null || dt.Rows.Count <= 0)
                return null;
            return null;
        }
       
        public static bool ImportTable(List<GridColumn> initColumnList, GridColumnCollection columns, DataTable RendTable, DataTable importTable,string FileName)
        {
            
            RendTable.Clear();
            RendTable.Columns.Clear();
            columns.Clear();
            foreach (GridColumn item in initColumnList)
            {
                item.Visible = true;
                columns.Add(item);
                if (!RendTable.Columns.Contains(item.FieldName))
                    RendTable.Columns.Add(item.FieldName);
            }
            DataColumnCollection rendColumns = RendTable.Columns;
            DataColumnCollection ImportGridColumns = importTable.Columns;
            foreach (DataColumn dc in ImportGridColumns)
            {
                if (dc.ColumnName.ToUpper().Contains("Column".ToUpper()))
                    continue;

                if (!rendColumns.Contains(dc.ColumnName.Trim()))
                {
                    GridColumn gc = new GridColumn();
                    gc.Caption = dc.ColumnName.Trim();
                    gc.FieldName = dc.ColumnName.Trim();
                    gc.Visible = true;
                    columns.Add(gc);
                    RendTable.Columns.Add(dc.ColumnName.Trim());
                }
            }

            foreach (DataRow item in importTable.Rows)
            {
                try
                {
                    if (string.IsNullOrEmpty(item["姓名"].ToString().Trim()) || string.IsNullOrEmpty(item["证件号"].ToString().Trim()))
                        continue;
                    else
                        RendTable.ImportRow(item);
                }
                catch (Exception) {
                }
            }

            //foreach (DataRow item in RendTable.Rows)
            //{
            //    string cardno = string.IsNullOrEmpty(item["证件号"].ToString()) ? "" : item["证件号"].ToString().Trim();
            //    EntityDao.imp.IDCard Id = EntityDao.imp.IDCard.Parse(cardno);
            //    item["isCollect"] = 0;
            //    if (Id != null)
            //        item["证件类别"] = "居民身份证";
            //    else if (EntityDao.imp.IDCard.isHKCard(cardno) != "")
            //        item["证件类别"] = EntityDao.imp.IDCard.isHKCard(cardno);
            //    else if (EntityDao.imp.IDCard.isHKCard(cardno) != "")
            //        item["证件类别"] = EntityDao.imp.IDCard.isTWCard(cardno);
            //    else
            //        item["errinfo"] = "未知证件类别";

            //}
            EntityDao.imp.ImportTable.WriteToDisk(RendTable);
            return true;

        }


        public static DataTable LoadDataFormDiskData(GridColumnCollection columns)
        {
            if (EntityDao.imp.ImportTable.isNotEmpty())
            {
                string info;
                DataTable RendTable = EntityDao.imp.ImportTable.ReadDataFormDisk(out info);
                if (RendTable == null)
                    return null;          
                List<string> list = new List<string>();
                foreach (GridColumn item in columns)
                    list.Add(item.FieldName.Trim().ToUpper());
                foreach (DataColumn dataColumn in RendTable.Columns)
                {
                    //排除英文字符字段
                    string reg = @"[\u4e00-\u9fa5]";
                    if (!Regex.IsMatch(dataColumn.ColumnName.Trim(), reg))
                        continue;
                    if (!list.Contains(dataColumn.ColumnName.ToUpper())) {
                        GridColumn gc = new GridColumn();                      
                        if (dataColumn.ColumnName.Trim().Contains("序号") || dataColumn.ColumnName.Trim().Contains("编号"))
                        {
                            gc.Fixed = FixedStyle.Left;
                            gc.VisibleIndex = 0;
                        }
                        gc.Caption = dataColumn.ColumnName.Trim();
                        gc.FieldName = dataColumn.ColumnName.Trim();
                        gc.Visible = true;
                        columns.Add(gc);
                    }                   
                }
                return RendTable;
            }
            else
                return null;
        }

        public static bool CopyExcelFile(string srcFileName) {
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
            string FileName = Path.GetFileName(srcFileName);
            string descFilePath = path +FileName;
            try
            {
                if (File.Exists(descFilePath))
                    File.Delete(descFilePath);
                File.Copy(srcFileName, descFilePath);
            }
            catch (Exception e)
            {
                
                return false;
            }
            return true;
        }

        public static string ReadConfig(string key) {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string value = config.AppSettings.Settings["collecter"].Value; //address
                return value;
            }
            catch {
                return "";
            }
        }

        public static bool WriteConfig(string key, string value) {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings[key].Value = value;
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}
