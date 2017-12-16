$(function () {
    CKEDITOR.replace('Description');

    $('#thumb-image-upload').change(function () {
        var $this = $(this),
            files = $this.get(0).files,
            url = '/Admin/Images/UploadProductMainImage',
            productId = $('#Id').val(),
            formData = new FormData();

        for (var i = 0; i < files.length; i++) {
            formData.append(files[i].name, files[i]);
        }

        formData.append('productId', productId);
        $.ajax({
            data: formData,
            contentType: false,
            processData: false,
            type: 'POST',
            url: url
        })
            .done(function (data) {
                var $imagePreviewContainer = $('#thumb-image-preview');
                for (var i = 0; i < data.length; i++) {
                    $imagePreviewContainer.fadeOut();
                    var imgSource = data[i].relativePath,
                        id = data[i].id,
                        name = data[i].name,
                        $imgTag = $imagePreviewContainer.find('.thumb-image'),
                        $idInput = $imagePreviewContainer.find('#ThumbImage_Id'),
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

    $('#galery-image-upload').change(function () {
        var $this = $(this),
            url = '/Admin/Images/UploadProductMainImage',
            files = $this.get(0).files,
            productId = $('#Id').val(),
            formData = new FormData();

        formData.append('productId', productId);
        $.ajax({
            data: formData,
            contentType: false,
            processData: false,
            type: 'POST',
            url: url
        })
            .done(function (data) {
                console.log(data);
            })
            .fail(function (err) {
                toastr.error(err.status, err.responseText);
            });
    });

    $('.create-product-version-toggle').click(function (e) {
        e.preventDefault();

        //string Name { get; set; }
        //decimal Price { get; set; }
        //int ProductId { get; set; }
    });
});