/*
 jQuery Responsive Thumbnail Gallery Plugin
 by John Polacek (@johnpolacek)
 
 Docs: http://johnpolacek.github.com/ResponsiveThumbnailGallery/
 
 License: http://www.opensource.org/licenses/mit-license.php
 */

(function ($) {

    $.ThumbnailGallery = function (el, options) {

        var isUnderBreakpoint,
                currImageNumber,
                imagesPath,
                imageWidth,
                imageHeight,
                thumbWidth,
                thumbHeight,
                gallery,
                view,
                mainImage,
                nav,
                thumbnails,
                buttons;

        var defaults = {
            thumbImages: 'images/thumbs/thumb',
            smallImages: 'img/small/image',
            largeImages: 'images/large/image',
            count: 9,
            thumbImageType: 'jpg',
            breakpoint: 600,
            imageType: 'jpg',
            shadowStrength: 1
        }

        var plugin = this;
        plugin.settings = {}

        var init = function () {
            plugin.settings = $.extend({}, defaults, options);
            this.el = el;

            gallery = $(el).empty();

            view = $('<div id="gallery-view"></div>');
            view.css('margin', '0 auto -1px');

            nav = $('<div id="gallery-nav"></div>');
            nav
                    .css('margin', '0 auto')
                    .css('position', 'relative')

            thumbnails = $('<div id="nav-thumbnails"></div>');
            buttons = $('<div id="nav-buttons"></div>');
            buttons
                    .css('position', 'absolute')
                    .css('top', '0');

            gallery.append(view, nav);
            nav.append(thumbnails, buttons);

            isUnderBreakpoint = $(window).width() < plugin.settings.breakpoint;
            imagesPath = isUnderBreakpoint ?
                    plugin.settings.smallImages : plugin.settings.largeImages;

            updateMainImage(1);

            for (var i = 0; i < plugin.settings.count; i++) {

                var button = $('<a href="#" class="gallery-button"></a>');
                button
                        .css('display', 'block')
                        .css('float', 'left');

                var thumbImage = $('<img class="thumbnail-image" src="' + (plugin.settings.thumbImages) + (i + 1) + '.' + plugin.settings.thumbImageType + '" />');
                thumbImage
                        .css('display', 'block')
                        .css('float', 'left');

                if (i === 0) {
                    thumbImage.load(function () {
                        thumbWidth = this.width;
                        thumbHeight = this.height;
                        $('.gallery-button')
                                .css('width', this.width)
                                .css('height', this.height);
                        nav.css('height', thumbHeight);
                        thumbnails.css('height', thumbHeight);
                        updateSize();
                    });
                } else {
                }
                thumbnails.append(thumbImage);
                buttons.append(button);
            }
            buttons.delegate('.gallery-button', 'click', function (e) {
                e.preventDefault();
                $(this)
                        .css('box-shadow', 'none')
                        .css('background', 'none');

                updateMainImage($(this).index() + 1);
            });

            $(window).resize(function (e) {
                updateSize();
            });
        }
        function updateMainImage(imageNumber) {
            currImageNumber = imageNumber;
            mainImage = $('<img src="' + imagesPath + imageNumber + '.' + plugin.settings.imageType + '" id="main-image" />');
            mainImage.load(function () {
                view.empty().append(mainImage);
                updateSize();
            });
            $("<img/>") // Make in memory copy of image to avoid css issues
                    .attr("src", $(mainImage).attr("src"))
                    .load(function () {
                        imageWidth = this.width;
                        imageHeight = this.height;
                    });
        }
        function updateSize() {
            if (thumbWidth && imageWidth) {
                var galleryWidth = gallery.width();

                // check breakpoint
                if (isUnderBreakpoint != $(window).width() < plugin.settings.breakpoint) {
                    // update main image
                    isUnderBreakpoint = $(window).width() < plugin.settings.breakpoint;
                    imagesPath = isUnderBreakpoint ?
                            plugin.settings.smallImages : plugin.settings.largeImages;
                    updateMainImage(currImageNumber);
                }
                // set main image size
                if (galleryWidth < imageWidth) {
                    mainImage
                            .css('width', galleryWidth)
                            .css('height', '');
                } else {
                    galleryWidth = imageWidth;
                    mainImage
                            .css('width', imageWidth)
                            .css('height', '');
                }

                // calculate number of rows
                var numThumbs = plugin.settings.count;
                var thumbSize = galleryWidth / numThumbs;
                var numRows = 1;
                var thumbScale = thumbSize / thumbWidth;
                var imageScale = galleryWidth / imageWidth;

                // if thumb is below scale threshold, add new row
                while (thumbScale < .5) {
                    numRows++;
                    thumbSize = (galleryWidth * numRows) / numThumbs;
                    thumbScale = thumbSize / thumbWidth;
                }

                // set thumbnail sizes
                var thumbsRemainder = numThumbs;        // tracks thumbs left to scale
                var thumbIndex = 0;                   // tracks thumb index to be scaled
                for (var i = 0; i < numRows; i++) {

                    var numThumbsInRow = Math.ceil(thumbsRemainder / (numRows - i));
                    // scale thumbs in row
                    for (var j = 0; j < numThumbsInRow; j++) {
                        thumbScale = (galleryWidth / numThumbsInRow) / thumbWidth;
                        var newWidth = thumbWidth * thumbScale;
                        var newHeight = thumbHeight * thumbScale;

                        thumbIndex++;
                    }
                    thumbsRemainder -= numThumbsInRow;
                }
            }
            // update view size
            view.width(galleryWidth);
            view.height(mainImage.height());
            // update nav size
            nav.width(galleryWidth);
            nav.height(thumbHeight * thumbScale * numRows);
        }
        init();
    }

})(jQuery);