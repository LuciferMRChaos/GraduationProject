<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="06CounsellorDetail.aspx.cs" Inherits="CounsellorDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
            height: 600px;
        }

        .auto-style5 {
            width: 35px;
        }

        .auto-style6 {
            width: 1061px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="auto-style4">
        <tr>
            <td class="auto-style5">
                <!--
                    <asp:Button ID="Button1" runat="server" Text="占位按钮" />
                    -->
            </td>
            <td class="auto-style6">
                <link rel="stylesheet" href="06CounsellorBlock/CounsellorDetail/CounsellorDetailCSS/bootstrap.min.css">
                <link rel="stylesheet" href="06CounsellorBlock/CounsellorDetail/CounsellorDetailCSS/style.css">
                <header class="container">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6 name">
                            <asp:Label ID="LBLCounsellorName" runat="server" Text="律师姓名"></asp:Label>
                        </div>
                    </div>
                </header>
                <div id="content" class="container">
                    <div class="row introduction">
                        <div class="col-xs-9 text">
                            <div class="row">
                                <div class="col-xs-12">
                                    律师等级：<asp:Label ID="LBLCounsellorLevel" runat="server" Text="律师等级"></asp:Label>
                                    <br>
                                    签约价格：<asp:Label ID="LBLCounsellorOfferMoney" runat="server" Text="签约价格"></asp:Label>
                                    <hr>
                                </div>
                            </div>
                            <div class="row title">
                                <div class="col-xs-12">
                                    律师简介
                                </div>
                                <asp:Label ID="LBLCounsellorTips" runat="server" Text="简介"></asp:Label>
                            </div>
                        </div>
                        <div class="col-xs-3  pic">
                            <asp:Image ID="IMGCounsellorImage" class="img-responsive" runat="server" />
                        </div>
                    </div>

                    <div class="row links">
                        <div class="col-xs-12 tab">
                            <div class="row tab-top">
                                <div class="col-xs-3 cur">个人信息</div>
                                <div class="col-xs-3">经办悬赏</div>
                                <div class="col-xs-3">专业领域</div>
                                <div class="col-xs-3">与我联系</div>
                            </div>
                            <div class="row tab-content">
                                <div class="col-xs-12 js current">
                                    <div class="row" align="left">
                                        <h1>
                                        律师姓名：<asp:Label ID="LBLCounsellorNamePage1" runat="server" Text="律师姓名"></asp:Label><br />
                                        律师性别：<asp:Label ID="LBLCounsellorSex" runat="server" Text="律师性别"></asp:Label><br />
                                        签约数量：<asp:Label ID="LBLCounsellorContractAmount" runat="server" Text="签约数量"></asp:Label><br />
                                        <!--
                                            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label><br />
                                            -->
                                        </h1>
                                    </div>
                                </div>
                                <div class="col-xs-12 p5">
                                    <asp:GridView ID="GVWantedAnswer" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableModelValidation="True">
                                        <Columns>
                                            <asp:BoundField DataField="WantedTitle" HeaderText="题目" SortExpression="WantedTitle" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="select WantedTitle from WantedAnswerInfo,WantedQuestionInfo where WantedQuestionInfo.WantedID=WantedAnswerInfo.WantedIDFromWantedQuestionInfo
and ([ResponderIDFromCounsellorInfo]) =(@ResponderIDFromCounsellorInfo)">
                                        <SelectParameters>
                                            <asp:QueryStringParameter Name="ResponderIDFromCounsellorInfo" QueryStringField="CounsellorID" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                                <div class="col-xs-12 d3">
                                    <div class="row" >
                                        <h1>
                                            <asp:Label ID="LBLCounsellorAdvantageField0" runat="server" Text="擅长领域1"></asp:Label><br />
                                            <asp:Label ID="LBLCounsellorAdvantageField1" runat="server" Text="擅长领域2"></asp:Label><br />
                                            <asp:Label ID="LBLCounsellorAdvantageField2" runat="server" Text="擅长领域3"></asp:Label><br />
                                            <asp:Label ID="LBLCounsellorAdvantageField3" runat="server" Text="擅长领域4"></asp:Label><br />
                                            <asp:Label ID="LBLCounsellorAdvantageField4" runat="server" Text="擅长领域5"></asp:Label><br />
                                            <asp:Label ID="LBLCounsellorAdvantageField5" runat="server" Text="擅长领域6"></asp:Label><br />
                                            <asp:Label ID="LBLCounsellorAdvantageField6" runat="server" Text="擅长领域7"></asp:Label><br />
                                            <asp:Label ID="LBLCounsellorAdvantageField7" runat="server" Text="擅长领域8"></asp:Label><br />
                                        </h1>
                                        
                                    </div>
                                </div>
                                <div class="col-xs-12 React">
                                    <div class="row">
                                        <br />
                                        <h1>律师电话：<asp:Label ID="LBLCounsellorPhoneNumber" runat="server" Text="律师电话"></asp:Label></h1>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <footer class="container">
                    <div class="row">
                        <asp:Button ID="BTNEstablishContract" runat="server" Text="与我签约" Height="32px" OnClick="BTNEstablishContract_Click" Width="106px" ForeColor="Blue" />
                    </div>
                    <div class="row">
                        封底2
                    </div>
                </footer>
                <!-- partial -->
                <script src="06CounsellorBlock/CounsellorDetail/CounsellorDetailJS/jquery.min.js"></script>
                <script src="06CounsellorBlock/CounsellorDetail/CounsellorDetailJS/script.js"></script>
            </td>
            <td>
                <!--
                    <asp:Button ID="Button2" runat="server" Text="占位按钮" />
                    -->
            </td>
        </tr>
    </table>
</asp:Content>

