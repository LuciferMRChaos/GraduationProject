<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test-Xiangsidu.aspx.cs" Inherits="test_Xiangsidu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            第一个字符串：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            第二个字符串：<asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True"></asp:TextBox><br />
            相似度检测：<asp:Label ID="Label1" runat="server" Text="待定"></asp:Label>
        </div>
    </form>
</body>
</html>
