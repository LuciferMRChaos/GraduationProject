using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_warning : MultipurposeMultiplexingClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string receive = TextBox1.Text;
        string test = "asdfghjkl";//此字符串应该从数据库：Admin中的【密码】中提取

        MultipurposeMultiplexingClass MM = new MultipurposeMultiplexingClass();
        
        Label1.Text= MM.SimilarityDetect(receive, test).ToString();
    }
}