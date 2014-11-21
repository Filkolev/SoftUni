function compareChars(value) {
    if (value[0].length != value[1].length) {
        return false;
    }

    for (var i = 0; i < value[0].length; i++) {
        if (value[0][i] != value[1][i]) {
            return false;
        }
    }

    return true;
}

var checkValues = [
    [
        ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q'],
        ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q']
    ],
    [
        ['3', '5', 'g', 'd'],
        ['5', '3', 'g', 'd']
    ],
    [
        ['q', 'g', 'q', 'h', 'a', 'k', 'u', '8', '}', 'q', '.', 'h', '|', ';'],
        ['6', 'f', 'w', 'q', ':', '”', 'd', '}', ']', 's', 'r']
    ]
]

for (var value in checkValues) {
    if (compareChars(checkValues[value])) {
        console.log('Equal');
    } else {
        console.log('Not Equal');
    }
}
