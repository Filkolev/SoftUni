function sortArray(value) {

    var arr = value;
    for (var i = 0; i < arr.length - 1; i += 1) {
        for (var j = i + 1; j < arr.length; j += 1) {
            if (arr[i] > arr[j]) {
                var temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }

    return arr;
}

var checkValues = [
    [5, 4, 3, 2, 1],
    [12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]
];

for (var k in checkValues) {
    console.log(sortArray(checkValues[k]).join(', '));
}