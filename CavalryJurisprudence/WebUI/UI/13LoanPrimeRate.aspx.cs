using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _13LoanPrimeRate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StartInfoSelection();
        EndInfoSelection();
    }
    private int DayJudgementSelection(int iYear, int iMonth)
    {
        switch (iMonth)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                return 31;
            case 4:
            case 6:
            case 9:
            case 11:
                return 30;
            case 2:
                if ((iYear % 4 == 0 && iYear % 100 != 0) || (iYear % 400 == 0))
                {
                    return 29;
                }
                else
                {
                    return 28;
                }
            default: return 30;
        }
    }
    //以下是开始日期相关
    private void StartInfoSelection()
    {
        if (!IsPostBack)
        {
            for (int iStartYear = 2019; iStartYear < 2121; iStartYear++)//绑定一百年
            {
                DDLStartYear.Items.Add(iStartYear.ToString());
            }
            for (int iStartDay = 1; iStartDay <= DayJudgementSelection(int.Parse(DDLStartYear.SelectedValue), int.Parse(DDLStartMonth.SelectedValue)); iStartDay++)
            {
                DDLStartDay.Items.Add(iStartDay.ToString());
            }
        }
    }

    protected void DDLStartYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLStartDay.Items.Clear();
        for (int iStartDay = 1; iStartDay <= DayJudgementSelection(int.Parse(DDLStartYear.SelectedValue), int.Parse(DDLStartMonth.SelectedValue)); iStartDay++)
        {
            DDLStartDay.Items.Add(iStartDay.ToString());
        }
    }
    //当重选月日后，重新选择日的信息
    protected void DDLStartMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLStartDay.Items.Clear();
        for (int iStartDay = 1; iStartDay <= DayJudgementSelection(int.Parse(DDLStartYear.SelectedValue), int.Parse(DDLStartMonth.SelectedValue)); iStartDay++)
        {
            DDLStartDay.Items.Add(iStartDay.ToString());
        }
    }
    //以下是结束日期相关
    private void EndInfoSelection()
    {
        if (!IsPostBack)
        {

            for (int iEndYear = int.Parse(DDLStartYear.SelectedValue); iEndYear < 2121; iEndYear++)//绑定一百年
            {
                DDLEndYear.Items.Add(iEndYear.ToString());
            }
            for (int iEndDay = 1; iEndDay <= DayJudgementSelection(int.Parse(DDLEndYear.SelectedValue), int.Parse(DDLEndMonth.SelectedValue)); iEndDay++)
            {
                DDLEndDay.Items.Add(iEndDay.ToString());
            }
            DDLStartYear.SelectedValue = 2019.ToString();//默认显示日期
        }
    }

    protected void DDLEndYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLEndDay.Items.Clear();
        for (int iEndDay = 01; iEndDay <= DayJudgementSelection(int.Parse(DDLEndYear.SelectedValue), int.Parse(DDLEndMonth.SelectedValue)); iEndDay++)
        {
            DDLEndDay.Items.Add(iEndDay.ToString());
        }
    }

    protected void DDLEndMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLEndDay.Items.Clear();
        for (int iEndDay = 01; iEndDay <= DayJudgementSelection(int.Parse(DDLEndYear.SelectedValue), int.Parse(DDLEndMonth.SelectedValue)); iEndDay++)
        {
            DDLEndDay.Items.Add(iEndDay.ToString());
        }
    }

    protected void BTNTest_Click(object sender, EventArgs e)
    {
        DateTime StartDateTime = new DateTime();
        string sStartYear = DDLStartYear.SelectedItem.Text;
        string sStartMonth = DDLStartMonth.SelectedItem.Text.PadLeft(2, '0');//PadLeft,补位，比如1补成01
        string sStartDay = DDLStartDay.SelectedItem.Text.PadLeft(2, '0');
        string sStartTime = sStartYear + sStartMonth + sStartDay;
        StartDateTime = DateTime.ParseExact(sStartTime, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

        DateTime EndDateTime = new DateTime();
        string sEndYear = DDLEndYear.SelectedItem.Text;
        string sEndMonth = DDLEndMonth.SelectedItem.Text.PadLeft(2, '0');
        string sEndDay = DDLEndDay.SelectedItem.Text.PadLeft(2, '0');
        string sEndTime = sEndYear + sEndMonth + sEndDay;
        EndDateTime = DateTime.ParseExact(sEndTime, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

        Label1.Text = StartDateTime.ToString();
        Label2.Text = EndDateTime.ToString();
        Label3.Text = (EndDateTime - StartDateTime).ToString();

        string[] arr = { "1", "2", "3", "4", "5", "\r\n" };
        for (int i = 0; i < arr.Length; i++)
        {//可输出数组
            //TextBox1.Text += arr[i].ToString();
        }
    }
}