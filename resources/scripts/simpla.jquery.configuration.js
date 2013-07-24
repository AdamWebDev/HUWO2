var asInitVals = new Array(); // part of DataTables initializing
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


			$('.open-popup-link').magnificPopup({
            type: 'inline'
        
    });

    $('.datepicker').datepicker({
        dateFormat: "yy-mm-dd"
    });

    $(".timepicker").timepicker({
        stepMinute: 15,
        timeFormat: "hh:mm TT"
    });

    $(document).tooltip({
        items: ".tooltip-url",
        content: "A URL is the address a web page, for example http://www.google.com",
        position: {
            my: "left+20",
            at: "center"
        }
    });

    var tooltips = $('.tooltip');
    tooltips.tooltip({
        items: "[data-help]",
        content: function () {
            return tooltips.data("help");
        },
        position: {
            my: "left+20",
            at: "center"
        }
    });

    var oTable = $('table.sortable').dataTable({
        "iDisplayLength": 50,
        "oLanguage": {
            "sSearch": "Search all columns:",
            "sZeroRecords": "No work orders here!"
        }
    });

    $("tfoot input").keyup(function () {
        /* Filter on the column (the index) of this element */
        oTable.fnFilter(this.value, $("tfoot input").index(this));
    });


    var path = window.location['pathname'];
    $('#main-nav a[href="' + path + '"]').addClass("current");

    // View Work Orders - hides any rows that don't have a value in them.
    $('ul.view-wo li').each(function () {
        var text = $(this).children('span').html();
        if (!text || text.trim() == '') $(this).hide();
        else $(this).children('span').html(replaceURLWithHTMLLinks(text));
    });

    /*
    * Support functions to provide a little bit of 'user friendlyness' to the textboxes in
    * the footer
    */
    $("tfoot input").each(function (i) {
        asInitVals[i] = this.value;
    });

    $("tfoot input").focus(function () {
        if (this.className == "search_init") {
            this.className = "";
            this.value = "";
        }
    });

    $("tfoot input").blur(function (i) {
        if (this.value == "") {
            this.className = "search_init";
            this.value = asInitVals[$("tfoot input").index(this)];
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
        $(".datepicker").datepicker({
            dateFormat: "yy-mm-dd"
        });
        $(".timepicker").timepicker({ stepMinute: 15, timeFormat: "hh:mm TT" });
    }
}

function replaceURLWithHTMLLinks(sometext) {
    var exp = /(\b(https?|ftp|file):\/\/[-A-Z0-9+&@#\/%?=~_|!:,.;]*[-A-Z0-9+&@#\/%=~_|])/ig;
    return sometext.replace(exp, "$1 (<a href='$1' target='_blank'>Link</a>)");
}