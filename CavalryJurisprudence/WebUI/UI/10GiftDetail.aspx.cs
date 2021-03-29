using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

public partial class _10GiftDetail : System.Web.UI.Page
{
    long lGiftID;
    int iGiftPrice;
    protected void Page_Load(object sender, EventArgs e)
    {
        GiftDetailDisplay();
    }
    private void GiftDetailDisplay()
    {
        lGiftID = long.Parse(Request.QueryString["GiftID"].ToString());
        GiftInfoBusiness GiftDetails = new GiftInfoBusiness();
        GiftInfoEntity GiftDetailsInfo = new GiftInfoEntity();
        if (!IsPostBack)
        {
            GiftDetailsInfo = GiftDetails.GetGiftInfoByID(lGiftID);
            iGiftPrice = GiftDetailsInfo.igiftPrice;
            LBLGiftName.Text = GiftDetailsInfo.sgiftName;
            LBLGiftTips.Text = GiftDetailsInfo.sgiftTips;
            LBLGiftInfo.Text = GiftDetailsInfo.sgiftInfo;
            LBLGiftAmount.Text = GiftDetailsInfo.igiftAmount.ToString();
            LBLGiftPrice.Text = iGiftPrice.ToString();
            IMGGiftImage.ImageUrl = GiftDetailsInfo.sgiftImage;
        }
    }

    protected void BTNGiftPurchase_Click(object sender, EventArgs e)
    {
        UsersLoginDetect();
    }
    private void UsersLoginDetect()
    {
        long lUserID = long.Parse(Session["UsersID"].ToString());
        if (lUserID == 0)
        {
            Response.Write("<script>alert('请先登录!')</script>");
        }
        else if(lUserID % 100 == 67)
        {
            Response.Write("<script>alert('本站律师不得兑换奖品!')</script>");
        }
        else if(lUserID % 100 == 99)
        {
            long lGiftID = long.Parse(Request.QueryString["GiftID"].ToString());
            GiftInfoBusiness GiftDetails = new GiftInfoBusiness();
            GiftInfoEntity GiftDetailsInfo = new GiftInfoEntity();
            GiftDetailsInfo = GiftDetails.GetGiftInfoByID(lGiftID);

            ClientGiftPurchase(GiftDetailsInfo.igiftPrice);
        }
    }
    private void ClientGiftPurchase(int iGiftPrice)
    {
        ClientInfoBusiness ClientRemainPoints = new ClientInfoBusiness();
        ClientInfoEntity ClientInfo = new ClientInfoEntity();
        ClientInfo = ClientRemainPoints.GetClientInfoByID(long.Parse(Session["UsersID"].ToString()));

        if ((long)iGiftPrice - (long)ClientInfo.lclientPoints<0)
        {
            GiftTradeBusiness GiftTrade = new GiftTradeBusiness();
            GiftTrade.ClientGiftPurchase(long.Parse(Request.QueryString["GiftID"].ToString()), long.Parse(Session["UsersID"].ToString()));
            int iReturnValue=ClientRemainPoints.ClientGiftPurchaseByPoints(iGiftPrice, long.Parse(Session["UsersID"].ToString()));
            if (iReturnValue > 0)
            {
                Response.Write("<script>alert('感谢您的兑换！')</script>");
            }
            else
            {
                Response.Write("<script>alert('程序出错，兑换失败！')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('您的剩余积分不足!')</script>");
        }
    }
}