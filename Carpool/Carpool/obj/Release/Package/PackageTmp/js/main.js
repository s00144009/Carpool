$(document).ready(function () {
    "use strict";
//+++++++++++++++++++++++++++++++++++++++++++
//     bainner slider Jquery Code Start
//+++++++++++++++++++++++++++++++++++++++++++   
    function customPager() {
        $.each(this.owl.userItems, function (i) {
            var titleData = jQuery(this).find('strong');
            var paginationLinks = jQuery('.owl-controls .owl-pagination .owl-page span');
            $(paginationLinks[i]).append(titleData);
        });
    }
    $("#owl-demo").owlCarousel({
        autoPlay: true,
        navigation: true,
        slideSpeed: 300,
        paginationSpeed: 400,
        singleItem: true,
        items: 1,
        navigationText: ['<i class="fa fa-long-arrow-left"></i>', '<i class="fa fa-long-arrow-right"></i>'],
        pagination: true,
        afterInit: customPager,
        afterUpdate: customPager
    });
//+++++++++++++++++++++++++++++++++++++++++++
//    on click hide and show Jquery Code Start
//+++++++++++++++++++++++++++++++++++++++++++
    $('.full-navgtion').hide();
    $('#clapess a').on('click', function () {
        $('.full-navgtion').slideToggle('slow');
    });
    $('#clapess2 a').on('click', function () {
        $('.full-navgtion').slideToggle('slow');
    });
    $('.search-open').hide();
    $('#btn-closs').on('click', function () {
        $('.search-open').slideToggle('slow');
    });
    $('#clapes-close a').on('click', function () {
        $('.search-open').slideToggle('slow');
    });
    $('.reserve-hotel').hide();
    $('#booking a').on('click', function () {
        $('.reserve-hotel').slideToggle('slow');
    });
    $('#clapess3 a').on('click', function () {
        $('.reserve-hotel').slideToggle('slow');
    });


    $('#booking2 a').on('click', function () {
        $('.reserve-hotel').toggle('slow');
    });
    $('#booking3 a').on('click', function () {
        $('.reserve-hotel').toggle('slow');
    });
//+++++++++++++++++++++++++++++++++++++++++++
//    isotop gallry Jquery Code start
//+++++++++++++++++++++++++++++++++++++++++++
    //+++++++++++++++++++++++++++++++++++++++++++
//    Pri-loding Jquery Code Start
//+++++++++++++++++++++++++++++++++++++++++++
    jQuery(window).on('load',function () {
        jQuery(".spinner-wrapper").delay(1500).fadeOut("slow");

        
        // external js: isotope.pkgd.js

        // init Isotope
        var $grid = $('.grid').isotope({
            itemSelector: '.element-item',
            layoutMode: 'fitRows',
//            fitRows: {
//                gutter: 30
//            }
        });
    });
    var $grid = $('.grid');
// filter functions
    var filterFns = {
        // show if number is greater than 50
        numberGreaterThan50: function () {
            var number = $(this).find('.number').text();
            return parseInt(number, 10) > 50;
        },
        // show if name ends with -ium
        ium: function () {
            var name = $(this).find('.name').text();
            return name.match(/ium$/);
        }
    };
// bind filter button click
    $('.filters-button-group').on('click', 'button', function () {
        var filterValue = $(this).attr('data-filter');
        // use filterFn if matches value
        filterValue = filterFns[ filterValue ] || filterValue;
        $grid.isotope({filter: filterValue});
    });
// change is-checked class on buttons
    $('.button-group').each(function (i, buttonGroup) {
        var $buttonGroup = $(buttonGroup);
        $buttonGroup.on('click', 'button', function () {
            $buttonGroup.find('.is-checked').removeClass('is-checked');
            $(this).addClass('is-checked');
        });
    });


    jQuery(function ($) {
        $("#date-from").datepicker({
            currentText: "Today:" + $.datepicker.formatDate('MM dd', new Date())
//            altFormat: "yy-mm-dd"
        }).datepicker("setDate", new Date());

        $("#date-to").datepicker({
            currentText: "Now"
        }).datepicker("setDate", new Date());

    });
});