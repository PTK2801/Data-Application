

$(document).ready(function () {

    var placeHolder = $('#PlaceHolder');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeHolder.html(data);
            placeHolder.find('.modal').modal('show');
        });
    });
});