$(document).ready(function() {
// Optional code to hide all divs
            $("div.mainContent").hide();

              // Selector
            var divs = $("#dashboard, #fnolrules, #cwfrules, #fnolguidelines, #cwfguidelines, #companylist, #help");
            
           
              // Show chosen div, and hide all others
            $(".leftLinks li a").click(function () 
            {
                $("div.mainContent").show();
                $("#" + $(this).attr("class")).show();
                divs.not(("#" + $(this).attr("class"))).hide();
            });
});