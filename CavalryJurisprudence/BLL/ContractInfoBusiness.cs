using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public class ContractInfoBusiness
    {
        public object CounsellorContractAmount(long lCounsellorID)//检验律师已经签约的数量
        {
            string sSQLText = " select count(*) from ClientInfo,ContractInfo where ContractInfo.CounsellorID = '"+ lCounsellorID + "' and ClientInfo.ClientID = ContractInfo.ClientID ";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public int ContractEstablish(long iCounsellorID,long lClientID)//律师签约方法方法
        {
            string sSQLText = "insert into ContractInfo values('"+ iCounsellorID + "','"+ lClientID + "')";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }
        public object CounsellorContractExistDetect(long lClientID)//检验律师已经签约的数量
        {
            string sSQLText = "select Count(*) from ContractInfo where ClientID='"+ lClientID + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }
    }
}
