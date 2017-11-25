$(function () {
    CKEDITOR.replace('Description');

    $('#thumb-image-upload').change(function () {
        var formData = new FormData(),
            $this = $(this),
            files = $this.get(0).files,
            value = $this.val();

        for (var i = 0; i < files.length; i++) {
            formData.append(files[i].name, files[i]);
        }

        $.ajax({
            data: formData,
            contentType: false,
            processData: false,
            type: 'POST',
            url: '/Admin/Images/UploadProductImage'
        })
            .done(function (data) {
                var $imagePreviewContainer = $('#thumb-image-preview');
                for (var i = 0; i < data.length; i++) {
                    $imagePreviewContainer.fadeOut();
                    var imgSource = data[i].relativePath,
                        id = data[i].id,
                        name = data[i].name,
                        $imgTag = $imagePreviewContainer.find('.thumb-image'),
                        $idInput = $imagePreviewContainer.find('#ThumbImageId'),
                        $imgUrlInput = $imagePreviewContainer.find('#ThumbImage_Path'),
                        $imgNameInput = $imagePreviewContainer.find('#ThumbImage_Name');

                    $imgUrlInput.val(data[i].relativePath);
                    $idInput.val(id);
                    $imgNameInput.val(name);
                    $imgTag.attr('src', imgSource).attr('alt', name);
                    $imagePreviewContainer.fadeIn();
                }
            })
            .fail(function (err) {
                toastr.error(err.status, err.responseText);
            });
    });
});