using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// GreetingsGoodNoon 的摘要说明
/// </summary>
public class GreetingsGoodNoon:GreetingsClass
{
    public GreetingsGoodNoon()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public override string GreetingsMethod()
    {
        string Greetings = "中午好！";
        return Greetings;
    }
}