<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="09WantedDetail.aspx.cs" Inherits="_09WantedDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style4 {
            height: 31px;
            text-align: left;
        }
        .auto-style5 {
            height: 162px;
            text-align: left;
        }
        .auto-style6 {
            text-align: center;
            width: 396px;
        }
        .auto-style7 {
            height: 84px;
            text-align: center;
        }
        .auto-style8 {
            width: 100%;
            height: 112px;
        }
        .auto-style9 {
            margin-left: 0px;
        }
        .auto-style10 {
            width: 100%;
            height: 261px;
        }
        .auto-style11 {
            width: 151px;
        }
        .auto-style12 {
            width: 181px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style6" rowspan="2">
                悬赏人姓名：<asp:Label ID="LBLClientName" runat="server" Text="悬赏人姓名"></asp:Label><br />
                <br />
                <asp:Button ID="BTNWantedInfoUpdate" runat="server" Text="修改悬赏信息" OnClick="BTNWantedInfoUpdate_Click" />
            </td>
            <td class="auto-style4">
                悬赏题目：<asp:TextBox ID="TBWantedTitle" runat="server"></asp:TextBox>
                &nbsp;
                悬赏金额：<asp:DropDownList runat="server" ID="DDLWantedBounty"></asp:DropDownList>万元&nbsp;
                悬赏领域：<asp:Label ID="LBLWantedField" runat="server" Text="领域"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:TextBox ID="TBWantedContent" runat="server" Height="147px" Width="961px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <link rel="stylesheet" href="09WantedBlock/WantedDetail/WantedDetailCSS/style.css">



    <div id="overlay">
        <!--在这里可以放单独的东西，上下滑动而其它地方不受影响-->

        <asp:DataList ID="DLWantedAnswerInfo" runat="server" DataSourceID="SqlDataSource1" DataKeyField="AnswerID" OnItemCommand="DLWantedAnswerInfo_ItemCommand" OnItemCreated="DLWantedAnswerInfo_ItemCreated" >
            <ItemTemplate>
                <table class="auto-style10">
                    <tr>
                        <td class="auto-style11">
                            <asp:Image ID="IMGResponderImage" runat="server" Height="213px" Width="153px" ImageUrl='<%# Eval("CounsellorImage") %>' />
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="TBRespondContent" runat="server" Height="212px" Width="676px" ReadOnly="True" Text='<%# Eval("RespondContent") %>' TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            <asp:Label ID="LBLRespondName" runat="server" Text='<%# Eval("CounsellorName") %>'></asp:Label>
                        </td>
                        <td class="auto-style12">
                            <asp:Label ID="LBLAnswer" runat="server" Text="最佳答案"  Visible='<%# Convert .ToInt32 (Eval("SelectedAsAnswer"))>0?true:false %>'></asp:Label>
                        </td>
                        <td>
                            点赞数：<br /> <asp:Button ID="BTNRespondLikedCount" runat="server" Text='<%# Eval("RespondLikedCount") %>' CommandName="BTNRespondLikedCount"/>
                        </td>
                        <td>
                            点踩数：<br /> 
                            <asp:Button ID="BTNRespondDislikedCount" runat="server" Text='<%# Eval("RespondDislikedCount") %>' CommandName="BTNRespondDislikedCount"/>
                        </td>
                        <td>
                            <asp:Button ID="BTNSelectAsAnswer" runat="server" CommandArgument='<%# Eval("AnswerID") %>' Text="选为答案" CommandName="BTNSelectAsAnswer" />
                            <br />
                            <asp:Label ID="LBLAnswerID" runat="server" Text='<%# Eval("AnswerID") %>' Visible="false" CommandName="LBLAnswerID" ></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="SELECT [CounsellorName],[AnswerID],[SelectedAsAnswer], [CounsellorImage], [RespondContent], [RespondLikedCount], [RespondDislikedCount] FROM [WantedAnswerInfo],[CounsellorInfo] WHERE [CounsellorID]=[ResponderIDFromCounsellorInfo] and ([WantedIDFromWantedQuestionInfo] = @WantedIDFromWantedQuestionInfo)">
            <SelectParameters>
                <asp:QueryStringParameter Name="WantedIDFromWantedQuestionInfo" QueryStringField="WantedID" Type="Int64" />
            </SelectParameters>
        </asp:SqlDataSource>

    </div>

    <div class="bgContain">
        <!--背景图片-->
        <img src="WebImages/09WantedDetailBackgroundImage.jpg" alt="背景图片" />
    </div>

    <div>
        
        <table class="auto-style8">
            <tr>
                <td class="auto-style7">
                    <asp:TextBox ID="TBReply" runat="server" CssClass="auto-style9" Height="75px" Width="961px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="BTNReply" runat="server" Text="我来回答" />
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>

