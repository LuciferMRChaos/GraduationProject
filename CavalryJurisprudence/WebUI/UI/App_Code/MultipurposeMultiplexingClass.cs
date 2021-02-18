using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
using BLL;

/// <summary>
/// 多功能复用类
/// 
/// 此类用于多页面 多次使用的类
/// 1.实现了分时段问候
/// 2.实现了加密
/// 3.实现了解密
/// 4.实现了相似度检测
/// 5.实现了简单的AI
/// </summary>
public class MultipurposeMultiplexingClass : System.Web.UI.Page
{
    public MultipurposeMultiplexingClass()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public string UsersGreetingsMethod(int iNowTime)
    {
        /**
         * 通过继承本方法，来实现【问候】功能
         * 使用【多态】来完成
         */
        string sGreetings = "";
        int iNowTimeGreetings = (int)(iNowTime / 4.0);
        GreetingsClass GreetingsSunrise = new GreetingsSunrise();
        GreetingsClass GreetingsGoodMorning = new GreetingsGoodMorning();
        GreetingsClass GreetingsGoodNoon = new GreetingsGoodNoon();
        GreetingsClass GreetingsGoodAfternoon = new GreetingsGoodAfternoon();
        GreetingsClass GreetingsGoodEvening = new GreetingsGoodEvening();
        GreetingsClass GreetingsGoodNight = new GreetingsGoodNight();

        switch (iNowTimeGreetings)
        {
            case 0: 
                sGreetings = GreetingsSunrise.GreetingsMethod();
                break;
            case 1: 
                sGreetings = GreetingsGoodMorning.GreetingsMethod();
                break;
            case 2:
                sGreetings = GreetingsGoodNoon.GreetingsMethod();
                break;
            case 3:
                sGreetings = GreetingsGoodAfternoon.GreetingsMethod();
                break;
            case 4:
                sGreetings = GreetingsGoodEvening.GreetingsMethod();
                break;
            case 5:
                sGreetings = GreetingsGoodNight.GreetingsMethod();
                break;
        }
        
        return sGreetings;
    }

    public int AdminHistoricalPasswordDetect(string sNewAdminPassword)
    {
        int iAdminPasswordHistoricalDetect = 0;
        AdminInfoBusiness AdminInfoBusiness = new AdminInfoBusiness();
        AdminInfoEntity AdminInfo = new AdminInfoEntity();
        AdminInfo = AdminInfoBusiness.GetAdminInfoByAdminAccount();

        string[] saAdminHistoricalPasswords = AdminInfo.saadminPasswords;//应该从数据库传过来数据
        int[] iaAdminHistoricalPasswordLength = new int[saAdminHistoricalPasswords.Length];//将历史密码的字符串型数组长度存入左边的int型数组

        for (int iCounter = 0; iCounter < saAdminHistoricalPasswords.Length; iCounter++)
        {
            iaAdminHistoricalPasswordLength[iCounter] = saAdminHistoricalPasswords[iCounter].Length;
        }
        //快速排序算法的应用
        int iTemporaryVariable;//临时整型变量，用于暂存长度
        string sTemporaryVariable;//临时字符串型变量，用于暂存字符串型数组中的单个字符串
        for (int iCounter = 1; iCounter < iaAdminHistoricalPasswordLength.Length; iCounter++)
        {
            if (iaAdminHistoricalPasswordLength[iCounter - 1] > iaAdminHistoricalPasswordLength[iCounter])
            {
                iTemporaryVariable = iaAdminHistoricalPasswordLength[iCounter];
                sTemporaryVariable = saAdminHistoricalPasswords[iCounter];
                for (int iCounterDeeper = iCounter; iCounterDeeper >= 0; iCounterDeeper--)
                {
                    if (iCounterDeeper > 0 && iaAdminHistoricalPasswordLength[iCounterDeeper - 1] > iTemporaryVariable)
                    {
                        iaAdminHistoricalPasswordLength[iCounterDeeper] = iaAdminHistoricalPasswordLength[iCounterDeeper - 1];
                        saAdminHistoricalPasswords[iCounterDeeper] = saAdminHistoricalPasswords[iCounterDeeper - 1];
                    }
                    else
                    {
                        iaAdminHistoricalPasswordLength[iCounterDeeper] = iTemporaryVariable;
                        saAdminHistoricalPasswords[iCounterDeeper] = sTemporaryVariable;
                        break;
                    }
                }
            }
        }
        //此时数组排好序了
        
        for(int iCounter=0;iCounter< saAdminHistoricalPasswords.Length; iCounter++)
        {
            //将传送来的数组（即新密码sNewAdminPassword）与旧密码数组进行比较
            if (sNewAdminPassword == saAdminHistoricalPasswords[iCounter])
            {
                iAdminPasswordHistoricalDetect++;//如果存在，则自增
            }
        }
        return iAdminPasswordHistoricalDetect;
    }

    public int SimilarityDetect(string sTargetString,string sStandbyString)
    {
        /**
         * 通过继承本方法，来实现【相似度检测】功能
         * 简单实现字符串相似度检测
         * 分为四个级别
         * 不同的相似度产生不同的解决方案，使用多态来完成
         */
        int iSolutionResult = 0;
        AttractedWarning AttractedWarningSolution1 = new Level1Warning();
        AttractedWarning AttractedWarningSolution2 = new Level2Warning();
        AttractedWarning AttractedWarningSolution3 = new Level3Warning();
        AttractedWarning AttractedWarningSolution4 = new Level4Warning();
        float fCount = 0;
        int iMinStringLength = sTargetString.Length < sStandbyString.Length ? sTargetString.Length : sStandbyString.Length;
        for (int i = 0; i < iMinStringLength; i++)
        {
            if (sTargetString[i] == sStandbyString[i])
            {
                fCount++;
            }
        }
        int iMaxStringLength = sTargetString.Length > sStandbyString.Length ? sTargetString.Length : sStandbyString.Length;
        float iResult = fCount / iMaxStringLength * 100;
        
        if (fCount / iMaxStringLength != 0)
        {
            
            if (iResult > 45 && iResult <= 55)
            {
                iSolutionResult=AttractedWarningSolution1.WarningMethod();
            }
            else if(iResult > 55 && iResult <= 75)
            {
                iSolutionResult = AttractedWarningSolution2.WarningMethod();
            }
            else if(iResult > 75 && iResult <= 85)
            {
                iSolutionResult = AttractedWarningSolution3.WarningMethod();
            }
            else if (iResult > 85 && iResult < 100)
            {
                iSolutionResult = AttractedWarningSolution4.WarningMethod();
            }
            else if (iResult == 100)
            {
                iSolutionResult = 100;
            }
        }
        else
        {
            iSolutionResult = 0;
        }

        return iSolutionResult;
    }

    private long[] Fibonacci(long laStandbyASCIIArrayLength)
    {
        //创建斐波那契数列数组
        
        long[] lFibonacci = new long[laStandbyASCIIArrayLength];
        
        for (int iCounter = 0; iCounter < laStandbyASCIIArrayLength; iCounter++)
        {
            if (iCounter == 0 || iCounter == 1)
            {
                lFibonacci[iCounter] = 1;
            }
            else
            lFibonacci[iCounter] = lFibonacci[iCounter - 1] + lFibonacci[iCounter - 2];
        }
        return lFibonacci;
    }
    public string DataEncryptMethod(string sEncryptPreparationData)
    {
        /**
         * 通过继承本方法，来实现【加密】功能
         */
        long[] laEncryptStandbyASCIIArray = new long[sEncryptPreparationData.Length];//待加密ASCII长整型数组
        for(int iCounter = 0; iCounter < sEncryptPreparationData.Length; iCounter++)
        {
            //将字符串中的每一个字符转换成ASCII码后存入laStandbyASCIIArray长整型数组中
            laEncryptStandbyASCIIArray[iCounter] = sEncryptPreparationData[iCounter];
        }
        long[] lFibonacciEcnryptCatalyst = Fibonacci(laEncryptStandbyASCIIArray.Length);//设置暂存斐波那契数列数组,调用斐波那契数列数组作为加密催化剂
        long[] lAfterCalculationArray = new long[laEncryptStandbyASCIIArray.Length];//设置长整型数组以存储计算后的数据
        for (int iCounter = 0; iCounter < laEncryptStandbyASCIIArray.Length; iCounter++)
        {
            //让原始的ASCII码长整型数组与斐波那契数列数组相加，从而实现简单的数据加密
            lAfterCalculationArray[iCounter] = laEncryptStandbyASCIIArray[iCounter] + lFibonacciEcnryptCatalyst[iCounter];
        }
        string sAfterEncryptData="";//设置字符串以使加密后的数据可以存储在数据库中
        for(int iCounter=0;iCounter< lAfterCalculationArray.Length; iCounter++)
        {
            sAfterEncryptData += (lAfterCalculationArray[iCounter].ToString() + ',');
        }
        return sAfterEncryptData;
    }
    public string DataDecipherMethod(string sDecipherPreparationData)
    {
        /**
         * 通过继承本方法，来实现【解密】功能
         */
        string sAfterDecipherData = "";
        string[] saDecipherStandbyStringArray = sDecipherPreparationData.Split(new char[] { ',' });//将加密后的字符串分离成字符串型数组

        long[] laDecipherStandbyASCIIArray = new long[saDecipherStandbyStringArray.Length];//设置长整型数组，用以暂存转回数字的待解密的长整型数组
        for(int iCounter=0;iCounter< saDecipherStandbyStringArray.Length-1;iCounter++)
        {
            laDecipherStandbyASCIIArray[iCounter] = long.Parse(saDecipherStandbyStringArray[iCounter]);
        }
        long[] laFibonacciDecipherCatalyst = Fibonacci(saDecipherStandbyStringArray.Length);
        long[] lAfterCalculationArray = new long[saDecipherStandbyStringArray.Length];
        for(int iCounter=0;iCounter< lAfterCalculationArray.Length - 1; iCounter++)
        {
            lAfterCalculationArray[iCounter] = laDecipherStandbyASCIIArray[iCounter] - laFibonacciDecipherCatalyst[iCounter];
        }

        for(int iCounter=0;iCounter< lAfterCalculationArray.Length; iCounter++)
        {
            sAfterDecipherData += (char)lAfterCalculationArray[iCounter];
        }
        return sAfterDecipherData;
    }


    public string Oracle(string sSearchPreparationData)
    {
        /**
         * 浅层次AI算法
         * 将传来的字符串与原有字符串型数组比较
         * 如果符合，则输出
         * 如果有多个符合，那么只输出最后一个
         */
        long lResult = 0;
        string sResult = "";
        string[] saTargetString = { "律师", "悬赏", "文章", "积分" };
        for(int iCounterLevel1 = 0; iCounterLevel1 < saTargetString.Length; iCounterLevel1++)
        {
            //进阶：改成数组
            string sTargetStringArraySubscript = saTargetString[iCounterLevel1];//将第iCounter个元素转换成数组
            long lTargetStringArraySubscript1 = sTargetStringArraySubscript[0];//将第【0】个元素转换成long型
            long lTargetStringArraySubscript2 = sTargetStringArraySubscript[1];//将第【1】个元素转换成long型

            string sTargetStringArraySubscript1 = lTargetStringArraySubscript1.ToString();//将第【0】个元素转换成string型
            string sTargetStringArraySubscript2 = lTargetStringArraySubscript2.ToString();//将第【1】个元素转换成string型

            long lTargetString = long.Parse(sTargetStringArraySubscript1 + sTargetStringArraySubscript2);//将元素相加得到新的字符串，是一串数字,再将字符串转换成long型

            for (int iCounterLevel2 = 0; iCounterLevel2 < sSearchPreparationData.Length - 1; iCounterLevel2++)
            {
                //遍历sSearchPreparationData即传过来的字符串
                //将传过来的字符串，前一个和后一个捏为一个新的字符串，如01，12，23这样，再转成数字进行比较

                long lSearchPreparationDataA = sSearchPreparationData[iCounterLevel2];
                long lSearchPreparationDataB = sSearchPreparationData[iCounterLevel2 + 1];

                string sSearchPreparationDataA = lSearchPreparationDataA.ToString();
                string sSearchPreparationDataB = lSearchPreparationDataB.ToString();

                long lSearchPreparationData = long.Parse(sSearchPreparationDataA + sSearchPreparationDataB);
                if(lTargetString== lSearchPreparationData)
                {
                    lResult = lTargetString;
                }
                else
                {
                    sResult = "您的输入有误，请重新输入！";
                }
            }
        }

        //通过得到的数，来决定打向哪个网页
        switch (lResult)
        {
            case 2445924072:
                System.Web.HttpContext.Current.Response.Redirect("06CounsellorList.aspx");
                break;
            case 2474836175:
                System.Web.HttpContext.Current.Response.Redirect("09WantedList.aspx");
                break;
            case 2599131456:
                System.Web.HttpContext.Current.Response.Redirect("07ArticleList.aspx");
                break;
            case 3121520998:
                System.Web.HttpContext.Current.Response.Redirect("10GiftList.aspx");
                break;
        }
        return sResult;
    }
}