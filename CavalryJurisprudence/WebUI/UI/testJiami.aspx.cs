using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string s = TextBox1.Text;
        MultipurposeMultiplexingClass DataEncrypt = new MultipurposeMultiplexingClass();


        Label1.Text = DataEncrypt.DataEncryptMethod(s);
        Label2.Text = DataEncrypt.DataDecipherMethod(DataEncrypt.DataEncryptMethod(s));
        Label3.Text = DataEncrypt.DataEncryptMethod(s).Length.ToString();
        TextBox2.Text= DataEncrypt.DataDecipherMethod(DataEncrypt.DataEncryptMethod(s));
    }
}