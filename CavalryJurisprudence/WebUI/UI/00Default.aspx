<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="00Default.aspx.cs" Inherits="_00Default_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="00Default/DefaultCSS/icon/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="00Default/DefaultCSS/swiper.css">
    <link rel="stylesheet" href="00Default/DefaultCSS/style.css">
    <section class="section__slider">
        <div class="container__center">
            <div class="swiper-container">
                <div class="swiper-wrapper">
                    <div class="swiper-slide">
                        <div class="swiper-slide__block">
                            <div class="swiper-slide__block__img" data-swiper-parallax-y="70%">
                                <a target="08CompanyInfo" href="08CompanyInfo.aspx">
                                    <img src="WebImages/00DefaultImage01.jpg" alt="第一张图片">
                                </a>
                            </div>
                            <div class="swiper-slide__block__text">
                                <h2 data-swiper-parallax-x="-60%" class="main__title">凯渥瑞
										<br>
                                    法律援助
										<span>.</span>
                                </h2>
                                <h3 data-swiper-parallax-x="-50%" class="main__subtitle">公司介绍
										<span>• 2020</span>
                                </h3>
                                <p data-swiper-parallax-x="-40%" class="paragraphe">凯渥瑞法律援助公司原本是凯渥瑞集团的法律部门，于2020年独立并成立分公司。凭借其法律部门的多年经验，配以高素质·低费用，短短几个月时间内帮助无数受害人捍卫了应有的权利</p>
                                <a data-swiper-parallax-x="-30%" class="link" target="08CompanyInfo" href="08CompanyInfo.aspx">Discover</a>
                                <span data-swiper-parallax-y="60%" class="number">1</span>
                            </div>
                        </div>
                    </div>
                    <div class="swiper-slide">
                        <div class="swiper-slide__block">
                            <div class="swiper-slide__block__img" data-swiper-parallax-y="70%">
                                <a target="standby" href="12EliteCounsellors.aspx">
                                    <img src="WebImages/00DefaultImage02.jpg" alt="第二张图片">
                                </a>
                            </div>
                            <div class="swiper-slide__block__text">
                                <h2 data-swiper-parallax-x="-60%" class="main__title">每一场战役
										<br>
                                    与您并肩同行
										<span>.</span>
                                </h2>
                                <h3 data-swiper-parallax-x="-50%" class="main__subtitle">精英律师
										<span>• 2020</span>
                                </h3>
                                <p data-swiper-parallax-x="-40%" class="paragraphe">无论前路多么艰辛，我们的律师都会与您一同捍卫法律的尊严.</p>
                                <a data-swiper-parallax-x="-30%" class="link" target="12EliteCounsellors" href="12EliteCounsellors.aspx">Discover</a>
                                <span data-swiper-parallax-y="60%" class="number">2</span>
                            </div>
                        </div>
                    </div>
                    <div class="swiper-slide">
                        <div class="swiper-slide__block">
                            <div class="swiper-slide__block__img" data-swiper-parallax-y="70%">
                                <a target="07ArticleList" href="07ArticleList.aspx">
                                    <img src="WebImages/00DefaultImage03.jpg" alt="第三张图片">
                                </a>
                            </div>
                            <div class="swiper-slide__block__text">
                                <h2 data-swiper-parallax-x="-60%" class="main__title">未雨绸缪
										<br>
                                    有备无患
										<span>.</span>
                                </h2>
                                <h3 data-swiper-parallax-x="-50%" class="main__subtitle">法律知识
										<span>• 2020</span>
                                </h3>
                                <p data-swiper-parallax-x="-40%" class="paragraphe">只有不断学习、进取，才能拥抱崭新的时代</p>
                                <a data-swiper-parallax-x="-30%" class="link" target="07ArticleList" href="07ArticleList.aspx">Discover</a>
                                <span data-swiper-parallax-y="60%" class="number">3</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="swiper-button-next">
                    <i class="fa fa-long-arrow-right" aria-hidden="true"></i>
                </div>
                <div class="swiper-button-prev">
                    <i class="fa fa-long-arrow-left" aria-hidden="true"></i>
                </div>
            </div>
        </div>
        <div align="center">
            <asp:Button ID="BTN2ManagersLogin" runat="server" Text="HideLoginTEST" OnClick="BTN2ManagersLogin_Click" />
        </div>
    </section>
    <script src="00Default/DefaultJS/swiper.min.js"></script>
    <script src="00Default/DefaultJS/script.js"></script>
</asp:Content>

