<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogsCompile.aspx.cs" Inherits="Logs_LogsCompile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1200px;
            height: 980px;
        }
        .auto-style2 {
            height: 165px;
        }
        .auto-style3 {
            height: 165px;
            width: 434px;
        }
        .auto-style4 {
            width: 434px;
        }
        .auto-style5 {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3"><asp:Label ID="LBLDate" runat="server" Text="日期："></asp:Label>
&nbsp;<asp:DropDownList ID="DDLYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLYear_SelectedIndexChanged">
            </asp:DropDownList>
            年<asp:DropDownList ID="DDLMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLMonth_SelectedIndexChanged">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            月<asp:DropDownList ID="DDLDay" runat="server">
            </asp:DropDownList>
            日<br />
            <asp:Label ID="LBLExpect" runat="server" Text="预计任务："></asp:Label>
            <asp:TextBox ID="TBReality" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LBLReality" runat="server" Text="实际完成："></asp:Label>
            <asp:TextBox ID="TBExpect" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LBLFailReason" runat="server" Text="未完成原因："></asp:Label>
            <asp:TextBox ID="TBFailReason" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text="技巧与经验："></asp:Label>
            <asp:TextBox ID="TBExperience" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="BTNConfirm" runat="server" OnClick="BTNConfirm_Click" Text="写入日志" /></td>
                    <td class="auto-style2">
                        <asp:GridView ID="GVLogs" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style5" DataSourceID="SqlDataSource1" EnableModelValidation="True" ForeColor="#333333" GridLines="None" PageSize="5">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="LogID" HeaderText="LogID" InsertVisible="False" ReadOnly="True" SortExpression="LogID" />
                                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                                <asp:BoundField DataField="Expect" HeaderText="Expect" SortExpression="Expect" />
                                <asp:BoundField DataField="Reality" HeaderText="Reality" SortExpression="Reality" />
                                <asp:BoundField DataField="FailReason" HeaderText="FailReason" SortExpression="FailReason" />
                                <asp:BoundField DataField="Experience" HeaderText="Experience" SortExpression="Experience" />
                            </Columns>
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="SELECT * FROM [DevelopLogs]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            
        </div>
    </form>
</body>
</html>
