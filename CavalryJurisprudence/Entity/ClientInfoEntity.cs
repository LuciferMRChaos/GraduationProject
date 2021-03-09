using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ClientInfoEntity
    {
        long lClientID;
        public long lclientID
        {
            get { return lClientID;}
            set { lClientID=value;}
        }
        string sClientPassword;
        public string sclientPassword
        {
            get { return sClientPassword; }
            set { sClientPassword = value; }
        }
        string sClientName;
        public string sclientName
        {
            get { return sClientName; }
            set { sClientName = value; }
        }
        string sClientSex;
        public string sclientSex
        {
            get { return sClientSex; }
            set { sClientSex = value; }
        }
        int iClientAge;
        public int iclientAge
        {
            get { return iClientAge; }
            set { iClientAge = value; }
        }
        string sClientEmail;
        public string sclientEmail
        {
            get { return sClientEmail; }
            set { sClientEmail = value; }
        }
        long lClientPhoneNumber;
        public long lclientPhoneNumber
        {
            get { return lClientPhoneNumber; }
            set { lClientPhoneNumber = value; }
        }

        long lClientDepositingMoney;
        public long lclientDepositingMoney
        {
            get { return lClientDepositingMoney; }
            set { lClientDepositingMoney = value; }
        }

        long lClientWallet;
        public long lclientWallet
        {
            get { return lClientWallet; }
            set { lClientWallet = value; }
        }
        long lClientTotalDepositedMoney;
        public long lclientTotalDepositedMoney
        {
            get { return lClientTotalDepositedMoney; }
            set { lClientTotalDepositedMoney = value; }
        }
        string sClientImage;
        public string sclientImage
        {
            get { return sClientImage; }
            set { sClientImage = value; }
        }
        string sClientAddress;
        public string sclientAddress
        {
            get { return sClientAddress; }
            set { sClientAddress = value; }
        }
        long lClientPoints;
        public long lclientPoints
        {
            get { return lClientPoints; }
            set { lClientPoints = value; }
        }
        int iClientLevel;
        public int iclientLevel
        {
            get { return iClientLevel; }
            set { iClientLevel = value; }
        }
    }
}
