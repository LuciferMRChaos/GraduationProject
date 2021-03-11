using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

/// <summary>
/// Level4Warning 四级警告
/// </summary>
public class Level4Warning:AttractedWarning
{
    public Level4Warning()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public override int WarningMethod()
    {
        int iResult = 4;
        AdminInfoBusiness Admininfo = new AdminInfoBusiness();
        Admininfo.AdminInfoThreateningLevel(iResult);
        System.Web.HttpContext.Current.Response.Redirect("11AttractedWarning.aspx");
        return iResult;
    }
}