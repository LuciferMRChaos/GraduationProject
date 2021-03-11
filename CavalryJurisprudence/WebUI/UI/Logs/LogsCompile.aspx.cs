using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

public partial class Logs_LogsCompile : System.Web.UI.Page
{//月的item由前台绑定
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int year = 1980; year <= 2030; year++)
            {
                DDLYear.Items.Add(year.ToString());//后台绑定item
            }

            DDLYear.SelectedValue = DateTime.Now.Year.ToString();//设置默认为今年
            DDLMonth.SelectedValue = DateTime.Now.Month.ToString();//设置默认为今月

            //绑定day的天数
            int i;
            for (i = 1; i <= Day(int.Parse(DDLYear.SelectedValue), int.Parse(DDLMonth.SelectedValue)); i++)
            {
                DDLDay.Items.Add(i.ToString());
            }

            DDLDay.SelectedValue = DateTime.Now.Day.ToString();//设置默认为今天
            /*为什么放在这里？上面设置了日的日期，如果放在年月那里就会被覆盖掉*/


        }
    }

    private int Day(int year,int month)//设置“日”的相关操作
    {
        switch (month)
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
                if((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))//判断是否闰年
                {
                    return 29;
                }
                return 28;
            default:return 30;
        }
    }

    protected void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLDay.Items.Clear();
        int i;
        for (i = 1; i <= Day(int.Parse(DDLYear.SelectedValue), int.Parse(DDLMonth.SelectedValue)); i++)
        {
            DDLDay.Items.Add(i.ToString());
        }
    }

    protected void DDLMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLDay.Items.Clear();
        int i;
        for (i = 1; i <= Day(int.Parse(DDLYear.SelectedValue), int.Parse(DDLMonth.SelectedValue)); i++)
        {
            DDLDay.Items.Add(i.ToString());
        }
    }

    protected void BTNConfirm_Click(object sender, EventArgs e)
    {
        string Date = DDLYear.SelectedValue + '-' + DDLMonth.SelectedItem.Text + '-' + DDLDay.Items[DDLDay.SelectedIndex].Text;//测试显示
        DevelopLogs DevelopLogsEntity = new DevelopLogs();
        DevelopLogsEntity.Date = Date;
        DevelopLogsEntity.Except = TBExpect.Text;
        DevelopLogsEntity.Reality = TBReality.Text;
        DevelopLogsEntity.FailReason = TBFailReason.Text;
        DevelopLogsEntity.Experience = TBExperience.Text;

        DevelopLogsBusiness DevelopLogsBusiness = new DevelopLogsBusiness();
        int ReturnedValue=DevelopLogsBusiness.DevelopLogsCompile(DevelopLogsEntity);
        if (ReturnedValue > 0)
        {
            Response.Write("<script>alert('日志填写完毕！')</script>");
        }
    }
}