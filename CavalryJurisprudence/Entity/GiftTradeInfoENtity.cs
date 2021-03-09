using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class GiftTradeInfoENtity
    {
        long lGiftTradeInfo;
        public long lgiftTradeInfo
        {
            get { return lGiftTradeInfo; }
            set { lGiftTradeInfo = value; }
        }
        long lGiftID;
        public long lgiftID
        {
            get { return lGiftID; }
            set { lGiftID = value; }
        }
        long lClientID;
        public long lclientID
        {
            get { return lClientID; }
            set { lClientID = value; }
        }
    }
}
