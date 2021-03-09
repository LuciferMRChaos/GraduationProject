using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class AdminInfoEntity
    {
        string sAdminAccount;
        public string sadminAccount
        {
            get { return sAdminAccount; }
            set { sAdminAccount = value; }
        }
        string[] saAdminPasswords = new string[5];
        public string[] saadminPasswords
        {
            get { return saAdminPasswords; }
            set { saAdminPasswords = value; }
        }
        int iAdminInfoHackedThreateningLevel;
        public int iadminInfoHackedThreateningLevel
        {
            get { return iAdminInfoHackedThreateningLevel; }
            set { iAdminInfoHackedThreateningLevel = value; }
        }
    }
}
