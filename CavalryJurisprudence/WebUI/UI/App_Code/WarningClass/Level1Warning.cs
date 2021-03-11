using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

/// <summary>
/// Level1Warning 一级警告
/// </summary>
public class Level1Warning:AttractedWarning
{
    public Level1Warning()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public override int WarningMethod()
    {
        int iResult = 1;
        AdminInfoBusiness Admininfo = new AdminInfoBusiness();
        Admininfo.AdminInfoThreateningLevel(iResult);
        System.Web.HttpContext.Current.Response.Redirect("0000.aspx");
        return iResult;
    }
}