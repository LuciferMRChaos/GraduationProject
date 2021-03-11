using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

public partial class _0000 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /**
         * 最开始的网页
         * 侦测admin被攻击的状态
         * 如果达到4级，直接打到攻击警告页面重置
         */

        Session["UsersID"] = 0;
        long lJudgementValue = 0L;

        AdminInfoBusiness AdminInfoBusiness = new AdminInfoBusiness();
        
        AdminInfoEntity ThreateningLevel = new AdminInfoEntity();
        ThreateningLevel = AdminInfoBusiness.GetAdminInfoByAdminAccount();
        lJudgementValue = ThreateningLevel.iadminInfoHackedThreateningLevel;

        if (lJudgementValue != 4)
        {
            Response.Redirect("~/00Default.aspx");
        }
        else if(lJudgementValue == 4)
        {
            AttractedWarning AttractedWarningSolution4 = new Level4Warning();
            AttractedWarningSolution4.WarningMethod();
        }
    }
}