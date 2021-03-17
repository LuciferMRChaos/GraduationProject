using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class UsersLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BTNConfirm_Click(object sender, EventArgs e)
    {
        UsersAccountClassificationJudgement();
    }

    private void UsersAccountClassificationJudgement()
    {
        long iUsersAccount = long.Parse(TBUsersAccount.Text.ToString());
        long iJudgeNumber = iUsersAccount % 100;
        /**
         * 以字母c的ASCII码作为区分
         * 大写C的ASCII码为67，是律师；小写的ASCII码为99，是客户
         */
        if (iJudgeNumber == 99)//先直接看后缀，若不符合基本的两种用户直接弹出
        {
            ClientLoginJudgement();
        }
        else if (iJudgeNumber == 67)
        {
            CounsellorLoginJudgement();
        }
        else
        {
            Response.Write("<script>alert('信息有误！请检查后再次输入！')</script>");
        }
    }

    private void ClientLoginJudgement()
    {
        /**
         * 功能：查询是否存在客户
         */
        ClientInfoBusiness ClientExistJudgement = new ClientInfoBusiness();
        if ((int)ClientExistJudgement.ClientExistJudgementByClientID(long.Parse(TBUsersAccount.Text)) > 0)
        {
            if ((int)ClientExistJudgement.ClientExistJudgementByClientPassword(TBUsersPassword.Text) > 0)
            {
                Session["UsersID"] = TBUsersAccount.Text;
                Response.Redirect("~/03ClientPersonalCentre.aspx");
            }
            else
            {
                Response.Write("<script>alert('客户密码有误！')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('客户账号有误！')</script>");
        }
    }
    private void CounsellorLoginJudgement()
    {
        /**
         * 功能：查询是否存在律师
         */
        CounsellorInfoBusiness CounsellorExistJudgement = new CounsellorInfoBusiness();
        if ((int)CounsellorExistJudgement.CounsellorExistJudgementByCounsellorID(long.Parse(TBUsersAccount.Text)) > 0)
        {
            if ((int)CounsellorExistJudgement.CounsellorExistJudgementByCounsellorPassword(TBUsersPassword.Text) > 0)
            {
                Session["UsersID"] = TBUsersAccount.Text;
                Response.Redirect("~/03CounsellorPersonalCentre.aspx");
            }
            else
            {
                Response.Write("<script>alert('律师密码有误！')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('律师账号有误！')</script>");
        }
    }

    protected void BTNPasswordReset_Click(object sender, EventArgs e)
    {
        ClientInfoBusiness ClientInfo = new ClientInfoBusiness();
        CounsellorInfoBusiness CounsellorInfo = new CounsellorInfoBusiness();
        long lClientID = ClientInfo.ClientPasswordResetJudgementByClientEmailAndPhoneNumber(TBUsersEmail.Text, long.Parse(TBUsersPhoneNumber.Text));
        long lCounsellorID = CounsellorInfo.CounsellorPasswordResetJudgementByCounsellorEmailAndPhoneNumber(TBUsersEmail.Text, long.Parse(TBUsersPhoneNumber.Text));
        if(lClientID > 0|| lCounsellorID > 0)
        {
            if(lClientID > 0)
            {
                int iClientReturnValue = ClientInfo.ClientPasswordReset(TBUsersNewPassword.Text,lClientID);
                if (iClientReturnValue > 0)
                {
                    Response.Write("<script>alert('您的密码重置成功！')</script>");
                }
            }
            else if(lCounsellorID > 0)
            {
                int iCounsellorReturnValue = CounsellorInfo.CounsellorPasswordReset(TBUsersNewPassword.Text, lCounsellorID);
                if (iCounsellorReturnValue > 0)
                {
                    Response.Write("<script>alert('您的密码重置成功！')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script>alert('信息错误！')</script>");
        }
    }
}