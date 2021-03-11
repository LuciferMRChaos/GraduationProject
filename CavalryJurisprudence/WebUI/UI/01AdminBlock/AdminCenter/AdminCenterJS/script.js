$(function(){
  zui.tabs.initTabs();
  zui.shell.initializeShellJs();
  
  $('#throw-toast').click(function(){
    test(zui.toast.handleError, 'Your content can no longer be accessed. Please contact your administrator.');
  });
  

  
});
