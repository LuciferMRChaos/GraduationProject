using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;
using DAL;
using System.Data;
using System.Data.SqlClient;

public partial class _11AttractedWarning : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LBLWarningContent.Text = "系统检测到爆破攻击，请务必修改密码";
        AttractedWarningDefaultDisplay();
        if (!IsPostBack)
        {
            ViewState["KEYsStorageArray"] = "";
            ViewState["SuccessTimes"] = 0;
            LBLTest.Text = ViewState["SuccessTimes"].ToString();
        }
    }

    private void AttractedWarningDefaultDisplay()
    {
        LBLWarningContent.Text = "管理员账户遭到爆破攻击！请立即修改相关信息！";
        AdminInfoBusiness AdminInfoBusiness = new AdminInfoBusiness();
        AdminInfoEntity AdminInfo = new AdminInfoEntity();
        AdminInfo = AdminInfoBusiness.GetAdminInfoByAdminAccount();

        if (AdminInfo.iadminInfoHackedThreateningLevel == 2)
        {
            LBLWarningLevel.Text = "二级警告！";
            LBLSolution.Visible = false;
            TBBoardKey.Visible = false;
        }
        else if (AdminInfo.iadminInfoHackedThreateningLevel == 3)
        {

            LBLWarningLevel.Text = "三级警告！";
            LBLSolution.Text = "请通知任一董事会成员输入密钥以解锁";
            TBResetAccount.Visible = false;
            TBResetPassword.Visible = false;
            TBResetPasswordConfirm.Visible = false;
        }
        else if (AdminInfo.iadminInfoHackedThreateningLevel == 4)
        {
            LBLWarningLevel.Text = "四级警告！";
            LBLWarningContent.Text = "本网站正遭受攻击，为保证您的数据安全，我们务必暂时封锁网站，给您带来的不便还请谅解";
            LBLSolution.Text = "请通知全部董事会成员输入密钥以解锁";
            TBResetAccount.Visible = false;
            TBResetPassword.Visible = false;
            TBResetPasswordConfirm.Visible = false;
        }
    }

    protected void BTNAdminInfoResetConfirm_Click(object sender, EventArgs e)
    {
        /**
         * 根据需求，Click产生不同状态
         */

        AdminInfoBusiness AdminInfoBusiness = new AdminInfoBusiness();
        AdminInfoEntity AdminInfo = new AdminInfoEntity();
        AdminInfo = AdminInfoBusiness.GetAdminInfoByAdminAccount();
        if (AdminInfo.iadminInfoHackedThreateningLevel == 3)
        {
            BoardInfoBusiness BoardInfoBusiness = new BoardInfoBusiness();
            if ((int)BoardInfoBusiness.BoardKeyExistJudgement(TBBoardKey.Text)>0)
            {
                LBLSolution.Text = "请重置管理员的信息";
                TBBoardKey.Visible = false;
                TBResetAccount.Visible = true;
                TBResetPassword.Visible = true;
                TBResetPasswordConfirm.Visible = true;
            }
            else
            {
                LBLWarningLevel.Text = "三级警告！";
                LBLSolution.Text = "请通知任一董事会成员输入密钥以解锁";
                TBResetAccount.Visible = false;
                TBResetPassword.Visible = false;
                TBResetPasswordConfirm.Visible = false;
            }
        }

        else if (AdminInfo.iadminInfoHackedThreateningLevel == 4)
        {
            BoardInfoBusiness BoardInfoBusiness = new BoardInfoBusiness();
            int iBoardMemberAmount = int.Parse(BoardInfoBusiness.GetAllBoardMemberAmount().ToString());

            BoardKeyMethod(TBBoardKey.Text, iBoardMemberAmount);

            if (int.Parse(ViewState["SuccessTimes"].ToString()) < iBoardMemberAmount)
            {
                LBLWarningLevel.Text = "四级警告！";
                LBLSolution.Text = "请通知任一董事会成员输入密钥以解锁";
                TBBoardKey.Visible = true;
                TBResetAccount.Visible = false;
                TBResetPassword.Visible = false;
                TBResetPasswordConfirm.Visible = false;
            }
            else if (int.Parse(ViewState["SuccessTimes"].ToString()) == iBoardMemberAmount)
            {
                LBLSolution.Text = "请立即重置管理员的信息";
                TBBoardKey.Visible = false;
                TBResetAccount.Visible = true;
                TBResetPassword.Visible = true;
                TBResetPasswordConfirm.Visible = true;
            }
            LBLTest.Text = ViewState["SuccessTimes"].ToString();
        }
    }

    private void BoardKeyMethod(string sInputBoardKey, int iBoardMemberAmount)
    {
        BoardInfoBusiness BoardInfoBusiness = new BoardInfoBusiness();
        
        int iExistKeyCounter = 0;
        if ((int)BoardInfoBusiness.BoardKeyExistJudgement(sInputBoardKey) > 0)//输入的密钥存在
        {
            string[] sa = ViewState["KEYsStorageArray"].ToString().Split(new char[] { ',' });
            for(int iCounter = 0; iCounter < sa.Length; iCounter++)
            {
                if (sInputBoardKey == sa[iCounter])
                {
                    iExistKeyCounter++;
                }
            }
            if (iExistKeyCounter == 0)
            {
                ViewState["SuccessTimes"] = (int)ViewState["SuccessTimes"] + 1;
                ViewState["KEYsStorageArray"] = ViewState["KEYsStorageArray"] + sInputBoardKey+",";
            }
        }
    }
}