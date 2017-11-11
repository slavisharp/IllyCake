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