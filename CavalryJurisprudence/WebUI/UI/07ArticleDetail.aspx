<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="07ArticleDetail.aspx.cs" Inherits="ArticleDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="07ArticleBlock/ArticleDetail/ArticleDetailCSS/style.css" />
        <div class="page">
            <div class="wrapper">
                <div class="content-wrapper">
                    <div class="content">
                        <h1>
                            <asp:Label ID="LBLArticleTitle" runat="server" Text="文章标题"></asp:Label></h1>
                        <p><asp:Label ID="LBLArticleReadCount" runat="server" Text="阅读数："></asp:Label><asp:Label ID="LBLArticleReadCountNumber" runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="LBLArticleLiked" runat="server" Text="点赞数："></asp:Label><asp:Label ID="LBLArticleLikedCount" runat="server" Text="Label"></asp:Label>
                            <asp:Button ID="BTNArticleLiked" runat="server" Text="👍" OnClick="BTNArticleLiked_Click" />
                            <asp:Label ID="LBLArticleDisliked" runat="server" Text="点踩数："></asp:Label><asp:Label ID="LBLArticleDislikedCount" runat="server" Text="Label"></asp:Label>
                            <asp:Button ID="BTNArticleDisliked" runat="server" Text="😢" OnClick="BTNArticleDisliked_Click" />
                        </p>
                        <p>
                            <asp:Label ID="LBLArticleContent" runat="server" Text="文章内容"></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="sidebar">
                    <h2> <asp:Image ID="IMGArticleAuthorImage" runat="server" Width="125px" Height="150px" /></h2>
                    <p>发布人：<asp:Label ID="LBLAuthorName" runat="server" Text="发布人姓名"></asp:Label> </p>
                    <asp:Label ID="LBLAuthorTips" runat="server" Text="发布人简介"></asp:Label>
                </div>
            </div>
        </div>
    <asp:Button ID="BTNArticleCollect" runat="server" Text="收藏此文章" OnClick="BTNArticleCollect_Click" /><br />
    <asp:LinkButton ID="LBAutherInfoDetails" runat="server" OnClick="LBAutherInfoDetails_Click">想要了解作者更多信息？</asp:LinkButton>
</asp:Content>

