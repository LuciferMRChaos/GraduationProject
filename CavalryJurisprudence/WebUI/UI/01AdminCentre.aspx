<%@ Page Language="C#" AutoEventWireup="true" CodeFile="01AdminCentre.aspx.cs" Inherits="AdminLogin_AdminCenter_AdminCenter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <link rel="stylesheet" href="01AdminBlock/AdminCenter/AdminCenterCSS/style.css" />
            <div>
                <header class="zl-topbar">
                    <!--标题部分设置-->
                    <div class="app-info">
                        <!--设置链接样式-->
                        <a class="home-link" href="#">
                            <!--设置链接样式-->
                            <div>
                                <asp:Image ID="IMGLogo" runat="server" ImageUrl="~/CavalryLOGO.png" CssClass="auto-style1" Height="78px" />
                            </div>
                            &nbsp;
                            <div>时刻谨记 · 客户至上</div>
                        </a>
                    </div>
                </header>
                <main class="zl-main">
                    <div class="zl-gradient-overlay"></div>
                    <aside class="zl-sidebar" id="scroll-sidebar">
                        <nav class="zl-sidenav">
                            <ul class="shell-menu">
                                <li role="menuitem"><a href="#menu-item-1" id="menu-item-1">快速设置面板</a> </li>
                                <!--
                                    <li role="menuitem"><a href="#menu-item-2" id="menu-item-2">清理程序</a> </li>
                                 -->
                                <li role="menuitem"><a href="#menu-item-3" id="menu-item-3">客户信息</a> </li>
                                <li role="menuitem"><a href="#menu-item-4" id="menu-item-4">律师信息</a> </li>
                                <li role="menuitem"><a href="#menu-item-5" id="menu-item-5">题目信息</a> </li>
                                <li role="menuitem"><a href="#menu-item-6" id="menu-item-6">礼品信息</a> </li>
                            </ul>
                        </nav>
                    </aside>
                    <section class="zl-content">
                        <div class="zl-wrapper">
                            <div id="content-item-1" class="zl-page">
                                <div class="zl-page--header">
                                    <div class="zl-flex--row">
                                        <div class="zl-col--8">
                                            <h1>
                                                <asp:Label ID="LBLAdminGreetings" runat="server" Text="管理员问候语"></asp:Label><asp:Label ID="LBLNewAccount" runat="server" Text="问候语"></asp:Label></h1>
                                            <p>
                                                <asp:Label ID="LBLAttractedAlert" runat="server" Text="警告语"></asp:Label><br />
                                                <asp:Label ID="LBLAdminAccount" runat="server" Text="账户："></asp:Label><asp:TextBox ID="TBAdminAccount" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBAdminAccount" runat="server" ErrorMessage="请填写新的管理员账户" ControlToValidate="TBAdminAccount" ValidationGroup="UpdateAdminInfo"></asp:RequiredFieldValidator><br />
                                                <asp:Label ID="LBLAdminPassword" runat="server" Text="密码："></asp:Label><asp:Label ID="LBLAdminPasswordShow" runat="server" Text="密码展示"></asp:Label><br />
                                                <asp:TextBox ID="TBAdminPassword" runat="server" placeholder="请输入新的密码"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBAdminPassword" runat="server" ErrorMessage="请填写新的管理员密码" ControlToValidate="TBAdminPassword" ValidationGroup="UpdateAdminInfo"></asp:RequiredFieldValidator><br />
                                                <asp:Button ID="AdminInfoUpdate" runat="server" Text="更新管理员信息" OnClick="AdminInfoUpdate_Click" ValidationGroup="UpdateAdminInfo" /><br />
                                                注意：账户后会自动增加'A'
                                            </p>
                                            <!--<p>新增内容时要去proto-page-script.js里添加事件！</p>-->
                                        </div>
                                    </div>
                                </div>
                                <div class="zl-page--content">
                                    <div class="zl-page--content-inner">
                                        <div class="zc-tab--container">
                                            <nav class="zc-tabs" data-toggle="zui-tabs" role="navigation">
                                                <ul class="zc-tab--navigation">
                                                    <li class="zc-tab--item"><a class="active" href="#test1">添加问题</a></li>
                                                    <li class="zc-tab--item"><a href="#test2">添加文章</a></li>
                                                    <li class="zc-tab--item"><a href="#test3">添加礼品</a></li>
                                                    <li class="zc-tab--item"><a href="#test4">删除信息</a></li>
                                                    <li class="zc-tab--slider">
                                                        <div class="zc-tab-indicator"></div>
                                                    </li>
                                                </ul>
                                            </nav>
                                            <div class="zc-tabs--content-container">
                                                <div id="test1" class="zc-tab--content active" data-bind="busy: isBusy, busySettings: {}">
                                                    请选择问题领域：
                                                    <asp:DropDownList ID="DDLQuestionFieldsSelecting" runat="server" AutoPostBack="False">
                                                        <asp:ListItem Value="0">刑法·盗窃罪共犯问题</asp:ListItem>
                                                        <asp:ListItem Value="1">刑法·贪污贿赂问题</asp:ListItem>
                                                        <asp:ListItem Value="2">刑事诉讼法</asp:ListItem>
                                                        <asp:ListItem Value="3">民法·合同问题</asp:ListItem>
                                                        <asp:ListItem Value="4">民法·知识产权</asp:ListItem>
                                                        <asp:ListItem Value="5">婚姻继承问题</asp:ListItem>
                                                        <asp:ListItem Value="6">民法·侵权责任问题</asp:ListItem>
                                                        <asp:ListItem Value="7">民法·抵押担保问题</asp:ListItem>
                                                    </asp:DropDownList><br />
                                                    请选择问题等级：
                                                    <asp:DropDownList ID="DDLQuestionLevel" runat="server">
                                                        <asp:ListItem Value="0">请选择等级</asp:ListItem>
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                    </asp:DropDownList><br />
                                                    请输入问题标题：<asp:TextBox ID="TBQuestionTitle" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBQuestionTitle" runat="server" ErrorMessage="请输入问题标题" ControlToValidate="TBQuestionTitle" ValidationGroup="PostQuestion"></asp:RequiredFieldValidator><br />
                                                    请输入答案：A:<asp:TextBox ID="TBAnswerA" runat="server" Width="180px"></asp:TextBox>B:<asp:TextBox ID="TBAnwserB" runat="server" Width="180px"></asp:TextBox>C:<asp:TextBox ID="TBAnswerC" runat="server" Width="180px"></asp:TextBox>D:<asp:TextBox ID="TBAnswerD" runat="server" Width="180px"></asp:TextBox><br />
                                                    请选择选项：
                                                    <asp:DropDownList ID="DDLCorrectAnswer" runat="server">
                                                        <asp:ListItem Value="0">请选择选项</asp:ListItem>
                                                        <asp:ListItem Value="1">A</asp:ListItem>
                                                        <asp:ListItem Value="2">B</asp:ListItem>
                                                        <asp:ListItem Value="3">C</asp:ListItem>
                                                        <asp:ListItem Value="4">D</asp:ListItem>
                                                    </asp:DropDownList><br />

                                                    <asp:Button ID="BTNPostQuestion" runat="server" Text="发布该问题" OnClick="BTNPostQuestion_Click" ValidationGroup="PostQuestion" />
                                                </div>
                                                <div id="test2" class="zc-tab--content" data-bind="busy: isBusy, busySettings: {}">
                                                    请输入文章标题：<asp:TextBox ID="TBArticleTitle" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBArticleTitle" runat="server" ErrorMessage="请填入文章标题" ControlToValidate="TBArticleTitle" ValidationGroup="PostArticle"></asp:RequiredFieldValidator><br />
                                                    请输入文章内容：<asp:TextBox ID="TBArticleContent" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBArticleContent" runat="server" ErrorMessage="请填入文章内容" ControlToValidate="TBArticleContent" ValidationGroup="PostArticle"></asp:RequiredFieldValidator><br />
                                                    <asp:Button ID="BTNPostArticle" runat="server" Text="发布文章" OnClick="BTNPostArticle_Click" ValidationGroup="PostArticle" />
                                                </div>
                                                <div id="test3" class="zc-tab--content" data-bind="busy: isBusy, busySettings: {}">
                                                    请输入礼品名称：<asp:TextBox ID="TBGiftName" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBGiftName" runat="server" ErrorMessage="请填入礼品名称" ControlToValidate="TBGiftName" ValidationGroup="PostGift"></asp:RequiredFieldValidator><br />
                                                    请输入礼品简介：<asp:TextBox ID="TBGiftTips" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBGiftTips" runat="server" ErrorMessage="请填入礼品简介" ControlToValidate="TBGiftTips" ValidationGroup="PostGift"></asp:RequiredFieldValidator><br />
                                                    请输入礼品介绍：<asp:TextBox ID="TBGiftInfo" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBGiftInfo" runat="server" ErrorMessage="请填入礼品信息" ControlToValidate="TBGiftInfo" ValidationGroup="PostGift"></asp:RequiredFieldValidator><br />
                                                    请输入礼品数量：<asp:TextBox ID="TBGiftAmount" runat="server"></asp:TextBox><br />
                                                    请输入礼品价格：<asp:TextBox ID="TBGiftPrice" runat="server"></asp:TextBox><br />
                                                    请上传礼品图片：<asp:FileUpload ID="FUGiftImageUpload" runat="server" /><br />
                                                    <asp:Button ID="BTNAddGift" runat="server" Text="添加礼品" OnClick="BTNAddGift_Click" ValidationGroup="PostGift" />
                                                </div>
                                                <div id="test4" class="zc-tab--content" data-bind="busy: isBusy, busySettings: {}">
                                                    我要删除：<br />
                                                    <asp:RadioButton ID="RBDeleteALLClientInfo" runat="server" GroupName="UsersDelete" Text="全部客户信息" /><br />
                                                    <asp:RadioButton ID="RBDeleteALLBlackListInfo" runat="server" GroupName="UsersDelete" Text="全部黑名单信息" /><br />
                                                    <asp:RadioButton ID="RBDeleteALLGiftInfo" runat="server" GroupName="UsersDelete" Text="全部礼品信息" /><br />
                                                    <asp:RadioButton ID="RBDeleteALLArticleInfo" runat="server" GroupName="UsersDelete" Text="全部文章信息" /><br />
                                                    <asp:RadioButton ID="RBCancel" runat="server" GroupName="UsersDelete" Text="算了" /><br />
                                                    <asp:Button ID="BTNDeleteALLSelectedInfo" runat="server" Text="删除选定的全部信息" OnClick="BTNDeleteALLSelectedInfo_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--
                            <div id="content-item-2" class="zl-page" align="center">
                                <p>
                                    改成系统摧毁按钮，按下以后会出现新按钮：你确定吗？
                                确定后会出现输入框，要求输入密钥
                                输入后会再次要求确定
                                最后一次确定后
                                清除所有信息
                                </p>
                            </div>
                            -->
                            <div id="content-item-3" class="zl-page">
                                <asp:GridView ID="GVClientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="ClientID" DataSourceID="SqlDataSource1ClientInfo" EnableModelValidation="True" CellPadding="4" ForeColor="#333333" GridLines="None" Height="315px" Width="930px" AllowPaging="True" AllowSorting="True">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                        <asp:BoundField DataField="ClientID" HeaderText="客户ID" ReadOnly="True" SortExpression="ClientID" />
                                        <asp:BoundField DataField="ClientPassword" HeaderText="客户密码" SortExpression="ClientPassword" />
                                        <asp:BoundField DataField="ClientName" HeaderText="客户姓名" SortExpression="ClientName" />
                                        <asp:BoundField DataField="ClientSex" HeaderText="客户性别" SortExpression="ClientSex" />
                                        <asp:BoundField DataField="ClientAge" HeaderText="客户年龄" SortExpression="ClientAge" />
                                        <asp:BoundField DataField="ClientEmail" HeaderText="客户邮箱" SortExpression="ClientEmail" />
                                        <asp:BoundField DataField="ClientPhoneNumber" HeaderText="客户电话" SortExpression="ClientPhoneNumber" />
                                        <asp:BoundField DataField="ClientDepositingMoney" HeaderText="客户上次充值金额" SortExpression="ClientDepositingMoney" />
                                        <asp:BoundField DataField="ClientWallet" HeaderText="客户余额" SortExpression="ClientWallet" />
                                        <asp:BoundField DataField="ClientTotalDepositedMoney" HeaderText="客户总存储金额" SortExpression="ClientTotalDepositedMoney" />
                                        <asp:BoundField DataField="ClientImage" HeaderText="客户照片地址" SortExpression="ClientImage" />
                                        <asp:BoundField DataField="ClientAddress" HeaderText="客户地址" SortExpression="ClientAddress" />
                                        <asp:BoundField DataField="ClientPoints" HeaderText="客户积分" SortExpression="ClientPoints" />
                                        <asp:BoundField DataField="ClientLevel" HeaderText="客户等级" SortExpression="ClientLevel" />
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1ClientInfo" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="SELECT * FROM [ClientInfo]" DeleteCommand="DELETE FROM [ClientInfo] WHERE [ClientID] = @ClientID" InsertCommand="INSERT INTO [ClientInfo] ([ClientID], [ClientPassword], [ClientName], [ClientSex], [ClientAge], [ClientEmail], [ClientPhoneNumber], [ClientDepositingMoney], [ClientWallet], [ClientTotalDepositedMoney], [ClientImage], [ClientAddress], [ClientPoints], [ClientLevel]) VALUES (@ClientID, @ClientPassword, @ClientName, @ClientSex, @ClientAge, @ClientEmail, @ClientPhoneNumber, @ClientDepositingMoney, @ClientWallet, @ClientTotalDepositedMoney, @ClientImage, @ClientAddress, @ClientPoints, @ClientLevel)" UpdateCommand="UPDATE [ClientInfo] SET [ClientPassword] = @ClientPassword, [ClientName] = @ClientName, [ClientSex] = @ClientSex, [ClientAge] = @ClientAge, [ClientEmail] = @ClientEmail, [ClientPhoneNumber] = @ClientPhoneNumber, [ClientDepositingMoney] = @ClientDepositingMoney, [ClientWallet] = @ClientWallet, [ClientTotalDepositedMoney] = @ClientTotalDepositedMoney, [ClientImage] = @ClientImage, [ClientAddress] = @ClientAddress, [ClientPoints] = @ClientPoints, [ClientLevel] = @ClientLevel WHERE [ClientID] = @ClientID">
                                    <DeleteParameters>
                                        <asp:Parameter Name="ClientID" Type="Int64" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="ClientID" Type="Int64" />
                                        <asp:Parameter Name="ClientPassword" Type="String" />
                                        <asp:Parameter Name="ClientName" Type="String" />
                                        <asp:Parameter Name="ClientSex" Type="String" />
                                        <asp:Parameter Name="ClientAge" Type="Int32" />
                                        <asp:Parameter Name="ClientEmail" Type="String" />
                                        <asp:Parameter Name="ClientPhoneNumber" Type="Int64" />
                                        <asp:Parameter Name="ClientDepositingMoney" Type="Int64" />
                                        <asp:Parameter Name="ClientWallet" Type="Int64" />
                                        <asp:Parameter Name="ClientTotalDepositedMoney" Type="Int64" />
                                        <asp:Parameter Name="ClientImage" Type="String" />
                                        <asp:Parameter Name="ClientAddress" Type="String" />
                                        <asp:Parameter Name="ClientPoints" Type="Int64" />
                                        <asp:Parameter Name="ClientLevel" Type="Int32" />
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="ClientPassword" Type="String" />
                                        <asp:Parameter Name="ClientName" Type="String" />
                                        <asp:Parameter Name="ClientSex" Type="String" />
                                        <asp:Parameter Name="ClientAge" Type="Int32" />
                                        <asp:Parameter Name="ClientEmail" Type="String" />
                                        <asp:Parameter Name="ClientPhoneNumber" Type="Int64" />
                                        <asp:Parameter Name="ClientDepositingMoney" Type="Int64" />
                                        <asp:Parameter Name="ClientWallet" Type="Int64" />
                                        <asp:Parameter Name="ClientTotalDepositedMoney" Type="Int64" />
                                        <asp:Parameter Name="ClientImage" Type="String" />
                                        <asp:Parameter Name="ClientAddress" Type="String" />
                                        <asp:Parameter Name="ClientPoints" Type="Int64" />
                                        <asp:Parameter Name="ClientLevel" Type="Int32" />
                                        <asp:Parameter Name="ClientID" Type="Int64" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div id="content-item-4" class="zl-page">
                                <asp:GridView ID="GVCounsellorInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="CounsellorID" DataSourceID="SqlDataSource2CounsellorInfo" EnableModelValidation="True" Height="315px" Width="930px" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                        <asp:BoundField DataField="CounsellorID" HeaderText="律师ID" ReadOnly="True" SortExpression="CounsellorID" />
                                        <asp:BoundField DataField="CounsellorPassword" HeaderText="律师密码" SortExpression="CounsellorPassword" />
                                        <asp:BoundField DataField="CounsellorName" HeaderText="律师姓名" SortExpression="CounsellorName" />
                                        <asp:BoundField DataField="CounsellorSex" HeaderText="律师性别" SortExpression="CounsellorSex" />
                                        <asp:BoundField DataField="CounsellorAge" HeaderText="律师年龄" SortExpression="CounsellorAge" />
                                        <asp:BoundField DataField="CounsellorEmail" HeaderText="律师邮箱" SortExpression="CounsellorEmail" />
                                        <asp:BoundField DataField="CounsellorPhoneNumber" HeaderText="律师电话" SortExpression="CounsellorPhoneNumber" />
                                        <asp:BoundField DataField="CounsellorImage" HeaderText="律师照片地址" SortExpression="CounsellorImage" />
                                        <asp:BoundField DataField="CounsellorSelfIntroduction" HeaderText="律师自我介绍" SortExpression="CounsellorSelfIntroduction" />
                                        <asp:BoundField DataField="CounsellorWallet" HeaderText="律师钱包" SortExpression="CounsellorWallet" />
                                        <asp:BoundField DataField="CounsellorLevel" HeaderText="律师等级" SortExpression="CounsellorLevel" />
                                        <asp:BoundField DataField="CounsellorOfferMoney" HeaderText="律师签约价格" SortExpression="CounsellorOfferMoney" />
                                        <asp:BoundField DataField="CounsellorAdvantageField1" HeaderText="律师擅长领域1" SortExpression="CounsellorAdvantageField1" />
                                        <asp:BoundField DataField="CounsellorAdvantageField2" HeaderText="律师擅长领域2" SortExpression="CounsellorAdvantageField2" />
                                        <asp:BoundField DataField="CounsellorAdvantageField3" HeaderText="律师擅长领域3" SortExpression="CounsellorAdvantageField3" />
                                        <asp:BoundField DataField="CounsellorAdvantageField4" HeaderText="律师擅长领域4" SortExpression="CounsellorAdvantageField4" />
                                        <asp:BoundField DataField="CounsellorAdvantageField5" HeaderText="律师擅长领域5" SortExpression="CounsellorAdvantageField5" />
                                        <asp:BoundField DataField="CounsellorAdvantageField6" HeaderText="律师擅长领域6" SortExpression="CounsellorAdvantageField6" />
                                        <asp:BoundField DataField="CounsellorAdvantageField7" HeaderText="律师擅长领域7" SortExpression="CounsellorAdvantageField7" />
                                        <asp:BoundField DataField="CounsellorAdvantageField8" HeaderText="律师擅长领域8" SortExpression="CounsellorAdvantageField8" />
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource2CounsellorInfo" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="SELECT * FROM [CounsellorInfo]" DeleteCommand="DELETE FROM [CounsellorInfo] WHERE [CounsellorID] = @CounsellorID" InsertCommand="INSERT INTO [CounsellorInfo] ([CounsellorID], [CounsellorPassword], [CounsellorName], [CounsellorSex], [CounsellorAge], [CounsellorEmail], [CounsellorPhoneNumber], [CounsellorImage], [CounsellorSelfIntroduction], [CounsellorWallet], [CounsellorLevel], [CounsellorOfferMoney], [CounsellorAdvantageField1], [CounsellorAdvantageField2], [CounsellorAdvantageField3], [CounsellorAdvantageField4], [CounsellorAdvantageField5], [CounsellorAdvantageField6], [CounsellorAdvantageField7], [CounsellorAdvantageField8]) VALUES (@CounsellorID, @CounsellorPassword, @CounsellorName, @CounsellorSex, @CounsellorAge, @CounsellorEmail, @CounsellorPhoneNumber, @CounsellorImage, @CounsellorSelfIntroduction, @CounsellorWallet, @CounsellorLevel, @CounsellorOfferMoney, @CounsellorAdvantageField1, @CounsellorAdvantageField2, @CounsellorAdvantageField3, @CounsellorAdvantageField4, @CounsellorAdvantageField5, @CounsellorAdvantageField6, @CounsellorAdvantageField7, @CounsellorAdvantageField8)" UpdateCommand="UPDATE [CounsellorInfo] SET [CounsellorPassword] = @CounsellorPassword, [CounsellorName] = @CounsellorName, [CounsellorSex] = @CounsellorSex, [CounsellorAge] = @CounsellorAge, [CounsellorEmail] = @CounsellorEmail, [CounsellorPhoneNumber] = @CounsellorPhoneNumber, [CounsellorImage] = @CounsellorImage, [CounsellorSelfIntroduction] = @CounsellorSelfIntroduction, [CounsellorWallet] = @CounsellorWallet, [CounsellorLevel] = @CounsellorLevel, [CounsellorOfferMoney] = @CounsellorOfferMoney, [CounsellorAdvantageField1] = @CounsellorAdvantageField1, [CounsellorAdvantageField2] = @CounsellorAdvantageField2, [CounsellorAdvantageField3] = @CounsellorAdvantageField3, [CounsellorAdvantageField4] = @CounsellorAdvantageField4, [CounsellorAdvantageField5] = @CounsellorAdvantageField5, [CounsellorAdvantageField6] = @CounsellorAdvantageField6, [CounsellorAdvantageField7] = @CounsellorAdvantageField7, [CounsellorAdvantageField8] = @CounsellorAdvantageField8 WHERE [CounsellorID] = @CounsellorID">
                                    <DeleteParameters>
                                        <asp:Parameter Name="CounsellorID" Type="Int64" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="CounsellorID" Type="Int64" />
                                        <asp:Parameter Name="CounsellorPassword" Type="String" />
                                        <asp:Parameter Name="CounsellorName" Type="String" />
                                        <asp:Parameter Name="CounsellorSex" Type="String" />
                                        <asp:Parameter Name="CounsellorAge" Type="Int32" />
                                        <asp:Parameter Name="CounsellorEmail" Type="String" />
                                        <asp:Parameter Name="CounsellorPhoneNumber" Type="Int64" />
                                        <asp:Parameter Name="CounsellorImage" Type="String" />
                                        <asp:Parameter Name="CounsellorSelfIntroduction" Type="String" />
                                        <asp:Parameter Name="CounsellorWallet" Type="Int64" />
                                        <asp:Parameter Name="CounsellorLevel" Type="Int32" />
                                        <asp:Parameter Name="CounsellorOfferMoney" Type="Int64" />
                                        <asp:Parameter Name="CounsellorAdvantageField1" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField2" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField3" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField4" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField5" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField6" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField7" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField8" Type="String" />
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="CounsellorPassword" Type="String" />
                                        <asp:Parameter Name="CounsellorName" Type="String" />
                                        <asp:Parameter Name="CounsellorSex" Type="String" />
                                        <asp:Parameter Name="CounsellorAge" Type="Int32" />
                                        <asp:Parameter Name="CounsellorEmail" Type="String" />
                                        <asp:Parameter Name="CounsellorPhoneNumber" Type="Int64" />
                                        <asp:Parameter Name="CounsellorImage" Type="String" />
                                        <asp:Parameter Name="CounsellorSelfIntroduction" Type="String" />
                                        <asp:Parameter Name="CounsellorWallet" Type="Int64" />
                                        <asp:Parameter Name="CounsellorLevel" Type="Int32" />
                                        <asp:Parameter Name="CounsellorOfferMoney" Type="Int64" />
                                        <asp:Parameter Name="CounsellorAdvantageField1" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField2" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField3" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField4" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField5" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField6" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField7" Type="String" />
                                        <asp:Parameter Name="CounsellorAdvantageField8" Type="String" />
                                        <asp:Parameter Name="CounsellorID" Type="Int64" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div id="content-item-5" class="zl-page">
                                <asp:GridView ID="GVQuestionInfo" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="QuestionID" DataSourceID="SqlDataSource3QuestionInfo" EnableModelValidation="True" ForeColor="#333333" GridLines="None" Height="315px" Width="930px" AllowPaging="True" AllowSorting="True">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                        <asp:BoundField DataField="QuestionID" HeaderText="问题ID" InsertVisible="False" ReadOnly="True" SortExpression="QuestionID" />
                                        <asp:BoundField DataField="QuestionField" HeaderText="问题领域" SortExpression="QuestionField" />
                                        <asp:BoundField DataField="QuestionLevel" HeaderText="问题等级" SortExpression="QuestionLevel" />
                                        <asp:BoundField DataField="QuestionTitle" HeaderText="问题标题" SortExpression="QuestionTitle" />
                                        <asp:BoundField DataField="AnswerSelectionA" HeaderText="回答选项A" SortExpression="AnswerSelectionA" />
                                        <asp:BoundField DataField="AnswerSelectionB" HeaderText="回答选项B" SortExpression="AnswerSelectionB" />
                                        <asp:BoundField DataField="AnswerSelectionC" HeaderText="回答选项C" SortExpression="AnswerSelectionC" />
                                        <asp:BoundField DataField="AnswerSelectionD" HeaderText="回答选项D" SortExpression="AnswerSelectionD" />
                                        <asp:BoundField DataField="CorrectAnswer" HeaderText="正确选项" SortExpression="CorrectAnswer" />
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource3QuestionInfo" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="SELECT * FROM [QuestionInfo]" DeleteCommand="DELETE FROM [QuestionInfo] WHERE [QuestionID] = @QuestionID" InsertCommand="INSERT INTO [QuestionInfo] ([QuestionField], [QuestionLevel], [QuestionTitle], [AnswerSelectionA], [AnswerSelectionB], [AnswerSelectionC], [AnswerSelectionD], [CorrectAnswer]) VALUES (@QuestionField, @QuestionLevel, @QuestionTitle, @AnswerSelectionA, @AnswerSelectionB, @AnswerSelectionC, @AnswerSelectionD, @CorrectAnswer)" UpdateCommand="UPDATE [QuestionInfo] SET [QuestionField] = @QuestionField, [QuestionLevel] = @QuestionLevel, [QuestionTitle] = @QuestionTitle, [AnswerSelectionA] = @AnswerSelectionA, [AnswerSelectionB] = @AnswerSelectionB, [AnswerSelectionC] = @AnswerSelectionC, [AnswerSelectionD] = @AnswerSelectionD, [CorrectAnswer] = @CorrectAnswer WHERE [QuestionID] = @QuestionID">
                                    <DeleteParameters>
                                        <asp:Parameter Name="QuestionID" Type="Int64" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="QuestionField" Type="String" />
                                        <asp:Parameter Name="QuestionLevel" Type="Int32" />
                                        <asp:Parameter Name="QuestionTitle" Type="String" />
                                        <asp:Parameter Name="AnswerSelectionA" Type="String" />
                                        <asp:Parameter Name="AnswerSelectionB" Type="String" />
                                        <asp:Parameter Name="AnswerSelectionC" Type="String" />
                                        <asp:Parameter Name="AnswerSelectionD" Type="String" />
                                        <asp:Parameter Name="CorrectAnswer" Type="String" />
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="QuestionField" Type="String" />
                                        <asp:Parameter Name="QuestionLevel" Type="Int32" />
                                        <asp:Parameter Name="QuestionTitle" Type="String" />
                                        <asp:Parameter Name="AnswerSelectionA" Type="String" />
                                        <asp:Parameter Name="AnswerSelectionB" Type="String" />
                                        <asp:Parameter Name="AnswerSelectionC" Type="String" />
                                        <asp:Parameter Name="AnswerSelectionD" Type="String" />
                                        <asp:Parameter Name="CorrectAnswer" Type="String" />
                                        <asp:Parameter Name="QuestionID" Type="Int64" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div id="content-item-6" class="zl-page">
                                <asp:GridView ID="GVGiftInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="GiftID" DataSourceID="SqlDataSource4GiftInfo" EnableModelValidation="True" Height="315px" Width="930px" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                        <asp:BoundField DataField="GiftID" HeaderText="礼品ID" InsertVisible="False" ReadOnly="True" SortExpression="GiftID" />
                                        <asp:BoundField DataField="GiftName" HeaderText="礼品名" SortExpression="GiftName" />
                                        <asp:BoundField DataField="GiftTips" HeaderText="礼品简介" SortExpression="GiftTips" />
                                        <asp:BoundField DataField="GiftInfo" HeaderText="礼品信息" SortExpression="GiftInfo" />
                                        <asp:BoundField DataField="GiftAmount" HeaderText="礼品数量" SortExpression="GiftAmount" />
                                        <asp:BoundField DataField="GiftPrice" HeaderText="礼品价格" SortExpression="GiftPrice" />
                                        <asp:BoundField DataField="GiftImage" HeaderText="礼品照片地址" SortExpression="GiftImage" />
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource4GiftInfo" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="SELECT * FROM [GiftInfo]" DeleteCommand="DELETE FROM [GiftInfo] WHERE [GiftID] = @GiftID" InsertCommand="INSERT INTO [GiftInfo] ([GiftName], [GiftTips], [GiftInfo], [GiftAmount], [GiftPrice], [GiftImage]) VALUES (@GiftName, @GiftTips, @GiftInfo, @GiftAmount, @GiftPrice, @GiftImage)" UpdateCommand="UPDATE [GiftInfo] SET [GiftName] = @GiftName, [GiftTips] = @GiftTips, [GiftInfo] = @GiftInfo, [GiftAmount] = @GiftAmount, [GiftPrice] = @GiftPrice, [GiftImage] = @GiftImage WHERE [GiftID] = @GiftID">
                                    <DeleteParameters>
                                        <asp:Parameter Name="GiftID" Type="Int64" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="GiftName" Type="String" />
                                        <asp:Parameter Name="GiftTips" Type="String" />
                                        <asp:Parameter Name="GiftInfo" Type="String" />
                                        <asp:Parameter Name="GiftAmount" Type="Int32" />
                                        <asp:Parameter Name="GiftPrice" Type="Int32" />
                                        <asp:Parameter Name="GiftImage" Type="String" />
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="GiftName" Type="String" />
                                        <asp:Parameter Name="GiftTips" Type="String" />
                                        <asp:Parameter Name="GiftInfo" Type="String" />
                                        <asp:Parameter Name="GiftAmount" Type="Int32" />
                                        <asp:Parameter Name="GiftPrice" Type="Int32" />
                                        <asp:Parameter Name="GiftImage" Type="String" />
                                        <asp:Parameter Name="GiftID" Type="Int64" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>

                        <!--封底-->
                        <footer class="zl-footer">
                            <div class="shell-footer">
                                <div class="zl-wrapper">
                                    <div class="footer-container">
                                        <ul class="footer-list">
                                            <li><span>快速链接</span></li>
                                            <li>
                                                <asp:HyperLink ID="HLIBM" runat="server" NavigateUrl="https://www.ibm.com/cn-zh">IBM</asp:HyperLink>
                                            </li>
                                            <li>
                                                <asp:HyperLink ID="HLSony" runat="server" NavigateUrl="https://www.sony.com.cn/">索尼</asp:HyperLink>
                                            </li>
                                            <li>
                                                <asp:HyperLink ID="HLApple" runat="server" NavigateUrl="https://www.apple.com.cn/">苹果</asp:HyperLink>
                                            </li>
                                            <li>
                                                <asp:HyperLink ID="HLDLUFL" runat="server" NavigateUrl="https://rj2jg.dlufl.edu.cn/">大连外国语大学·软件学院教工第二党支部</asp:HyperLink>
                                            </li>
                                            <li>
                                                <asp:HyperLink ID="HLQuit" runat="server" NavigateUrl="~/0000.aspx">退出</asp:HyperLink>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </footer>
                    </section>
                </main>
            </div>
        <script src="01AdminBlock/AdminCenter/AdminCenterJS/jquery.min.js"></script>
        <!--控制所有的tab选择-->
        <script src="01AdminBlock/AdminCenter/AdminCenterJS/zui-jquery-tabs.js"></script>
        <!--控制第一页下的小型tab-->
        <script src="01AdminBlock/AdminCenter/AdminCenterJS/proto-page-script.js"></script>
        <!--控制左边tab选择-->
        <script src="01AdminBlock/AdminCenter/AdminCenterJS/script.js"></script>
        <!--控制左边tab隐藏和第一页下的小型tab-->
        </div>
    </form>
</body>
</html>
