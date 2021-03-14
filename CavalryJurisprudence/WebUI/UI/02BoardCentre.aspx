<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="02BoardCentre.aspx.cs" Inherits="BoardCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="02BoardCenterBlock/BoardCenterCSS/style.css">

    <h1 style="margin-bottom: 40px;">
        <asp:Label ID="LBLBoardGreetings" runat="server" Text="问候语"></asp:Label>
        <asp:Label ID="LBLBoardMemberName" runat="server" Text="董事会成员姓名"></asp:Label>
        <asp:Label ID="LBLBoardMemberSex" runat="server" Text="董事会性别"></asp:Label>
    </h1>
    <div class="tabArea" style="width: 98%; margin-left: 5px; height: 100%">
        <ul class="tabMenu">
            <li class="on"><a href="#"><span>快速设置</span></a></li>
            <li><a href="#"><span>密钥查看</span></a></li>
            <li><a href="#"><span>投票开除</span></a></li>
            <li><a href="#"><span>个人信息</span></a></li>
        </ul>
        <div class="tabCont">
            快速设置面板 
            <div class="tabArea" style="width: 98%; margin-left: 5px; margin-top: 30px;">
                <ul class="subTab">
                    <li class="on "><a href="#"><span>开除申请</span></a></li>
                    <!--
                        <li><a href="#"><span>改密申请</span></a></li>
                        -->
                    <li><a href="#"><span>入会申请</span></a></li>
                </ul>
                <div class="tabCont">
                    <asp:GridView ID="GVBoardDischargeInfo" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CounsellorID" DataSourceID="SqlDataSourceBoardDIschargeInfo" EnableModelValidation="True" Font-Size="Large" ForeColor="#333333" GridLines="None" OnRowCommand="GVBoardDischargeInfo_RowCommand">
                        <alternatingrowstyle backcolor="White" />
                        <columns>
                            <asp:BoundField DataField="BoardDischargeID" HeaderText="开除流水号ID" InsertVisible="False" SortExpression="BoardDischargeID">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BoardMemberSequenceID" HeaderText="董事会成员ID" InsertVisible="False" SortExpression="BoardMemberSequenceID">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CounsellorName" HeaderText="董事会成员姓名" SortExpression="CounsellorName">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CounsellorSex" HeaderText="董事会成员性别" SortExpression="CounsellorSex">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CounsellorAge" HeaderText="董事会成员年龄" SortExpression="CounsellorAge">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:Button ID="BTNAgree" runat="server" CommandArgument='<%# Eval("BoardDischargeID").ToString()+"Y" %>' Font-Size="Medium" ForeColor="Black" Text="同意" />
                                    <asp:Button ID="BTNDeny" runat="server" CommandArgument='<%# Eval("BoardDischargeID").ToString()+"N" %>' Font-Size="Medium" ForeColor="Black" Text="拒绝" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </columns>
                        <editrowstyle backcolor="#2461BF" />
                        <footerstyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                        <headerstyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                        <pagerstyle backcolor="#2461BF" forecolor="White" horizontalalign="Center" />
                        <rowstyle backcolor="#EFF3FB" />
                        <selectedrowstyle backcolor="#D1DDF1" font-bold="True" font-size="XX-Large" forecolor="#333333" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceBoardDIschargeInfo" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="select * from BoardMemberDischargeInfo,BoardInfo,CounsellorInfo where BoardMemberSequenceID=BEENDischargedBoardID and BoardMemberIDfromCounsellor=CounsellorID"></asp:SqlDataSource>
                </div>
                <!--
                    <div class="tabCont">
                    改密申请
                </div>
                    -->
                <div class="tabCont">
                    <asp:GridView ID="GVBoardApplyInfo" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CounsellorID1" DataSourceID="SqlDataSourceBoardApplyInfo" EnableModelValidation="True" ForeColor="#333333" GridLines="None" OnRowCommand="GVBoardApplyInfo_RowCommand1" Font-Size="Large">
                        <alternatingrowstyle backcolor="White" />
                        <columns>
                            <asp:BoundField DataField="BoardApplyID" HeaderText="申请流水号ID" InsertVisible="False" SortExpression="BoardApplyID" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CounsellorSex" HeaderText="律师性别" SortExpression="CounsellorSex" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CounsellorAge" HeaderText="律师年龄" SortExpression="CounsellorAge" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CounsellorWallet" HeaderText="律师余额" SortExpression="CounsellorWallet" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="CounsellorID" DataNavigateUrlFormatString="06CounsellorResume.aspx?CounsellorID={0}" DataTextField="CounsellorName" HeaderText="律师姓名" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:HyperLinkField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:Button ID="BTNAgree" runat="server" Text="同意" CommandArgument='<%# Eval("BoardApplyID").ToString()+"Y" %>' Font-Size="Medium" ForeColor="Black" />
                                    <asp:Button ID="BTNRefuse" runat="server" Text="拒绝" CommandArgument='<%# Eval("BoardApplyID").ToString()+"N" %>' Font-Size="Medium" ForeColor="Black" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </columns>
                        <editrowstyle backcolor="#2461BF" />
                        <footerstyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                        <headerstyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                        <pagerstyle backcolor="#2461BF" forecolor="White" horizontalalign="Center" />
                        <rowstyle backcolor="#EFF3FB" />
                        <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceBoardApplyInfo" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="select * from BoardApplyInfo,CounsellorInfo where BoardApplyInfo.CounsellorID=CounsellorInfo.CounsellorID"></asp:SqlDataSource>
                </div>
            </div>


            <!--
                <div class="tabArea" style="width: 98%; margin-left: 5px; margin-top: 30px;">
                <ul class="subTab fixed">
                    <li class="on "><a href="#"><span>二级菜单 01</span></a></li>
                    <li><a href="#"><span>二级菜单 02</span></a></li>
                    <li><a href="#"><span>二级菜单 03</span></a></li>
                </ul>
                <div class="tabCont">tabCont 二级菜单内容01</div>
                <div class="tabCont">tabCont 二级菜单内容02</div>
                <div class="tabCont">tabCont 二级菜单内容03</div>
            </div>
                -->
        </div>
        <div class="tabCont">
            <h1>董事会密钥：</h1>
            <asp:Label ID="LBLBoardSecretKEY" runat="server" Text="董事会密钥"></asp:Label>
        </div>
        <div class="tabCont">
            <asp:GridView ID="GVBoardMemberDischarge" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CounsellorID" DataSourceID="SqlDataSourceBoardInfoExceptFounders" EnableModelValidation="True" ForeColor="#333333" GridLines="None" OnRowCommand="GVBoardMemberDischarge_RowCommand" Font-Size="Large">
                <alternatingrowstyle backcolor="White" />
                <columns>
                    <asp:BoundField DataField="CounsellorName" HeaderText="成员姓名" SortExpression="CounsellorName" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CounsellorSex" HeaderText="成员性别" SortExpression="CounsellorSex" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CounsellorAge" HeaderText="成员年龄" SortExpression="CounsellorAge" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CounsellorWallet" HeaderText="成员余额" SortExpression="CounsellorWallet" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="投票">
                        <ItemTemplate>
                            <asp:Button ID="BTNVote2Discharge" runat="server" CommandArgument='<%# Eval("BoardMemberSequenceID") %>' Text="投票开除" Font-Size="Medium" ForeColor="Black" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </columns>
                <editrowstyle backcolor="#2461BF" />
                <footerstyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                <headerstyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                <pagerstyle backcolor="#2461BF" forecolor="White" horizontalalign="Center" />
                <rowstyle backcolor="#EFF3FB" />
                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSourceBoardInfoExceptFounders" runat="server" ConnectionString="<%$ ConnectionStrings:CavalryJurisprudenceConnectionString %>" SelectCommand="select * from BoardInfo,CounsellorInfo where FounderIdentityJudgement!='Y' and BoardInfo.BoardMemberIDfromCounsellor=CounsellorInfo.CounsellorID"></asp:SqlDataSource>
            <br />
        </div>

        <div class="tabCont">
            <h1>
                <asp:Label ID="LBLWelcome" runat="server" Text="欢迎您!"></asp:Label><br />
                <asp:Label ID="LBLFounderCode" runat="server" Text="创始人代号"></asp:Label><br />
                <asp:Label ID="LBLBoardSequenceID" runat="server" Text="董事会ID"></asp:Label><br />
                <asp:TextBox ID="TBBoardPassword" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidatorOnTBBoardPassword" runat="server" ErrorMessage="请填写新的密码" ControlToValidate="TBBoardPassword"></asp:RequiredFieldValidator>
                <asp:Button ID="BTNUpdate" runat="server" Text="修改密码" OnClick="BTNUpdate_Click" />
            </h1>

        </div>
    </div>

    <script src="02BoardCenterBlock/BoardCenterJS/jquery.min.js"></script>
    <script src="02BoardCenterBlock/BoardCenterJS/script.js"></script>
</asp:Content>

