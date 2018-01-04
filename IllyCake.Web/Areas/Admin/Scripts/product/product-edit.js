$(function () {
    CKEDITOR.replace('Description');

    $('.delete-gallery-image-btn').click(function (e) {
        e.preventDefault();
        deleteGalerryImage($(this));
    });

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
            url = '/Admin/Images/UploadProductGaleryImages',
            files = $this.get(0).files,
            productId = $('#Id').val(),
            formData = new FormData();

        formData.append('productId', productId);
        for (var i = 0; i < files.length; i++) {
            formData.append(files[i].name, files[i]);
        }

        var $imgTemplate = $(
            '<div class="carousel-item"> ' +
                '<img class="d-block w-100" src="" alt= "" >' +
                '<a class="btn btn-danger btn-sm pull-righ delete-gallery-image-btn" data-image-id=""><i class="fa fa-trash"></i></a>' +
            '</div>'
        );

        $.ajax({
            data: formData,
            contentType: false,
            processData: false,
            type: 'POST',
            url: url
        }).done(function (data) {
            console.log(data);
            for (var i = 0; i < data.length; i++) {
                var $img = $imgTemplate.clone(),
                    $carouselInner = $('.carousel-inner'),
                    $deleteBtn = $img.find('.delete-gallery-image-btn');

                $img.find('img').attr('src', data[i].relativePath).attr('alt', data[i].name);
                if ($carouselInner.find('.carousel-item').length === 0) {
                    $img.addClass('active');
                }

                $deleteBtn.data('image-id', data[i].id);
                $deleteBtn.click(function (e) {
                    e.preventDefault();
                    deleteGalerryImage($(this));
                });
                $carouselInner.append($img);
            }

            toastr.success('Kaчването е успешно');
        }).fail(function (err) {
            toastr.error(err.status, err.responseText);
        });
    });

    function deleteGalerryImage($deleteBtn) {
        var url = '/Admin/Images/DeleteProductImage',
            imageId = $deleteBtn.data('image-id'),
            productId = $('#Id').val(),
            token = $('input[name="__RequestVerificationToken"]').val(),
            data = { productId: productId, imageId: imageId, __RequestVerificationToken: token };

        $.ajax({
            data: data,
            traditional: true,
            type: 'POST',
            url: url
        }).done(function (data) {
            var $parent = $deleteBtn.closest('.carousel-item');
            $parent.closest('.carousel').carousel('next');
            setTimeout(function () {
                $parent.remove();
            }, 1500);
            toastr.success(data.success);
        }).fail(function (err) {
            toastr.error(err.status, err.responseText);
        });
    }
});