<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="03ClientPersonalCentre.aspx.cs" Inherits="ClientPersonalCentre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link rel="stylesheet" href="03PersonalCentreBlock/ClientPersonalCentre/ClientPersonalCentreCSS/style.css">
    <section id="vertical_tab_nav">
        <ul>
            <li><a href="index.html">个人信息</a></li>
            <li><a href="index.html">撰写悬赏</a></li>
            <li><a href="index.html">我的悬赏</a></li>
            <li><a href="index.html">文章收藏</a></li>
            <li><a href="index.html">签约律师</a></li>
            <li><a href="index.html">礼品订单</a></li>
            <li><a href="index.html">账号注销</a></li>
            <!--顶多到7，否则就出去了-->
        </ul>

        <div>
            <article>
                <h2>
                    <asp:Label ID="LBLClientGreetings" runat="server" Text="问候语" Font-Size="XX-Large" ForeColor="Red"></asp:Label>
                    <asp:Label ID="LBLClientNameGreeting" runat="server" Text="客户姓名"></asp:Label>&nbsp
						<asp:Label ID="LBLClientSexPolitely" runat="server" Text="性别"></asp:Label>
                </h2>
                <p>
                    我的ID：<asp:Label ID="LBLClientID" runat="server" Text="客户ID"></asp:Label><br />
                    我的密码：<asp:TextBox ID="TBClientPassword" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBClientPassword" runat="server" ErrorMessage="请填写新的密码" ControlToValidate="TBClientPassword"></asp:RequiredFieldValidator><br />
                    我的姓名：<asp:TextBox ID="TBClientName" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBClientName" runat="server" ErrorMessage="请填写新的姓名" ControlToValidate="TBClientName"></asp:RequiredFieldValidator><br />
                    我的性别：<asp:RadioButton ID="RBMale" runat="server" GroupName="UserSex" AutoPostBack="False" Text="男" />
                    <asp:RadioButton ID="RBFemale" runat="server" GroupName="UserSex" AutoPostBack="False" Text="女" /><br />
                    我的年龄：<asp:DropDownList ID="DDLClientAge" runat="server"></asp:DropDownList><br />
                    我的邮箱：<asp:TextBox ID="TBClientEmail" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBClientEmail" runat="server" ErrorMessage="请填写新的邮箱" ControlToValidate="TBClientEmail"></asp:RequiredFieldValidator><br />
                    我的电话：<asp:TextBox ID="TBClientPhoneNumber" runat="server" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBClientPhoneNumber" runat="server" ErrorMessage="请填写新的电话" ControlToValidate="TBClientPhoneNumber"></asp:RequiredFieldValidator><br />
                    <!--OnKeyPress保证了不可以输入数字以外的字符-->
                    存入金额：<asp:DropDownList ID="DDLClientDepositingMoney" runat="server"></asp:DropDownList>万元<br />
                    我的钱包：<asp:Label ID="LBLClientWallet" runat="server" Text="客户钱包"></asp:Label>元<br />
                    我的照片：<asp:Image ID="IMGClientImage" runat="server" Height="85px" Width="60px" />更新照片？<asp:FileUpload ID="FUClientImageUpload" runat="server" /><br />
                    我的地址：<asp:TextBox ID="TBClientAddress" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBClientAddress" runat="server" ErrorMessage="请填写新的地址" ControlToValidate="TBClientAddress"></asp:RequiredFieldValidator><br />
                    我的积分：<asp:Label ID="LBLClientPoints" runat="server" Text="客户积分"></asp:Label><br />
                    我的等级：<asp:Label ID="LBLClientLevel" runat="server" Text="客户等级"></asp:Label><br />
                    <asp:Button ID="BTNClientInfoUpdateConfirm" runat="server" Text="更新我的信息" OnClick="BTNClientInfoUpdateConfirm_Click" />
                </p>
            </article>

            <article>
                <h2>悬赏内容</h2>
                <p>
                    悬赏题目：<asp:TextBox ID="TBWantedTitle" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBWantedTitle" runat="server" ErrorMessage="请填写悬赏标题" ControlToValidate="TBWantedTitle"></asp:RequiredFieldValidator><br />
                    悬赏类别：<asp:DropDownList ID="DDLQuestionFieldsSelecting" runat="server" AutoPostBack="False">
                        <asp:ListItem Value="0">刑法·盗窃罪共犯问题</asp:ListItem>
                        <asp:ListItem Value="1">刑法·贪污贿赂问题</asp:ListItem>
                        <asp:ListItem Value="2">刑事诉讼法</asp:ListItem>
                        <asp:ListItem Value="3">民法·合同问题</asp:ListItem>
                        <asp:ListItem Value="4">民法·知识产权</asp:ListItem>
                        <asp:ListItem Value="5">婚姻继承问题</asp:ListItem>
                        <asp:ListItem Value="6">民法·侵权责任问题</asp:ListItem>
                        <asp:ListItem Value="7">民法·抵押担保问题</asp:ListItem>
                    </asp:DropDownList><br />
                    悬赏详情：<asp:TextBox ID="TBWantedDetail" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBWantedDetail" runat="server" ErrorMessage="请填写悬赏内容" ControlToValidate="TBWantedDetail"></asp:RequiredFieldValidator><br />
                    悬赏金额：<asp:DropDownList ID="DDLWantedOfferMoney" runat="server"></asp:DropDownList><asp:Label runat="server" Text="万元" ID="LBLClientDepositingMoney"></asp:Label><br />
                </p>
                <asp:Button ID="BTNPostWanted" runat="server" Text="发布悬赏" />
            </article>

            <article>
                <h2>发布过的悬赏</h2>
                <div align="center">
                    <p>
                        <asp:GridView ID="GVPostedWantedInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="WantedID" DataSourceID="SqlDataSource2" EnableModelValidation="True">
                            <Columns>
                                <asp:HyperLinkField DataNavigateUrlFields="WantedID" DataNavigateUrlFormatString="09WantedDetail.aspx?WantedID={0}" DataTextField="WantedTitle" HeaderText="悬赏标题" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="select * from WantedQuestionInfo where WantedPromoterID=@WantedPromoterID">
                            <SelectParameters>
                                <asp:SessionParameter Name="WantedPromoterID" SessionField="UsersID" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </p>
                    <!--后期加上 删除？-->
                </div>
            </article>

            <article>
                <h2>收藏的文章</h2>
                <div align="center">
                    <asp:GridView ID="GVArticleCollectionInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="ArticleCollectionID,ArticleID1" DataSourceID="SqlDataSource3" EnableModelValidation="True">
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="ArticleID" DataNavigateUrlFormatString="07ArticleDetail.aspx?ArticleID={0}" DataTextField="ArticleTitle" HeaderText="文章标题" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="select * from ArticleCollectionInfo,ArticleInfo where ArticleCollectionInfo.ArticleID=ArticleInfo.ArticleID and ClientID=@ClientID">
                        <SelectParameters>
                            <asp:SessionParameter Name="ClientID" SessionField="UsersID" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </article>
            <article>
                <h2>签约律师</h2>
                <div align="center">
                    <p>
                    <asp:GridView ID="GVCounsellorContract" runat="server" AutoGenerateColumns="False" DataKeyNames="ContractID,CounsellorID1" DataSourceID="SqlDataSource1" EnableModelValidation="True">
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="CounsellorID" DataNavigateUrlFormatString="06CounsellorDetail.aspx?CounsellorID={0}" DataTextField="CounsellorName" HeaderText="律师姓名" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="select * from ContractInfo,CounsellorInfo where ContractInfo.CounsellorID=CounsellorInfo.CounsellorID and ([ClientID] = @ClientID)">
                        <SelectParameters>
                            <asp:SessionParameter Name="ClientID" SessionField="UsersID" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </p>
                </div>
            </article>
            <article>
                <h2>兑换的礼物</h2>
                <div align="center">
                    <asp:GridView ID="GVGiftPurchased" runat="server" AutoGenerateColumns="False" DataKeyNames="GiftTradeID,GiftID1" DataSourceID="SqlDataSource4" EnableModelValidation="True">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="GiftID" DataNavigateUrlFormatString="10GiftDetail.aspx?GiftID={0}" DataTextField="GiftName" HeaderText="礼物列表" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="select * from GiftTradeInfo,GiftInfo where GiftTradeInfo.GiftID=GiftInfo.GiftID and ([ClientID]=@ClientID)">
                    <SelectParameters>
                        <asp:SessionParameter Name="ClientID" SessionField="UsersID" />
                    </SelectParameters>
                </asp:SqlDataSource>
                </div>
            </article>
            <article>

                <asp:Button ID="BTNClientAccountDestory" runat="server" Text="点击以注销账户" OnClick="BTNClientAccountDestory_Click" />
            </article>
        </div>
    </section>

    <script src="03PersonalCentreBlock/ClientPersonalCentre/ClientPersonalCentreJS/jquery.min.js"></script>
    <script src="03PersonalCentreBlock/ClientPersonalCentre/ClientPersonalCentreJS/script.js"></script>
</asp:Content>

