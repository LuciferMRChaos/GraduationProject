<%@ Page Language="C#" AutoEventWireup="true" CodeFile="06CounsellorResume.aspx.cs" Inherits="CounsellorResume" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <link rel="stylesheet" href="06CounsellorBlock/CounsellorResume/CounsellorResumeCSS/bulma.min.css" />
            <!--让两个模块并排-->
            <link rel="stylesheet" href="06CounsellorBlock/CounsellorResume/CounsellorResumeCSS/style.css" />
            <section class="hero is-fullheight">
                <div class="hero-body">
                    <div class="container">
                        <div class="columns">
                            <div class="column is-3 is-flex">
                                <div class="column-child sidebar shadow">
                                    <div class="sidebar-header has-text-centered">
                                        <asp:Image ID="IMGCounsellorImage" class="sidebar-image" runat="server" ImageUrl="~/测试.jpg" Height="200px" />
                                        <h2 class="header-name">
                                            律师姓名：<asp:Label ID="LBLCounsellorName" runat="server" Text="律师姓名"></asp:Label></h2>
                                        <h5>电话：<asp:Label ID="LBLCounsellorPhoneNumber" runat="server" Text="电话"></asp:Label><br /></h5>
                                    </div>
                                </div>
                            </div>
                            <div class="column is-flex">
                                <div class="column-child terminal shadow">
                                    <div class="terminal-bar dark-mode">
                                        <div class="icon-btn"></div>
                                        <!--题头栏目-->
                                        <div class="terminal-bar-text is-hidden-mobile dark-mode-text">集团内部资料·请勿外泄</div>
                                    </div>
                                    <div class="terminal-window primary-bg" onclick="document.getElementById('dummyKeyboard').focus();">
                                        <div class="terminal-output" id="terminalOutput">
                                            <div class="terminal-line">
                                                <p>同意人数：<asp:Label ID="LBLAgreeCount" runat="server" Text="同意人数"></asp:Label></p>
                                                <p>拒绝人数：<asp:Label ID="LBLRefuseCount" runat="server" Text="拒绝人数"></asp:Label></p>
                                                <div align="center">
                                                    <p>
                                                        性别：<asp:Label ID="LBLCounsellorSex" runat="server" Text="性别"></asp:Label><br />
                                                        年龄：<asp:Label ID="LBLCounsellorAge" runat="server" Text="年龄"></asp:Label><br />
                                                        邮箱：<asp:Label ID="LBLCounsellorEmail" runat="server" Text="邮箱"></asp:Label><br />
                                                        
                                                        自我介绍：<asp:Label ID="LBLCounsellorSelfIntroduction" runat="server" Text="自我介绍"></asp:Label><br />
                                                        钱包：<asp:Label ID="LBLCounsellorWallet" runat="server" Text="钱包"></asp:Label><br />
                                                        擅长领域：<asp:Label ID="LBLCounsellorAdvantageFields" runat="server" Text="擅长领域"></asp:Label><br />
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <footer class="footer">
                    <div class="content has-text-centered">
                        <p>
                            <asp:Label ID="LBLVote" runat="server" Text="投票结果"></asp:Label>
                            <asp:Button ID="BTNAgree" runat="server" Text="同意" OnClick="BTNAgree_Click" />
                            &nbsp;
                            <asp:Button ID="BTNRefuse" runat="server" Text="拒绝" OnClick="BTNRefuse_Click" /> 

                        </p>
                    </div>
                </footer>
            </section>
            <script src="06CounsellorBlock/CounsellorResume/CounsellorResumeJS/script.js"></script>
        </div>
    </form>
</body>
</html>
