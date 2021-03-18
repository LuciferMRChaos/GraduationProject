<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="05UsersRegister.aspx.cs" Inherits="_06ClientRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style4 {
            width: 14px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="05UsersRegisterBlock/UsersRegisterCSS/style.css">
    <div class="body-content" id="overlay">
        <div class="module" align="center">
            <h1>请填写以下信息以注册!</h1>
            <asp:TextBox ID="TBUserPassword" runat="server" placeholder="请输入密码" required="请输入密码"></asp:TextBox>
            <asp:TextBox ID="TBUserName" runat="server" placeholder="请输入真实姓名" required="请输入真实姓名"></asp:TextBox>
            请选择您的性别：<asp:RadioButton ID="RBUserMale" runat="server" GroupName="UsersSex" AutoPostBack="False" Text="男" /> <asp:RadioButton ID="RBUserFemale" runat="server" GroupName="UsersSex" AutoPostBack="False" Text="女" /><br />
            请选择您的年龄：<asp:DropDownList ID="DDLUserAge" runat="server"></asp:DropDownList><br />
            <asp:TextBox ID="TBUserEmail" runat="server" placeholder="请输入邮箱" required="请输入邮箱"></asp:TextBox>
            <asp:TextBox ID="TBUserPhoneNumber" required="请输入电话" runat="server" placeholder="请输入电话号码" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>

            <div class="Select">
                <asp:RadioButton ID="RBClientSelected" runat="server" GroupName="UserCategory" AutoPostBack="True" Text="法律咨询" />
                <asp:RadioButton ID="RBCounsellorSelected" runat="server" GroupName="UserCategory" AutoPostBack="True" Text="岗位求职" /><br />
            </div>
            <br />
            
            <div class="ClientInfo">
                <asp:TextBox ID="TBClientAddress" runat="server" placeholder="请输入您的地址" required="请输入地址"></asp:TextBox>
                <asp:Label runat="server" Text="请选择您要预存的佣金：" ID="LBLClientMoneyDepositingNotice"></asp:Label><asp:DropDownList ID="DDLClientDepositingMoney" runat="server"></asp:DropDownList><asp:Label runat="server" Text="万元" ID="LBLClientDepositingMoney"></asp:Label>
            </div>
            <div class="CounsellorInfo">
                <asp:Label ID="LBLCounsellorSelfIntroduction" runat="server" Text="自我介绍："></asp:Label><asp:TextBox ID="TBCounsellorSelfIntroduction" runat="server" Width="303px" TextMode="MultiLine" Height="36px"></asp:TextBox><br />
                <asp:Label ID="LBLCounsellorAdvantageFieldsSelecting" runat="server" Text="请选择您擅长的领域"></asp:Label>
                <table class="auto-style1">
                    <tr>
                        <td rowspan="4" class="auto-style4">
                            <asp:ListBox ID="LBXCounsellorAdvantageFields" runat="server" Rows="8" Height="75px" Width="185px" SelectionMode="Multiple">
                                <asp:ListItem Value="0">刑法·盗窃罪共犯问题</asp:ListItem>
                                <asp:ListItem Value="1">刑法·贪污贿赂问题</asp:ListItem>
                                <asp:ListItem Value="2">刑事诉讼法</asp:ListItem>
                                <asp:ListItem Value="3">民法·合同问题</asp:ListItem>
                                <asp:ListItem Value="4">民法·知识产权</asp:ListItem>
                                <asp:ListItem Value="5">婚姻继承问题</asp:ListItem>
                                <asp:ListItem Value="6">民法·侵权责任问题</asp:ListItem>
                                <asp:ListItem Value="7">民法·抵押担保问题</asp:ListItem>
                            </asp:ListBox>
                        </td>
                        <td>
                            <asp:Button ID="BTNAllFieldsSelect" runat="server" Text="全部选中" OnClick="BTNAllFieldsSelect_Click" />
                        </td>
                        <td rowspan="4">
                            <asp:ListBox ID="LBXCounsellorAdvantageFieldsSelected" runat="server" Rows="8" SelectionMode="Multiple" Height="75px" Width="185px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="BTNAllFieldsCancel" runat="server" Text="全部取消" OnClick="BTNAllFieldsCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="BTNSingleFieldSelect" runat="server" Text="选中该项" OnClick="BTNSingleFieldSelect_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="BTNSingleFieldCancel" runat="server" Text="剔除该项" OnClick="BTNSingleFieldCancel_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="LBLUserImage" runat="server" Text="请上传照片"></asp:Label>
            <asp:FileUpload ID="FUUserImageUpload" runat="server" />
            </div>
            <br />
            <asp:Button ID="BTNRegisterConfirm" runat="server" Text="确认注册" OnClick="BTNRegisterConfirm_Click" />
        </div>
    </div>
</asp:Content>
