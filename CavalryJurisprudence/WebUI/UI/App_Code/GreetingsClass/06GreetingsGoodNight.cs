using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// GreetingsGoodNight 的摘要说明
/// </summary>
public class GreetingsGoodNight:GreetingsClass
{
    public GreetingsGoodNight()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public override string GreetingsMethod()
    {
        string Greetings = "该休息了！";
        return Greetings;
    }
}