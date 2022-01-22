using System;
using System.Data;
using DevExpress.XtraGrid.Columns;

namespace AppClient.UIS
{
    public class HCUIConllectPorcess
    {
        public static int WriteToTable(EntityDao.Entity.Patient patient,DataTable CollectTable) {
            int rs = EntityDao.imp.Covid.WriteData(patient);
            if (rs == 1)
            {
                DataRow dr = CollectTable.NewRow();
                dr["perName"] = patient.UserName;
                dr["typeName"] = patient.UserCollectType;
                dr["Barcode"] = patient.UserBarcode;
                dr["age"] = patient.UserAge;
                dr["sex"] = patient.UserSex;
                dr["perCertTYpec"] = patient.UserCardType;
                dr["perCertNo"] = patient.UserCardNo;
                dr["Colleter"] = EntityDao.imp.Covid.GetLoginUser();
                dr["perDel"] = patient.UserPhone;
                dr["county"] = "思明区";
                dr["Classification"] = patient.UserJob;
                dr["Subcategory"] = patient.UserSubJob;
                dr["principal"] = patient.UserSendUnit;
                dr["note"] = patient.UserCommand;
                dr["SampleName"] = patient.UserSampleType;
                dr["Unit"] = patient.UserUnit;
                dr["sampTime"] = patient.UserCollectTime;
                dr["CreateTime"] = patient.UserCollectTime;
                dr["CyAddress"] = EntityDao.imp.Covid.GetloginAddress();
                dr["isCool"] = patient.IsCool;
                CollectTable.Rows.Add(dr);
            }
            return rs;
        }

        public static bool InitTables(GridColumnCollection columns,DataTable srctable) {
            try
            {
                srctable.Rows.Clear();
                srctable.Columns.Clear();
                foreach (GridColumn item in columns)
                    srctable.Columns.Add(new DataColumn(item.FieldName));
                return true;
            }
            catch (Exception e) {
               
                return false;
            }            
        }


        public static DataTable PackageAction(DataTable dt) {
            EntityDao.imp.PackSamples pack = new EntityDao.imp.PackSamples();
            return pack.GetPackSamplesAndPackage(dt);
        }


        private static bool isEmpty(DataTable ds) {
            if (ds == null || ds.Rows.Count <= 0)
                return true;
            else
                return false;
        }
      
        
    }
}
