<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="08CompanyInfo.aspx.cs" Inherits="CompanyInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="08CompanyInfoBlock/CompanyInfoCSS/style.css">

    <div class="container">
        <div class="card">

            <div class="front side"><!--正面-->
                <h1 class="logo">公司信息</h1>
            </div>

            <div class="back side"><!--背面-->
                客户数：<asp:Label ID="LBLClientAmount" runat="server" Text="客户数："></asp:Label>人
                <br />
                律师数：<asp:Label ID="LBLCounsellorAmount" runat="server" Text="律师数"></asp:Label>人
                <br />
            </div>
        </div>
    </div>
</asp:Content>

