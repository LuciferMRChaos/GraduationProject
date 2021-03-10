using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class ClientInfoBusiness
    {
        public int ClientInfoRegister(ClientInfoEntity ClientInfo)//客户信息注册方法
        {
            string sSQLText = "insert into ClientInfo values('"+ClientInfo.lclientID+"','" + ClientInfo.sclientPassword + "','"+ClientInfo.sclientName+"','"+ClientInfo.sclientSex+"','"+ClientInfo.iclientAge+"','"+ClientInfo.sclientEmail+"','"+ClientInfo.lclientPhoneNumber+"','"+ClientInfo.lclientDepositingMoney+"','"+ClientInfo.lclientWallet+"','"+ClientInfo.lclientTotalDepositedMoney+"','"+ClientInfo.sclientImage+"','"+ClientInfo.sclientAddress+"','"+ClientInfo.lclientPoints+"','"+ClientInfo.iclientLevel+"')";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public object ClientExistJudgementByClientPhoneNumber(long lClientPhoneNumber)//通过电话号判断客户是否存在方法
        {
            string sSQLText = "select count(*) from ClientInfo where ClientPhoneNumber='" + lClientPhoneNumber + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public object ClientExistJudgementByClientID(long lClientID)//判断客户是否存在方法
        {
            string sSQLText = "select count(*) from ClientInfo where ClientID='" + lClientID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public object ClientExistJudgementByClientPassword(string sClientPassword)//判断客户密码是否正确方法
        {
            string sSQLText = "select count(*) from ClientInfo where ClientPassword='" + sClientPassword + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public ClientInfoEntity GetClientInfoByID(long lClientID)//展示客户全部信息方法
        {
            string sSQLText = "select * from ClientInfo where ClientID='" + lClientID + "'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);//得到多值
            ClientInfoEntity ClientInfo = new ClientInfoEntity();//实体化Entity层的ClientInfoEntity
            if (dataTable.Rows.Count > 0)
            {
                ClientInfo.lclientID = long.Parse("" + dataTable.Rows[0][0]);
                ClientInfo.sclientPassword = "" + dataTable.Rows[0][1];
                ClientInfo.sclientName = "" + dataTable.Rows[0][2];
                ClientInfo.sclientSex = "" + dataTable.Rows[0][3];
                ClientInfo.iclientAge = int.Parse("" + dataTable.Rows[0][4]);
                ClientInfo.sclientEmail = "" + dataTable.Rows[0][5];
                ClientInfo.lclientPhoneNumber = long.Parse("" + dataTable.Rows[0][6]);
                ClientInfo.lclientDepositingMoney = long.Parse("" + dataTable.Rows[0][7]);
                ClientInfo.lclientWallet = long.Parse("" + dataTable.Rows[0][8]);
                ClientInfo.lclientTotalDepositedMoney = long.Parse("" + dataTable.Rows[0][9]);
                ClientInfo.sclientImage = "" + dataTable.Rows[0][10];
                ClientInfo.sclientAddress = "" + dataTable.Rows[0][11];
                ClientInfo.lclientPoints = long.Parse("" + dataTable.Rows[0][12]);
                ClientInfo.iclientLevel = int.Parse("" + dataTable.Rows[0][13]);
            }
            return ClientInfo;
        }
        public int ClientInfoUpdate(string sClientPassword,string sClientName,string sClientSex,int iClientAge,string sClientEmail,long lClientPhoneNumber,long lClientDepositingMoney,string sClientImage,string sClientAddress,long lClientID)
        {
            /**
             * 更新客户信息
             */
            string sSQLText= "update ClientInfo set ClientPassword = '"+ sClientPassword + "', ClientName = '"+ sClientName + "', ClientSex = '"+sClientSex+"', ClientAge = '"+ iClientAge + "', ClientEmail = '"+sClientEmail+ "', ClientPhoneNumber = '"+lClientPhoneNumber+"', ClientDepositingMoney = '"+lClientDepositingMoney+"', ClientImage = '"+ sClientImage + "', ClientAddress = '"+ sClientAddress + "' where ClientID = '"+ lClientID + "'";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }
        public int ClientInfoUpdate(string sClientPassword, string sClientName, string sClientSex, int iClientAge, string sClientEmail, long lClientPhoneNumber, long lClientDepositingMoney, string sClientAddress, long lClientID)
        {
            /**
             * 更新客户信息
             * 重载
             */
            string sSQLText = "update ClientInfo set ClientPassword = '" + sClientPassword + "', ClientName = '" + sClientName + "', ClientSex = '" + sClientSex + "', ClientAge = '" + iClientAge + "', ClientEmail = '" + sClientEmail + "', ClientPhoneNumber = '" + lClientPhoneNumber + "', ClientDepositingMoney = '" + lClientDepositingMoney + "', ClientAddress = '" + sClientAddress + "' where ClientID = '" + lClientID + "'";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }

        public int DeleteClientInfoByClientID(long lClientID)//删除客户信息
        {
            string sSQLText = "delete from ClientInfo where ClientID='" + lClientID + "'";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }

        public int ClientGiftPurchaseByPoints(long lGiftPrice,long lClientID)//购买礼品减少积分方法
        {
            string sSQLText = "update ClientInfo set ClientPoints=ClientPoints-'"+lGiftPrice+"' where ClientID='"+ lClientID + "'";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public int ClientWalletMoneyUpdate(long lClientWallet, long lClientID)//购买礼品减少积分方法
        {
            string sSQLText = "update ClientInfo set ClientWallet=ClientWallet-'"+ lClientWallet + "' where ClientID='"+ lClientID + "'";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public long GetClientIDByWantedID(long lWantedID)
        {
            string sSQLText = "select ClientID from WantedQuestionInfo,ClientInfo where WantedQuestionInfo.WantedPromoterID = ClientInfo.ClientID and WantedID ='"+ lWantedID + "' ";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);
            long lClientID = 0;
            if (dataTable.Rows.Count > 0)
            {
                lClientID = long.Parse("" + dataTable.Rows[0][0]);
            }
            return lClientID;
        }

        public int ClientWantedBountyMoney(long lClientBountyMoney, long lClientID)//选中答案后支出相应的悬赏金
        {
            string sSQLText = "update ClientInfo set ClientWallet=ClientWallet-'"+ lClientBountyMoney + "' where ClientID='"+ lClientID + "'";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }

        public long ClientPasswordResetJudgementByClientEmailAndPhoneNumber(string sClientEmial,long lClientPhoneNumber)//客户密码重置判断方法
        {
            string sSQLText = "select ClientID from ClientInfo where ClientEmail='"+ sClientEmial + "' and ClientPhoneNumber='"+ lClientPhoneNumber + "'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);
            long lClientID = 0;
            if (dataTable.Rows.Count > 0)
            {
                lClientID = long.Parse("" + dataTable.Rows[0][0]);
            }
            return lClientID;
        }

        public int ClientPasswordReset(string sClientPassword,long lClientID)//客户密码更新
        {
            string sSQLText = "update ClientInfo set ClientPassword='"+ sClientPassword + "' where ClientID='"+ lClientID + "'";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }
    }
}
