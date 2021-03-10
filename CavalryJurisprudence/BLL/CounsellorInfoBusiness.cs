using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class CounsellorInfoBusiness
    {
        public int CounsellorInfoRegister(CounsellorInfoEntity CounsellorInfo)//律师信息注册方法
        {
            string sSQLText = "insert into CounsellorInfo values('"+CounsellorInfo.lcounsellorID+"','"+CounsellorInfo.scounsellorPassword+"','"+ CounsellorInfo .scounsellorName+ "','"+CounsellorInfo.scounsellorSex+"','"+CounsellorInfo.icounsellorAge+"','"+CounsellorInfo.scounsellorEmail+"','"+CounsellorInfo.lcounsellorPhoneNumber+"','"+CounsellorInfo.scounsellorImage+"','"+CounsellorInfo.scounsellorSelfIntroduction+"','"+CounsellorInfo.lcounsellorWallet+"','"+CounsellorInfo.icounsellorLevel+"','"+CounsellorInfo.lcounsellorOfferMoney+"','"+CounsellorInfo.sacounsellorAdvantageField[0]+ "','" + CounsellorInfo.sacounsellorAdvantageField[1] + "','" + CounsellorInfo.sacounsellorAdvantageField[2] + "','" + CounsellorInfo.sacounsellorAdvantageField[3] + "','" + CounsellorInfo.sacounsellorAdvantageField[4] + "','" + CounsellorInfo.sacounsellorAdvantageField[5] + "','" + CounsellorInfo.sacounsellorAdvantageField[6] + "','" + CounsellorInfo.sacounsellorAdvantageField[7] + "')";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public object CounsellorExistJudgementByCounsellorPhoneNumber(long lCounsellorPhoneNumber)//判断律师是否存在方法
        {
            string sSQLText = "select count(*) from CounsellorInfo where CounsellorPhoneNumber='"+ lCounsellorPhoneNumber + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public object CounsellorExistJudgementByCounsellorID(long lCounsellorID)//判断律师是否存在方法
        {
            string sSQLText = "select count(*) from CounsellorInfo where CounsellorID='" + lCounsellorID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public object CounsellorExistJudgementByCounsellorPassword(string sCounsellorPassword)//判断律师密码是否正确方法
        {
            string sSQLText = "select count(*) from CounsellorInfo where CounsellorPassword='" + sCounsellorPassword + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public CounsellorInfoEntity GetCounsellorInfoByID(long lCounsellorID)//展示律师全部信息方法
        {
            string sSQLText = "select * from CounsellorInfo where CounsellorID='" + lCounsellorID + "'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);//返回多值
            CounsellorInfoEntity CounsellorInfo = new CounsellorInfoEntity();
            if (dataTable.Rows.Count > 0)
            {
                CounsellorInfo.lcounsellorID = long.Parse("" + dataTable.Rows[0][0]);
                CounsellorInfo.scounsellorPassword = "" + dataTable.Rows[0][1];
                CounsellorInfo.scounsellorName = "" + dataTable.Rows[0][2];
                CounsellorInfo.scounsellorSex = "" + dataTable.Rows[0][3];
                CounsellorInfo.icounsellorAge = int.Parse("" + dataTable.Rows[0][4]);
                CounsellorInfo.scounsellorEmail = "" + dataTable.Rows[0][5];
                CounsellorInfo.lcounsellorPhoneNumber = long.Parse("" + dataTable.Rows[0][6]);
                CounsellorInfo.scounsellorImage = "" + dataTable.Rows[0][7];
                CounsellorInfo.scounsellorSelfIntroduction = "" + dataTable.Rows[0][8];
                CounsellorInfo.lcounsellorWallet = long.Parse("" + dataTable.Rows[0][9]);
                CounsellorInfo.icounsellorLevel = int.Parse("" + dataTable.Rows[0][10]);
                CounsellorInfo.lcounsellorOfferMoney = long.Parse("" + dataTable.Rows[0][11]);
                for(int iCounter = 12; iCounter < 20; iCounter++)
                {
                    CounsellorInfo.sacounsellorAdvantageField[iCounter-12] = "" + dataTable.Rows[0][iCounter];
                }
            }
            return CounsellorInfo;
        }

        public CounsellorInfoEntity GetCounsellorResumeInfoByID(long lCounsellorID)//展示律师全部信息方法
        {
            string sSQLText = "select CounsellorInfo.CounsellorID,CounsellorImage,CounsellorName,CounsellorSex,CounsellorAge,CounsellorEmail,CounsellorPhoneNumber,CounsellorSelfIntroduction,CounsellorWallet,CounsellorAdvantageField1,CounsellorAdvantageField2,CounsellorAdvantageField3,CounsellorAdvantageField4,CounsellorAdvantageField5,CounsellorAdvantageField6,CounsellorAdvantageField7,CounsellorAdvantageField8 from BoardApplyInfo,CounsellorInfo where BoardApplyInfo.CounsellorID=CounsellorInfo.CounsellorID and CounsellorInfo.CounsellorID='" + lCounsellorID+"'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);//返回多值
            CounsellorInfoEntity CounsellorInfo = new CounsellorInfoEntity();
            if (dataTable.Rows.Count > 0)
            {
                CounsellorInfo.lcounsellorID = long.Parse("" + dataTable.Rows[0][0]);
                CounsellorInfo.scounsellorImage= "" + dataTable.Rows[0][1];
                CounsellorInfo.scounsellorName = "" + dataTable.Rows[0][2];
                CounsellorInfo.scounsellorSex = "" + dataTable.Rows[0][3];
                CounsellorInfo.icounsellorAge = int.Parse("" + dataTable.Rows[0][4]);
                CounsellorInfo.scounsellorEmail = "" + dataTable.Rows[0][5];
                CounsellorInfo.lcounsellorPhoneNumber = long.Parse("" + dataTable.Rows[0][6]);
                CounsellorInfo.scounsellorSelfIntroduction = "" + dataTable.Rows[0][7];
                CounsellorInfo.lcounsellorWallet = long.Parse("" + dataTable.Rows[0][8]);
                for (int iCounter = 9; iCounter < 17; iCounter++)
                {
                    CounsellorInfo.sacounsellorAdvantageField[iCounter - 9] = "" + dataTable.Rows[0][iCounter];
                }
            }
            return CounsellorInfo;
        }

        public int CounsellorInfoUpdate(string sCounsellorPassword,string sCounsellorName,string sCounsellorSex,int iCounsellorAge,string sCounsellorEmail,string sCounsellorImage,string[] saCounsellorAdvantageFieldsUpdate, long lCounsellorID)
        {
            //律师信息升级方法
            string sSQLText = "update CounsellorInfo set CounsellorPassword='"+sCounsellorPassword+"',CounsellorName='"+sCounsellorName+"',CounsellorSex='"+sCounsellorSex+"',CounsellorAge='"+iCounsellorAge+"',CounsellorEmail='"+sCounsellorEmail+"',CounsellorImage='"+sCounsellorImage+"',CounsellorAdvantageField1='"+ saCounsellorAdvantageFieldsUpdate[0]+ "',CounsellorAdvantageField2='" + saCounsellorAdvantageFieldsUpdate[1] + "',CounsellorAdvantageField3='" + saCounsellorAdvantageFieldsUpdate[2] + "',CounsellorAdvantageField4='" + saCounsellorAdvantageFieldsUpdate[3] + "',CounsellorAdvantageField5='" + saCounsellorAdvantageFieldsUpdate[4] + "',CounsellorAdvantageField6='" + saCounsellorAdvantageFieldsUpdate[5] + "',CounsellorAdvantageField7='" + saCounsellorAdvantageFieldsUpdate[6] + "',CounsellorAdvantageField8='" + saCounsellorAdvantageFieldsUpdate[7] + "' where CounsellorID='"+ lCounsellorID + "'";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }
        public int CounsellorInfoUpdate(string sCounsellorPassword, string sCounsellorName, string sCounsellorSex, int iCounsellorAge, string sCounsellorEmail, string[] saCounsellorAdvantageFieldsUpdate, long lCounsellorID)
        {
            //律师信息升级方法——重载，以防止律师照片信息被不慎抹掉
            string sSQLText = "update CounsellorInfo set CounsellorPassword='" + sCounsellorPassword + "',CounsellorName='" + sCounsellorName + "',CounsellorSex='" + sCounsellorSex + "',CounsellorAge='" + iCounsellorAge + "',CounsellorEmail='" + sCounsellorEmail + "',CounsellorAdvantageField1='" + saCounsellorAdvantageFieldsUpdate[0] + "',CounsellorAdvantageField2='" + saCounsellorAdvantageFieldsUpdate[1] + "',CounsellorAdvantageField3='" + saCounsellorAdvantageFieldsUpdate[2] + "',CounsellorAdvantageField4='" + saCounsellorAdvantageFieldsUpdate[3] + "',CounsellorAdvantageField5='" + saCounsellorAdvantageFieldsUpdate[4] + "',CounsellorAdvantageField6='" + saCounsellorAdvantageFieldsUpdate[5] + "',CounsellorAdvantageField7='" + saCounsellorAdvantageFieldsUpdate[6] + "',CounsellorAdvantageField8='" + saCounsellorAdvantageFieldsUpdate[7] + "' where CounsellorID='"+ lCounsellorID + "'";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }

        public object CounsellorArticleLikedAmount(long lCounsellorID)//文章好评数
        {
            string sSQLText = "select sum(ArticleLikedCount) from ArticleInfo where ArticleAuthorID='"+ lCounsellorID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }
        public object CounsellorArticleDislikedAmount(long lCounsellorID)//文章差评数
        {
            string sSQLText = "select sum(ArticleDislikedCount) from ArticleInfo where ArticleAuthorID='"+ lCounsellorID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }
        public object CounsellorRespondLikedCountAmount(long lCounsellorID)//回答好评数
        {
            string sSQLText = "select sum(RespondLikedCount) from WantedAnswerInfo where ResponderIDFromCounsellorInfo='"+ lCounsellorID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }
        public object CounsellorRespondDislikedCountAmount(long lCounsellorID)//回答差评数
        {
            string sSQLText = "select sum(RespondDislikedCount) from WantedAnswerInfo where ResponderIDFromCounsellorInfo='" + lCounsellorID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public int CounsellorLevelUpdate(long lCounsellorID)
        {
            //律师等级升级方法
            string sSQLText = "update CounsellorInfo set CounsellorLevel=CounsellorLevel+1 where CounsellorID='"+ lCounsellorID + "'";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }
        
        public int CounsellorWalletMoneyUpdate(long lCounsellorID,long lCounsellorWalletMoney)
        {
            //律师钱包升级方法
            string sSQLText = "update CounsellorInfo set CounsellorWallet=CounsellorWallet+'"+ lCounsellorWalletMoney + "' where CounsellorID='" + lCounsellorID + "'";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }

        public long GetCounsellorIDByAnswerID(long lAnswerID)
        {
            string sSQLText = "select CounsellorID from WantedAnswerInfo,CounsellorInfo where WantedAnswerInfo.ResponderIDFromCounsellorInfo = CounsellorInfo.CounsellorID and AnswerID ='"+lAnswerID+"' ";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);
            long lCounsellorID = 0;
            if (dataTable.Rows.Count > 0)
            {
                lCounsellorID = long.Parse("" + dataTable.Rows[0][0]);
            }
            return lCounsellorID;
        }

        public long CounsellorPasswordResetJudgementByCounsellorEmailAndPhoneNumber(string sCounsellorEmial, long lCounsellorPhoneNumber)//律师密码重置判断方法
        {
            string sSQLText = "select CounsellorID from CounsellorInfo where CounsellorEmail='"+ sCounsellorEmial + "' and CounsellorPhoneNumber='"+ lCounsellorPhoneNumber + "'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);
            long lCounsellorID= 0;
            if (dataTable.Rows.Count > 0)
            {
                lCounsellorID = long.Parse("" + dataTable.Rows[0][0]);
            }
            return lCounsellorID;
        }

        public int CounsellorPasswordReset(string sCounsellorPassword,long lCounsellorID)//律师密码更新
        {
            string sSQLText = "update CounsellorInfo set CounsellorPassword='"+ sCounsellorPassword + "' where CounsellorID='"+ lCounsellorID + "'";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public string[,] EliteCounsellorInfo()//展示精英律师信息方法
        {
            string sSQLText = "select CounsellorID,CounsellorName,CounsellorImage from CounsellorInfo where CounsellorID in(select TOP 10 ResponderIDFromCounsellorInfo from WantedAnswerInfo,CounsellorInfo,ArticleInfo where ResponderIDFromCounsellorInfo = CounsellorID and ResponderIDFromCounsellorInfo = ArticleAuthorID and ArticleAuthorID = CounsellorID group by ResponderIDFromCounsellorInfo order by(SUM(RespondLikedCount) + SUM(ArticleLikedCount)) - (SUM(RespondDislikedCount) + SUM(ArticleDislikedCount)) DESC)";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);//返回多值
            string[,] saXYEliteCounsellorInfo = new string[3,3];
            if (dataTable.Rows.Count > 0)
            {//二维数组,先全存string型，
                for(int iCounterX = 0; iCounterX < 3; iCounterX++)
                {
                    for(int iCounterY = 0; iCounterY < 3; iCounterY++)
                    {
                        saXYEliteCounsellorInfo[iCounterX, iCounterY] = "" + dataTable.Rows[iCounterX][iCounterY];
                    }
                }
            }
            return saXYEliteCounsellorInfo;
        }
    }
}
