/* ------ COMMON ----- */
$(function () {
    'use strict';

    $('.mvc-grid').mvcgrid();
    toastr.options.closeButton = true;
});
$(function () {
    attachEditableRow($('body'));
});

function attachEditableRow($parent) {
    $parent.find('.editable-row-toggle').click(function (e) {
        e.preventDefault();
        var $this = $(this),
            $parent = $this.closest('.editable-row');

        toggleEditMode($parent);
    });

    $parent.find('.editable-row .editable-row-save').click(function () {
        var $this = $(this),
            $parent = $this.closest('.editable-row'),
            token = $('input[name="__RequestVerificationToken"]').val(),
            data = { __RequestVerificationToken: token },
            url = '/Admin/' + $parent.data('controller') + '/' + $parent.data('action');

        $parent.find('.edit-mode-input').each(function (idx, element) {
            var $el = $(element),
                name = $el.attr('name');

            if ($el.is(':checkbox')) {
                data[name] = $el.is(':checked');
            } else {
                data[name] = $el.val();
            }
        });

        $.ajax({
            url: url,
            data: data,
            method: 'POST',
            traditional: true
        }).done(function (response) {
            toggleEditMode($parent);
            toastr.success(response.success);
        }).fail(function (response) {
            toggleEditMode($parent);
            toastr.error(response.status, response.responseText);
        });
    });

    $parent.find('.editable-row .editable-row-delete').click(function () {
        var $this = $(this),
            $parent = $this.closest('.editable-row'),
            id = $parent.find('.edit-mode-input-key').val(),
            token = $('input[name="__RequestVerificationToken"]').val(),
            data = { Id: id, __RequestVerificationToken: token },
            url = '/Admin/' + $parent.data('controller') + '/' + $this.data('action');

        $.ajax({
            url: url,
            data: data,
            method: 'POST',
            traditional: true
        }).done(function (response) {
            $parent.fadeOut();
            toastr.success(response.success);
        }).fail(function (response) {
            toastr.error(response.status, response.responseText);
        });
    });
}

function toggleEditMode($parent) {
    if ($parent.hasClass('read-mode')) {
        $parent.find('.edit-mode-only').removeClass('hidden');
        $parent.find('.read-mode-only').addClass('hidden');
        $parent.find('.edit-mode-input').attr('disabled', false);
        $parent.removeClass('read-mode').addClass('edit-mode');
    } else {
        $parent.find('.edit-mode-only').addClass('hidden');
        $parent.find('.read-mode-only').removeClass('hidden');
        $parent.find('.edit-mode-input').attr('disabled', 'disabled');
        $parent.removeClass('edit-mode').addClass('read-mode');
    }
}
$(function () {
    $.fn.mvcgrid.lang = {
            Text: {
            Contains: 'Съдържа',
            Equals: 'Равно на',
            NotEquals: 'Различно от',
            StartsWith: 'Започва с',
            EndsWith: 'Завършва на'
        },
        Number: {
            Equals: 'Равно на',
            NotEquals: 'Различно от',
            LessThan: 'По-малко от',
            GreaterThan: 'По-голямо от',
            LessThanOrEqual: 'По-малко или равно',
            GreaterThanOrEqual: 'По-голямо или равно'
        },
        Date: {
            Equals: 'Равна на',
            NotEquals: 'Различна от',
            LessThan: 'По малка от',
            GreaterThan: 'По-голяма от',
            LessThanOrEqual: 'По-малка или равна',
            GreaterThanOrEqual: 'По-голяма или равна'
        },
        Boolean: {
            Yes: 'Да',
            No: 'Не'
        },
        Filter: {
            Apply: '✔',
            Remove: '✘'
        },
        Operator: {
            Select: '',
            And: 'И',
            Or: 'Или'
        }
    };
});
/* ------ BLOG POSTS ----- */
$(function () {
    $('#blog-image-selection').change(function () {
        var formData = new FormData(),
            $this = $(this),
            files = $this.get(0).files,
            id = $this.data('id'),
            $target = $($this.data('target')),
            value = $this.val();

        for (var i = 0; i < files.length; i++) {
            formData.append(files[i].name, files[i]);
        }

        if (id !== undefined) {
            formData.append("blogPostId", id);
        }

        $.ajax({
            data: formData,
            contentType: false,
            processData: false,
            type: 'POST',
            url: '/Admin/Images/UploadBlogPostMainImage'
        })
            .done(function (data) {
                for (var i = 0; i < data.length; i++) {
                    var imgSource = data[i].relativePath,
                        id = data[i].id,
                        $imgTag = $('<img class="img-fluid"  src="' + imgSource + '" />'),
                        $idInput = $('<input type="hidden" name="ThumbImageId"/>'),
                        $imgUrlInput = $('<input type="hidden" name="ImageUrl"/>');
                    if ($this.val()) {
                        var imageName = $this.val().substr($this.val().lastIndexOf('\\') + 1);
                        $this.closest('.file-selection-container').find('.file-selection-label').html(imageName);
                    }

                    $imgUrlInput.val(data[i].relativePath);
                    $idInput.val(id);
                    $target.html($idInput);
                    $imgTag.hide();
                    $target.append($imgTag);
                    $target.append($imgUrlInput);
                    $imgTag.fadeIn();
                }
            })
            .fail(function (err) {
                console.log(err);
            });
    });
});
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
/* ------ PRODUCTS ----- */
$(function () {
    $('.sortable-categories').sortable({
        containerSelector: 'div.sortable,ol,ul',
        itemSelector: 'div.row, li',
        pullPlaceholder: false,
        handle: 'i.fa-arrows',
        onDrop: function ($item, container, _super, event) {
            _super($item, container, _super, event);
            var positionDelta = $item.data('index') - $item.data('old-index'),
                id = $item.data('id');

            $('.category-item').each(function (index, element) {
                $(element).find('.position').text(index);
            });
            updatePosition(id, positionDelta);
        }
    });

    function updatePosition(id, positionDelta) {
        var token = $('input[name="__RequestVerificationToken"]').val(),
            data = {
                categoryId: id,
                positionDelta: positionDelta,
                __RequestVerificationToken: token
            };
        $.ajax({
            data: data,
            url: '/Admin/ProductCategories/ChangePosition',
            traditional: true,
            method: 'POST'
        })
            .done(function (data) {
                
            }).fail(function (response) {
                toastr.error(response.status, response.responseText + "! Презареди страницата!");
            });
    }
});
$(function () {
    $('#thumb-image-selection').change(function () {
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
            url: '/Admin/Images/UploadProductImage'
        })
            .done(function (data) {
                for (var i = 0; i < data.length; i++) {
                    var imgSource = data[i].relativePath,
                        id = data[i].id,
                        $imgTag = $('<img class="img-fluid"  src="' + imgSource + '" />'),
                        $idInput = $('<input type="hidden" name="ThumbImageId"/>'),
                        $imgUrlInput = $('<input type="hidden" name="ImageUrl"/>');
                    if ($this.val()) {
                        var imageName = $this.val().substr($this.val().lastIndexOf('\\') + 1);
                        $this.closest('.file-selection-container').find('.file-selection-label').html(imageName);
                    }

                    $imgUrlInput.val(data[i].relativePath);
                    $idInput.val(id);
                    $target.html($idInput);
                    $imgTag.hide();
                    $target.append($imgTag);
                    $target.append($imgUrlInput);
                    $imgTag.fadeIn();
                }
            })
            .fail(function (err) {
                console.log(err);
            });
    });
});
$(function () {
    if ($('#Description').length > 0) {
        CKEDITOR.replace('Description');
    }
    
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