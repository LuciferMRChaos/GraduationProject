using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class CompanyInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CompanyInfoBusiness GetCompanyInfo = new BLL.CompanyInfoBusiness();
        LBLClientAmount.Text = GetCompanyInfo.GetAllClientAmount().ToString();
        LBLCounsellorAmount.Text = GetCompanyInfo.GetAllCounsellorAmount().ToString();
    }
}