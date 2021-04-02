<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="13LoanPrimeRate.aspx.cs" Inherits="_13LoanPrimeRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="13LoanPrimeRate/LoanPrimeRateCSS/style.css">
    </head>
    <body>
        <section>
            <h1>LPR利率计算工具</h1>
            <div>
            <asp:DropDownList ID="DDLStartYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLStartYear_SelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList ID="DDLStartMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLStartMonth_SelectedIndexChanged">
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
            <asp:DropDownList ID="DDLStartDay" runat="server"></asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Text="开始日期"></asp:Label>
            <br />
            <asp:DropDownList ID="DDLEndYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLEndYear_SelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList ID="DDLEndMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLEndMonth_SelectedIndexChanged">
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
            <asp:DropDownList ID="DDLEndDay" runat="server"></asp:DropDownList>
            <asp:Label ID="Label2" runat="server" Text="结束日期"></asp:Label>
            <asp:Button ID="BTNTest" runat="server" Text="Button" OnClick="BTNTest_Click" />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            
            
        </div>
            <div class="tbl-header">
                <table cellpadding="0" cellspacing="0" border="0">
                    <thead>
                        <tr>
                            <th>时间</th>
                            <th>1年利率(%)</th>
                            <th>5年利率(%)</th>
                            <th>当月利息(元)</th>
                            <th>最大利率(元)</th>
                        </tr>
                    </thead>
                </table>
            </div>
            <div class="tbl-content">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tbody>
                        <tr>
                            <td>2019年8月20日</td>
                            <td>4.25</td>
                            <td>4.85</td>
                            <td>0</td>
                            <td>0</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </section>
        <div class="Involution">
            结果仅供参考
        </div>
        <script src="13LoanPrimeRate/LoanPrimeRateJS/script.js"></script>
</asp:Content>

