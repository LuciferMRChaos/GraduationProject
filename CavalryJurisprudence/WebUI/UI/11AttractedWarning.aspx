<%@ Page Language="C#" AutoEventWireup="true" CodeFile="11AttractedWarning.aspx.cs" Inherits="_11AttractedWarning" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-decoration: none;
            padding: 7px 10px;
            background-color: #122;
            border-radius: 3px;
            color: #fff;
            -webkit-transition: 0.35s ease-in-out;
            transition: 0.35s ease-in-out;
            position: fixed;
            left: 552px;
            bottom: 15px;
            font-family: "Montserrat";
            width: 14%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            
            <link rel="stylesheet" href="11SecurityBlock/AttractedWarningCSS/style.css" />
        <div class="front side">
			<div class="content">
			<h1>
                <asp:Label ID="LBLWarningLevel" runat="server" Text="警告等级"></asp:Label></h1>
                <asp:Label ID="LBLTest" runat="server" Text="Label"></asp:Label>
			<p>
                <asp:Label ID="LBLWarningContent" runat="server" Text="警告内容"></asp:Label>
			</p>
		</div>
	</div>

	<div class="back side">
		<div class="content">
			<h1>
                <asp:Label ID="LBLAlert" runat="server" Text="系统锁定中"></asp:Label>
			</h1>
				<br />
                <asp:Label ID="LBLSolution" runat="server" Text="提示信息，如请重置密码等"></asp:Label><br />
                <br />
                <asp:TextBox ID="TBBoardKey" placeholder="请输入管理员密钥" runat="server"></asp:TextBox>
				<asp:TextBox ID="TBResetAccount" placeholder="请重置账号" runat="server"></asp:TextBox>
				<asp:TextBox ID="TBResetPassword" placeholder="请重置密码" runat="server" TextMode="Password"></asp:TextBox>
				<asp:TextBox ID="TBResetPasswordConfirm" placeholder="请再次输入重置的密码" runat="server" TextMode="Password"></asp:TextBox>
				<asp:Button ID="BTNAdminInfoResetConfirm" runat="server" Text="确认" OnClick="BTNAdminInfoResetConfirm_Click" />
		</div>
	</div>
  </div>
			
    </form>
</body>
</html>
