using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class WantedInfoBusiness
    {
        public WantedQuestionDetailsInfoEntity WantedQuestionDetailsInfoByID(long lWanted)//展示悬赏信息方法
        {
            string sSQLText = "select ClientName ,WantedTitle ,WantedBounty , WantedField , WantedContent from ClientInfo, WantedQuestionInfo where ClientID = WantedPromoterID and WantedID = '"+lWanted+"'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);//得到多值
            WantedQuestionDetailsInfoEntity WantedQuestionDetailsInfo = new WantedQuestionDetailsInfoEntity();//实体化Entity层的WantedQuestionDetailsInfoEntity
            if (dataTable.Rows.Count > 0)
            {
                WantedQuestionDetailsInfo.sclientName= "" + dataTable.Rows[0][0];
                WantedQuestionDetailsInfo.swantedTitle = "" + dataTable.Rows[0][1];
                WantedQuestionDetailsInfo.lwantedBounty = long.Parse("" + dataTable.Rows[0][2]);
                WantedQuestionDetailsInfo.swantedField = "" + dataTable.Rows[0][3];
                WantedQuestionDetailsInfo.swantedContent = "" + dataTable.Rows[0][4];
            }
            return WantedQuestionDetailsInfo;
        }

        public object AnswerState(long lWantedID)//查询是否存在满意答案
        {
            string sSQLText = "select count(*) from WantedAnswerInfo,WantedQuestionInfo where SelectedAsAnswer=1 and WantedID='" + lWantedID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public int SetAsAnswer(long lAnswerID)//将目标回答设置为答案
        {
            string sSQLText = "update WantedAnswerInfo set SelectedAsAnswer=1 where AnswerID='" + lAnswerID + "'";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }

        public int RespondLiked(long lAnswerID)//点赞
        {
            string sSQLText = "update WantedAnswerInfo set RespondLikedCount = RespondLikedCount+1 where AnswerID='" + lAnswerID + "'";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }
        public int RespondDisliked(long lAnswerID)//点踩
        {
            string sSQLText = "update WantedAnswerInfo set RespondDislikedCount = RespondDislikedCount+1 where AnswerID='" + lAnswerID + "'";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }

        public long GetWantedPromoterIDByWantedID(long lWantedID)//将目标回答设置为答案
        {
            long lPromoterID=0;
            string sSQLText = "select WantedPromoterID from WantedQuestionInfo where WantedID='"+ lWantedID + "'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);//得到多值
            if (dataTable.Rows.Count > 0)
            {
                lPromoterID = long.Parse("" + dataTable.Rows[0][0]);
            }
            return lPromoterID;
        }

        public int WantedInfoUpdate(string sWantedTitle,string sWantedContent,long lWantedBounty,long lWantedID)//更改悬赏内容
        {
            string sSQLText = "update WantedQuestionInfo set WantedTitle='"+ sWantedTitle + "',WantedContent='"+ sWantedContent + "',WantedBounty='"+ lWantedBounty + "' where WantedID='"+ lWantedID + "'";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }
    }
}
