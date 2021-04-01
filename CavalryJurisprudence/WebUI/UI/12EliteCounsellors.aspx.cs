using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class _12EliteCounsellors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EliteCounsellorsInfoDisplay();
    }
    private string[,] EliteCounsellorInfo()
    {
        //从BLL层获取精英律师的数据，包括名字、照片和链接
        CounsellorInfoBusiness EliteCounsellorInfo = new CounsellorInfoBusiness();
        string[,] saXYEliteCounsellorInfo = new string[3, 3];
        saXYEliteCounsellorInfo = EliteCounsellorInfo.EliteCounsellorInfo();
        return saXYEliteCounsellorInfo;
    }
    private void EliteCounsellorsInfoDisplay()
    {
        EliteCounsellorInfo();
        //精英律师姓名
        LBLFirstPlaceElite.Text = EliteCounsellorInfo()[0, 1];
        LBLSecondPlaceElite.Text = EliteCounsellorInfo()[1, 1];
        LBLThirdPlaceElite.Text = EliteCounsellorInfo()[2, 1];
        //精英律师图片
        IMGFirstPlaceElite.ImageUrl = EliteCounsellorInfo()[0, 2];
        IMGSecondPlaceElite.ImageUrl = EliteCounsellorInfo()[1, 2];
        IMGThirdPlaceElite.ImageUrl = EliteCounsellorInfo()[2, 2];
    }

    protected void BTNFirstPlaceElite_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/06CounsellorDetail.aspx?CounsellorID=" + EliteCounsellorInfo()[0, 0]);
    }

    protected void BTNSecondPlaceElite_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/06CounsellorDetail.aspx?CounsellorID=" + EliteCounsellorInfo()[1, 0]);
    }

    protected void BTNThirdPlaceElite_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/06CounsellorDetail.aspx?CounsellorID=" + EliteCounsellorInfo()[2, 0]);
    }
}