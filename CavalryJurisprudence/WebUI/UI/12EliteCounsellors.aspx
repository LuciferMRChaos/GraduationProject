<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="12EliteCounsellors.aspx.cs" Inherits="_12EliteCounsellors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="12EliteCounsellors/EliteCounsellorsCSS/style.css">
    <div class="wrapper">
        <div class="box">
            <div class="description">
                <h2>
                    <asp:Label ID="LBLFirstPlaceElite" runat="server" Text="第一精英"></asp:Label>
                </h2>
                <asp:Image ID="IMGFirstPlaceElite" runat="server" ImageUrl="~/测试.jpg" Height="254px" Width="200px" />
                <ul class="list">
                    <asp:Button ID="BTNFirstPlaceElite" runat="server" Text="查看律师" OnClick="BTNFirstPlaceElite_Click" />
                </ul>
            </div>
        </div>
        <div class="box">
            <div class="description">
                <h2>
                    <asp:Label ID="LBLSecondPlaceElite" runat="server" Text="第二精英"></asp:Label>
                </h2>
                <asp:Image ID="IMGSecondPlaceElite" runat="server" ImageUrl="~/测试.jpg" Height="254px" Width="200px" />
                <ul class="list">
                    <asp:Button ID="BTNSecondPlaceElite" runat="server" Text="查看律师" OnClick="BTNSecondPlaceElite_Click" />
                </ul>
            </div>
        </div>
        <div class="box">
            <div class="description">
                <h2>
                    <asp:Label ID="LBLThirdPlaceElite" runat="server" Text="第三精英"></asp:Label>
                </h2>
                <asp:Image ID="IMGThirdPlaceElite" runat="server" ImageUrl="" Height="254px" Width="200px" />
                <ul class="list">
                    <asp:Button ID="BTNThirdPlaceElite" runat="server" Text="查看律师" OnClick="BTNThirdPlaceElite_Click" />
                </ul>
            </div>
        </div>
    </div>
    <script src="12EliteCounsellors/EliteCounsellorsJS/vanilla-tilt.min.js"></script>
    <script src="12EliteCounsellors/EliteCounsellorsJS/script.js"></script>
</asp:Content>