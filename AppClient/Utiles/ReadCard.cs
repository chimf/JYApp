using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AppClient.Utiles.ReadCard;

namespace AppClient.Utiles
{

    public class ReadCard
    {
        #region Api
        [DllImport("Sdtapi.dll")]
        private static extern int InitComm(int iPort);
        [DllImport("Sdtapi.dll")]
        private static extern int Authenticate();
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseInfos(StringBuilder Name, StringBuilder Gender, StringBuilder Folk,
                                                    StringBuilder BirthDay, StringBuilder Code, StringBuilder Address,
                                                        StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd);
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseInfosPhoto(StringBuilder Name, StringBuilder Gender, StringBuilder Folk,
                                                    StringBuilder BirthDay, StringBuilder Code, StringBuilder Address,
                                                        StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd, StringBuilder directory);
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseInfosFPPhoto(StringBuilder Name, StringBuilder Gender, StringBuilder Folk,
                                                    StringBuilder BirthDay, StringBuilder Code, StringBuilder Address,
                                                        StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd, StringBuilder directory, StringBuilder pucFPMsg, ref int puiFPMsgLen);
        [DllImport("Sdtapi.dll")]
        private static extern int Routon_DecideIDCardType();
        [DllImport("Sdtapi.dll")]
        private static extern int Routon_ReadAllForeignBaseInfos(StringBuilder EnName, StringBuilder Gender, StringBuilder Code, StringBuilder Nation, StringBuilder CnName, StringBuilder BirthDay, StringBuilder ExpireStart, StringBuilder ExpireEnd, StringBuilder CardVertion, StringBuilder Agency, StringBuilder CardType, StringBuilder FutureItem);
        [DllImport("Sdtapi.dll")]
        private static extern int Routon_ReadAllGATBaseInfos(StringBuilder Name, StringBuilder Gender, StringBuilder FutureItem1, StringBuilder BirthDay, StringBuilder Address, StringBuilder Code, StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd, StringBuilder PassID, StringBuilder SignCnt, StringBuilder FutureItem2, StringBuilder CardType, StringBuilder FutureItem3);
        [DllImport("Sdtapi.dll")]
        private static extern int CloseComm();
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseMsg(byte[] pMsg, ref int len);
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseMsgW(byte[] pMsg, ref int len);
        [DllImport("Sdtapi.dll")]
        private static extern int Routon_IC_FindCard();
        [DllImport("Sdtapi.dll")]
        private static extern int Routon_IC_HL_ReadCardSN(StringBuilder SN);
        [DllImport("Sdtapi.dll")]
        private static extern int Routon_RepeatRead(bool isRepeat);
        #endregion

        public bool Read(EntityDao.Entity.Patient patient,out string desc) {
            try
            {
                desc = "";
                Routon_RepeatRead(true);
                //打开端口
                int intOpenRet = InitComm(1001);
                if (intOpenRet != 1)
                {
                    desc = "阅读机具未连接";
                    return false;
                }

                //卡认证
                int intReadRet = Authenticate();
                if (intReadRet != 1)
                {
                    desc = "读卡失败，请确认证件是否放置正确或证件是否有效";
                    return false;
                }
                int cardType = Routon_DecideIDCardType();
                if (cardType == 100)//身份证
                {
                    //三种方式读取基本信息
                    //ReadBaseInfos（推荐使用）
                    StringBuilder Name = new StringBuilder(31);
                    StringBuilder Gender = new StringBuilder(3);
                    StringBuilder Folk = new StringBuilder(10);
                    StringBuilder BirthDay = new StringBuilder(9);
                    StringBuilder Code = new StringBuilder(19);
                    StringBuilder Address = new StringBuilder(71);
                    StringBuilder Agency = new StringBuilder(31);
                    StringBuilder ExpireStart = new StringBuilder(9);
                    StringBuilder ExpireEnd = new StringBuilder(9);
                    StringBuilder directory = new StringBuilder(100);
                    StringBuilder pucFPMsg = new StringBuilder(1024);
                    directory.Append("C:\\");
                    int intReadBaseInfosRet = ReadBaseInfos(Name, Gender, Folk, BirthDay, Code, Address, Agency, ExpireStart, ExpireEnd);
                    //int intReadBaseInfosRet = ReadBaseInfosPhoto(Name, Gender, Folk, BirthDay, Code, Address, Agency, ExpireStart, ExpireEnd, directory);
                    //int pucFPMsgLen = 0;
                    //int intReadBaseInfosRet = ReadBaseInfosFPPhoto(Name, Gender, Folk, BirthDay, Code, Address, Agency, ExpireStart, ExpireEnd, directory, pucFPMsg, ref pucFPMsgLen);
                    if (intReadBaseInfosRet != 1)
                    {
                        desc = "读卡失败，请确认证件是否放置正确或证件是否有效";
                        return false;
                    }
                    patient.UserCardNo = Code.ToString();
                    patient.UserCardType = "居民身份证";
                    patient.UserName = Name.ToString();
                    patient.UserSex = Gender.ToString();
                    patient.UserAge = Convert.ToInt32(Agency.ToString());
                }
                else if (cardType == 101)  //外国人居留证
                {
                    StringBuilder Fgn_EnName = new StringBuilder(121); //英文姓名
                    StringBuilder Fgn_Gender = new StringBuilder(3);   //性别
                    StringBuilder Fgn_Code = new StringBuilder(31);    //外国身份证号码
                    StringBuilder Fgn_Nation = new StringBuilder(7);   //国籍
                    StringBuilder Fgn_CnName = new StringBuilder(31);   //中文姓名
                    StringBuilder Fgn_BirthDay = new StringBuilder(16);  //出生日期
                    StringBuilder Fgn_ExpireStart = new StringBuilder(17); //证件有效期起始日期
                    StringBuilder Fgn_ExpireEnd = new StringBuilder(17);  //证件有效期截至日期
                    StringBuilder Fgn_CardVersion = new StringBuilder(5);  //证件版本号信息
                    StringBuilder Fgn_Agency = new StringBuilder(9);  //申请受理机关代码
                    StringBuilder Fgn_CardType = new StringBuilder(3);  //证件类型标识
                    StringBuilder Fgn_FutureItem = new StringBuilder(7);  //预留项信息 暂无意义

                    int FornRet = Routon_ReadAllForeignBaseInfos(Fgn_EnName, Fgn_Gender, Fgn_Code, Fgn_Nation, Fgn_CnName,
                        Fgn_BirthDay, Fgn_ExpireStart, Fgn_ExpireEnd, Fgn_CardVersion, Fgn_Agency, Fgn_CardType, Fgn_FutureItem);
                    if (FornRet != 1)
                    {
                        desc = "读卡失败，请确认证件是否放置正确或证件是否有效";
                        return false;
                    }
                    patient.UserCardNo = Fgn_Code.ToString();
                    patient.UserName = Fgn_CnName.ToString() + " (" + Fgn_EnName.ToString() + ")";
                    patient.UserSex = Fgn_Gender.ToString();
                    patient.UserAge = Convert.ToInt32(Fgn_Agency.ToString());
                    patient.UserCardType = "居民身份证";
                }
                else if (cardType == 102)  //港澳台居住证
                {
                    StringBuilder GAT_Name = new StringBuilder(31);         //姓名
                    StringBuilder GAT_Sex = new StringBuilder(3);           //性别
                    StringBuilder GAT_FutureItem1 = new StringBuilder(5);   //港澳台居住证第一块预留区信息
                    StringBuilder GAT_BirthDay = new StringBuilder(17);     //出生日期
                    StringBuilder GAT_Address = new StringBuilder(71);      //地址
                    StringBuilder GAT_CardNo = new StringBuilder(37);       //证件号码
                    StringBuilder GAT_Agency = new StringBuilder(31);       //签发机关
                    StringBuilder GAT_ExpireStart = new StringBuilder(17);  //证件有效期起始日期
                    StringBuilder GAT_ExpireEnd = new StringBuilder(17);    //证件有效期截至日期
                    StringBuilder GAT_PassCardNo = new StringBuilder(19);   //通行证号码
                    StringBuilder GAT_PassNu = new StringBuilder(5);        //签发次数
                    StringBuilder GAT_FutureItem2 = new StringBuilder(7);   //港澳台居住证第二块预留区信息
                    StringBuilder GAT_CardType = new StringBuilder(3);      //证件类型标识
                    StringBuilder GAT_FutureItem3 = new StringBuilder(7);   //港澳台居住证第三块预留区信息

                    int GATRet = Routon_ReadAllGATBaseInfos(GAT_Name, GAT_Sex, GAT_FutureItem1, GAT_BirthDay, GAT_Address, GAT_CardNo,
                        GAT_Agency, GAT_ExpireStart, GAT_ExpireEnd, GAT_PassCardNo, GAT_PassNu, GAT_FutureItem2, GAT_CardType, GAT_FutureItem3);
                    if (GATRet != 1)
                    {
                        desc = "读卡失败，请确认证件是否放置正确或证件是否有效";
                        return false;
                    }
                    patient.UserCardNo = GAT_CardNo.ToString();
                    patient.UserName = GAT_Name.ToString();
                    patient.UserSex = GAT_Sex.ToString();
                    patient.UserAge = Convert.ToInt32(GAT_Agency.ToString());
                    patient.UserCardType = "港澳居民来往内地通行证";
                }
                return true;
            }
            catch (Exception E)
            {
                if (E.Message.Contains(".dll"))
                    desc = "未能加载卡具读卡驱动，请联系管理员将对应的卡具驱动文件拷贝到当前程序文件夹下即可！具体驱动如下：\n"+E.Message;
                else
                    desc = E.Message;
                return false;
            }
            finally {
                try
                {
                    CloseComm();
                }
                catch { }
            }
        }

    }

}
