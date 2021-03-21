<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="06CounsellorList.aspx.cs" Inherits="_06CounsellorList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="06CounsellorBlock/CounsellorList/CounsellorListCSS/style.css">
    <div id="overlay">
        <!--在这里可以放单独的东西，上下滑动而其它地方不受影响-->
        <h1>律师列表</h1>
        <p>愿我们的律师可以为您排忧解难！</p>
        <asp:DataList ID="DTCounsellorsList" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="5">
            <ItemTemplate>
                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:Image ID="IMGCounsellorImage" runat="server" ImageUrl='<%# Eval("CounsellorImage") %>' Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HLCounsellorName" runat="server" NavigateUrl='<%# Eval("CounsellorID", "06CounsellorDetail.aspx?CounsellorID={0}") %>' Text='<%# Eval("CounsellorName") %>'></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LBLCounsellorLevel" runat="server" Text='<%# Eval("CounsellorLevel") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="SELECT [CounsellorID], [CounsellorName], [CounsellorLevel], [CounsellorImage] FROM [CounsellorInfo] ORDER BY [CounsellorLevel] DESC"></asp:SqlDataSource>
    </div>

    <div class="bgContain">
        <!--背景图片-->
        <img src="WebImages/06CounsellorListBackgroundImage.jpg" alt="背景图片" />
    </div>
</asp:Content>