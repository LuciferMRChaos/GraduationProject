using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;

public partial class ArticleDetail : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        long lArticleID = long.Parse(Request.QueryString["ArticleID"].ToString());
        long lUsersID = long.Parse(Session["UsersID"].ToString());
        if (lUsersID % 100 != 99)
        {
            BTNArticleCollect.Visible = false;
        }

        if (!IsPostBack)
        {
            ArticleInfoDisplay(lArticleID);
        }
        ArticleInfoBusiness ArticleReadCountUpdate = new ArticleInfoBusiness();
        ArticleReadCountUpdate.ArticleReadCountUpdate(lArticleID);
    }

    private void ArticleInfoDisplay(long lArticleID)
    {
        //获得文章信息
        ArticleInfoBusiness GetArticleInfoByArticleID = new ArticleInfoBusiness();
        ArticleInfoEntity ArticleInfo = new ArticleInfoEntity();

        ArticleInfo=GetArticleInfoByArticleID.GetArticleInfoByID(lArticleID);
        LBLArticleTitle.Text = ArticleInfo.sarticleTitle;
        LBLArticleReadCountNumber.Text = ArticleInfo.iarticleReadCount.ToString();
        LBLArticleLikedCount.Text = ArticleInfo.iarticleLikedCount.ToString();
        LBLArticleDislikedCount.Text = ArticleInfo.iarticleDislikedCount.ToString();
        LBLArticleContent.Text = ArticleInfo.sarticleContent;

        //获得作者信息
        CounsellorInfoBusiness GetArticleAutherInfo = new CounsellorInfoBusiness();
        CounsellorInfoEntity ArticleAutherInfo = new CounsellorInfoEntity();

        long lAuthorID = ArticleInfo.larticleAutherID;
        if (lAuthorID == 0L)
        {
            BTNArticleDisliked.Visible = false;
            LBLArticleDisliked.Visible = false;
            LBLArticleDislikedCount.Visible = false;
            IMGArticleAuthorImage.Visible = false;
            LBLAuthorName.Text = "管理员";
            LBAutherInfoDetails.Visible = false;
            LBLAuthorTips.Text = "此文章由管理员发布";
        }
        else
        {
            ArticleAutherInfo = GetArticleAutherInfo.GetCounsellorInfoByID(lAuthorID);
            LBLAuthorName.Text = ArticleAutherInfo.scounsellorName;
            IMGArticleAuthorImage.ImageUrl = ArticleAutherInfo.scounsellorImage;
            LBLAuthorTips.Text = ArticleAutherInfo.scounsellorSelfIntroduction;
        }
    }

    protected void LBAutherInfoDetails_Click(object sender, EventArgs e)
    {
        long lAuthorID = GetArticleAutherID();
        Response.Redirect("~/06CounsellorDetail.aspx?CounsellorID=" + lAuthorID);
    }

    private long GetArticleAutherID()
    {
        long ArticleAutherID;
        long lArticleID = long.Parse(Request.QueryString["ArticleID"].ToString());

        ArticleInfoBusiness GetArticleInfoByArticleID = new ArticleInfoBusiness();
        ArticleInfoEntity ArticleInfo = new ArticleInfoEntity();
        ArticleInfo = GetArticleInfoByArticleID.GetArticleInfoByID(lArticleID);
        ArticleAutherID = ArticleInfo.larticleAutherID;
        return ArticleAutherID;
    }

    protected void BTNArticleLiked_Click(object sender, EventArgs e)
    {//点赞
        long lArticleID = long.Parse(Request.QueryString["ArticleID"].ToString());
        ArticleInfoBusiness ArticleLikedCountUpdate = new ArticleInfoBusiness();
        ArticleLikedCountUpdate.ArticleLikedCountUpdate(lArticleID);
    }

    protected void BTNArticleDisliked_Click(object sender, EventArgs e)
    {//点踩
        long lArticleID = long.Parse(Request.QueryString["ArticleID"].ToString());
        ArticleInfoBusiness ArticleDislikedCountUpdate = new ArticleInfoBusiness();
        ArticleDislikedCountUpdate.ArticleDislikedCountUpdate(lArticleID);
    }

    protected void BTNArticleCollect_Click(object sender, EventArgs e)
    {
        long lArticleID = long.Parse(Request.QueryString["ArticleID"].ToString());
        long lUsersID = long.Parse(Session["UsersID"].ToString());
        ArticleInfoBusiness ArticleInfo = new ArticleInfoBusiness();
        int iJudgementValue = int.Parse(ArticleInfo.CollectionExistJudgement(lUsersID, lArticleID).ToString());

        if (iJudgementValue > 0)
        {
            Response.Write("<script>alert('您已收藏此文章！')</script>");
        }
        else
        {
            int iReturnValue = ArticleInfo.ArticleInfoCollect(lArticleID, lUsersID);
            if (iReturnValue > 0)
            {
                Response.Write("<script>alert('收藏成功！')</script>");
            }
            
        }
    }
}