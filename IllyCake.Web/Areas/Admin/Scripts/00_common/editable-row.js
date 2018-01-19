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