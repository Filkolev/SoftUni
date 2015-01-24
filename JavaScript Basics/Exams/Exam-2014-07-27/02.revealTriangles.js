function solve(args) {
    var result = [];

    for (var t = 0; t < args.length; t++) {
        result[t] = [];
    }

    for (var i = 0; i < args.length - 1; i++) {
        var firstRow = args[i];
        var secondRow = args[i + 1];

        for (var j = 0; j < firstRow.length; j++) {
            if (firstRow[j] === secondRow[j - 1] &&
                firstRow[j] === secondRow[j] &&
                firstRow[j] === secondRow[j + 1]) {
                result[i][j] = '*';
                result[i + 1][j - 1] = '*';
                result[i + 1][j] = '*';
                result[i + 1][j + 1] = '*';
            } else {
                if (result[i][j] != '*') {
                    result[i][j] = args[i][j];
                }

                if (j > 0 && result[i + 1][j - 1] != '*') {
                    result[i + 1][j - 1] = args[i + 1][j - 1];

                    if (result[i + 1][j] != '*') {
                        result[i + 1][j] = args[i + 1][j];
                    }
                    if (result[i + 1][j + 1] != '*') {
                        result[i + 1][j + 1] = args[i + 1][j + 1];
                    }

                }
            }
        }

        var lastRow = args[args.length - 1];

        for (var m = 0; m < lastRow.length; m++) {
            if (result[args.length - 1][m] == undefined) {
                result[args.length - 1][m] = lastRow[m];
            }
        }
    }

    for (var k in result) {
        result[k] = result[k].join('');
        console.log(result[k]);
    }
}

//var checkValues = [
//    ['abcdexgh', 'bbbdxxxh', 'abcxxxxx'],
//    ['aa', 'aaa', 'aaaa', 'aaaaa'],
//    ['ax', 'xxx', 'b', 'bbb', 'bbbb'],
//    ['dffdsgyefg', 'ffffeyeee', 'jbfffays', 'dagfffdsss', 'dfdfa', 'dadaaadddf', 'sdaaaaa', 'daaaaaaasf']
//]

//for (var p in checkValues) {
//    solve(checkValues[p]);
//}