$(document).ready(function () {
    'use strict';

    function paintElements() {
        var classInput = $('#className'),
            className = classInput.val(),
            color = $('#color').val(),
            elementsToPaint = $('.' + className);

        elementsToPaint.css('background-color', color);
        classInput.val('');
    }

    $('#paintBtn').click(paintElements);
});