using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PageLoadDefaultDisplay();
    }

    protected void BTNSearch_Click(object sender, EventArgs e)
    {
        MultipurposeMultiplexingClass OracleSearch = new MultipurposeMultiplexingClass();
        LBLAlert.Text=OracleSearch.Oracle(TBSearch.Text);
    }
    private void PageLoadDefaultDisplay()
    {
        HLLogin.Visible = false;
        HLRegister.Visible = false;
        HLClientPersonalCentre.Visible = false;
        HLCounsellorPersonalCentre.Visible = false;
        long lUserID = long.Parse(Session["UsersID"].ToString());
        if (lUserID == 0)
        {
            HLLogin.Visible = true;
            HLRegister.Visible = true;
            LBQuit.Visible = false;
        }
        else if ((lUserID % 100 == 67))
        {
            HLCounsellorPersonalCentre.Visible = true;
        }
        else if (lUserID % 100 == 99)
        {
            HLClientPersonalCentre.Visible = true;
        }
        else
        {
            HLLogin.Visible = false;
            HLRegister.Visible = false;
        }

    }

    protected void LBQuit_Click(object sender, EventArgs e)
    {
        Session.Clear();
    }
}
