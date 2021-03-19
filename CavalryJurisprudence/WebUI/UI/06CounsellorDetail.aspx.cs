using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;

public partial class CounsellorDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CounsellorDetailInfoDisplay();
    }
    private void CounsellorDetailInfoDisplay()
    {
        long lUsersID = long.Parse(Session["UsersID"].ToString());
        if (lUsersID == 0|| lUsersID % 100 == 67)
        {
            BTNEstablishContract.Visible = false;
        }

        long lCounsellorID = long.Parse(Request.QueryString["CounsellorID"].ToString());
        //long lCounsellorID = 2020110619480567;//测试用
        
        CounsellorInfoBusiness CounsellorInfoBusiness = new CounsellorInfoBusiness();//实体化BLL层中的CounsellorInfoBusiness类
        CounsellorInfoEntity CounsellorInfoEntity = new CounsellorInfoEntity();
        ContractInfoBusiness ContractInfo = new ContractInfoBusiness();
        //最上面的信息
        CounsellorInfoEntity = CounsellorInfoBusiness.GetCounsellorInfoByID(lCounsellorID);
        LBLCounsellorName.Text = CounsellorInfoEntity.scounsellorName;
        LBLCounsellorLevel.Text = CounsellorInfoEntity.icounsellorLevel.ToString();
        IMGCounsellorImage.ImageUrl = CounsellorInfoEntity.scounsellorImage.ToString();
        LBLCounsellorTips.Text = CounsellorInfoEntity.scounsellorSelfIntroduction.ToString();
        LBLCounsellorOfferMoney.Text = CounsellorInfoEntity.lcounsellorOfferMoney.ToString();

        //第一页信息
        LBLCounsellorNamePage1.Text = CounsellorInfoEntity.scounsellorName;
        LBLCounsellorSex.Text = CounsellorInfoEntity.scounsellorSex;
        LBLCounsellorContractAmount.Text = ((int)ContractInfo.CounsellorContractAmount(lCounsellorID)).ToString();
        //第三页信息

        for (int iCounter = 0; iCounter < CounsellorInfoEntity.sacounsellorAdvantageField.Length; iCounter++)
        {
            //循环给Label赋值
            Label LBLCounsellorAdvantageFields = (Label)this.Master.FindControl("ContentPlaceHolder1").FindControl("LBLCounsellorAdvantageField" + iCounter);
            if (CounsellorInfoEntity.sacounsellorAdvantageField[iCounter] == "待定")
            {
                LBLCounsellorAdvantageFields.Visible = false;
            }
            else
            {
                LBLCounsellorAdvantageFields.Text = CounsellorInfoEntity.sacounsellorAdvantageField[iCounter];
            }
            
        }
        //第四页的信息
        LBLCounsellorPhoneNumber.Text = CounsellorInfoEntity.lcounsellorPhoneNumber.ToString();
    }

    protected void BTNEstablishContract_Click(object sender, EventArgs e)
    {
        long lClientID = long.Parse(Session["UsersID"].ToString());
        ClientInfoBusiness GetClientWallet = new ClientInfoBusiness();
        ClientInfoEntity ClientWallet = new ClientInfoEntity();
        ClientWallet = GetClientWallet.GetClientInfoByID(lClientID);


        long lCounsellorID = long.Parse(Request.QueryString["CounsellorID"].ToString());
        CounsellorInfoBusiness CounsellorInfoBusiness = new CounsellorInfoBusiness();//实体化BLL层中的CounsellorInfoBusiness类
        CounsellorInfoEntity CounsellorInfoEntity = new CounsellorInfoEntity();
        CounsellorInfoEntity = CounsellorInfoBusiness.GetCounsellorInfoByID(lCounsellorID);

        ContractInfoBusiness ContractEstablish = new ContractInfoBusiness();

        int iCounsellorContractExistDetect = int.Parse(ContractEstablish.CounsellorContractExistDetect(lClientID).ToString());

        if (iCounsellorContractExistDetect>0)
        {
            Response.Write("<script>alert('您已经与该律师签约！')</script>");
        }
        else
        {
            if (ClientWallet.lclientWallet >= CounsellorInfoEntity.lcounsellorOfferMoney)
            {
                int iContractJudegementValue = ContractEstablish.ContractEstablish(lCounsellorID, lClientID);
                int iClientJudegementValue = GetClientWallet.ClientWalletMoneyUpdate(CounsellorInfoEntity.lcounsellorOfferMoney, lClientID);
                int iCounsellorJudegementValue = CounsellorInfoBusiness.CounsellorWalletMoneyUpdate(lCounsellorID, CounsellorInfoEntity.lcounsellorOfferMoney);
                if (iContractJudegementValue > 0 && iClientJudegementValue > 0 && iCounsellorJudegementValue > 0)
                {
                    Response.Write("<script>alert('您已经成功签约！')</script>");
                }
                else
                {
                    Response.Write("<script>alert('签约失败！')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('您的余额不足以签约！')</script>");
            }
        }

    }
}