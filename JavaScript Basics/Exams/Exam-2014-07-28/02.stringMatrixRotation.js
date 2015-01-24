function solve(args) {
    var degree = parseInt(args[0].match(/\d+/)[0]) % 360;
    var rotations = degree / 90;
    var result;

    var maxLendth = 0;
    var currentLength;

    for (var j = 1; j < args.length; j +=1) {
        if (args[j].length > maxLendth) {
            maxLendth = args[j].length;
        }
    }

    var initialMatrix = [];

    for (var k = 1; k < args.length; k += 1) {
        var str = args[k];
        while (str.length < maxLendth) {
            str += ' ';
        }

        initialMatrix[k - 1] = str;
    }

    for (var i = 0; i < rotations; i++) {
        initialMatrix = rotateMatrix(initialMatrix);
    }

    for (var row = 0; row < initialMatrix.length; row++) {
        if (rotations != 0) {
            console.log(initialMatrix[row].join(''));
        } else {
            console.log(initialMatrix[row]);
        }
        
    }

    function rotateMatrix(matrix) {
        var result = [];

        var colWidth = 0;

        for (var p in matrix) {
            if (matrix[p].length > colWidth) {
                colWidth = matrix[p].length;
            }
        }

        for (var col = 0; col < colWidth; col += 1) {
            result[col] = [];
            for (var row = matrix.length - 1; row >= 0; row -= 1) {
                result[col][matrix.length - row] = matrix[row][col];
            }
        }

        return result;        
    }
}

//var checkValues = [
//    [
//        'Rotate(90)',
//        'hello',
//        'softuni',
//        'exam'
//    ],
//    [
//        'Rotate(180)',
//        'hello',
//        'softuni',
//        'exam'
//    ],
//    [
//        'Rotate(270)',
//        'hello',
//        'softuni',
//        'exam'
//    ],
//    [
//        'Rotate(720)',
//        'js',
//        'exam'
//    ],
//    [
//        'Rotate(810)',
//        'js',
//        'exam'
//    ],
//    [
//        'Rotate(0)',
//        'js',
//        'exam'
//    ]
//];

//for (var i in checkValues) {
//    solve(checkValues[i]);
//}