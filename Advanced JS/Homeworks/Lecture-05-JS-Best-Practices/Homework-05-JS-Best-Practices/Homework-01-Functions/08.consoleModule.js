var specialConsole = (function () {
    'use strict';

    function replaceParams(message, parameters) {
        var pattern = /{(\d+)}/g,
            match = pattern.exec(message);

        while (match) {
            var placeholder = match[0],
                index = parseInt(match[1]),
                replacement = parameters[index];

            if (replacement === undefined) {
                console.error('Incorrect number of parameters provided!');
                return null;
            }

            if (replacement === null) {
                replacement = '';
            }

            message = message.replace(placeholder, replacement.toString());

            match = pattern.exec(message);
        }

        return message;
    }

    function parseMessage(args) {
        var message = args[0];

        Array.prototype.shift.apply(args);

        message = replaceParams(message, args);

        return message;
    }

    function writeLine() {
        var message = parseMessage(arguments);

        if (message !== null) {
            console.log(message);
        }
    }

    function writeWarning() {
        var message = parseMessage(arguments);

        if (message !== null) {
            console.warn(message);
        }
    }

    function writeInfo() {
        var message = parseMessage(arguments);

        if (message !== null) {
            console.info(message);
        }
    }

    function writeError() {
        var message = parseMessage(arguments);

        if (message !== null) {
            console.error(message);
        }
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning,
        writeInfo: writeInfo
    };
})();

specialConsole.writeLine('Message: hello');
specialConsole.writeLine('Message: {0}', 'hello');
specialConsole.writeLine('Object: {0}', { name: 'Gosho', toString: function () { return this.name } });
specialConsole.writeError('Error: {0}', 'A fatal error has occurred.');
specialConsole.writeWarning('Warning: {0}', 'You are not allowed to do that!');
specialConsole.writeInfo('Info: {0}', 'Hi there! Here is some info for you.');
specialConsole.writeError('Error object: {0}', { msg: 'An error happened', toString: function () { return this.msg } });
specialConsole.writeLine('{0} - {1}', 'Federer', 'Nadal');
specialConsole.writeLine('{0} - {2}', 'Federer', 'Nadal');