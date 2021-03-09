using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class WantedQuestionDetailsInfoEntity
    {
        string sClientName;
        public string sclientName
        {
            get { return sClientName; }
            set { sClientName = value; }
        }
        string sWantedTitle;
        public string swantedTitle
        {
            get { return sWantedTitle; }
            set { sWantedTitle = value; }
        }
        long lWantedBounty;
        public long lwantedBounty
        {
            get { return lWantedBounty; }
            set { lWantedBounty = value; }
        }
        string sWantedField;
        public string swantedField
        {
            get { return sWantedField; }
            set { sWantedField = value; }
        }
        string sWantedContent;
        public string swantedContent
        {
            get { return sWantedContent; }
            set { sWantedContent = value; }
        }
        long lWantedID;
        public long lwantedID
        {
            get { return lWantedID; }
            set { lWantedID = value; }
        }
    }
}
