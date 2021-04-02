using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_Xiangsidu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string a = TextBox1.Text;
        string b = TextBox2.Text;
        MultipurposeMultiplexingClass warning = new MultipurposeMultiplexingClass();
        
        Label1.Text= warning.SimilarityDetect(a, b).ToString();
    }
}