using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ArticleInfoEntity
    {
        long lArticleID;
        public long larticleID
        {
            get { return lArticleID; }
            set { lArticleID = value; }
        }
        string  sArticleTitle;
        public string sarticleTitle
        {
            get { return sArticleTitle; }
            set { sArticleTitle = value; }
        }
        long lArticleAutherID;
        public long larticleAutherID
        {
            get { return lArticleAutherID; }
            set { lArticleAutherID = value; }
        }
        string sArticleContent;
        public string sarticleContent
        {
            get { return sArticleContent; }
            set { sArticleContent = value; }
        }
        int iArticleReadCount;
        public int iarticleReadCount
        {
            get { return iArticleReadCount; }
            set { iArticleReadCount = value; }
        }
        int iArticleLikedCount;
        public int iarticleLikedCount
        {
            get { return iArticleLikedCount; }
            set { iArticleLikedCount = value; }
        }
        int iArticleDislikedCount;
        public int iarticleDislikedCount
        {
            get { return iArticleDislikedCount; }
            set { iArticleDislikedCount = value; }
        }
    }
}
