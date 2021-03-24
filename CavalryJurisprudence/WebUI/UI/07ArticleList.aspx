<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="07ArticleList.aspx.cs" Inherits="_07ArticleList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="07ArticleBlock/ArticleList/ArticleListCSS/style.css">

    <div class="header">
        <div class="inner-header flex">
            <asp:GridView ID="GVArticleTitle" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ArticleID" DataSourceID="SqlDataSource1" EnableModelValidation="True">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="ArticleID" DataNavigateUrlFormatString="07ArticleDetail.aspx?ArticleID={0}" DataTextField="ArticleTitle" HeaderText="文章标题" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="SELECT [ArticleID], [ArticleTitle] FROM [ArticleInfo]"></asp:SqlDataSource>
        </div>
        <div>
            <svg class="waves"
                viewBox="0 24 150 28" preserveAspectRatio="none" shape-rendering="auto">
                <defs>
                    <path id="gentle-wave" d="M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z" />
                </defs>
                <g class="parallax">
                    <!--海浪-->
                    <use xlink:href="#gentle-wave" x="48" y="0" fill="rgba(255,255,255,0.7" />
                    <use xlink:href="#gentle-wave" x="48" y="3" fill="rgba(255,255,255,0.5)" />
                    <use xlink:href="#gentle-wave" x="48" y="5" fill="rgba(255,255,255,0.3)" />
                    <use xlink:href="#gentle-wave" x="48" y="7" fill="#fff" />
                </g>
            </svg>
        </div>
    </div>
    <div class="content flex">
        <p>封底</p>
    </div>
</asp:Content>

