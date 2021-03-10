using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class CompanyInfoBusiness
    {
        public object GetAllClientAmount()//判断客户数量方法
        {
            string SQLText = "select count(*) from ClientInfo";
            object ReturnValue = DataBaseAccess.GetOneData(SQLText);
            return ReturnValue;
        }
        public object GetAllCounsellorAmount()//判断客户数量方法
        {
            string SQLText = "select count(*) from CounsellorInfo";
            object ReturnValue = DataBaseAccess.GetOneData(SQLText);
            return ReturnValue;
        }
    }
}
