$(function () {
  'use strict';
  $('.product').hover(function () {
    $(this).toggleClass('hovered');
  });
});
$(function () {
    var Cart = function () {

    };
});
$(function () {
    $('.image-updater').change(function () {
        var formData = new FormData(),
            $this = $(this),
            files = $this.get(0).files,
            $target = $($this.data('target')),
            value = $this.val();

        for (var i = 0; i < files.length; i++) {
            formData.append(files[i].name, files[i]);
        }
        
        $.ajax({
            data: formData,
            contentType: false,
            processData: false,
            type: 'POST',
            url: '/Images/UploadQuoteImage'
        })
            .done(function (data) {
                for (var i = 0; i < data.length; i++) {
                    var imgSource = data[i].relativePath;
                    $target.append($('<img src="' + imgSource + '" />'));
                }
                
                console.log(data);
            })
            .fail(function (err) {
                console.log(err);
            });
    });
});