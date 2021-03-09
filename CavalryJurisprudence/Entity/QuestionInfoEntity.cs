using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class QuestionInfoEntity
    {
        long lQuestionID;
        public long lquestionID
        {
            get { return lQuestionID; }
            set { lQuestionID = value; }
        }
        string sQuestionField;
        public string squestionField
        {
            get { return sQuestionField; }
            set { sQuestionField = value; }
        }
        int iQuestionLevel;
        public int iquestionLevel
        {
            get { return iQuestionLevel; }
            set { iQuestionLevel = value; }
        }
        string sQuestionTitle;
        public string squestionTitle
        {
            get { return sQuestionTitle; }
            set { sQuestionTitle = value; }
        }
        string sQuestionSelectionA;
        public string squestionSelectionA
        {
            get { return sQuestionSelectionA; }
            set { sQuestionSelectionA = value; }
        }
        string sQuestionSelectionB;
        public string squestionSelectionB
        {
            get { return sQuestionSelectionB; }
            set { sQuestionSelectionB = value; }
        }
        string sQuestionSelectionC;
        public string squestionSelectionC
        {
            get { return sQuestionSelectionC; }
            set { sQuestionSelectionC = value; }
        }
        string sQuestionSelectionD;
        public string squestionSelectionD
        {
            get { return sQuestionSelectionD; }
            set { sQuestionSelectionD = value; }
        }
        char cCorrectAnswer;
        public char ccorrectAnswer
        {
            get { return cCorrectAnswer; }
            set { cCorrectAnswer = value; }
        }

        int[] iaQuestionIDsArray = new int[3];
        public int[] iaquestionIDsArray
        {
            get { return iaQuestionIDsArray; }
            set { iaQuestionIDsArray = value; }
        }
    }
}
