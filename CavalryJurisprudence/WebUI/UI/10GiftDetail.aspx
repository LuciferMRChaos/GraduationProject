<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="10GiftDetail.aspx.cs" Inherits="_10GiftDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="10GiftBlock/GiftDetail/GiftDetailCSS/style.css">
    <div class="wrapper">
        <div class="product-img">
            <asp:Image ID="IMGGiftImage" runat="server" Height="520" Width="360" ImageUrl="~/测试.jpg" />
        </div>
        <div class="product-info">
            <div class="product-text">
                <h1>
                    <asp:Label ID="LBLGiftName" runat="server" Text="礼品名"></asp:Label>
                </h1>
                <h2>
                    <asp:Label ID="LBLGiftTips" runat="server" Text="礼品简介" Font-Size="XX-Small"></asp:Label>
                </h2>

                <asp:Label ID="LBLGiftInfo" runat="server" Text="礼品介绍，可自动换行测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试" Font-Size="Small"></asp:Label>
            </div>
            <div class="product-price-btn">
                剩余<asp:Label ID="LBLGiftAmount" runat="server" Text="x"></asp:Label>件
          
          <br />
                仅需<asp:Label ID="LBLGiftPrice" runat="server" Text="价格" Font-Size="X-Small"></asp:Label>积分
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BTNGiftPurchase" runat="server" Text="立即抢购" OnClick="BTNGiftPurchase_Click" />
            </div>
        </div>
    </div>
</asp:Content>

