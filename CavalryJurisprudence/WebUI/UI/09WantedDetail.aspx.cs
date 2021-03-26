using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

public partial class _09WantedDetail : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        WantedPromoterDefaultInfoDisplay();
    }

    private void WantedPromoterDefaultInfoDisplay()
    {
        long lWantedID = long.Parse(Request.QueryString["WantedID"].ToString());//接收Wantedlist传来的ID
        WantedInfoBusiness WantedQuestionDetailsInfoSearch = new WantedInfoBusiness();
        WantedQuestionDetailsInfoEntity WantedQuestionInfo = new WantedQuestionDetailsInfoEntity();

        long UsersID = long.Parse(Session["UsersID"].ToString());
        TBWantedTitle.ReadOnly = true;
        TBWantedContent.ReadOnly = true;
        DDLWantedBounty.Enabled = false;
        TBReply.Visible = false;
        BTNReply.Visible = false;
        BTNWantedInfoUpdate.Visible = false;
        if (UsersID % 100 == 67)
        {//如果是律师登录
            TBReply.Visible = true;
            BTNReply.Visible = true;
        }
        else if(UsersID % 100 == 99)
        {
            //附加：如果是当前问题的提问人,则可以修改悬赏的信息
            long lPromoterID = WantedQuestionDetailsInfoSearch.GetWantedPromoterIDByWantedID(lWantedID);
            if (UsersID == lPromoterID)
            {
                TBWantedTitle.ReadOnly = false;
                TBWantedContent.ReadOnly = false;
                DDLWantedBounty.Enabled = true;
                BTNWantedInfoUpdate.Visible = true;
            }
            TBReply.Visible = false;
            BTNReply.Visible = false;
        }
        else
        {
            //游客登录
        }

        if (!IsPostBack)
        {
            WantedQuestionInfo = WantedQuestionDetailsInfoSearch.WantedQuestionDetailsInfoByID(lWantedID);
            LBLClientName.Text = WantedQuestionInfo.sclientName;
            TBWantedContent.Text = WantedQuestionInfo.swantedContent;
            DDLWantedBounty.SelectedValue = (WantedQuestionInfo.lwantedBounty / 10000).ToString();

            TBWantedTitle.Text = WantedQuestionInfo.swantedTitle;
            LBLWantedField.Text = WantedQuestionInfo.swantedField;

            for (long iWantedBounty = WantedQuestionInfo.lwantedBounty / 10000; iWantedBounty < 101; iWantedBounty += 5)//绑定1~x万元
            {
                DDLWantedBounty.Items.Add(iWantedBounty.ToString());
            }
        }
        
        
    }
    
    protected void DLWantedAnswerInfo_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Button BTNSelectAsAnswer = (Button)e.Item.FindControl("BTNSelectAsAnswer");
        Label LBLAnswerID = (Label)e.Item.FindControl("LBLAnswerID");
        WantedInfoBusiness SetTargetAsAnswer = new WantedInfoBusiness();
        int iReturnedValue = 0;
        if (e.CommandName== "BTNSelectAsAnswer")
        {
            //当客户登录时，若没有选定的答案，则点击后可设置最佳答案
            iReturnedValue = SetTargetAsAnswer.SetAsAnswer(long.Parse(LBLAnswerID.Text));
            if (iReturnedValue > 0)
            {
                long lWantedID = long.Parse(Request.QueryString["WantedID"].ToString());
                CounsellorInfoBusiness CounsellorInfo = new CounsellorInfoBusiness();
                ClientInfoBusiness ClientInfo = new ClientInfoBusiness();

                long lCounsellorID = CounsellorInfo.GetCounsellorIDByAnswerID(long.Parse(LBLAnswerID.Text));
                long lClientID = ClientInfo.GetClientIDByWantedID(lWantedID);

                WantedInfoBusiness WantedQuestionDetailsInfoSearch = new WantedInfoBusiness();
                WantedQuestionDetailsInfoEntity WantedQuestionInfo = new WantedQuestionDetailsInfoEntity();
                WantedQuestionInfo = WantedQuestionDetailsInfoSearch.WantedQuestionDetailsInfoByID(lWantedID);
                long lBountyMoney= WantedQuestionInfo.lwantedBounty;
                LBLWantedField.Text = lBountyMoney.ToString();
                ClientInfo.ClientWantedBountyMoney(lBountyMoney, lClientID);
                CounsellorInfo.CounsellorWalletMoneyUpdate(lCounsellorID, lBountyMoney);

                Response.Write("<script>alert('成功设置为答案！')</script>");
            }
            else
            {
                Response.Write("<script>alert('设置为答案失败！')</script>");
            }
        }
        /**
         * 任何身份都可以点赞，包括游客
         */
        else if(e.CommandName== "BTNRespondLikedCount")
        {
            //点了点赞后，让点赞数+1
            iReturnedValue = SetTargetAsAnswer.RespondLiked(long.Parse(LBLAnswerID.Text));
            if (iReturnedValue > 0)
            {
                Response.Write("<script>alert('您赞了此答案！')</script>");
            }
            else
            {
                Response.Write("<script>alert('点赞失败！！')</script>");
            }
        }
        else if(e.CommandName== "BTNRespondDislikedCount")
        { //点了点踩后，让点踩数+1
            iReturnedValue = SetTargetAsAnswer.RespondDisliked(long.Parse(LBLAnswerID.Text));
            if (iReturnedValue > 0)
            {
                Response.Write("<script>alert('您踩了此答案！')</script>");
            }
            else
            {
                Response.Write("<script>alert('点踩失败！')</script>");
            }
        }
    }

    protected void DLWantedAnswerInfo_ItemCreated(object sender, DataListItemEventArgs e)
    {
        long lWantedID = long.Parse(Request.QueryString["WantedID"].ToString());
        Button BTNSelectAsAnswer = (Button)e.Item.FindControl("BTNSelectAsAnswer");

        WantedInfoBusiness AnswerAmount = new WantedInfoBusiness();
        int iResultJudgement = int.Parse(AnswerAmount.AnswerState(lWantedID).ToString());

        long UsersID = long.Parse(Session["UsersID"].ToString());
        if (iResultJudgement > 0||UsersID % 100 != 99)
        {
            BTNSelectAsAnswer.Visible = false;
        }
    }

    protected void BTNWantedInfoUpdate_Click(object sender, EventArgs e)
    {
        long lWantedID = long.Parse(Request.QueryString["WantedID"].ToString());

        WantedInfoBusiness WantedInfoUpdate = new WantedInfoBusiness();

        string sWantedTitle = TBWantedTitle.Text;
        string sWantedCountent = TBWantedContent.Text;
        long lWantedBounty = long.Parse(DDLWantedBounty.SelectedValue)*10000;


        int iResultJudgement = WantedInfoUpdate.WantedInfoUpdate(sWantedTitle, sWantedCountent, lWantedBounty,lWantedID);

        if (iResultJudgement > 0)
        {
            Response.Write("<script>alert('您已成功修改问题！')</script>");
        }
    }
}