using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;

public partial class CounsellorResume : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CounsellorInfoDisplayPage();
    }
    private void CounsellorInfoDisplayPage()
    {
        long lCounsellorID = long.Parse(Request.QueryString["CounsellorID"].ToString());
        CounsellorInfoBusiness CounsellorInfoBusiness = new CounsellorInfoBusiness();//实体化BLL层中的CounsellorInfoBusiness类
        CounsellorInfoEntity CounsellorInfoDetails= new CounsellorInfoEntity();

        CounsellorInfoDetails = CounsellorInfoBusiness.GetCounsellorResumeInfoByID(lCounsellorID);
        
        IMGCounsellorImage.ImageUrl = CounsellorInfoDetails.scounsellorImage;
        LBLCounsellorName.Text = CounsellorInfoDetails.scounsellorName;
        LBLCounsellorSex.Text = CounsellorInfoDetails.scounsellorSex;
        LBLCounsellorAge.Text = CounsellorInfoDetails.icounsellorAge.ToString();
        LBLCounsellorEmail.Text = CounsellorInfoDetails.scounsellorEmail;
        LBLCounsellorPhoneNumber.Text = CounsellorInfoDetails.lcounsellorPhoneNumber.ToString();
        LBLCounsellorSelfIntroduction.Text = CounsellorInfoDetails.scounsellorSelfIntroduction;
        LBLCounsellorWallet.Text = CounsellorInfoDetails.lcounsellorWallet.ToString();

        string[] saCounsellorAdvantageFields = new string[8];
        saCounsellorAdvantageFields = CounsellorInfoDetails.sacounsellorAdvantageField;

        StringBuilder CounsellorAdvantageFields = new StringBuilder();

        for(int iCounter = 0; iCounter < 8; iCounter++)
        {
            CounsellorAdvantageFields.Append(saCounsellorAdvantageFields[iCounter]+",");
        }

        string sCounsellorAdvantageFields = CounsellorAdvantageFields.ToString();
        LBLCounsellorAdvantageFields.Text = sCounsellorAdvantageFields;

        long lBoardMemberSequenceID = long.Parse(Session["UsersID"].ToString());
        BoardInfoBusiness BoardInfo = new BoardInfoBusiness();

        int iJudgementValue = (int)BoardInfo.ApplySelectionJudgement(lBoardMemberSequenceID);
        if (iJudgementValue > 0)
        {
            LBLVote.Text = "您已投票！";
            BTNAgree.Visible = false;
            BTNRefuse.Visible = false;
        }
        else
        {
            LBLVote.Visible = false;
        }
        long lBoardApplyID;
        lBoardApplyID = BoardInfo.GetBoardApplyIDByCounsellorID(lCounsellorID);

        BoardInfoBusiness GetResultAmount = new BoardInfoBusiness();//显示投票数
        LBLAgreeCount.Text=GetResultAmount.BoardApplyAgreeAmount(lBoardApplyID).ToString();
        LBLRefuseCount.Text = GetResultAmount.BoardApplyRefuseAmount(lBoardApplyID).ToString();
    }

    protected void BTNAgree_Click(object sender, EventArgs e)
    {
        long lCounsellorID = long.Parse(Request.QueryString["CounsellorID"].ToString());
        long lBoardMemberSequenceID = long.Parse(Session["UsersID"].ToString());
        long lBoardApplyID;
        BoardInfoBusiness BoardInfo = new BoardInfoBusiness();
        lBoardApplyID = BoardInfo.GetBoardApplyIDByCounsellorID(lCounsellorID);

        int iReturnValue=BoardInfo.BoardApplyConfirm(lBoardApplyID, lBoardMemberSequenceID, 'Y');

        if (iReturnValue > 0)
        {
            Response.Write("<script>alert('投票成功！')</script>");
        }
    }

    protected void BTNRefuse_Click(object sender, EventArgs e)
    {
        long lCounsellorID = long.Parse(Request.QueryString["CounsellorID"].ToString());
        long lBoardMemberSequenceID = long.Parse(Session["UsersID"].ToString());
        long lBoardApplyID;
        BoardInfoBusiness BoardInfo = new BoardInfoBusiness();
        lBoardApplyID = BoardInfo.GetBoardApplyIDByCounsellorID(lCounsellorID);

        int iReturnValue = BoardInfo.BoardApplyDeny(lBoardApplyID, lBoardMemberSequenceID, 'N');

        if (iReturnValue > 0)
        {
            Response.Write("<script>alert('投票成功！')</script>");
        }
    }
}