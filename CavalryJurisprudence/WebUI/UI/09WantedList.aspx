<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="09WantedList.aspx.cs" Inherits="_09WantedList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" href="09WantedBlock/WantedList/WantedListCSS/style.css">
    <div id="overlay">
        <!--在这里可以放单独的东西，上下滑动而其它地方不受影响-->
        <div align="center">
            <h1>
        <asp:GridView ID="GVWantedQuestionInfo" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="WantedID" DataSourceID="SqlDataSource1" EnableModelValidation="True" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="悬赏人" HeaderText="悬赏人" SortExpression="悬赏人" />
                <asp:BoundField DataField="悬赏标题" HeaderText="悬赏标题" SortExpression="悬赏标题" />
                <asp:BoundField DataField="所属领域" HeaderText="所属领域" SortExpression="所属领域" />
                <asp:HyperLinkField DataNavigateUrlFields="WantedID" DataNavigateUrlFormatString="09WantedDetail.aspx?WantedID={0}" DataTextField="悬赏金额" HeaderText="悬赏金额" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="SELECT DISTINCT WantedID , ClientName AS '悬赏人',WantedField AS '所属领域',WantedTitle AS '悬赏标题',WantedBounty AS '悬赏金额' FROM ClientInfo,CounsellorInfo,WantedAnswerInfo,WantedQuestionInfo WHERE ClientID=WantedPromoterID AND CounsellorID=ResponderIDFromCounsellorInfo"></asp:SqlDataSource>
        </h1>
        </div>
    </div>

    <div class="bgContain">
        <!--背景图片-->
        <img src="WebImages/09WantedListBackgroundImage.jpg" alt="背景图片" />
    </div>
</asp:Content>

