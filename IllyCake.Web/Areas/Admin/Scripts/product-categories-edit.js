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

    });
});