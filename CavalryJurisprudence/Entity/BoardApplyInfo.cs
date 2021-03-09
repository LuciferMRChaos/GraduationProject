using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class BoardApplyInfo
    {
        long lCounsellorID;
        public long lcounsellorID
        {
            get { return lCounsellorID; }
            set { lCounsellorID = value; }
        }

        string sStandbySecretKEY;
        public string sstandbySecretKEY
        {
            get { return sStandbySecretKEY; }
            set { sStandbySecretKEY = value; }
        }

    }
}
