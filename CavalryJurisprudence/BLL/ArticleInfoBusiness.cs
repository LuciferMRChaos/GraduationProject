using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class ArticleInfoBusiness
    {
        public int ArticleInfoPost(ArticleInfoEntity ArticleInfo)//发布文章方法
        {
            string sSQLText = "insert into ArticleInfo values('"+ ArticleInfo.sarticleTitle+ "','"+ ArticleInfo.larticleAutherID+ "','"+ ArticleInfo.sarticleContent+ "','"+ ArticleInfo.iarticleReadCount+ "','"+ ArticleInfo.iarticleLikedCount+ "','"+ ArticleInfo.iarticleDislikedCount+ "')";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }
        public ArticleInfoEntity GetArticleInfoByID(long lArtcleID)//展示全部信息方法
        {
            string sSQLText = "select * from ArticleInfo where ArticleID='" + lArtcleID + "'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);//得到多值
            ArticleInfoEntity ArticleInfo = new ArticleInfoEntity();//
            if (dataTable.Rows.Count > 0)
            {
                ArticleInfo.larticleID = long.Parse("" + dataTable.Rows[0][0]);
                ArticleInfo.sarticleTitle = "" + dataTable.Rows[0][1];
                ArticleInfo.larticleAutherID = long.Parse("" + dataTable.Rows[0][2]);
                ArticleInfo.sarticleContent = "" + dataTable.Rows[0][3];
                ArticleInfo.iarticleReadCount = int.Parse("" + dataTable.Rows[0][4]);
                ArticleInfo.iarticleLikedCount = int.Parse("" + dataTable.Rows[0][5]);
                ArticleInfo.iarticleDislikedCount = int.Parse("" + dataTable.Rows[0][6]);
            }
            return ArticleInfo;
        }

        public int ArticleReadCountUpdate(long lArticleID)//阅读数+1
        {
            string sSQLText = "update ArticleInfo set ArticleReadCount=ArticleReadCount +'" + 1 + "' where ArticleID='" + lArticleID + "'";
            int iReturnedValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public int ArticleLikedCountUpdate(long lArticleID)//点赞数+1
        {
            string sSQLText = "update ArticleInfo set ArticleLikedCount=ArticleLikedCount+'" + 1 + "' where ArticleID='" + lArticleID + "'";
            int iReturnedValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public int ArticleDislikedCountUpdate(long lArticleID)//点踩数+1
        {
            string sSQLText = "update ArticleInfo set ArticleDislikedCount=ArticleDislikedCount+'" + 1 + "' where ArticleID='" + lArticleID + "'";
            int iReturnedValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public object CollectionExistJudgement(long lClientID,long lArticleID)//判断是否已经收藏文章方法
        {
            string sSQLText = "select count(*) from ArticleCollectionInfo where ClientID='"+ lClientID + "' and ArticleID='"+ lArticleID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public int ArticleInfoCollect(long lArticleID,long lClientID)//收藏文章方法
        {
            string sSQLText = "insert into ArticleCollectionInfo values('"+ lArticleID + "','"+ lClientID + "')";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public int DeleteAllArticleInfo()//删除全部文章信息
        {
            string sSQLText = "delete from ArticleInfo";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }
    }
}
