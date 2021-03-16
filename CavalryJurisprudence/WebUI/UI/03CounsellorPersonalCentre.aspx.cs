using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;

public partial class CounsellorPersonCentre : MultipurposeMultiplexingClass
{
    string sNewFullyCounsellorImagePathAndName;//该变量会在不同方法中用到，所以要使用全局变量

    static int iQuestionID;
    protected void Page_Load(object sender, EventArgs e)
    {
        CounsellorGreetings();//律师问候函数
        CounsellorInfoDisplayPage();//律师信息展示函数
    }

    private void CounsellorGreetings()
    {
        /**
         * 使用继承来实现问候
         */
        int iNowTime = int.Parse(DateTime.Now.ToString("HH"));
        MultipurposeMultiplexingClass UsersGreetingsMethod = new MultipurposeMultiplexingClass();
        UsersGreetingsMethod.UsersGreetingsMethod(iNowTime);
        string sClientGreetings = UsersGreetingsMethod.UsersGreetingsMethod(iNowTime);
        LBLCounsellorGreetings.Text = sClientGreetings;
    }
    private void CounsellorInfoDisplayPage()
    {
        string[] saDefaultCounsellorAdvantageFields = { "刑法·盗窃罪共犯问题", "刑法·贪污贿赂问题", "刑事诉讼法", "民法·合同问题", "民法·知识产权", "婚姻继承问题", "民法·侵权责任问题", "民法·抵押担保问题" };//默认全部擅长领域
        int iCounsellorAge;
        long lCounsellorID= long.Parse(Session["UsersID"].ToString());

        LBLBoardSequenceID.Visible = false;
        LBLBoardPassword.Visible = false;


        CounsellorInfoBusiness CounsellorInfoBusiness = new CounsellorInfoBusiness();//实体化BLL层中的CounsellorInfoBusiness类
        CounsellorInfoEntity CounsellorInfoEntity = new CounsellorInfoEntity();
        if (!IsPostBack)
        {
            CounsellorInfoEntity = CounsellorInfoBusiness.GetCounsellorInfoByID(lCounsellorID);
            string[] saCounsellorAdvantageFields = new string[8];
            IMGCounsellorImageDisplay.ImageUrl = CounsellorInfoEntity.scounsellorImage;
            LBLCounsellorName.Text = CounsellorInfoEntity.scounsellorName;
            LBLCounsellorID.Text = CounsellorInfoEntity.lcounsellorID.ToString();
            TBCounsellorPassword.Text = CounsellorInfoEntity.scounsellorPassword.ToString();
            TBCounsellorName.Text = CounsellorInfoEntity.scounsellorName;
            if (CounsellorInfoEntity.scounsellorSex == "男")
            {
                RBMale.Checked = true;
            }
            else
            {
                RBFemale.Checked = true;
            }
            for (iCounsellorAge = 18; iCounsellorAge < 126; iCounsellorAge++)
            {
                DDLCounsellorAge.Items.Add(iCounsellorAge.ToString());
            }
            DDLCounsellorAge.SelectedValue = CounsellorInfoEntity.icounsellorAge.ToString();
            TBCounsellorEmail.Text = CounsellorInfoEntity.scounsellorEmail;
            TBCounsellorPhoneNumber.Text = CounsellorInfoEntity.lcounsellorPhoneNumber.ToString();
            IMGCounsellorImage.ImageUrl = CounsellorInfoEntity.scounsellorImage;
            LBLCounsellorWallet.Text = CounsellorInfoEntity.lcounsellorWallet.ToString();
            LBLCounsellorLevel.Text = CounsellorInfoEntity.icounsellorLevel.ToString();
            for (int iCounter = 0; iCounter < saCounsellorAdvantageFields.Length; iCounter++)
            {
                saCounsellorAdvantageFields[iCounter] = CounsellorInfoEntity.sacounsellorAdvantageField[iCounter];
            }
            CounsellorAdvantageFieldsBonding(saCounsellorAdvantageFields, saDefaultCounsellorAdvantageFields);

            QuestionInfoDisplay(CounsellorInfoEntity.icounsellorLevel);//第三页等级提升的相关信息


            BoardInfoBusiness BoardInfo = new BoardInfoBusiness();
            int iCounsellorApplyExistJudgement=(int)BoardInfo.CounsellorApplyExistJudgement(lCounsellorID);
            int iBoardExistJudgement = (int)BoardInfo.BoardExistJudgement(lCounsellorID);
            
            if (CounsellorInfoEntity.icounsellorLevel != 3)
            {
                LBLBoardAccessAlert.Text = "请提升您的等级，以获取准入资格！";
                BTNBoardAccessApply.Visible = false;
            }
            else if (iBoardExistJudgement>0)
            {
                BTNBoardAccessApply.Visible = false;

                LBLBoardAccessAlert.Text = "申请已通过！请借助如下信息以登录董事会";
                BoardInfoEntity BoardInfoEntity = new BoardInfoEntity();
                BoardInfoEntity = BoardInfo.GetBoardInfoByCounsellorID(lCounsellorID);
                LBLBoardSequenceID.Visible = true;
                LBLBoardSequenceID.Text = "您的董事会账号为："+BoardInfoEntity.boadrMemberSequenceID.ToString();
                if (BoardInfoEntity.boardMemberLoginPassword=="password")
                {
                    LBLBoardPassword.Visible = true;
                    LBLBoardPassword.Text = "初始密码为:"+BoardInfoEntity.boardMemberLoginPassword+",请务必更改密码";
                }
            }
            else if (iCounsellorApplyExistJudgement > 0)
            {
                LBLBoardAccessAlert.Text = "您已申请加入董事会，请耐心等待结果！！";
                BTNBoardAccessApply.Visible = false;
            }
            else
            {
                LBLBoardAccessAlert.Text = "您的能力通过审核！请点击下方按钮以申请加入董事会";
            }
        }

        //差评警告系统
        double dBlackListAlert;
        double dCounsellorArticleLikedAmount = 0;
        double dCounsellorArticleDislikedAmount = 0;
        double dCounsellorRespondLikedCountAmount = 0;
        double dCounsellorRespondDislikedCountAmount = 0;
        if (CounsellorInfoBusiness.CounsellorArticleLikedAmount(lCounsellorID).ToString() == ""|| CounsellorInfoBusiness.CounsellorArticleDislikedAmount(lCounsellorID).ToString()==""|| CounsellorInfoBusiness.CounsellorRespondLikedCountAmount(lCounsellorID).ToString()==""|| CounsellorInfoBusiness.CounsellorRespondDislikedCountAmount(lCounsellorID).ToString()=="")
        {
            LBLBlackListAlert.Visible = false;
        }
        else
        {
            dCounsellorArticleLikedAmount = double.Parse(CounsellorInfoBusiness.CounsellorArticleLikedAmount(lCounsellorID).ToString());
            dCounsellorArticleDislikedAmount = double.Parse(CounsellorInfoBusiness.CounsellorArticleDislikedAmount(lCounsellorID).ToString());
            dCounsellorRespondLikedCountAmount = double.Parse(CounsellorInfoBusiness.CounsellorRespondLikedCountAmount(lCounsellorID).ToString());
            dCounsellorRespondDislikedCountAmount = double.Parse(CounsellorInfoBusiness.CounsellorRespondDislikedCountAmount(lCounsellorID).ToString());
            if (dCounsellorArticleDislikedAmount + dCounsellorRespondDislikedCountAmount > 500)
            {
                dBlackListAlert = (dCounsellorArticleLikedAmount + dCounsellorRespondLikedCountAmount) / (dCounsellorArticleDislikedAmount + dCounsellorRespondDislikedCountAmount);
                if (dBlackListAlert < 1)
                {
                    LBLBlackListAlert.Text = "警告！您的差评比过低！";
                }
                else
                {
                    LBLBlackListAlert.Visible = false;
                }
            }
            else
            {
                LBLBlackListAlert.Visible = false;
            }
        }
    }
    private void QuestionInfoDisplay(int iQuestionLevel)
    {
        string sQuestionFieldRandom = QuestionFieldRandom();
        QuestionInfoBusiness questionInfoBusiness = new QuestionInfoBusiness();
        QuestionInfoEntity questionInfoEntity = new QuestionInfoEntity();
        
        if (iQuestionLevel > 2)
        {
            LBLQuestionLevelInfo.Visible = false;
            LBLQuestionTitleInfo.Visible = false;
            LBLQuestionLevel.Visible = false;
            LBLQuestionTitle.Text = "您已得到最高级别";
            LBLQuestionSelectionAInfo.Visible = false;
            LBLQuestionSelectionA.Visible = false;
            LBLQuestionSelectionBInfo.Visible = false;
            LBLQuestionSelectionB.Visible = false;
            LBLQuestionSelectionCInfo.Visible = false;
            LBLQuestionSelectionC.Visible = false;
            LBLQuestionSelectionDInfo.Visible = false;
            LBLQuestionSelectionD.Visible = false;
            BTNCounsellorInfoUpdate.Visible = false;
            DDLQuestionSelection.Visible = false;
            BTNCounsellorLevelUpdate.Visible = false;
        }
        else
        {
            iQuestionID = questionInfoBusiness.RandomQuestionID(sQuestionFieldRandom, iQuestionLevel+1);
            questionInfoEntity = questionInfoBusiness.GETQuestionInfoByID(iQuestionID);
            LBLQuestionLevel.Text = questionInfoEntity.iquestionLevel.ToString();
            LBLQuestionTitle.Text = questionInfoEntity.squestionTitle;
            LBLQuestionSelectionA.Text = questionInfoEntity.squestionSelectionA;
            LBLQuestionSelectionB.Text = questionInfoEntity.squestionSelectionB;
            LBLQuestionSelectionC.Text = questionInfoEntity.squestionSelectionC;
            LBLQuestionSelectionD.Text = questionInfoEntity.squestionSelectionD;
        }
    }

    private string QuestionFieldRandom()
    {
        //递归实现问题领域的随机选取
        long lCounsellorID = long.Parse(Session["UsersID"].ToString());
        CounsellorInfoBusiness CounsellorInfoBusiness = new CounsellorInfoBusiness();//实体化BLL层中的CounsellorInfoBusiness类
        CounsellorInfoEntity CounsellorInfoEntity = new CounsellorInfoEntity();
        CounsellorInfoEntity = CounsellorInfoBusiness.GetCounsellorInfoByID(lCounsellorID);
        string[] saCounsellorAdvantageFields = new string[8];

        for (int iCounter = 0; iCounter < saCounsellorAdvantageFields.Length; iCounter++)
        {
            saCounsellorAdvantageFields[iCounter] = CounsellorInfoEntity.sacounsellorAdvantageField[iCounter];
        }//将获取的擅长领域加入到本方法内的数组

        Random RandomQuestionID = new Random();
        int iIndex = RandomQuestionID.Next(saCounsellorAdvantageFields.Length);
        int iQuestionFieldExistCounter = 0;
        string sQuestionFieldRandom = saCounsellorAdvantageFields[iIndex].ToString();

        string[] sQuestionFields = { "刑法·贪污贿赂问题", "刑事诉讼法", "民法·合同问题", "民法·知识产权", "婚姻继承问题", "民法·侵权责任问题", "民法·抵押担保问题", "刑法·盗窃罪共犯问题" };
        for (int iCounter = 0; iCounter < 8; iCounter++)
        {
            if (sQuestionFieldRandom == sQuestionFields[iCounter])
            {
                iQuestionFieldExistCounter++;
            }
        }
        if (iQuestionFieldExistCounter > 0)
        {
            return sQuestionFieldRandom;
        }
        else
        {
            return QuestionFieldRandom();
        }
    }

    private void CounsellorAdvantageFieldsBonding(string[] saCounsellorAdvantageFields,string[] saDefaultCounsellorAdvantageFields)
    {
        //listbox内容绑定方法
        for (int iCounter = 0; iCounter < saCounsellorAdvantageFields.Length; iCounter++)
        {
            //将擅长的值输入到左边已选定的listbox
            if (saCounsellorAdvantageFields[iCounter] == "待定")
            {
                continue;
            }
            LBXCounsellorAdvantageFieldsSelected.Items.Add(saCounsellorAdvantageFields[iCounter]);
        }
        for (int iCounter = 0; iCounter < saDefaultCounsellorAdvantageFields.Length; iCounter++)
        {
            //第一层遍历：saDefaultCounsellorAdvantageFields的值
            for (int iCounterDeeper = 0; iCounterDeeper < LBXCounsellorAdvantageFieldsSelected.Items.Count; iCounterDeeper++)
            {
                //第二层遍历：LBXCounsellorAdvantageFieldsSelected里的值
                if (saDefaultCounsellorAdvantageFields[iCounter] == LBXCounsellorAdvantageFieldsSelected.Items[iCounterDeeper].ToString())
                {
                    saDefaultCounsellorAdvantageFields[iCounter] = "X";
                }
            }
        }
        for (int iCounter = 0; iCounter < saDefaultCounsellorAdvantageFields.Length; iCounter++)
        {
            //将剩下的擅长领域值输入到左边的listbox LBXCounsellorAdvantageFieldsUpdate
            if (saDefaultCounsellorAdvantageFields[iCounter] == "X")
            {
                continue;
            }
            LBXCounsellorAdvantageFieldsUnselected.Items.Add(saDefaultCounsellorAdvantageFields[iCounter]);
        }
    }

    private void CounsellorInfoUpdate()
    {
        long lCounsellorID = long.Parse(Session["UsersID"].ToString());
        CounsellorInfoBusiness CounsellorInfoUpdate = new CounsellorInfoBusiness();

        string sNewCounsellorSex;
        if (RBMale.Checked == true)
        {
            sNewCounsellorSex = "男";
        }
        else
        {
            sNewCounsellorSex = "女";
        }
        IMGCounsellorImageUpdate();
        string sCounsellorUpdateImagePath = "WebImages/ClientImages/" + this.sNewFullyCounsellorImagePathAndName;


        string[] saCounsellorAdvantageFieldsUpdate=new string[8];

        for(int iCounter = 0; iCounter < LBXCounsellorAdvantageFieldsSelected.Items.Count; iCounter++)
        {
            saCounsellorAdvantageFieldsUpdate[iCounter] = LBXCounsellorAdvantageFieldsSelected.Items[iCounter].ToString();
        }

        for (int iCounter = 0; iCounter < saCounsellorAdvantageFieldsUpdate.Length; iCounter++)
        {
            if (saCounsellorAdvantageFieldsUpdate[iCounter] == null)
            {
                saCounsellorAdvantageFieldsUpdate[iCounter] = "待定";
            }
        }

        int iResultJudgement;
        if (this.sNewFullyCounsellorImagePathAndName.Substring(this.sNewFullyCounsellorImagePathAndName.Length - 1, 1) != "N")
        {
            //如果上传图片，则更新图片路径
            iResultJudgement = CounsellorInfoUpdate.CounsellorInfoUpdate(TBCounsellorPassword.Text,TBCounsellorName.Text, sNewCounsellorSex,int.Parse(DDLCounsellorAge.SelectedValue),TBCounsellorEmail.Text, sCounsellorUpdateImagePath, saCounsellorAdvantageFieldsUpdate, lCounsellorID);
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
            iResultJudgement = CounsellorInfoUpdate.CounsellorInfoUpdate(TBCounsellorPassword.Text, TBCounsellorName.Text, sNewCounsellorSex, int.Parse(DDLCounsellorAge.SelectedValue), TBCounsellorEmail.Text, saCounsellorAdvantageFieldsUpdate, lCounsellorID); ;
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
    private void IMGCounsellorImageUpdate()
    {
        if (FUCounsellorImageUpload.HasFile)
        {
            string sFUCounsellorNewImageName = FUCounsellorImageUpload.PostedFile.FileName;//获取文件名字
            int iNewImageNamePointPosition = sFUCounsellorNewImageName.LastIndexOf(".");//找到文件名中“.”的位置，从1开始
            string sNewImageNameSuffix = sFUCounsellorNewImageName.Substring(iNewImageNamePointPosition);//以“iNewImageNamePointPosition”的值作为划分，读取后缀名
            string sRenameNewImageNameByCounsellorName = TBCounsellorName.Text;//通过人名标题为图片命名，来新照片就换掉
            FUCounsellorImageUpload.SaveAs(Server.MapPath("WebImages/CounsellorImages/" + sRenameNewImageNameByCounsellorName + sNewImageNameSuffix));
            sNewFullyCounsellorImagePathAndName = sRenameNewImageNameByCounsellorName + sNewImageNameSuffix;//拿到当前完整的文件名
        }
        else
        {
            sNewFullyCounsellorImagePathAndName = "N";
        }
    }
    
    protected void BTNAllFieldsSelect_Click(object sender, EventArgs e)
    {
        int iLBXCounsellorAdvantageFieldsUnselectedCount = LBXCounsellorAdvantageFieldsUnselected.Items.Count;

        for (int iCounter = 0; iCounter < iLBXCounsellorAdvantageFieldsUnselectedCount; iCounter++)
        {
            ListItem LICounsellorAdvantageFieldsItem = LBXCounsellorAdvantageFieldsUnselected.Items[0];
            LBXCounsellorAdvantageFieldsUnselected.Items.Remove(LICounsellorAdvantageFieldsItem);
            LBXCounsellorAdvantageFieldsSelected.Items.Add(LICounsellorAdvantageFieldsItem);
        }
        if (iLBXCounsellorAdvantageFieldsUnselectedCount == 0)
        {
            Response.Write("<script>alert('已全部选定！')</script>");
        }
    }

    protected void BTNAllFieldsCancel_Click(object sender, EventArgs e)
    {
        int iLBXCounsellorAdvantageFieldsSelectedCount = LBXCounsellorAdvantageFieldsSelected.Items.Count;
        for (int iCounter = 0; iCounter < iLBXCounsellorAdvantageFieldsSelectedCount; iCounter++)
        {
            ListItem LICounsellorAdvantageFieldsSelected = LBXCounsellorAdvantageFieldsSelected.Items[0];
            LBXCounsellorAdvantageFieldsSelected.Items.Remove(LICounsellorAdvantageFieldsSelected);
            LBXCounsellorAdvantageFieldsUnselected.Items.Add(LICounsellorAdvantageFieldsSelected);
        }
        if (iLBXCounsellorAdvantageFieldsSelectedCount == 0)
        {
            Response.Write("<script>alert('已全部取消！')</script>");
        }
    }

    protected void BTNSingleFieldSelect_Click(object sender, EventArgs e)
    {
        int iCounsellorAdvantageFieldsCount = LBXCounsellorAdvantageFieldsUnselected.Items.Count;
        int iCounsellorAdvantageFieldsIndex = LBXCounsellorAdvantageFieldsUnselected.SelectedIndex;
        if (iCounsellorAdvantageFieldsCount > 0)
        {
            if (iCounsellorAdvantageFieldsIndex >= 0)
            {
                ListItem LICounsellorAdvantageFieldsItem = LBXCounsellorAdvantageFieldsUnselected.SelectedItem;
                LBXCounsellorAdvantageFieldsUnselected.Items.Remove(LICounsellorAdvantageFieldsItem);
                LBXCounsellorAdvantageFieldsSelected.Items.Add(LICounsellorAdvantageFieldsItem);
            }
        }
        else
        {
            Response.Write("<script>alert('已全部选定！')</script>");
        }
    }

    protected void BTNSingleFieldCancel_Click(object sender, EventArgs e)
    {
        int iCounsellorAdvantageFieldsSelectedCount = LBXCounsellorAdvantageFieldsSelected.Items.Count;
        int iCounsellorAdvantageFieldsSelectedIndex = LBXCounsellorAdvantageFieldsSelected.SelectedIndex;
        if (iCounsellorAdvantageFieldsSelectedCount > 0)
        {
            ListItem LICounsellorAdvantageFieldsSelectedItem = LBXCounsellorAdvantageFieldsSelected.SelectedItem;
            LBXCounsellorAdvantageFieldsSelected.Items.Remove(LICounsellorAdvantageFieldsSelectedItem);
            LBXCounsellorAdvantageFieldsUnselected.Items.Add(LICounsellorAdvantageFieldsSelectedItem);
        }
        else
        {
            Response.Write("<script>alert('已全部清空！')</script>");
        }
    }

    protected void BTNCounsellorInfoUpdate_Click(object sender, EventArgs e)
    {
        CounsellorInfoUpdate();
    }

    protected void BTNPostArticle_Click(object sender, EventArgs e)
    {
        PostArticle();
    }

    private void PostArticle()
    {
        long lCounsellorID = long.Parse(Session["UsersID"].ToString());
        ArticleInfoBusiness PostArticle = new ArticleInfoBusiness();
        ArticleInfoEntity ArticleInfo = new ArticleInfoEntity();
        ArticleInfo.sarticleTitle = TBArticleTitle.Text;
        ArticleInfo.sarticleContent = TBArticleContent.Text;
        ArticleInfo.larticleAutherID = lCounsellorID;
        ArticleInfo.iarticleReadCount = 0;
        ArticleInfo.iarticleLikedCount = 0;
        ArticleInfo.iarticleDislikedCount = 0;

        int iResultJudgement = PostArticle.ArticleInfoPost(ArticleInfo);
        if (iResultJudgement > 0)
        {
            Response.Write("<script>alert('成功发布文章！')</script>");
        }
        else
        {
            Response.Write("<script>alert('抱歉，发布失败！')</script>");
        }
    }

    protected void BTNCounsellorLevelUpdate_Click(object sender, EventArgs e)
    {
        //等级提升按钮
        long lCounsellorID = long.Parse(Session["UsersID"].ToString());
        QuestionInfoBusiness questionInfoBusiness = new QuestionInfoBusiness();
        QuestionInfoEntity questionInfoEntity = new QuestionInfoEntity();
        questionInfoEntity = questionInfoBusiness.GETQuestionInfoByID(iQuestionID);

        if (questionInfoEntity.ccorrectAnswer == char.Parse(DDLQuestionSelection.SelectedValue))
        {
            Response.Write("<script>alert('回答正确！')</script>");
            CounsellorInfoBusiness CounsellorLevelUpdate = new CounsellorInfoBusiness();
            CounsellorLevelUpdate.CounsellorLevelUpdate(lCounsellorID);
            //律师等级+1
        }
        else
        {
            Response.Write("<script>alert('回答错误！')</script>");
        }
    }

    protected void BTNBoardAccessApply_Click(object sender, EventArgs e)
    {
        long lCounsellorID = long.Parse(Session["UsersID"].ToString());
        string sRandomSecretKEY=RandomString();

        BoardInfoBusiness BoardInfo = new BoardInfoBusiness();
        int iReturnValue = BoardInfo.BoardApply(lCounsellorID, sRandomSecretKEY);

        if (iReturnValue > 0)
        {
            Response.Write("<script>alert('申请成功！请等待结果！')</script>");
        }
        else
        {
            Response.Write("<script>alert('申请失败！')</script>");
        }
    }

    private string RandomString()
    {
        Random AmountRandom = new Random();//决定字符串的长度
        int iAmountRandom = AmountRandom.Next(10, 15);
        StringBuilder RandomSecretKEY = new StringBuilder();

        Random ASCIIRandom = new Random();//随机决定字符

        for (int iCounter = 0; iCounter <= iAmountRandom; iCounter++)
        {
            int iASCIIRandom = ASCIIRandom.Next(33, 126);
            char cASCIIRandom = (char)iASCIIRandom;
            RandomSecretKEY.Append(cASCIIRandom);
        }
        string sRandomSecretKEY = RandomSecretKEY.ToString();

        BoardInfoBusiness BoardKEYExist = new BoardInfoBusiness();

        if ((int)BoardKEYExist.BoardKeyExistJudgement(sRandomSecretKEY) > 0)
        {
            return RandomString();
        }
        else
        {
            return sRandomSecretKEY;
        }
    }
}