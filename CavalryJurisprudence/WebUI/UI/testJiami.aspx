<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testJiami.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            输入的字符串：<asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox><br />
            加密后的字符串：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
            解密后的字符串：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
            字符串长度：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
            ???<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
