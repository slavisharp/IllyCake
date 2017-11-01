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
                        $idInput = $('<input type="hidden" name="ThumbImageId"/>');
                    if ($this.val()) {
                        var imageName = $this.val().substr($this.val().lastIndexOf('\\') + 1);
                        $this.closest('.file-selection-container').find('.file-selection-label').html(imageName);
                    }
                    
                    $idInput.val(id);
                    $target.html($idInput);
                    $imgTag.hide();
                    $target.append($imgTag);
                    $imgTag.fadeIn();
                }
            })
            .fail(function (err) {
                console.log(err);
            });
    });
});