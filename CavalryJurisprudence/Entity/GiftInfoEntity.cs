using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class GiftInfoEntity
    {
        long lGiftID;
        public long lgiftID
        {
            get { return lGiftID; }
            set { lGiftID = value; }
        }
        string sGiftName;
        public string sgiftName
        {
            get { return sGiftName; }
            set { sGiftName = value; }
        }
        string sGiftTips;
        public string sgiftTips
        {
            get { return sGiftTips; }
            set { sGiftTips = value; }
        }
        string sGiftInfo;
        public string sgiftInfo
        {
            get { return sGiftInfo; }
            set { sGiftInfo = value; }
        }
        int iGiftAmount;
        public int igiftAmount
        {
            get { return iGiftAmount; }
            set { iGiftAmount = value; }
        }
        int iGiftPrice;
        public int igiftPrice
        {
            get { return iGiftPrice; }
            set { iGiftPrice = value; }
        }
        string sGiftImage;
        public string sgiftImage
        {
            get { return sGiftImage; }
            set { sGiftImage = value; }
        }
    }
}
