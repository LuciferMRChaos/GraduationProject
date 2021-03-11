using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Data;

public partial class AdminLogin_AdminCenter_AdminCenter : MultipurposeMultiplexingClass
{
    string sNewFullyGiftImagePathAndName;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGreetings();//管理员用户问候函数
        AttractedWarning();
        DefaultDisPlayInfo();
    }
    private void DefaultDisPlayInfo()
    {
        AdminInfoBusiness AdminInfoBusiness = new AdminInfoBusiness();
        AdminInfoEntity AdminInfo = new AdminInfoEntity();
        AdminInfo = AdminInfoBusiness.GetAdminInfoByAdminAccount();
        if (!IsPostBack)
        {
            MultipurposeMultiplexingClass DataEncrypt = new MultipurposeMultiplexingClass();
            TBAdminAccount.Text = AdminInfo.sadminAccount;

            string sDecipherPassword = DataEncrypt.DataDecipherMethod(AdminInfo.saadminPasswords[0]);
            LBLAdminPasswordShow.Text = sDecipherPassword;
        }
    }

    private void AdminGreetings()
    {
        /**
         * 使用 继承+多态 来实现问候
         */
        int iNowTime = int.Parse(DateTime.Now.ToString("HH"));
        MultipurposeMultiplexingClass UsersGreetingsMethod = new MultipurposeMultiplexingClass();
        UsersGreetingsMethod.UsersGreetingsMethod(iNowTime);
        string sAdminGreetings = UsersGreetingsMethod.UsersGreetingsMethod(iNowTime);
        LBLAdminGreetings.Text = sAdminGreetings;
    }

    private void AttractedWarning()
    {
        AdminInfoBusiness AdminInfoBusiness = new AdminInfoBusiness();
        AdminInfoEntity AdminInfo = new AdminInfoEntity();
        AdminInfo = AdminInfoBusiness.GetAdminInfoByAdminAccount();
        if (AdminInfo.iadminInfoHackedThreateningLevel == 1)
        {
            LBLAttractedAlert.Text = "检测到爆破攻击！建议修改密码！";
        }
        else if (AdminInfo.iadminInfoHackedThreateningLevel > 1)
        {
            Response.Redirect("~/11AttractedWarning.aspx");
        }
        else
        {
            LBLAttractedAlert.Visible = false;
        }
    }

    protected void BTNPostQuestion_Click(object sender, EventArgs e)
    {
        AddQuestionInfo();
    }
    private void AddQuestionInfo()
    {
        QuestionInfoBusiness AddQuestion = new QuestionInfoBusiness();
        QuestionInfoEntity QuestionDetail = new QuestionInfoEntity();
        QuestionDetail.squestionField = DDLQuestionFieldsSelecting.SelectedItem.Text;
        QuestionDetail.squestionTitle = TBQuestionTitle.Text;
        QuestionDetail.squestionSelectionA = TBAnswerA.Text;
        QuestionDetail.squestionSelectionB = TBAnwserB.Text;
        QuestionDetail.squestionSelectionC = TBAnswerC.Text;
        QuestionDetail.squestionSelectionD = TBAnswerD.Text;
        QuestionDetail.ccorrectAnswer = char.Parse(DDLCorrectAnswer.SelectedItem.Text);
        QuestionDetail.iquestionLevel = int.Parse(DDLQuestionLevel.SelectedItem.Text);
        int iResultJudgement = AddQuestion.QuestionInfoAdd(QuestionDetail);
        if (iResultJudgement > 0)
        {
            Response.Write("<script>alert('已成功加入问题！')</script>");
        }
        else
        {
            Response.Write("<script>alert('问题加入失败！')</script>");
        }
    }

    protected void BTNAddGift_Click(object sender, EventArgs e)
    {
        AddGiftInfo();
    }
    private void AddGiftInfo()
    {
        GiftInfoEntity GiftInfoDetail = new GiftInfoEntity();
        GiftInfoBusiness GiftInfoAdd = new GiftInfoBusiness();
        GiftInfoDetail.sgiftName = TBGiftName.Text;
        GiftInfoDetail.sgiftTips = TBGiftTips.Text;
        GiftInfoDetail.sgiftInfo = TBGiftInfo.Text;
        GiftInfoDetail.igiftAmount = int.Parse(TBGiftAmount.Text);
        GiftInfoDetail.igiftPrice = int.Parse(TBGiftPrice.Text);
        IMGGiftImageUpdate();
        GiftInfoDetail.sgiftImage = "WebImages/GiftImages/" + this.sNewFullyGiftImagePathAndName;
        int iResultJudgement = GiftInfoAdd.GiftInfoAdd(GiftInfoDetail);
        if (iResultJudgement > 0)
        {
            Response.Write("<script>alert('已成功导入礼品信息！')</script>");
        }
        else
        {
            Response.Write("<script>alert('礼品信息导入失败！')</script>");
        }
    }

    private void IMGGiftImageUpdate()
    {
        if (FUGiftImageUpload.HasFile)
        {
            string sFUGiftImageName = FUGiftImageUpload.PostedFile.FileName;//获取文件名字
            int iNewGiftImageNamePointPosition = sFUGiftImageName.LastIndexOf(".");//找到文件名中“.”的位置，从1开始
            string sNewGiftImageNameSuffix = sFUGiftImageName.Substring(iNewGiftImageNamePointPosition); //以“iNewImageNamePointPositionn”的值作为划分,读取后缀名
            string sRenameNewImageNameByGiftName = TBGiftName.Text;//通过礼物标题为图片命名,来新照片就更新掉
            FUGiftImageUpload.SaveAs(Server.MapPath("WebImages/GiftImages/" + sRenameNewImageNameByGiftName + sNewGiftImageNameSuffix));
            sNewFullyGiftImagePathAndName = sRenameNewImageNameByGiftName + sNewGiftImageNameSuffix;//拿到当前完整的文件名
        }
        else
        {
            sNewFullyGiftImagePathAndName = "N";
        }
    }

    protected void AdminInfoUpdate_Click(object sender, EventArgs e)
    {
        MultipurposeMultiplexingClass DataEncrypt = new MultipurposeMultiplexingClass();
        string sEncryptPassword = DataEncrypt.DataEncryptMethod(TBAdminPassword.Text);


        MultipurposeMultiplexingClass AdminHistoricalPasswordExistDetect = new MultipurposeMultiplexingClass();
        int iResultJudgement = AdminHistoricalPasswordExistDetect.AdminHistoricalPasswordDetect(sEncryptPassword);
        if (iResultJudgement > 0)
        {
            Response.Write("<script>alert('修改失败！存在相同的历史密码')</script>");
        }
        else
        {
            AdminAllInfoUpdate(sEncryptPassword);
        }
    }

    private void AdminAllInfoUpdate(string sEncryptPassword)
    {
        Response.Write("<script>alert('修改成功！')</script>");
        AdminInfoBusiness AdminInfoUpdate = new AdminInfoBusiness();
        AdminInfoEntity AdminInfo = new AdminInfoEntity();
        AdminInfo = AdminInfoUpdate.GetAdminInfoByAdminAccount();
        string sAdminNewAccount = TBAdminAccount.Text + "A";
        if (AdminHistoricalPasswordDetect(sEncryptPassword) == 0)
        {
            string sAdminUsedPassword = AdminInfo.saadminPasswords[0];
            AdminInfoUpdate.AdminPasswordUpdate(sEncryptPassword, sAdminUsedPassword, sAdminNewAccount);
        }
    }

    protected void BTNPostArticle_Click(object sender, EventArgs e)
    {
        ArticleInfoBusiness ArticlePost = new ArticleInfoBusiness();
        ArticleInfoEntity ArticleInfo = new ArticleInfoEntity();
        ArticleInfo.sarticleTitle = TBArticleTitle.Text;
        ArticleInfo.larticleAutherID = 0;
        ArticleInfo.sarticleContent = TBArticleContent.Text;
        ArticleInfo.iarticleReadCount = 0;
        ArticleInfo.iarticleLikedCount = 0;
        ArticleInfo.iarticleDislikedCount = 0;

        int iReturnValue = ArticlePost.ArticleInfoPost(ArticleInfo);
        if (iReturnValue > 0)
        {
            Response.Write("<script>alert('文章发布成功！')</script>");
        }
    }

    protected void BTNDeleteALLSelectedInfo_Click(object sender, EventArgs e)
    {
        if (RBDeleteALLClientInfo.Checked == true)
        {
            Response.Write("<script>alert('已删除全部客户信息！')</script>");
        }
        else if (RBDeleteALLBlackListInfo.Checked == true)
        {
            BlackListInfoBusiness DeleteBlackList = new BlackListInfoBusiness();
            int iReturnValue = DeleteBlackList.DeleteAllBlackListInfo();
            if (iReturnValue > 0)
            {
                Response.Write("<script>alert('已删除全部黑名单信息！')</script>");
            }
        }
        else if (RBDeleteALLGiftInfo.Checked == true)
        {
            GiftInfoBusiness DeleteGift = new GiftInfoBusiness();
            int iReturnValue = DeleteGift.DeleteAllGiftInfo();
            if (iReturnValue > 0)
            {
                Response.Write("<script>alert('已删除全部礼品信息！')</script>");
            }
        }
        else if (RBDeleteALLArticleInfo.Checked == true)
        {
            ArticleInfoBusiness DeleteArticle = new ArticleInfoBusiness();
            int iReturnValue = DeleteArticle.DeleteAllArticleInfo();
            if (iReturnValue > 0)
            {
                Response.Write("<script>alert('已删除全部文章信息！')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('已取消！')</script>");
        }
    }
}