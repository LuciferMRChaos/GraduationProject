using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_Label2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] sa = { "0", "1", "2", "3", "4", "5" };
        for (int i = 0; i < 6; i++)
        {
            //在使用母版页的情况下，为label赋值
            Label lbl_lbl = (Label)this.Master.FindControl("ContentPlaceHolder1").FindControl("Label" + i);
            lbl_lbl.Text = "xxxx" + sa[i];
        }
    }
}