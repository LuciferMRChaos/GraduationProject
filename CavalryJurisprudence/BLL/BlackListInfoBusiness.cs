using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class BlackListInfoBusiness
    {
        public object BlackListExist(long lCounsellorPhone,string sCounsellorEmail)//查询是否存在于黑名单中
        {
            string sSQLText = "select count(*) from BlackListInfo where CounsellorPhone='"+ lCounsellorPhone + "' and CounsellorEmail='"+ sCounsellorEmail + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public int DeleteAllBlackListInfo()//删除全部黑名单信息
        {
            string sSQLText = "delete from BlackListInfo";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }
    }
}
