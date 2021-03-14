using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

public partial class BoardCenter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BoardMemberGreetings();
        BoardMemberInfoDefaultDisplay();
    }
    private void BoardMemberGreetings()
    {
        /**
         * 使用 继承+多态 来实现问候
         */
        int iNowTime = int.Parse(DateTime.Now.ToString("HH"));
        MultipurposeMultiplexingClass UsersGreetingsMethod = new MultipurposeMultiplexingClass();
        UsersGreetingsMethod.UsersGreetingsMethod(iNowTime);
        string sAdminGreetings = UsersGreetingsMethod.UsersGreetingsMethod(iNowTime);
        LBLBoardGreetings.Text = sAdminGreetings;
    }
    private void BoardMemberInfoDefaultDisplay()
    {
        LBLFounderCode.Visible = false;
        long lBoardSequenceID = long.Parse(Session["BoardMemberID"].ToString());

        //LBLBoardGreetings.Text=
        BoardInfoBusiness BoardMemberPersonalInfoDisplay = new BoardInfoBusiness();
        CounsellorInfoEntity BoardMemberPersonalInfo = new CounsellorInfoEntity();
        BoardMemberPersonalInfo = BoardMemberPersonalInfoDisplay.GetBoardPersonInfoByCounsellorID(lBoardSequenceID);
        LBLBoardMemberName.Text = BoardMemberPersonalInfo.scounsellorName;
        if (BoardMemberPersonalInfo.scounsellorSex == "男")
        {
            LBLBoardMemberSex.Text = "先生";
        }
        else if(BoardMemberPersonalInfo.scounsellorSex == "女")
        {
            LBLBoardMemberSex.Text = "女生";
        }
        else
        {
            LBLBoardMemberSex.Text = BoardMemberPersonalInfo.scounsellorSex;
        }

        BoardInfoBusiness BoardInfo = new BoardInfoBusiness();
        long lBoardID = BoardInfo.GetBoardMemberIDBySequence(lBoardSequenceID);

        BoardInfoEntity BoardMemberInfo = new BoardInfoEntity();
        BoardMemberInfo = BoardInfo.GetBoardInfoBySequenceID(lBoardSequenceID);
        LBLBoardSecretKEY.Text = BoardMemberInfo.boardSecretKey;
        LBLBoardSequenceID.Text = BoardMemberInfo.boadrMemberSequenceID.ToString();
        if (!IsPostBack)
        {
            TBBoardPassword.Text = BoardMemberInfo.boardMemberLoginPassword;
        }
        

        if (lBoardID % 100 != 67)
        {
            LBLFounderCode.Visible = true;
            LBLFounderCode.Text = "欢迎您，创始人"+lBoardID.ToString();
        }
        else
        {
            LBLBoardSequenceID.Visible = false;
        }
    }

    protected void GVBoardApplyInfo_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        //先查该董事会成员是否已经投票
        int iJudgementValue = 0;
        long lBoardSequenceID = long.Parse(Session["BoardMemberID"].ToString());
        string sBoardDesitionResult = e.CommandArgument.ToString();
        long lBoardApplyID = long.Parse(sBoardDesitionResult.Substring(0, sBoardDesitionResult.Length - 1));
        BoardInfoBusiness BoardApplyResult = new BoardInfoBusiness();
        int iReturnValue = int.Parse(BoardApplyResult.BoardMemberVotedExistJudgement(lBoardSequenceID, lBoardApplyID).ToString());
        if (iReturnValue>0)
        {
            Response.Write("<script>alert('您已投票！')</script>");
        }
        else
        {
            if (sBoardDesitionResult[sBoardDesitionResult.Length - 1] == 'Y')
            {
                iJudgementValue=BoardApplyResult.BoardApplyResult(lBoardApplyID, lBoardSequenceID, 'Y');
                if (iJudgementValue > 0)
                {
                    Response.Write("<script>alert('赞同票投票成功！')</script>");
                }
            }
            else
            {
                iJudgementValue=BoardApplyResult.BoardApplyResult(lBoardApplyID, lBoardSequenceID, 'N');
                if (iJudgementValue > 0)
                {
                    Response.Write("<script>alert('反对票投票成功！')</script>");
                }
            }
        }
    }

    protected void GVBoardMemberDischarge_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long lBoardSequenceID = long.Parse(Session["BoardMemberID"].ToString());
        long lBEENDischargeBoardMemberID = long.Parse(e.CommandArgument.ToString());
        BoardInfoBusiness BoardInfo = new BoardInfoBusiness();
        int iReturnValue = int.Parse(BoardInfo.BoardMemberDischargeExistJudgement(lBoardSequenceID, lBEENDischargeBoardMemberID).ToString());
        if (iReturnValue>0)
        {
            Response.Write("<script>alert('您已申请开除此成员！')</script>");
        }
        else
        {
            BoardInfo.BoardMemberDischarge(lBoardSequenceID, lBEENDischargeBoardMemberID);
        }
    }

    protected void GVBoardDischargeInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int iJudgementValue = 0;
        long lBoardSequenceID = long.Parse(Session["BoardMemberID"].ToString());

        string sBoardDischargeID = e.CommandArgument.ToString();
        long lBoardDischargeID = long.Parse(sBoardDischargeID.Substring(0, sBoardDischargeID.Length - 1));

        BoardInfoBusiness BoardInfo = new BoardInfoBusiness();
        int iReturnValue = int.Parse(BoardInfo.BoardMemberDischargeVoteExistJudgement(lBoardDischargeID, lBoardSequenceID).ToString());
        if (iReturnValue > 0)
        {
            Response.Write("<script>alert('您已投过票！')</script>");
        }
        else
        {
            if(sBoardDischargeID[sBoardDischargeID.Length - 1] == 'Y')
            {
                iJudgementValue=BoardInfo.BoardMemberDischargeResult(lBoardDischargeID, lBoardSequenceID, "Y");
                if (iJudgementValue > 0)
                {
                    Response.Write("<script>alert('赞同票投票成功！')</script>");
                }
            }
            else
            {
                iJudgementValue=BoardInfo.BoardMemberDischargeResult(lBoardDischargeID, lBoardSequenceID, "N");
                if (iJudgementValue > 0)
                {
                    Response.Write("<script>alert('反对票投票成功！')</script>");
                }
            }
        }
    }

    protected void BTNUpdate_Click(object sender, EventArgs e)
    {
        long lBoardSequenceID = long.Parse(Session["BoardMemberID"].ToString());
        BoardInfoBusiness BoardPasswordUpdate = new BoardInfoBusiness();
        int iReturnValue=(int)BoardPasswordUpdate.BoardMemberLoginPasswordUpdate(TBBoardPassword.Text, lBoardSequenceID);
        if (iReturnValue > 0)
        {
            Response.Write("<script>alert('成功修改密码！')</script>");
        }
        else
        {
            Response.Write("<script>alert('修改密码失败！')</script>");
        }
    }
}