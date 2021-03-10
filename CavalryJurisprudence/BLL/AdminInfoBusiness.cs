using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Entity;
using DAL;

namespace BLL
{
    public class AdminInfoBusiness
    {
        public object AdminExistJudgementByAdminAccount(string sAdminAccount)//判断管理员用户名是否存在方法
        {
            string sSQLText = "select count(*) from AdminInfo where AdminAccount='"+ sAdminAccount + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            return ReturnValue;
        }

        public AdminInfoEntity GetAdminInfoByAdminAccount()//展示管理员全部信息方法
        {
            string sSQLText = "select * from AdminInfo";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);
            AdminInfoEntity AdminInfo = new AdminInfoEntity();
            if (dataTable.Rows.Count > 0)
            {
                AdminInfo.sadminAccount = "" + dataTable.Rows[0][0];
                for(int iCounter = 1; iCounter < 6; iCounter++)
                {
                    AdminInfo.saadminPasswords[iCounter - 1] = "" + dataTable.Rows[0][iCounter];
                }
                AdminInfo.iadminInfoHackedThreateningLevel= int.Parse("" + dataTable.Rows[0][6]);
            }
            return AdminInfo;
        }

        public int AdminInfoThreateningLevel(int iAdminInfoHackedThreateningLevel)
        {
            string sSQLText = "update AdminInfo set AdminInfoHackedThreateningLevel='"+ iAdminInfoHackedThreateningLevel + "'";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }

        public int AdminPasswordUpdate(string sAdminUsingPassword,string sAdminUsedPassword,string sAdminNewAccount)
        {
            string sSQLText = "update AdminInfo set AdminUsingPassword='" + sAdminUsingPassword + "',AdminHistoricalPassword1='"+ sAdminUsedPassword + "',AdminAccount='" + sAdminNewAccount + "'";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }
    }
}
