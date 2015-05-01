var Noty = (function () {
    function display(type, text, time, layout) {
        var n = noty({
            text: text,
            type: type,
            closeWith: ['click'],
            dismissQueue: true,
            layout: layout,
            theme: 'defaultTheme',
            maxVisible: 5,
            timeout: time
        });
    }

    function success(text, layout) {
        display('success', text, 2000, layout);
    }

    function error(text, layout) {
        display('error', text, 5000, layout);
    }

    return {
        success: success,
        error: error
    }
})();