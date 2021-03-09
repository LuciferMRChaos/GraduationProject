using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class DevelopLogs
    {
        string sDate;
        public string Date
        {
            get { return sDate; }
            set { sDate = value; }
        }
        string sExcept;
        public string Except
        {
            get { return sExcept; }
            set { sExcept = value; }
        }
        string sReality;
        public string Reality
        {
            get { return sReality; }
            set { sReality = value; }
        }
        string sFailReason;
        public string FailReason
        {
            get { return sFailReason; }
            set { sFailReason = value; }
        }
        string sExperience;
        public string Experience
        {
            get { return sExperience; }
            set { sExperience = value; }
        }
    }
}
