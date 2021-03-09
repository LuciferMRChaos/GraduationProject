using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class BoardInfoEntity
    {
        long BoardMemberSequenceID;
        public long boadrMemberSequenceID
        {
            get { return BoardMemberSequenceID; }
            set { BoardMemberSequenceID = value; }
        }
        long BoardMemberIDfromCounsellor;
        public long boardMemberIDfromCounsellor
        {
            get { return BoardMemberIDfromCounsellor; }
            set { BoardMemberIDfromCounsellor = value; }
        }
        string BoardSecretKey;
        public string boardSecretKey
        {
            get { return BoardSecretKey; }
            set { BoardSecretKey = value; }
        }
        string FounderIdentityJudgement;
        public string founderIdentityJudgement
        {
            get { return FounderIdentityJudgement; }
            set { FounderIdentityJudgement = value; }
        }
        string BoardMemberLoginPassword;
        public string boardMemberLoginPassword
        {
            get { return BoardMemberLoginPassword; }
            set { BoardMemberLoginPassword = value; }
        }
    }
}
