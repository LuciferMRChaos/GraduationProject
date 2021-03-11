using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _00Default_Default : System.Web.UI.Page
{
    private static int CountNumber = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            CountNumber = 0;
        }
    }

    protected void BTN2ManagersLogin_Click(object sender, EventArgs e)
    {
        Click2HiddenPage();
    }

    public void Click2HiddenPage()
    {
        CountNumber++;
        if (CountNumber >= 5)
        {
            Response.Redirect("01AdminLogin.aspx");
        }
    }
}