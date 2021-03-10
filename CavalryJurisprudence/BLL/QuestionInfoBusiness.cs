using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;
using System.Data;

namespace BLL
{
    public class QuestionInfoBusiness
    {
        public int QuestionInfoAdd(QuestionInfoEntity QuestionInfo)//增加问题方法
        {
            string sSQLText = "insert into QuestionInfo values('"+QuestionInfo.squestionField+"','"+QuestionInfo.iquestionLevel+"','"+QuestionInfo.squestionTitle+"','"+QuestionInfo.squestionSelectionA+"','"+QuestionInfo.squestionSelectionB+"','"+QuestionInfo.squestionSelectionC+"','"+QuestionInfo.squestionSelectionD+"','"+QuestionInfo.ccorrectAnswer+"')";
            int iReturnedValue = DAL.DataBaseAccess.ExecuteSql(sSQLText);
            return iReturnedValue;
        }
        public int GetQuestionAmountByQuestionFieldAndLevel(string sQuestionField,int iQuestionLevel)//计算所有符合条件的问题数量
        {
            string sSQLText = "select count(*) from QuestionInfo where QuestionField='"+ sQuestionField + "' and QuestionLevel='"+ iQuestionLevel + "'";
            object ReturnValue = DataBaseAccess.GetOneData(sSQLText);
            int iReturnValue = int.Parse(ReturnValue.ToString());
            return iReturnValue;//获取符合条件的ID数量
        }

        public int[] GetAllQuestionID(string sQuestionField, int iQuestionLevel)
        {
            int iAllQuestionIDAmount = GetQuestionAmountByQuestionFieldAndLevel(sQuestionField, iQuestionLevel);
            int[] iaAllQuestionID = new int[iAllQuestionIDAmount];
            string sSQLText = "select QuestionID from QuestionInfo where QuestionField='"+ sQuestionField + "' and QuestionLevel='"+ iQuestionLevel + "'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);
            if (dataTable.Rows.Count > 0)
            {
                for (int iCounter = 0; iCounter < iAllQuestionIDAmount; iCounter++)
                {
                    iaAllQuestionID[iCounter] = int.Parse("" + dataTable.Rows[iCounter][0]);
                }
            }
            return iaAllQuestionID;
        }

        public int RandomQuestionID(string sQuestionField, int iQuestionLevel)
        {
            int[] iaAllQuestionID = GetAllQuestionID(sQuestionField, iQuestionLevel);
            Random RandomQuestionID = new Random();
            int iIndex = RandomQuestionID.Next(iaAllQuestionID.Length);
            return iaAllQuestionID[iIndex];
        }

        public QuestionInfoEntity GETQuestionInfoByID(long lQuestionID)//通过ID,找出符合的问题
        {
            string sSQLText = "select * from QuestionInfo where QuestionID='"+ lQuestionID + "'";
            DataTable dataTable = DAL.DataBaseAccess.GetDataSet(sSQLText);
            QuestionInfoEntity QuestionInfo = new QuestionInfoEntity();
            if (dataTable.Rows.Count > 0)
            {
                QuestionInfo.lquestionID = int.Parse("" + dataTable.Rows[0][0]);
                QuestionInfo.squestionField = "" + dataTable.Rows[0][1];
                QuestionInfo.iquestionLevel = int.Parse("" + dataTable.Rows[0][2]);
                QuestionInfo.squestionTitle= "" + dataTable.Rows[0][3];
                QuestionInfo.squestionSelectionA= "" + dataTable.Rows[0][4];
                QuestionInfo.squestionSelectionB= "" + dataTable.Rows[0][5];
                QuestionInfo.squestionSelectionC = "" + dataTable.Rows[0][6];
                QuestionInfo.squestionSelectionD = "" + dataTable.Rows[0][7];
                QuestionInfo.ccorrectAnswer = char.Parse("" + dataTable.Rows[0][8]);
            }
            return QuestionInfo;
        }
    }
}
