using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class GiftInfoBusiness
    {
        public int GiftInfoAdd(GiftInfoEntity GiftInfo)
        {
            string sSQLText = "insert into GiftInfo values('"+GiftInfo.sgiftName+"','"+GiftInfo.sgiftTips+"','"+GiftInfo.sgiftInfo+"','"+GiftInfo.igiftAmount+"','"+GiftInfo.igiftPrice+"','"+GiftInfo.sgiftImage+"')";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }
        public GiftInfoEntity GetGiftInfoByID(long GiftID)//查找礼物信息方法
        {
            string SQLText = "select * from GiftInfo where GiftID='" + GiftID + "'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(SQLText);//可以返回多值
            GiftInfoEntity GiftDetail = new GiftInfoEntity();
            if (dataTable.Rows.Count > 0)
            {
                GiftDetail.sgiftName = "" + dataTable.Rows[0][1];
                GiftDetail.sgiftTips = "" + dataTable.Rows[0][2];
                GiftDetail.sgiftInfo = "" + dataTable.Rows[0][3];
                GiftDetail.igiftAmount = int.Parse("" + dataTable.Rows[0][4]);
                GiftDetail.igiftPrice = int.Parse("" + dataTable.Rows[0][5]);
                GiftDetail.sgiftImage = "" + dataTable.Rows[0][6];
            }
            return GiftDetail;
        }

        public int DeleteAllGiftInfo()//删除全部礼品信息
        {
            string sSQLText = "delete from GiftInfo";
            int iReturnValue = DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnValue;
        }
    }
}
