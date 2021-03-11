$(function() {

    var menuItem1 = $('#menu-item-1');
    var menuItem2 = $('#menu-item-2');
    var menuItem3 = $('#menu-item-3');
    var menuItem4 = $('#menu-item-4');
    var menuItem5 = $('#menu-item-5');
    var menuItem6 = $('#menu-item-6');

    var page1 = $('#content-item-1');
    var page2 = $('#content-item-2');
    var page3 = $('#content-item-3');
    var page4 = $('#content-item-4');
    var page5 = $('#content-item-5');
    var page6 = $('#content-item-6');

    menuItem1.click(function() {
        menuItem1.addClass('active');
        menuItem2.removeClass('active');
        menuItem3.removeClass('active');
        menuItem4.removeClass('active');
        menuItem5.removeClass('active');
        menuItem5.removeClass('active');
        page1.show();
        page2.hide();
        page3.hide();
        page4.hide();
        page5.hide();
        page6.hide();
    });

    menuItem2.click(function() {
        menuItem2.addClass('active');
        menuItem1.removeClass('active');
        menuItem3.removeClass('active');
        menuItem4.removeClass('active');
		menuItem5.removeClass('active');
        page1.hide();
        page2.show();
        page3.hide();
        page4.hide();
        page5.hide();
        page6.hide();
    });

    menuItem3.click(function() {
        menuItem3.addClass('active');
        menuItem1.removeClass('active');
        menuItem2.removeClass('active');
        menuItem4.removeClass('active');
		menuItem5.removeClass('active');
        page1.hide();
        page2.hide();
        page3.show();
        page4.hide();
        page4.hide();
        page6.hide();
    });

    menuItem4.click(function() {
        menuItem4.addClass('active');
        menuItem1.removeClass('active');
        menuItem2.removeClass('active');
        menuItem3.removeClass('active');
		menuItem5.removeClass('active');
        page1.hide();
        page2.hide();
        page3.hide();
        page4.show();
        page5.hide();
        page6.hide();
    });

	menuItem5.click(function() {
        menuItem5.addClass('active');
        menuItem1.removeClass('active');
        menuItem2.removeClass('active');
        menuItem3.removeClass('active');
		menuItem4.removeClass('active');
        page1.hide();
        page2.hide();
        page3.hide();
        page4.hide();
        page5.show();
        page6.hide();
    });

    menuItem6.click(function () {
        menuItem6.addClass('active');
        menuItem1.removeClass('active');
        menuItem2.removeClass('active');
        menuItem3.removeClass('active');
        menuItem4.removeClass('active');
        menuItem5.removeClass('active');
        page1.hide();
        page2.hide();
        page3.hide();
        page4.hide();
        page5.hide();
        page6.show();
    });

	page1.show();/*默认显示第一页*/
    page2.hide();
    page3.hide();
    page4.hide();
    page5.hide();
    page6.hide();
});