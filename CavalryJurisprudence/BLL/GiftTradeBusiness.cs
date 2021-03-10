using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data;

namespace BLL
{
    public class GiftTradeBusiness
    {
        public int ClientGiftPurchase(long GiftID, long lClientID)//购买礼品方法
        {
            string sSQLText = "insert into GiftTradeInfo values('"+ GiftID + "','"+ lClientID + "')";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }
    }
}
