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

    var ckEditorFields = $('.paragraph #Text');
    if (ckEditorFields.length > 0) {
        CKEDITOR.replace('Text');
    }
});