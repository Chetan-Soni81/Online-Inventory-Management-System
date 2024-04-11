// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




const hamburger = document.querySelector('#toggle-btn')

$('#toggle-btn').on('click', function () {
    $('#sidebar').toggleClass('expand')
})

$(function () {
    var modelPopupBox = $('#modelPopupBox');
    $('button[data-toggle="ajax-modal"]').on('click', function (event) {
        console.log('pressed');
        debugger;
        var uri = $(this).data('url');
        var decodeUrl = decodeURIComponent(uri);
        $.get(decodeUrl).done(function (data) {
            modelPopupBox.html(data);
            modelPopupBox.find('.modal').modal('show');
        })
    })

    modelPopupBox.on('click', '[data-save="modal"]', function (event) {
        debugger;
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            modelPopupBox.find('.modal').modal('hide');
            location.reload();
        })
    })

    modelPopupBox.on('click', '[data-dismiss="modal"]', function (event) {
        modelPopupBox.find('.modal').modal('hide');
    })

    console.log('attached')
});