$(document).ready(function () {

    //Sidebar Accordion Menu:

    $("#main-nav li ul").hide(); // Hide all sub menus
    $("#main-nav li a.current").parent().find("ul").slideToggle("slow"); // Slide down the current menu item's sub menu

    $("#main-nav li a.nav-top-item").click( // When a top menu item is clicked...
			function () {
			    $(this).parent().siblings().find("ul").slideUp("normal"); // Slide up all sub menus except the one clicked
			    $(this).next().slideToggle("normal"); // Slide down the clicked sub menu
			    return false;
			}
		);

    $("#main-nav li a.no-submenu").click( // When a menu item with no sub menu is clicked...
			function () {
			    window.location.href = (this.href); // Just open the link instead of a sub menu
			    return false;
			}
		);

    // Sidebar Accordion Menu Hover Effect:

    $("#main-nav li .nav-top-item").hover(
			function () {
			    $(this).stop().animate({ paddingRight: "25px" }, 200);
			},
			function () {
			    $(this).stop().animate({ paddingRight: "15px" });
			}
		);

    //Minimize Content Box

    // Content box tabs:

    $('.content-box .content-box-content div.tab-content').hide(); // Hide the content divs
    $('ul.content-box-tabs li a.default-tab').addClass('current'); // Add the class "current" to the default tab
    $('.content-box-content div.default-tab').show(); // Show the div with class "default-tab"

    $('.content-box ul.content-box-tabs li a').click( // When a tab is clicked...
			function () {
			    $(this).parent().siblings().find("a").removeClass('current'); // Remove "current" class from all tabs
			    $(this).addClass('current'); // Add class "current" to clicked tab
			    var currentTab = $(this).attr('href'); // Set variable "currentTab" to the value of href of clicked tab
			    $(currentTab).siblings().hide(); // Hide all content divs
			    $(currentTab).show(); // Show the content div with the id equal to the id of clicked tab
			    return false;
			}
		);

    //Close button:

    $(".close").click(
			function () {
			    $(this).parent().fadeTo(400, 0, function () { // Links with the class "close" will close parent
			        $(this).slideUp(400);
			    });
			    return false;
			}
		);

    // Alternating table rows:

    $('tbody tr:even').addClass("alt-row"); // Add class "alt-row" to even table rows

    // Check all checkboxes when the one in a table head is checked:

    $('.check-all').click(
			function () {
			    $(this).parent().parent().parent().parent().find("input[type='checkbox']").attr('checked', $(this).is(':checked'));
			}
		);

    $('.datepicker').datepicker();

    $(".timepicker").timepicker({
        stepMinute: 15,
        timeFormat: "hh:mm TT"
    });

    var path = window.location['pathname'];
    console.log(path);
    $('#main-nav a[href="' + path + '"]').addClass("current");

    // hides any rows that don't have a value in them.
    $('ul.view-wo li').each(function () {
        if ($(this).children('span').html() == '') {
            $(this).hide();
        }
    });
});


function checkDate(sender, args) {
    var dt = new Date();
    if (sender._selectedDate > dt) {
        sender
            ._textbox
            .set_Value(dt.format(sender._format));
    }
}

function pageLoad(sender, args) {
    if (args.get_isPartialLoad()) {
        $(".datepicker").datepicker();
        $(".timepicker").timepicker({ stepMinute: 15, timeFormat: "hh:mm TT" });
    }
}