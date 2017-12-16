$(function () {
    'use strict';

    $('.mvc-grid').mvcgrid();
    toastr.options.closeButton = true;
});
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
$(function () {
    $('.btn-toggle-edit,.btn-cancel-edit').click(function () {
        var $this = $(this),
            $row = $this.closest('.row-line-item');

        toggleEditMode($row);
    });

    $('.category-item .btn-save-edit').click(function () {
        var $this = $(this),
            $row = $this.closest('.category-item'),
            token = $('input[name="__RequestVerificationToken"]').val(),
            id = $row.data('id'),
            name = $row.find('.edit-name').val(),
            showOnHomePage = $row.find('.edit-home-page').is(':checked'),
            data = {
                __RequestVerificationToken: token,
                Id: id,
                Name: name,
                ShowOnHomePage: showOnHomePage
            };

        $.ajax({
            data: data,
            url: '/Admin/ProductCategories/Edit',
            traditional: true,
            method: 'POST'
        })
            .done(function (data) {
                toastr.success(data.success);
                toggleEditMode($row);
            }).fail(function (response) {
                toastr.error(response.status, response.responseText);
                toggleEditMode($row);
        });
    });

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

    function toggleEditMode($row) {
        if ($row.hasClass('edit-only-mode')) {
            $row.removeClass('edit-only-mode').addClass('read-only-mode');
        } else {
            $row.removeClass('read-only-mode').addClass('edit-only-mode');
        }
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