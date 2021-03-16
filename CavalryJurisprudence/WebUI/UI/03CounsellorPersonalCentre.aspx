<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="03CounsellorPersonalCentre.aspx.cs" Inherits="CounsellorPersonCentre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style4 {
            width: 362px;
        }
        .auto-style5 {
            width: 218px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="03PersonalCentreBlock/CounsellorPersonalCentre/CounsellorPersonalCentreCSS/style.css">
    <script type="text/javascript" src="03PersonalCentreBlock/CounsellorPersonalCentre/CounsellorPersonalCentreJS/jquery.min.js"></script>
    <div class="body admin-panel clearfix">
        <div class="slidebar">
            <div class="logo" align="center">
                <asp:Image ID="IMGCounsellorImageDisplay" runat="server" Height="145px" Width="120px" />
            </div>
            <ul class="leftLinks">
                <li><a class="dashboard" href="#">个人信息</a></li>
                <li><a class="fnolrules" href="#">我的客户</a></li>
                <li><a class="cwfrules" href="#">等级提升</a></li>
                <li><a class="fnolguidelines" href="#">撰写文章</a></li>
                <li><a class="cwfguidelines" href="#">文章列表</a></li>
                <li><a class="companylist" href="#">申请加入</a></li>
                   <!-- <li><a class="help" href="#">第七页</a></li>
                    -->
            </ul>
        </div>
        <div class="main">
            <ul class="topbar clearfix">
                <li class="title">
                    <asp:Label ID="LBLCounsellorGreetings" runat="server" Text="律师问候语"></asp:Label><asp:Label ID="LBLCounsellorName" runat="server" Text="律师姓名"></asp:Label></li>
                <asp:Label ID="LBLBlackListAlert" runat="server" Text="黑名单警告语"></asp:Label>
            </ul>
            <div class="mainContent">
                <div id="dashboard">
                    <h2 class="header"><i class="h2icon fa fa-area-chart">先了解自己，再了解别人</i></h2>
                    我的ID：<asp:Label ID="LBLCounsellorID" runat="server" Text="律师ID"></asp:Label><br />
                    我的密码：<asp:TextBox ID="TBCounsellorPassword" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBCounsellorPassword" runat="server" ErrorMessage="请填写密码" ControlToValidate="TBCounsellorPassword"></asp:RequiredFieldValidator><br />
                    我的姓名：<asp:TextBox ID="TBCounsellorName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBCounsellorName" runat="server" ErrorMessage="请填写姓名" ControlToValidate="TBCounsellorName"></asp:RequiredFieldValidator><br />
                    我的性别：<asp:RadioButton ID="RBMale" runat="server" GroupName="CounsellorSex" AutoPostBack="False" Text="男" /> <asp:RadioButton ID="RBFemale" runat="server" GroupName="CounsellorSex" AutoPostBack="False" Text="女" /><br />
                    我的年龄：<asp:DropDownList ID="DDLCounsellorAge" runat="server"></asp:DropDownList><br />
                    我的Email：<asp:TextBox ID="TBCounsellorEmail" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBCounsellorEmail" runat="server" ErrorMessage="请填写邮箱" ControlToValidate="TBCounsellorEmail"></asp:RequiredFieldValidator><br />
                    我的电话：<asp:TextBox ID="TBCounsellorPhoneNumber" runat="server" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBCounsellorPhoneNumber" runat="server" ErrorMessage="请填写电话" ControlToValidate="TBCounsellorPhoneNumber"></asp:RequiredFieldValidator><br />
                    我的照片：<asp:Image ID="IMGCounsellorImage" runat="server" Height="85px" Width="60px" />更新照片？<asp:FileUpload ID="FUCounsellorImageUpload" runat="server" /><br />
                    我的钱包：<asp:Label ID="LBLCounsellorWallet" runat="server" Text="律师钱包余额"></asp:Label> 元，<!--提取/<待定/>元，<asp:Button ID="BTNWithdrawTargetCounsellorWalletMoney" runat="server" Text="确认提取" />，或者：<asp:Button ID="BTNWithdrawAllCounsellorWalletMoney" runat="server" Text="全部提取" /><br />-->
                    我的等级：<asp:Label ID="LBLCounsellorLevel" runat="server" Text="律师等级"></asp:Label><br />
                    我的擅长领域：
                    <table class="auto-style1">
                    <tr>
                        <td rowspan="4" class="auto-style4">
                            <asp:ListBox ID="LBXCounsellorAdvantageFieldsSelected" runat="server" Rows="8" Height="75px" Width="185px" SelectionMode="Multiple">
                            </asp:ListBox>
                        </td>
                        <td class="auto-style5">
                            <asp:Button ID="BTNAllFieldsSelect" runat="server" Text="全部选中" OnClick="BTNAllFieldsSelect_Click" />
                        </td>
                        <td rowspan="4">
                            <asp:ListBox ID="LBXCounsellorAdvantageFieldsUnselected" runat="server" Rows="8" SelectionMode="Multiple" Height="75px" Width="185px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Button ID="BTNAllFieldsCancel" runat="server" Text="全部取消" OnClick="BTNAllFieldsCancel_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Button ID="BTNSingleFieldSelect" runat="server" Text="选中该项" OnClick="BTNSingleFieldSelect_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Button ID="BTNSingleFieldCancel" runat="server" Text="剔除该项" OnClick="BTNSingleFieldCancel_Click"/>
                        </td>
                    </tr>
                </table><br />
                    <asp:Button ID="BTNCounsellorInfoUpdate" runat="server" Text="更新我的信息" OnClick="BTNCounsellorInfoUpdate_Click" />
                </div>
                <div id="fnolrules">
                    <h2 class="header">一切为了客户</h2>
                    <div align="Center">
                        <asp:GridView ID="GVContractClients" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ContractID,ClientID1" DataSourceID="SqlDataSource2" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="ClientName" HeaderText="客户姓名" SortExpression="ClientName" />
                        </Columns>
                    </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="select * from ContractInfo,ClientInfo where ContractInfo.ClientID=ClientInfo.ClientID and CounsellorID=@CounsellorID">
                            <SelectParameters>
                                <asp:SessionParameter Name="CounsellorID" SessionField="UserID" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="select * from ArticleInfo where ([ArticleAuthorID] = @ArticleAuthorID)">
                        <SelectParameters>
                            <asp:SessionParameter Name="ArticleAuthorID" SessionField="UserID" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    </div>
                    
                </div>
                <div id="cwfrules">
                    <h2 class="header"><i class="h2icon fa fa-cube"></i>提升自己，永不停息</h2>
                    <asp:Label ID="LBLQuestionLevelInfo" runat="server" Text="题目等级："></asp:Label>
                    <asp:Label ID="LBLQuestionLevel" runat="server" Text="题目等级"></asp:Label><br />
                    <br />
                    <asp:Label ID="LBLQuestionTitleInfo" runat="server" Text="问题题目："></asp:Label>
                    <asp:Label ID="LBLQuestionTitle" runat="server" Text="题目标题"></asp:Label><br />
                    <asp:Label ID="LBLQuestionSelectionAInfo" runat="server" Text="A:"></asp:Label>
                    <asp:Label ID="LBLQuestionSelectionA" runat="server" Text="选项A"></asp:Label><br />
                    <asp:Label ID="LBLQuestionSelectionBInfo" runat="server" Text="B:"></asp:Label>
                    <asp:Label ID="LBLQuestionSelectionB" runat="server" Text="选项B"></asp:Label><br />
                    <asp:Label ID="LBLQuestionSelectionCInfo" runat="server" Text="C:"></asp:Label>
                    <asp:Label ID="LBLQuestionSelectionC" runat="server" Text="选项C"></asp:Label><br />
                    <asp:Label ID="LBLQuestionSelectionDInfo" runat="server" Text="D:"></asp:Label>
                    <asp:Label ID="LBLQuestionSelectionD" runat="server" Text="选项D"></asp:Label><br />
                    <br />
                    <asp:DropDownList ID="DDLQuestionSelection" runat="server">
                        <asp:ListItem Selected="True">请选择</asp:ListItem>
                        <asp:ListItem>A</asp:ListItem>
                        <asp:ListItem>B</asp:ListItem>
                        <asp:ListItem>C</asp:ListItem>
                        <asp:ListItem>D</asp:ListItem>
                    </asp:DropDownList><br />
                    <br />

                    <asp:Button ID="BTNCounsellorLevelUpdate" runat="server" Text="确认" OnClick="BTNCounsellorLevelUpdate_Click" />
                </div>
                <div id="fnolguidelines">
                    <h2 class="header"><span></span>有心得？写下来！</h2>
                    <div align="center">
                        文章题目：<asp:TextBox ID="TBArticleTitle" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBArticleTitle" runat="server" ErrorMessage="请填写标题" ControlToValidate="TBArticleTitle"></asp:RequiredFieldValidator><br />
                        文章内容：<asp:TextBox ID="TBArticleContent" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBArticleContent" runat="server" ErrorMessage="请填写内容" ControlToValidate="TBArticleContent"></asp:RequiredFieldValidator><br />
                        <br />
                        <asp:Button ID="BTNPostArticle" runat="server" Text="发布" OnClick="BTNPostArticle_Click" />
                    </div>
                </div>
                <div id="cwfguidelines">
                    <h2 class="header"><span></span>温故而知新</h2>
                    <div align="center">
                        <asp:GridView ID="GVArticles" runat="server" AutoGenerateColumns="False" DataKeyNames="ArticleID" DataSourceID="SqlDataSource1" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="ArticleTitle" HeaderText="文章题目" SortExpression="ArticleTitle" />
                                <asp:BoundField DataField="ArticleLikedCount" HeaderText="点赞数" SortExpression="ArticleLikedCount" />
                                <asp:BoundField DataField="ArticleDislikedCount" HeaderText="点踩数" SortExpression="ArticleDislikedCount" />
                            </Columns>
                        </asp:GridView>
                    </div>
                        <!--进阶，让文章可以更改和删除-->
                </div>
                
                <div id="companylist">
                    <h2 class="header">
                        <asp:Label ID="LBLBoardAccessAlert" runat="server" Text="加入提示语"></asp:Label><br /></h2>
                        <asp:Label ID="LBLBoardSequenceID" runat="server" Text="董事会ID"></asp:Label><br />
                        <asp:Label ID="LBLBoardPassword" runat="server" Text="董事会ID"></asp:Label><br />
                    
                    <asp:Button ID="BTNBoardAccessApply" runat="server" Text="申请加入董事会" OnClick="BTNBoardAccessApply_Click" />
                </div>
               <!-- <div id="help">
                    <h2 class="header"><i class="h2icon fa fa-question-circle"></i>第七页</h2>
                    <div class="helpbox">
                        <ul class="fa-ul">
                            <h3>第七页小标题</h3>
                            第七页内容
                        </ul>
                    </div>
                </div>-->
            </div>
        </div>
    </div>
    <script src="03PersonalCentreBlock/CounsellorPersonalCentre/CounsellorPersonalCentreJS/script.js"></script>
</asp:Content>

