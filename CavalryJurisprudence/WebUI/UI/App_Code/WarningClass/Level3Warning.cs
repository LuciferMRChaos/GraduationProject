using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
/// <summary>
/// Level3Warning 三级警告
/// </summary>
public class Level3Warning:AttractedWarning
{
    public Level3Warning()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public override int WarningMethod()
    {
        int iResult = 3;
        AdminInfoBusiness Admininfo = new AdminInfoBusiness();
        Admininfo.AdminInfoThreateningLevel(iResult);
        System.Web.HttpContext.Current.Response.Redirect("0000.aspx");
        return iResult;
    }
}