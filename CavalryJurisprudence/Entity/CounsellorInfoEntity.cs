using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class CounsellorInfoEntity
    {
        long lCounsellorID;
        public long lcounsellorID
        {
            get { return lCounsellorID; }
            set { lCounsellorID = value; }
        }
        string sCounsellorPassword;
        public string scounsellorPassword
        {
            get { return sCounsellorPassword; }
            set { sCounsellorPassword = value; }
        }
        string sCounsellorName;
        public string scounsellorName
        {
            get { return sCounsellorName; }
            set { sCounsellorName = value; }
        }
        string sCounsellorSex;
        public string scounsellorSex
        {
            get { return sCounsellorSex; }
            set { sCounsellorSex = value; }
        }
        int iCounsellorAge;
        public int icounsellorAge
        {
            get { return iCounsellorAge; }
            set { iCounsellorAge = value; }
        }
        string sCounsellorEmail;
        public string scounsellorEmail
        {
            get { return sCounsellorEmail; }
            set { sCounsellorEmail = value; }
        }
        long lCounsellorPhoneNumber;
        public long lcounsellorPhoneNumber
        {
            get { return lCounsellorPhoneNumber; }
            set { lCounsellorPhoneNumber = value; }
        }
        string sCounsellorImage;
        public string scounsellorImage
        {
            get { return sCounsellorImage; }
            set { sCounsellorImage = value; }
        }
        string sCounsellorSelfIntroduction;
        public string scounsellorSelfIntroduction
        {
            get { return sCounsellorSelfIntroduction; }
            set { sCounsellorSelfIntroduction = value; }
        }
        long lCounsellorWallet;
        public long lcounsellorWallet
        {
            get { return lCounsellorWallet; }
            set { lCounsellorWallet = value; }
        }
        int iCounsellorLevel;
        public int icounsellorLevel
        {
            get { return iCounsellorLevel; }
            set { iCounsellorLevel = value; }
        }

        long lCounsellorOfferMoney;
        public long lcounsellorOfferMoney
        {
            get { return lCounsellorOfferMoney; }
            set { lCounsellorOfferMoney = value; }
        }

        string[] saCounsellorAdvantageField=new string[8];
        public string[] sacounsellorAdvantageField
        {
            get { return saCounsellorAdvantageField; }
            set { saCounsellorAdvantageField = value; }
        }
        int iAgreeAmount;
        public int iagreeAmount
        {
            get { return iAgreeAmount; }
            set { iAgreeAmount = value; }
        }
        int iRefuseAmount;
        public int irefuseAmount
        {
            get { return iRefuseAmount; }
            set { iRefuseAmount = value; }
        }
    }
}
