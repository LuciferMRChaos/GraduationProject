<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test-warning.aspx.cs" Inherits="test_warning" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 164px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox><br />
            <asp:Label ID="Label1" runat="server" Text="测试"></asp:Label>
        </div>
    </form>
</body>
</html>
