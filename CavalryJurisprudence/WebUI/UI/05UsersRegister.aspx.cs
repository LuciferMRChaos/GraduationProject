using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;

public partial class _06ClientRegister : System.Web.UI.Page
{
    //string sNewFullyClientImagePathAndName;//该变量会在不同方法中用到，所以要使用全局变量
    /**
     * 默认显示两种用户都必须填写的信息
     * 二者不同的都隐藏掉
     * 当进入判断分支时，另一种用户要填写的信息都隐藏掉，只显示自己需要填写的
     */
    string sFullyUsersUploadImagePathAndName;//该变量会在不同方法中用到，所以要使用全局变量
    int iClientDepositingMoney = 0;
    int iClientAge = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        DDLsPageLoadInfo();
        DefaultOptionVisible();
    }

    private void DDLsPageLoadInfo()
    {
        if (!IsPostBack)
        {
            for (iClientDepositingMoney = 0; iClientDepositingMoney < 101; iClientDepositingMoney += 5)//绑定1~x万元
            {
                DDLClientDepositingMoney.Items.Add(iClientDepositingMoney.ToString());
            }
            for (iClientAge = 18; iClientAge < 126; iClientAge++)//绑定18~120岁
            {
                DDLUserAge.Items.Add(iClientAge.ToString());
            }
        }
    }

    private void DefaultOptionVisible()
    {
        //客户隐藏信息
        TBClientAddress.Visible = false;
        LBLClientDepositingMoney.Visible = false;
        LBLClientMoneyDepositingNotice.Visible = false;
        DDLClientDepositingMoney.Visible = false;

        //律师隐藏信息
        LBLCounsellorAdvantageFieldsSelecting.Visible = false;
        LBXCounsellorAdvantageFields.Visible = false;
        BTNAllFieldsSelect.Visible = false;
        LBXCounsellorAdvantageFieldsSelected.Visible = false;
        BTNAllFieldsSelect.Visible = false;
        BTNAllFieldsCancel.Visible = false;
        BTNSingleFieldSelect.Visible = false;
        BTNSingleFieldCancel.Visible = false;
        LBLUserImage.Visible = false;
        FUUserImageUpload.Visible = false;
        LBLCounsellorSelfIntroduction.Visible = false;
        TBCounsellorSelfIntroduction.Visible = false;

        if (RBClientSelected.Checked == true)
        {
            TBClientAddress.Visible = true;
            LBLClientDepositingMoney.Visible = true;
            LBLClientMoneyDepositingNotice.Visible = true;
            DDLClientDepositingMoney.Visible = true;
            LBLUserImage.Visible = true;
            FUUserImageUpload.Visible = true;
        }
        else if (RBCounsellorSelected.Checked == true)
        {
            LBLCounsellorAdvantageFieldsSelecting.Visible = true;
            LBXCounsellorAdvantageFields.Visible = true;
            BTNAllFieldsSelect.Visible = true;
            LBXCounsellorAdvantageFieldsSelected.Visible = true;
            BTNAllFieldsSelect.Visible = true;
            BTNAllFieldsCancel.Visible = true;
            BTNSingleFieldSelect.Visible = true;
            BTNSingleFieldCancel.Visible = true;
            LBLUserImage.Visible = true;
            FUUserImageUpload.Visible = true;
            LBLCounsellorSelfIntroduction.Visible = true;
            TBCounsellorSelfIntroduction.Visible = true;
        }
    }

    protected void BTNAllFieldsSelect_Click(object sender, EventArgs e)
    {
        /**
         * 全部选中
         */
        int iLBXCounsellorAdvantageFieldsCount = LBXCounsellorAdvantageFields.Items.Count;

        for (int iCounter = 0; iCounter < iLBXCounsellorAdvantageFieldsCount; iCounter++)
        {
            ListItem LICounsellorAdvantageFieldsItem = LBXCounsellorAdvantageFields.Items[0];
            LBXCounsellorAdvantageFields.Items.Remove(LICounsellorAdvantageFieldsItem);
            LBXCounsellorAdvantageFieldsSelected.Items.Add(LICounsellorAdvantageFieldsItem);
        }
        if (iLBXCounsellorAdvantageFieldsCount == 0)
        {
            Response.Write("<script>alert('已全部选定！')</script>");
        }
    }

    protected void BTNAllFieldsCancel_Click(object sender, EventArgs e)
    {
        /**
         * 全部取消
         */
        int iLBXCounsellorAdvantageFieldsSelectedCount = LBXCounsellorAdvantageFieldsSelected.Items.Count;
        for (int iCounter = 0; iCounter < iLBXCounsellorAdvantageFieldsSelectedCount; iCounter++)
        {
            ListItem LICounsellorAdvantageFieldsSelected = LBXCounsellorAdvantageFieldsSelected.Items[0];
            LBXCounsellorAdvantageFieldsSelected.Items.Remove(LICounsellorAdvantageFieldsSelected);
            LBXCounsellorAdvantageFields.Items.Add(LICounsellorAdvantageFieldsSelected);
        }
        if (iLBXCounsellorAdvantageFieldsSelectedCount == 0)
        {
            Response.Write("<script>alert('已全部取消！')</script>");
        }
    }

    protected void BTNSingleFieldSelect_Click(object sender, EventArgs e)
    {
        /**
         * 选择单个
         */
        int iCounsellorAdvantageFieldsCount = LBXCounsellorAdvantageFields.Items.Count;
        int iCounsellorAdvantageFieldsIndex = LBXCounsellorAdvantageFields.SelectedIndex;
        if (iCounsellorAdvantageFieldsCount > 0)
        {
            if (iCounsellorAdvantageFieldsIndex >= 0)
            {
                ListItem LICounsellorAdvantageFieldsItem = LBXCounsellorAdvantageFields.SelectedItem;
                LBXCounsellorAdvantageFields.Items.Remove(LICounsellorAdvantageFieldsItem);
                LBXCounsellorAdvantageFieldsSelected.Items.Add(LICounsellorAdvantageFieldsItem);
            }
            else
            {
                Response.Write("<script>alert('请至少选定一个！')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('已全部选定！')</script>");
        }
    }

    protected void BTNSingleFieldCancel_Click(object sender, EventArgs e)
    {
        /**
         * 取消单个
         */
        int iCounsellorAdvantageFieldsSelectedCount = LBXCounsellorAdvantageFieldsSelected.Items.Count;
        int iCounsellorAdvantageFieldsSelectedIndex = LBXCounsellorAdvantageFieldsSelected.SelectedIndex;
        if (iCounsellorAdvantageFieldsSelectedCount > 0)
        {
            ListItem LICounsellorAdvantageFieldsSelectedItem = LBXCounsellorAdvantageFieldsSelected.SelectedItem;
            LBXCounsellorAdvantageFieldsSelected.Items.Remove(LICounsellorAdvantageFieldsSelectedItem);
            LBXCounsellorAdvantageFields.Items.Add(LICounsellorAdvantageFieldsSelectedItem);
        }
        else
        {
            Response.Write("<script>alert('已全部清空！')</script>");
        }
    }

    protected void BTNRegisterConfirm_Click(object sender, EventArgs e)
    {
        if (RBClientSelected.Checked==true||RBCounsellorSelected.Checked==true)
        {
            //如果选择了用户类型，则按下注册键进行注册需要的操作
            UsersInfoInsert();
        }
        else
        {
            Response.Write("<script>alert('请选择您的账户类型！')</script>");
        }
    }

    private void UsersInfoInsert()
    {
        
        long UserID = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));//用户ID的设置
        string UserPassword = TBUserPassword.Text;
        if (RBClientSelected.Checked == true)
        {
            long lClientPhoneNumber = long.Parse(TBUserPhoneNumber.Text);
            ClientInfoBusiness ClientExistJudgement = new ClientInfoBusiness();
            int iClientExitsJudgement = (int)ClientExistJudgement.ClientExistJudgementByClientPhoneNumber(lClientPhoneNumber);
            if (iClientExitsJudgement==0)
            {
                ClientInfoEntity ClientInfo = new ClientInfoEntity();//实例化Entity层客户的信息
                ClientInfo.lclientID = long.Parse(UserID.ToString() + "99");//客户ID详细设置
                ClientInfo.sclientPassword = TBUserPassword.Text;
                ClientInfo.sclientName = TBUserName.Text;
                if (RBUserMale.Checked == true)
                {
                    ClientInfo.sclientSex = "男";
                }
                else if (RBUserFemale.Checked == true)
                {
                    ClientInfo.sclientSex = "女";
                }
                else
                {
                    Response.Write("<script>alert('请务必选择性别！')</script>");
                }

                ClientInfo.iclientAge = int.Parse(DDLUserAge.SelectedValue);
                ClientInfo.sclientEmail = TBUserEmail.Text;
                ClientInfo.lclientPhoneNumber = long.Parse(TBUserPhoneNumber.Text);
                ClientInfo.lclientDepositingMoney = long.Parse(DDLClientDepositingMoney.SelectedValue) * 10000;
                ClientInfo.lclientWallet = 0;
                ClientInfo.lclientTotalDepositedMoney = 0;

                IMGUserImageUpLoad();
                ClientInfo.sclientImage = "WebImages/ClientImages/" + this.sFullyUsersUploadImagePathAndName;

                ClientInfo.sclientAddress = TBClientAddress.Text;
                ClientInfo.lclientPoints = 0;
                ClientInfo.iclientLevel = 1;
                ClientInfoBusiness ClientRegister = new ClientInfoBusiness();
                int iResultJudgement = ClientRegister.ClientInfoRegister(ClientInfo);
                if (iResultJudgement > 0)
                {
                    Session["UsersID"] = long.Parse(UserID.ToString() + "99");
                    Response.Redirect("~/03ClientPersonalCentre.aspx");
                }
                else
                {
                    Response.Write("<script>alert('抱歉，未成功注册！')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('该手机号已注册！')</script>");
            }
        }
        else if(RBCounsellorSelected.Checked == true)
        {
            CounsellorInfoBusiness CounsellorExistInfo = new CounsellorInfoBusiness();
            BlackListInfoBusiness BlackListExistInfo = new BlackListInfoBusiness();
            if((int)CounsellorExistInfo.CounsellorExistJudgementByCounsellorPhoneNumber(long.Parse(TBUserPhoneNumber.Text))!=0)
            {
                Response.Write("<script>alert('抱歉，该手机号已注册')</script>");
            }
            else if ((int)BlackListExistInfo.BlackListExist(long.Parse(TBUserPhoneNumber.Text),TBUserEmail.Text)>0)
            {
                Response.Write("<script>alert('由于您的违规行为，不可注册！')</script>");
            }
            else
            {
                CounsellorInfoEntity CounsellorInfo = new CounsellorInfoEntity();

                CounsellorInfo.lcounsellorID = long.Parse(UserID.ToString() + "67");
                CounsellorInfo.scounsellorPassword = TBUserPassword.Text;
                CounsellorInfo.scounsellorName = TBUserName.Text;
                if (RBUserMale.Checked == true)
                {
                    CounsellorInfo.scounsellorSex = "男";
                }
                else
                {
                    CounsellorInfo.scounsellorSex = "女";
                }
                CounsellorInfo.icounsellorAge = int.Parse(DDLUserAge.SelectedValue);
                CounsellorInfo.scounsellorEmail = TBUserEmail.Text;
                CounsellorInfo.lcounsellorPhoneNumber = long.Parse(TBUserPhoneNumber.Text);
                IMGUserImageUpLoad();
                CounsellorInfo.scounsellorImage = "WebImages/CounsellorImages/" + this.sFullyUsersUploadImagePathAndName;
                CounsellorInfo.scounsellorSelfIntroduction = TBCounsellorSelfIntroduction.Text;
                CounsellorInfo.lcounsellorWallet = 0;
                CounsellorInfo.icounsellorLevel = 0;
                CounsellorInfo.lcounsellorOfferMoney = 0;
                CounsellorInfo.sacounsellorAdvantageField = CounsellorAdvantageFieldsInfo();

                CounsellorInfoBusiness CounsellorInfoRegister = new CounsellorInfoBusiness();

                int iResultJudgement = CounsellorInfoRegister.CounsellorInfoRegister(CounsellorInfo);
                if (iResultJudgement > 0)
                {
                    Session["UsersID"] = long.Parse(UserID.ToString() + "67");
                    Response.Redirect("~/03CounsellorPersonalCentre.aspx");
                }
                else
                {
                    Response.Write("<script>alert('抱歉，未成功注册！')</script>");
                }
            }
        }
    }
    private string[] CounsellorAdvantageFieldsInfo()
    {
        /**
         * 律师擅长领域方法
         * 
         * 将右边的Listbox(即LBXCounsellorAdvantageFieldsSelected)里的值 循环 放入字符串型数组
         * 如果数组中有null，则默认设置为“待定”
         */
        string[] saCounsellorAdvantageFields = new string[8];
        for (int iCounter = 0; iCounter < LBXCounsellorAdvantageFieldsSelected.Items.Count; iCounter++)
        {
            saCounsellorAdvantageFields[iCounter] = LBXCounsellorAdvantageFieldsSelected.Items[iCounter].ToString();
        }
        for(int iCounter = 0; iCounter < saCounsellorAdvantageFields.Length; iCounter++)
        {
            if (saCounsellorAdvantageFields[iCounter] == null)
            {
                saCounsellorAdvantageFields[iCounter] = "待定";
            }
        }
        return saCounsellorAdvantageFields;//返回整个数组
    }

    //多用户图片上传函数：
    private void IMGUserImageUpLoad()
    {
        if (FUUserImageUpload.HasFile)
        {
            string sFUUserUploadImageName = FUUserImageUpload.PostedFile.FileName;//获取文件名字
            int iUserUploadImageNamePointPosition = sFUUserUploadImageName.LastIndexOf(".");//找到文件名中“.”的位置，从1开始
            string sNewImageNameSuffix = sFUUserUploadImageName.Substring(iUserUploadImageNamePointPosition); //以“iNewImageNamePointPositionn”的值作为划分,读取后缀名
            string sSetImageNameByUserName = TBUserName.Text;//通过人名标题为图片命名,来新照片就更新掉
            if(RBClientSelected.Checked == true)
            {
                FUUserImageUpload.SaveAs(Server.MapPath("WebImages/ClientImages/" + sSetImageNameByUserName + sNewImageNameSuffix));
            }
            else
            {
                FUUserImageUpload.SaveAs(Server.MapPath("WebImages/CounsellorImages/" + sSetImageNameByUserName + sNewImageNameSuffix));
            }
            
            sFullyUsersUploadImagePathAndName = sSetImageNameByUserName + sNewImageNameSuffix;//拿到当前完整的文件名
        }
        else
        {
            sFullyUsersUploadImagePathAndName = "测试图片";
        }
    }
}