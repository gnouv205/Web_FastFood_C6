

window.triggerFileInput = (element) => {
    element.click();
};

/*price range*/

 $('#sl2').slider();

	var RGBChange = function() {
	  $('#RGB').css('background', 'rgb('+r.getValue()+','+g.getValue()+','+b.getValue()+')')
	};	
		
/*scroll to top*/

$(document).ready(function(){
    $(function () {
        $.scrollUp({
            scrollName: 'scrollUp', // Element ID
            scrollDistance: 300, // Distance from top/bottom before showing element (px)
            scrollFrom: 'top', // 'top' or 'bottom'
            scrollSpeed: 300, // Speed back to top (ms)
            easingType: 'linear',
            animation: 'fade', // 'fade', 'slide', 'none'
            animationSpeed: 200, // Animation speed (ms)
            scrollText: '<i class="fa fa-angle-up"></i>', // Text or HTML for the 'back to top' element
            zIndex: 2147483647 // Z-Index for the overlay
        });
    });
});
