$(function () {
    $('.btn-toggle-edit,.btn-cancel-edit').click(function () {
        var $this = $(this),
            $row = $this.closest('.row-line-item');

        if ($row.hasClass('edit-only-mode')) {
            $row.removeClass('edit-only-mode').addClass('read-only-mode');
        } else {
            $row.removeClass('read-only-mode').addClass('edit-only-mode');
        }
    });

    $('.category-item .btn-save-edit').click(function () {
        var $this = $(this),
            $row = $this.closest('.category-item'),
            token = $('input[name="__RequestVerificationToken"]').val(),
            id = $row.data('id'),
            name = $row.find('.name').val(),
            showOnHomePage = $row.find('.home-page').val(),
            data = {
                __RequestVerificationToken: token,
                Id: id,
                Name: name,
                ShowOnHomePaeg: showOnHomePage
            };

        $.ajax({
            data: data,
            url: '/Admin/ProductCategories/Edit',
            traditional: true,
            method: 'POST'
        }).done(function () {

        }).fail(function () {

        });
    });
});