$(document).ready(function () {
    'use strict';

    var liToInsertBeforeTarget = $('<li>')
            .text('List item inserted with before()')
            .addClass('dynamicallyAdded'),
        liToInsertAfterTarget = $('<li>')
            .text('List item inserted with after()')
            .addClass('dynamicallyAdded'),
        textToPrependToTarget = $('<span>')
            .text('Prepended text with prepend()')
            .addClass('dynamicallyAdded'),
        textToAppendToTarget = $('<span>')
            .text('Appended text with append()')
            .addClass('dynamicallyAdded');

    $('#target')
        .before(liToInsertBeforeTarget)
        .after(liToInsertAfterTarget)
        .prepend(textToPrependToTarget)
        .append(textToAppendToTarget);
});