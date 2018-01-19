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