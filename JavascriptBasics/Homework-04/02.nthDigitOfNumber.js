function findNthDigit(arr) {
    var index = arr[0] - 1;
    var number = arr[1].toString();

    number = number.replace(/\D+/g, '');
    number = number.split('').reverse().join('');

    return number[index];
}

var checkValues = [
    [1, 6],
    [2, -55],
    [6, 923456],
    [3, 1451.78],
    [6, 888.88]
]

for (var i in checkValues) {
    var result = findNthDigit(checkValues[i])
    if (result == undefined) {
        console.log('The number doesn\'t have 6 digits');
    } else {
        console.log(result);
    }
}