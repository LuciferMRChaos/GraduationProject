using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

/// <summary>
/// Level2Warning 二级警告
/// </summary>
public class Level2Warning:AttractedWarning
{
    public Level2Warning()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public override int WarningMethod()
    {
        int iResult = 2;
        AdminInfoBusiness Admininfo = new AdminInfoBusiness();
        Admininfo.AdminInfoThreateningLevel(iResult);
        System.Web.HttpContext.Current.Response.Redirect("0000.aspx");
        return iResult;
    }
}