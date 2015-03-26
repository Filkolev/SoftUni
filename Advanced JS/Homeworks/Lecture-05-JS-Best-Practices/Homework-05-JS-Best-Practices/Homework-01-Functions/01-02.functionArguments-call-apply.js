function printArgsInfo() {
    'use strict';

    var i;

    if (arguments.length === 0) {
        console.log('No arguments.');
        return;
    }

    for (i in arguments) {
        if (arguments.hasOwnProperty(i)) {
            var type = Array.isArray(arguments[i]) ? 'array' : typeof (arguments[i]);

            console.log(arguments[i] + ' (' + type + ')');
        }
    }
}