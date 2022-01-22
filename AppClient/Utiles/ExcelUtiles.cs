using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;
using System.Text;

namespace AppClient.Utiles
{
    public class ExcelUtiles
    {
        public static DataTable ExcelToDataTable(string filePath, out string errinfo, bool isColumnName, int startRows = 0)
        {
            DataTable dataTable = null;
            FileStream fs = null;
            DataColumn column = null;
            DataRow dataRow = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            errinfo = "";
            int startRow = 0;
            try
            {
                using (fs = File.OpenRead(filePath))
                {
                    // 2007版本
                    if (filePath.IndexOf(".xlsx") > 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003版本
                    else if (filePath.IndexOf(".xls") > 0)
                        workbook = new HSSFWorkbook(fs);

                    if (workbook != null)
                    {
                        sheet = workbook.GetSheetAt(0);//读取第一个sheet，当然也可以循环读取每个sheet
                        dataTable = new DataTable();
                        if (sheet != null)
                        {
                            int rowCount = sheet.LastRowNum;//总行数
                            if (rowCount > 0)
                            {
                                IRow firstRow = sheet.GetRow(startRows);//第一行
                                int cellCount = firstRow.LastCellNum;//列数

                                //构建datatable的列
                                if (isColumnName)
                                {
                                    startRow = startRows + 1;//如果第一行是列名，则从第二行开始读取
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        cell = firstRow.GetCell(i);
                                        if (cell != null)
                                        {
                                            if (cell.StringCellValue != null)
                                            {
                                                column = new DataColumn(cell.StringCellValue);
                                                int intc;
                                                if (!Int32.TryParse(column.ColumnName, out intc))
                                                    dataTable.Columns.Add(column);
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        column = new DataColumn("column" + (i + 1));
                                        dataTable.Columns.Add(column);
                                    }
                                }


                                for (int i = startRow; i <= rowCount; ++i)
                                {
                                    row = sheet.GetRow(i);
                                    if (row == null) continue;

                                    dataRow = dataTable.NewRow();
                                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                                    {
                                        try
                                        {
                                            cell = row.GetCell(j);
                                            if (cell == null)
                                            {

                                                dataRow[j] = "";
                                            }
                                            else
                                            {
                                                //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)
                                                try
                                                {
                                                    switch (cell.CellType)
                                                    {
                                                        case CellType.Blank:
                                                            try
                                                            {

                                                                dataRow[j] = "";
                                                            }
                                                            catch (Exception e) { }
                                                            break;

                                                        case CellType.Formula:
                                                            cell.SetCellType(CellType.String);
                                                            if (cell.StringCellValue.Equals("#NAME?"))
                                                                dataRow[j] = "";
                                                            else
                                                            {
                                                                DateTime d = DateTime.FromOADate(Double.Parse(cell.StringCellValue));
                                                                dataRow[j] = d.ToString("yyyy-MM-dd HH:mm:ss");
                                                            }
                                                            break;

                                                        case CellType.Numeric:
                                                            short format = cell.CellStyle.DataFormat;

                                                            ////    //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理
                                                            // if (format != )
                                                            if (format == 14 || format == 31 || format == 57 || format == 58)
                                                                dataRow[j] = cell.DateCellValue;
                                                            else
                                                                dataRow[j] = cell.NumericCellValue;
                                                            break;

                                                        case CellType.String:
                                                            if (cell.StringCellValue.Equals("#NAME?"))
                                                            {
                                                                dataRow[j] = "";
                                                                continue;
                                                            }
                                                            dataRow[j] = cell.StringCellValue;
                                                            break;
                                                    }
                                                }
                                                catch (Exception e)
                                                {
                                                    if (cell.StringCellValue.Equals("#NAME?"))
                                                    {
                                                        dataRow[j] = "";
                                                        continue;
                                                    }
                                                    dataRow[j] = cell.StringCellValue;
                                                }
                                            }
                                        }
                                        catch
                                        {
                                            continue;
                                        }
                                    }
                                    dataTable.Rows.Add(dataRow);
                                }
                            }
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception e)
            {
                errinfo = e.Message;
                if (fs != null)
                {
                    fs.Close();
                }
                return null;
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


        public static bool checkDir(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        

    }
}
