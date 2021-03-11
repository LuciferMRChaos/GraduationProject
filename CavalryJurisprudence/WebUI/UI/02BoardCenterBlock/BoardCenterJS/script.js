// 탭 메뉴
// subTab01,subTab02 css가 생성될때 만들어짐.현재는 없음
function tabUI() {
    var el;
    el = $('.tabArea');
    if(el.length <= 0){
        return;
    }
    el.each(function(idx, obj){
        if($(obj).find('.tabMenu > li, .subTab01 > li, .subTab02 > li, .subTab03 > li, .subTab > li').hasClass('on')){
            $(obj).find('.tabMenu > li, .subTab01 > li, .subTab02 > li, .subTab03 > li, .subTab > li').each(function(){
                var idx = $(this).filter('.on').index();
                if(idx >= 0){
                    $(obj).find('.tabMenu > li, .subTab01 > li, .subTab02 > li, .subTab03 > li .subTab > li').eq(idx).addClass('on').siblings().removeClass('on');;
                    $(obj).find('.tabMenu > li.on > a, .subTab01 > li.on > a, .subTab02 > li.on a, .subTab03 > li.on > a, .subTab > li.on > a').after('<span class="blind">선택됨</span>');
                    $(obj).find('> .tabCont').hide().eq(idx).show();
                }
            });
        }
        else{
            $(obj).find('.tabMenu > li, .subTab01 > li, .subTab > li').eq(0).addClass('on').siblings().removeClass('on');;
            $(obj).find('.tabMenu > li.on > a, .subTab01 > li.on > a, .subTab02 > li.on > a, .subTab03 > li.on > a, .subTab > li.on > a').after('<span class="blind">선택됨</span>');
            $(obj).find('> .tabCont').hide().eq(0).show();
        }

        bindEvents(obj);
    });

    function bindEvents(obj){
        var $this = $(obj);

        $this.find('.tabMenu > li > a, .subTab01 > li > a, .subTab02 > li > a, .subTab03 > li > a, .subTab > li > a').on('click', function(e){
            e.preventDefault();
            var index = $(this).closest('li').index();

            if($this.find('> .tabCont').eq(index).length <= 0){
                return;
            }

            $(this).closest(el).find('.tabMenu > li > span.blind, .subTab01 > li > span.blind, .subTab02 > li > span.blind, .subTab03 > li > span.blind, .subTab > li > span.blind').remove();
            $(this).after('<span class="blind">선택됨</span>');
            $(this).closest(el).find('.tabMenu > li, .subTab01 > li, .subTab02 > li, .subTab03 > li, .subTab > li').eq(index).addClass('on').siblings().removeClass('on');
            $(this).closest(el).find('> .tabCont').hide().eq(index).show();

            // 스크롤 디자인
            designScroll();

        });

    }
}

/*function값 확인바람*/
$(function(){
    tabUI();
});