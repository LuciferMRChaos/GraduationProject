using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// GreetingsSunrise 的摘要说明
/// </summary>
public class GreetingsSunrise:GreetingsClass
{
    public GreetingsSunrise()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public override string GreetingsMethod()
    {
        string Greetings = "等待朝阳";
        return Greetings;
    }
}