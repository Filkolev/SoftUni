function solve(args) {
    var result = [];
    var maxLength = 0;

    for (var j = 0; j < args.length; j++) {
        if (args[j].length > maxLength) {
            maxLength = args[j].length;
        }
    }

    for (var k = 0; k < args.length; k++) {
        result[k] = [];

        for (var p = 0; p < args[k].length; p++) {
            result[k].push(true);
        }
    }

    for (var row = 0; row < args.length - 2; row++) {
        for (var col = 0; col < maxLength - 2; col++) {
            if (!args[row] ||
                !args[row + 1] ||
                !args[row + 2]) {
                continue;
            }

            if (!args[row][col] ||
                !args[row][col + 2] ||
                !args[row + 1][col + 1] ||
                !args[row + 2][col + 2] ||
                !args[row + 2][col]) {
                continue;
            }

            if (args[row][col].toLocaleLowerCase() == args[row][col + 2].toLocaleLowerCase() &&
                args[row][col].toLocaleLowerCase() == args[row + 1][col + 1].toLocaleLowerCase() &&
                args[row][col].toLocaleLowerCase() == args[row + 2][col + 2].toLocaleLowerCase() &&
                args[row][col].toLocaleLowerCase() == args[row + 2][col].toLocaleLowerCase()) {
                result[row][col] = false;
                result[row][col + 2] = false;
                result[row + 1][col + 1] = false;
                result[row + 2][col + 2] = false;
                result[row + 2][col] = false;
            }
        }
    }

    for (var row = 0; row < args.length; row++) {
        var rowString = '';
        for (var col = 0; col < args[row].length; col++) {
            if (result[row][col] == true) {
                rowString += args[row][col].toString();
            }
        }

        console.log(rowString);
    }
}