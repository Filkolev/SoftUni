var specialConsole = (function () {
    function replaceParams(message, parameters) {
        var pattern = /{(\d+)}/g;

        var match = pattern.exec(message);

        while (match) {
            var placeholder = match[0];
            var index = parseInt(match[1]);

            var replacement = parameters[index];

            if (replacement === undefined) {
                writeError("Incorrect number of parameters provided!");
                return null;
            }

            if (replacement === null) {
                replacement = "";
            }

            message = message.replace(placeholder, replacement.toString());

            match = pattern.exec(message);
        }

        return message;
    }

    function writeLine() {
        var message = arguments[0];
        Array.prototype.shift.apply(arguments);

        message = replaceParams(message, arguments);

        if (message !== null) {
            console.log(message);
        }
    }

    function writeError() {
        var message = arguments[0];
        Array.prototype.shift.apply(arguments);

        message = replaceParams(message, arguments);

        if (message !== null) {
            console.error(message);
        }
    }

    function writeWarning() {
        var message = arguments[0];
        Array.prototype.shift.apply(arguments);

        message = replaceParams(message, arguments);

        if (message !== null) {
            console.warn(message);
        }
    }

    function writeInfo() {
        var message = arguments[0];
        Array.prototype.shift.apply(arguments);

        message = replaceParams(message, arguments);

        if (message !== null) {
            console.info(message);
        }
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning,
        writeInfo: writeInfo
    };
})();

console.log("Problem 8. Console Module");
specialConsole.writeLine("Message: hello");
specialConsole.writeLine("Message: {0}", "hello");
specialConsole.writeLine("Object: {0}", { name: "Gosho", toString: function() { return this.name } });
specialConsole.writeError("Error: {0}", "A fatal error has occurred.");
specialConsole.writeWarning("Warning: {0}", "You are not allowed to do that!");
specialConsole.writeInfo("Info: {0}", "Hi there! Here is some info for you.");
specialConsole.writeError("Error object: {0}", { msg: "An error happened", toString: function () { return this.msg } });
specialConsole.writeLine("{0} - {1}", "Federer", "Nadal");
specialConsole.writeLine("{0} - {2}", "Federer", "Nadal");
console.log("\n\n");