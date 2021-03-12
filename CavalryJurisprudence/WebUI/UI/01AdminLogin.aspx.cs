using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

public partial class AdminLogin_AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BTNLogin_Click(object sender, EventArgs e)
    {
        /**
         *本界面实现的功能：
         *1.实现了对于管理人员用户类型的判断，从而实现了单登录页面，多用户登录
         *2.实现了基本的登录功能，比如账户、密码判断
         */
        AdministratorAccountClassificationJudgement();
    }

    private void AdministratorAccountClassificationJudgement()
    {
        /**
         * 用户类别判断算法
         * 
         * 以名称后面的【A】或【66】来区分是 【管理员】或【董事会】
         */
        int iInputStringJudgement = 0;
        string sAdministratorAccount = TBAdministratorAccount.Text.ToString();//获取前台传来的【账户】信息
        for (int iCounter = 0; iCounter < sAdministratorAccount.Length; iCounter++)
        {
            if (sAdministratorAccount[iCounter] <= 0 || sAdministratorAccount[iCounter] > 9)
            {
                iInputStringJudgement++;
            }
            else
            {
                iInputStringJudgement = 0;
            }
        }
        string sClassificationJudgementJudgeString = sAdministratorAccount.Substring(sAdministratorAccount.Length - 1, 1);//取最后一个字符以验证

        if (sClassificationJudgementJudgeString == 'A'.ToString() || sClassificationJudgementJudgeString == 'a'.ToString())
        {
            AdminLogin();//转到管理员登录函数
        }
        else if (sClassificationJudgementJudgeString == "6" && iInputStringJudgement > 0)
        {
            BoardLogin();//转到董事会成员登陆函数
        }
        else
        {
            Response.Write("<script>alert('信息不存在！！')</script>");
        }
    }
    private void AdminLogin()
    {
        /**
         * 查询是否存在 管理员
         */
        string sPasswordReceive = TBAdministratorPassword.Text;

        AdminInfoBusiness GetAdminInfo = new AdminInfoBusiness();
        AdminInfoEntity AdminInfo = new AdminInfoEntity();
        AdminInfo = GetAdminInfo.GetAdminInfoByAdminAccount();

        int iReturnValue = (int)GetAdminInfo.AdminExistJudgementByAdminAccount(TBAdministratorAccount.Text);
        if (iReturnValue > 0)
        {
            MultipurposeMultiplexingClass DataEncrypt = new MultipurposeMultiplexingClass();
            string sEncryptPassword = DataEncrypt.DataEncryptMethod(TBAdministratorPassword.Text);

            string sAdminPassword = AdminInfo.saadminPasswords[0];
            MultipurposeMultiplexingClass AttractedWarningLevel = new MultipurposeMultiplexingClass();
            int iReturnLevel = AttractedWarningLevel.SimilarityDetect(sEncryptPassword, sAdminPassword);//相似度检测算法，用以防止爆破攻击

            if (iReturnLevel == 100)
            {
                Response.Redirect("~/01AdminCentre.aspx");
            }
            else
            {
                Response.Redirect("~/0000.aspx");
            }
        }
        else
        {
            Response.Redirect("~/0000.aspx");
        }
    }
    private void BoardLogin()
    {
        /**
         * 查询是否存在 董事会成员
         * 
         */
        BoardInfoBusiness BoardLogin = new BoardInfoBusiness();
        int iJudgementValue = (int)BoardLogin.BoardExistJudgement(long.Parse(TBAdministratorAccount.Text), TBAdministratorPassword.Text);
        if (iJudgementValue > 0)
        {
            Session["BoardMemberID"] = TBAdministratorAccount.Text;
            Response.Redirect("~/02BoardCentre.aspx");
        }
        else
        {
            Response.Redirect("~/0000.aspx");
        }
    }
}