function findMaxSequence(value) {
    var resultArr = [];

    var maxLength = 0;
    var element = value[0];
    var currentLength = 1;

    if (value.length == 1) {
        resultArr.push(value[0]);
    }

    for (var i = 1; i < value.length; i++) {
        if (value[i] === value[i - 1]) {
            currentLength += 1;
        } else {
            if (currentLength >= maxLength) {
                maxLength = currentLength;
                element = value[i - 1];
                currentLength = 1;
            }
        }
    }

    for (var i = 0; i < maxLength; i++) {
        resultArr.push(element);
    }

    return resultArr;
}

var checkValues = [
    [2, 1, 1, 2, 3, 3, 2, 2, 2, 1],
    ['happy'],
    [2, 'qwe', 'qwe', 3, 3, '3']
];

for (var key in checkValues) {
    console.log(findMaxSequence(checkValues[key]));
}