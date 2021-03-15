using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientPersonalCentre : MultipurposeMultiplexingClass
{
    string sNewFullyClientImagePathAndName;//该变量会在不同方法中用到，所以要使用全局变量
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientGreetings();//客户问候函数
        ClientInfoDisplayPage();//展示客户信息
    }
    private void ClientGreetings()
    {
        /**
         * 使用继承来实现问候
         */
        int iNowTime = int.Parse(DateTime.Now.ToString("HH"));
        MultipurposeMultiplexingClass UsersGreetingsMethod = new MultipurposeMultiplexingClass();
        UsersGreetingsMethod.UsersGreetingsMethod(iNowTime);
        string sClientGreetings = UsersGreetingsMethod.UsersGreetingsMethod(iNowTime);
        LBLClientGreetings.Text = sClientGreetings;
    }

    private void ClientInfoDisplayPage()
    {
        /**
         * 展示客户的一些信息
         */
        int iClientAge;
        int iClientDepositingMoney;
        long lClientID = long.Parse(Session["UsersID"].ToString());//接收Login页面传来的Session
        ClientInfoBusiness ClientInfoBusiness = new ClientInfoBusiness();//实体化BLL层中的ClientInfoBusiness类
        ClientInfoEntity ClientInfoEntity = new ClientInfoEntity();
        if (!IsPostBack)
        {
            ClientInfoEntity = ClientInfoBusiness.GetClientInfoByID(lClientID);

            if (ClientInfoEntity.sclientSex == "男")
            {

                LBLClientSexPolitely.Text = "先生";
            }
            else
            {
                LBLClientSexPolitely.Text = "女士";
            }

            LBLClientID.Text = ClientInfoEntity.lclientID.ToString();
            TBClientPassword.Text = ClientInfoEntity.sclientPassword;
            LBLClientNameGreeting.Text = ClientInfoEntity.sclientName;
            TBClientName.Text = ClientInfoEntity.sclientName;
            if (ClientInfoEntity.sclientSex == "男")
            {
                RBMale.Checked = true;
            }
            else
            {
                RBFemale.Checked = true;
            }

            for (iClientAge = 18; iClientAge < 126; iClientAge++)//绑定18~120岁
            {
                DDLClientAge.Items.Add(iClientAge.ToString());
            }
            DDLClientAge.SelectedValue= ClientInfoEntity.iclientAge.ToString();
            TBClientEmail.Text = ClientInfoEntity.sclientEmail;
            TBClientPhoneNumber.Text = ClientInfoEntity.lclientPhoneNumber.ToString();

            for (iClientDepositingMoney = 0; iClientDepositingMoney < 101; iClientDepositingMoney+=5)//绑定1~x万元
            {
                DDLClientDepositingMoney.Items.Add(iClientDepositingMoney.ToString());
            }

            LBLClientWallet.Text = ClientInfoEntity.lclientWallet.ToString();
            IMGClientImage.ImageUrl = ClientInfoEntity.sclientImage;
            TBClientAddress.Text = ClientInfoEntity.sclientAddress;
            LBLClientPoints.Text = ClientInfoEntity.lclientPoints.ToString();
            LBLClientLevel.Text = ClientInfoEntity.iclientLevel.ToString();

            for (int iWantedOfferMoney = 5; iWantedOfferMoney < 101; iWantedOfferMoney += 5)//绑定1~x万元
            {//悬赏金额
                DDLWantedOfferMoney.Items.Add(iWantedOfferMoney.ToString());
            }
        }
    }
    protected void BTNClientInfoUpdateConfirm_Click(object sender, EventArgs e)
    {
        ClientInfoUpdate();
    }
    private void ClientInfoUpdate()
    {
        ClientInfoBusiness ClientInfoUpdate = new ClientInfoBusiness();
        string sNewClientSex;
        if (RBMale.Checked == true)
        {
            sNewClientSex = "男";
        }
        else
        {
            sNewClientSex = "女";
        }
        IMGClientImageUpdate();
        string sClientUpdateImagePath = "WebImages/ClientImages/" + this.sNewFullyClientImagePathAndName;
        int iResultJudgement = 0;
        if (this.sNewFullyClientImagePathAndName.Substring(this.sNewFullyClientImagePathAndName.Length-1,1)!="N")
        {
            //如果上传图片，则更新图片路径
            iResultJudgement=ClientInfoUpdate.ClientInfoUpdate(TBClientPassword.Text.ToString(), TBClientName.Text.ToString(), sNewClientSex, int.Parse(DDLClientAge.SelectedValue), TBClientEmail.Text, long.Parse(TBClientPhoneNumber.Text), long.Parse(DDLClientDepositingMoney.SelectedValue) * 10000, sClientUpdateImagePath, TBClientAddress.Text.ToString(), long.Parse(Session["ClientID"].ToString()));
            if (iResultJudgement > 0)
            {
                Response.Write("<script>alert('信息已修改！')</script>");
            }
            else
            {
                Response.Write("<script>alert('信息未修改！')</script>");
            }
        }
        else
        {
            //如果未上传图片，则不更新图片路径
            iResultJudgement = ClientInfoUpdate.ClientInfoUpdate(TBClientPassword.Text.ToString(), TBClientName.Text.ToString(), sNewClientSex, int.Parse(DDLClientAge.SelectedValue), TBClientEmail.Text, long.Parse(TBClientPhoneNumber.Text), long.Parse(DDLClientDepositingMoney.SelectedValue) * 10000, TBClientAddress.Text.ToString(), long.Parse(Session["ClientID"].ToString()));
            if (iResultJudgement > 0)
            {
                Response.Write("<script>alert('信息已修改！')</script>");
            }
            else
            {
                Response.Write("<script>alert('信息未修改！')</script>");
            }
        }
    }
    private void IMGClientImageUpdate()
    {
        if (FUClientImageUpload.HasFile)
        {
                string sFUClientNewImageName = FUClientImageUpload.PostedFile.FileName;//获取文件名字
                int iNewImageNamePointPosition = sFUClientNewImageName.LastIndexOf(".");//找到文件名中“.”的位置，从1开始
                string sNewImageNameSuffix = sFUClientNewImageName.Substring(iNewImageNamePointPosition); //以“iNewImageNamePointPositionn”的值作为划分,读取后缀名
                string sRenameNewImageNameByClientName = TBClientName.Text;//通过人名标题为图片命名,来新照片就更新掉
                FUClientImageUpload.SaveAs(Server.MapPath("WebImages/ClientImages/" + sRenameNewImageNameByClientName + sNewImageNameSuffix));
                sNewFullyClientImagePathAndName = sRenameNewImageNameByClientName + sNewImageNameSuffix;//拿到当前完整的文件名
        }
        else
        {
            sNewFullyClientImagePathAndName = "N";
        }
    }

    protected void BTNClientAccountDestory_Click(object sender, EventArgs e)
    {
        ClientInfoBusiness ClientAccountDestory = new ClientInfoBusiness();
        int iResultJudgement = ClientAccountDestory.DeleteClientInfoByClientID(long.Parse(Session["ClientID"].ToString()));
        if (iResultJudgement > 0)
        {
            Response.Write("<script>alert('信息已成功注销，希望您的再次光临！')</script>");
        }
        else
        {
            Response.Write("<script>alert('注销失败！请联系管理人员！')</script>");
        }
    }
}