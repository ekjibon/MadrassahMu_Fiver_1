window.onload = function () {
    const CSSPreProcessor = `Sass`;
    const JSVersion = `ES6`;

    //Make only App__Main Section scrollable
    //var screenHeight = screen.height;
    //var appMainHeight = screenHeight - 110;
    //$(".js-app-main").css("min-height", appMainHeight+"px");
    //Toggle Sidenav
    if (window.screen.width > 1199) {
        $(".js-grid-container").addClass("sidenav-active");
    }

    $(".js-sidenav-toggle").on('click', function () {
        var isActive = $(".js-grid-container").hasClass("sidenav-active");

        if (isActive) {
            $(".js-grid-container").removeClass("sidenav-active");
        } else {
            $(".js-grid-container").addClass("sidenav-active");
        }
    });  

    //Toggle Sidenav Items
    $(".closed .js-dropdown-item").hide();
    $(".js-dropdown-item-title").on('click', function () {
        var isClosed = $(this).parent().hasClass("closed");

        if (isClosed) {
            $(this).parent().removeClass("closed");
            $(this).parent().find(".js-dropdown-item").slideDown(100);
        } else {
            $(this).parent().addClass("closed");
            $(this).parent().find(".js-dropdown-item").slideUp(100);
        }
    });
};

