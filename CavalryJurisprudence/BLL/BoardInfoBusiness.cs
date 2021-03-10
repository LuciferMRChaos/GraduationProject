using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Entity;


namespace BLL
{
    public class BoardInfoBusiness
    {
        public int BoardApply(long lCounsellorID,string sStandbySecretKEY)//董事会递交加入申请方法
        {
            string sSQLText = "insert into BoardApplyInfo values('"+ lCounsellorID + "','"+ sStandbySecretKEY + "')";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public object CounsellorApplyExistJudgement(long lCounsellorID)//判断律师是否已经提交了申请
        {
            string SQLText = "select count(*) from BoardApplyInfo where CounsellorID='"+ lCounsellorID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(SQLText);
            return ReturnValue;
        }

        public object GetAllBoardMemberAmount()//判断董事会数量方法
        {
            string SQLText = "select count(*) from BoardInfo";
            object ReturnValue = DataBaseAccess.GetOneData(SQLText);
            return ReturnValue;
        }
        public object BoardKeyExistJudgement(string BoardSecretKey)//判断密钥是否存在方法
        {
            string sSQLText = "select count(*) from BoardInfo where BoardSecretKey='"+ BoardSecretKey + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public object BoardExistJudgement(long lBoardMemberSequenceID,string sBoardPassword)//判断账户密码是否存在
        {
            string SQLText = "select count(*) from BoardInfo where BoardMemberSequenceID='"+ lBoardMemberSequenceID + "' and BoardMemberLoginPassword='"+ sBoardPassword + "'";
            object ReturnValue = DataBaseAccess.GetOneData(SQLText);
            return ReturnValue;
        }

        public long GetBoardApplyIDByCounsellorID(long lCounsellorID)//通过律师ID查找BoardApplyID
        {
            long lBoardApplyID;
            string sSQLText = "select BoardApplyID from BoardApplyInfo where CounsellorID='"+ lCounsellorID + "'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);
            lBoardApplyID= long.Parse("" + dataTable.Rows[0][0]);
            return lBoardApplyID;
        }

        public int BoardApplyResult(long lBoardApplyID,long lBoardMemberSequenceID,char sResult)//投票同意
        {
            string sSQLText = "insert into BoardApplyResult values('"+ lBoardApplyID + "','"+ lBoardMemberSequenceID + "','"+ sResult + "')";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public object ApplySelectionJudgement(long lBoardMemberSequenceID)//判断董事会成员是否已经投票
        {
            string SQLText = "select count(*) from BoardApplyResult where BoardMemberSequenceID='"+ lBoardMemberSequenceID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(SQLText);
            return ReturnValue;
        }

        public long GetBoardMemberIDBySequence(long lBoardSequenceID)//通过SequenceID查找身份ID
        {
            long lBoardMemberID;
            string sSQLText = "select BoardMemberIDfromCounsellor from BoardInfo where BoardMemberSequenceID='"+ lBoardSequenceID + "'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);
            lBoardMemberID = long.Parse("" + dataTable.Rows[0][0]);
            return lBoardMemberID;
        }

        public object BoardApplyAgreeAmount(long BoardApplyID)//计算同意票
        {
            string sSQLText = "select count(*) from BoardApplyResult where BoardApplyID='" + BoardApplyID + "' and Result='Y'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public object BoardApplyRefuseAmount(long BoardApplyID)//计算拒绝票
        {
            string sSQLText = "select count(*) from BoardApplyResult where BoardApplyID='" + BoardApplyID + "' and Result='N'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public object BoardMemberVotedExistJudgement(long lBoardMemberSequenceID,long lBoardApplyID)//判断密钥是否存在方法
        {
            string sSQLText = "select count(*) from BoardApplyResult where BoardMemberSequenceID='"+ lBoardMemberSequenceID + "' and BoardApplyID='"+ lBoardApplyID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public object BoardMemberDischargeExistJudgement(long lDischargeApplicantID, long lBEENDischargedBoardID)//判断是否存在于开除申请表中
        {
            string sSQLText = "select count(*) from BoardMemberDischargeInfo where DischargeApplicantID='"+ lDischargeApplicantID + "' and BEENDischargedBoardID='"+ lBEENDischargedBoardID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public int BoardMemberDischarge(long lDischargeApplicantID, long lBEENDischargeBoardID)//董事会成员申请开除方法
        {
            string sSQLText = "insert into BoardMemberDischargeInfo values('"+ lDischargeApplicantID + "','"+ lBEENDischargeBoardID + "')";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public object BoardMemberDischargeVoteExistJudgement(long lBoardDischargeID, long lBoardSequenceID)//判断是否存在于开除结果表中
        {
            string sSQLText = " select count(*) from BoardMemberDischargeResult where BoardDischargeID='"+ lBoardDischargeID + "' and BoardApplicantID='"+ lBoardSequenceID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public int BoardMemberDischargeResult(long lDischargeID, long lDischargeApplicantID,string sResult)//董事会成员开除结果方法
        {
            string sSQLText = "insert into BoardMemberDischargeResult values('"+ lDischargeID + "','"+ lDischargeApplicantID + "','"+ sResult + "')";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public object BoardExistJudgement(long lBoardMemberIDfromCounsellor)//查看是否存在于董事会
        {
            string sSQLText = "select COUNT(*) from BoardInfo where BoardMemberIDfromCounsellor ='"+ lBoardMemberIDfromCounsellor + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public BoardInfoEntity GetBoardInfoByCounsellorID(long lBoardMemberIDfromCounsellor)//通过律师ID展示董事会成员全部信息方法
        {
            string sSQLText = "select * from BoardInfo where BoardMemberIDfromCounsellor ='"+ lBoardMemberIDfromCounsellor + "'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);
            BoardInfoEntity BoardInfo = new BoardInfoEntity();
            if (dataTable.Rows.Count > 0)
            {
                BoardInfo.boadrMemberSequenceID = long.Parse("" + dataTable.Rows[0][0]);
                BoardInfo.boardMemberIDfromCounsellor = long.Parse("" + dataTable.Rows[0][1]);
                BoardInfo.boardSecretKey = "" + dataTable.Rows[0][2];
                BoardInfo.founderIdentityJudgement = "" + dataTable.Rows[0][3];
                BoardInfo.boardMemberLoginPassword = "" + dataTable.Rows[0][4];
            }
            return BoardInfo;
        }

        public CounsellorInfoEntity GetBoardPersonInfoByCounsellorID(long lBoardMemberSequenceID)//通过董事会成员ID展示董事会成员姓名与性别方法
        {
            string sSQLText = "select CounsellorName,CounsellorSex from CounsellorInfo where CounsellorID=(select BoardMemberIDfromCounsellor from BoardInfo where BoardMemberSequenceID ='"+ lBoardMemberSequenceID + "')";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);
            CounsellorInfoEntity BoardMemberPersonalInfo = new CounsellorInfoEntity();
            if (dataTable.Rows.Count > 0)
            {
                BoardMemberPersonalInfo.scounsellorName = "" + dataTable.Rows[0][0];
                BoardMemberPersonalInfo.scounsellorSex = "" + dataTable.Rows[0][1];
            }
            return BoardMemberPersonalInfo;
        }

        public int BoardMemberLoginPasswordUpdate(string sBoardMemberLoginPassword,long lBoardMemberSequenceID)//董事会成员修改密码
        {
            string sSQLText = "update BoardInfo set BoardMemberLoginPassword='"+ sBoardMemberLoginPassword + "' where BoardMemberSequenceID='"+ lBoardMemberSequenceID + "'";
            int iReturnedValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public BoardInfoEntity GetBoardInfoBySequenceID(long lBoardMemberSequenceID)//通过董事会ID展示董事会成员全部信息方法
        {
            string sSQLText = "select * from BoardInfo where BoardMemberSequenceID ='" + lBoardMemberSequenceID + "'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);
            BoardInfoEntity BoardInfo = new BoardInfoEntity();
            if (dataTable.Rows.Count > 0)
            {
                BoardInfo.boadrMemberSequenceID = long.Parse("" + dataTable.Rows[0][0]);
                BoardInfo.boardMemberIDfromCounsellor = long.Parse("" + dataTable.Rows[0][1]);
                BoardInfo.boardSecretKey = "" + dataTable.Rows[0][2];
                BoardInfo.founderIdentityJudgement = "" + dataTable.Rows[0][3];
                BoardInfo.boardMemberLoginPassword = "" + dataTable.Rows[0][4];
            }
            return BoardInfo;
        }
    }
}
