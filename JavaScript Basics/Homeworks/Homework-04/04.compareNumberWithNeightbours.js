function biggerThanNeighbors(index, arr) {
    if (index < 0 || index >= arr.length) {
        return undefined;
    }

    if (index == 0 || index == arr.length - 1) {
        return 'only one neighbor';
    }

    if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1]) {
        return 'bigger';
    }

    return 'not bigger';
}

var checkValues = [
    [2, [1, 2, 3, 3, 5]],
    [2, [1, 2, 5, 3, 4]],
    [5, [1, 2, 5, 3, 4]],
    [0, [1, 2, 5, 3, 4]]
];

for (var i in checkValues) {
    var result = biggerThanNeighbors(checkValues[i][0], checkValues[i][1]);

    if (result == undefined) {
        console.log('invalid index');
    } else {
        console.log(result);
    }
}