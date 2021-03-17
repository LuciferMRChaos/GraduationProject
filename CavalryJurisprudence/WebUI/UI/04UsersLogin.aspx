<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="04UsersLogin.aspx.cs" Inherits="UsersLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="04UsersLoginBlock/UsersLoginCSS/style.css">
    <div class="body-container">
        <!--如果母版用了css，则网页不能放在文件夹里，否则css会失效-->
        <div class="auth-page-container">
            <div class="main-form front">
                <div class="main-form-inner">
                    <p style="color: cornflowerblue">
                        <strong>欢迎您！</strong> 请登录
                    </p>
                    <div class="engine-name"></div>
                        <input type="hidden" name="action" value="registration">
                        <div class="adm-login-row">
                            <br />
                            <asp:TextBox ID="TBUsersAccount" class="login-input" placeholder="请输入用户名" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBUsersAccount" runat="server" ErrorMessage="请输入用户名" ControlToValidate="TBUsersAccount" ValidationGroup="Login"></asp:RequiredFieldValidator>
                        </div>
                        <div class="adm-login-row">
                            <asp:TextBox ID="TBUsersPassword" class="login-input" placeholder="请输入密码" runat="server" TextMode="Password"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBUsersPassword" runat="server" ErrorMessage="请输入密码" ControlToValidate="TBUsersPassword" ValidationGroup="Login"></asp:RequiredFieldValidator>
                        </div>
                        <div class="adm-login-row adm-clearfix adm-margin">
                            <button class="adm-button-reverse adm-float-left toggler adm-button-small" type="button">忘记密码？</button>
                            <asp:Button ID="BTNConfirm" runat="server" Text="登录" class="adm-button-action adm-float-right" type="submit" OnClick="BTNConfirm_Click" ValidationGroup="Login" />
                        </div>
                </div>
            </div>

            <div class="main-form back">
                <div class="main-form-inner">
                    <div class="engine-name"></div>
                        <input type="hidden" name="action" value="reset_pwd">
                        <div class="adm-login-row restore-pass">
                            <asp:TextBox ID="TBUsersEmail" type="text" placeholder="请输入您的邮箱" class="login-input" runat="server" ></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBUsersEmail" runat="server" ErrorMessage="请输入邮箱" ControlToValidate="TBUsersEmail" ValidationGroup="ForgetPassword"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TBUsersPhoneNumber" placeholder="请输入您的电话" class="login-input" runat="server" ></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBUsersPhoneNumber" runat="server" ErrorMessage="请输入电话" ControlToValidate="TBUsersPhoneNumber" ValidationGroup="ForgetPassword"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TBUsersNewPassword" placeholder="请输入您的新密码" class="login-input" runat="server"  TextMode="Password"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBUsersNewPassword" runat="server" ErrorMessage="请输入新密码" ControlToValidate="TBUsersPhoneNumber" ValidationGroup="ForgetPassword"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TBUsersNewPasswordConfirm" placeholder="请确认您的新密码" class="login-input" runat="server"  TextMode="Password"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBUsersNewPasswordConfirm" runat="server" ErrorMessage="请再次输入新密码" ControlToValidate="TBUsersNewPasswordConfirm" ValidationGroup="ForgetPassword"></asp:RequiredFieldValidator> <asp:CompareValidator ID="CompareValidatorOnPassword" runat="server" ErrorMessage="两次输入的密码不一致" ControlToValidate="TBUsersNewPasswordConfirm" ControlToCompare="TBUsersNewPassword"></asp:CompareValidator>
                        </div>

                        <div class="adm-login-row adm-clearfix adm-margin">
                            <button class="adm-button adm-button-reverse adm-float-left toggler adm-button-small" type="button">返回</button>
                            <asp:Button ID="BTNPasswordReset" runat="server" Text="重置" class="adm-button-action adm-float-right" type="submit" OnClick="BTNPasswordReset_Click" ValidationGroup="ForgetPassword" />
                        </div>
                </div>
            </div>
        </div>
    </div>
    <script src="04UsersLoginBlock/UsersLoginJS/jquery.min.js"></script>
    <!--控制翻转-->
    <script src="04UsersLoginBlock/UsersLoginJS/script.js"></script>
</asp:Content>

