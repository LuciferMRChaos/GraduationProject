using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// GreetingsGoodEvening 的摘要说明
/// </summary>
public class GreetingsGoodEvening:GreetingsClass
{
    public GreetingsGoodEvening()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public override string GreetingsMethod()
    {
        string Greetings = "晚上好！";
        return Greetings;
    }
}