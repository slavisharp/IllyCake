$(function () {
    $('.add-paragrpaph-btn').click(function () {
        var id = $('#Id').val(),
            token = $('input[name="__RequestVerificationToken"]').val(),
            data = {
                blogId: id,
                __RequestVerificationToken: token
            };
        $.ajax({
            url: '/Admin/BlogPosts/CreateParagraph',
            method: 'POST',
            data: data,
            traditional: true
        }).done(function (html) {
            var $paragraph = $(html);
            attachEditableRow($paragraph)
            $('#paragraphs-wrapper').append($paragraph)
        }).fail(function (response) {
            toastr.error(response.status, response.responseText);
        });
    });

    $('.paragraph-text-edit').each(function (index, element) {
        var id = $(element).attr('id');
        CKEDITOR.replace(id);
    });

    $('.paragraph .paragraph-image-file-input').change(function () {
        var $this = $(this),
            $parent = $this.closest('.paragraph'),
            files = $this.get(0).files,
            url = '/Admin/Images/UploadParagraphImage',
            paragraphId = $parent.find('#Id').val(),
            formData = new FormData();

        for (var i = 0; i < files.length; i++) {
            formData.append(files[i].name, files[i]);
        }

        formData.append('paragraphId', paragraphId);
        $.ajax({
            data: formData,
            contentType: false,
            processData: false,
            type: 'POST',
            url: url
        }).done(function (data) {
            var $imagePreviewContainer = $parent.find('.paragraph-image-preview');
            if (data && data.length > 0) {
                var image = data[0]
                $imagePreviewContainer.fadeOut(400, function () {
                    $parent.find('#ThumbImageId').val(image.id);
                    $imagePreviewContainer.find('.img-fluid').attr('alt', image.name).attr('src', image.relativePath);
                    $imagePreviewContainer.fadeIn();
                });
            }
        }).fail(function (err) {
            toastr.error(err.status, err.responseText);
        });
    });

    $('.paragraph .video-edit-input').bind('input propertychange', function () {
        var $this = $(this),
            value = $this.val(),
            $videoContainer = $this.closest('.paragraph').find('.video-container');

        if (value && value.length > 0) {
            $videoContainer.removeClass('no-content');
        } else {
            $videoContainer.addClass('no-content');
        }

        $videoContainer.html($this.val());
    });
});