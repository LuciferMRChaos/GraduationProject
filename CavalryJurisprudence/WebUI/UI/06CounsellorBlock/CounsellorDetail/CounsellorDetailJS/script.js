$(function(){/*模块滑动*/
  var index;
  $(".tab-top > div").on("mouseover",function(){
    index = $(".tab-top > div").index(this);
    $(".tab-content > div").removeClass("current").eq(index).addClass("current");
    $(this).addClass("cur").siblings().removeClass("cur");
  });
  
  $(".tab-content a").hover(function(){
    $(".tab-content a img").css("opacity","0.2");
    $(this).find("img").css("opacity","1").siblings("i").show();
  },function(){
    $(".tab-content a img").css("opacity","0.6");
    $(this).find("img").siblings("i").hide();
  });
  
  $("i.fa-heart").click(function(e){
    $(this).toggleClass("like");
    e.stopPropagation();
    e.preventDefault();
  });
});