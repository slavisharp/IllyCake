$(function () {
    'use strict';

    $('.mvc-grid').mvcgrid();
});
$(function () {
    $('.product-image-updater').change(function () {
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
            url: '/Images/UploadProductImage'
        })
            .done(function (data) {
                for (var i = 0; i < data.length; i++) {
                    var imgSource = data[i].relativePath;
                    $target.append($('<img src="' + imgSource + '" />'));
                }
                
                console.log(data);
            })
            .fail(function (err) {
                console.log(err);
            });
    });
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