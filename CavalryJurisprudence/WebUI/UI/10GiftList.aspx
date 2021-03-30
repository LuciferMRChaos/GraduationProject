<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="10GiftList.aspx.cs" Inherits="_10GiftList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" href="10GiftBlock/GiftList/GiftListCSS/style.css">
    <div id="overlay">
        <!--在这里可以放单独的东西，上下滑动而其它地方不受影响-->
        <h1>礼品商城</h1>
        <asp:DataList ID="DLGiftList" runat="server" DataSourceID="SqlDataSource2" RepeatColumns="5">
            <ItemTemplate>
                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:Image ID="IMGGiftImage" runat="server" Height="200px" ImageUrl='<%# Eval("GiftImage") %>' Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HLGiftName" runat="server" NavigateUrl='<%# Eval("GiftID", "10GiftDetail.aspx?GiftID={0}") %>' Text='<%# Eval("GiftName") %>' ForeColor="White"></asp:HyperLink>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="SELECT [GiftID], [GiftName], [GiftImage] FROM [GiftInfo]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <asp:Label ID="Label1" runat="server" Text="测试测试测试"></asp:Label>
        <p>第二段文字</p>
    </div>

    <div class="bgContain">
        <!--背景图片-->
        <img src="WebImages/06CounsellorListBackgroundImage.jpg" alt="背景图片" />
    </div>
</asp:Content>

