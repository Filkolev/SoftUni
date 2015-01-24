function findMostFreqNum(value) {
    var frequencies = {};

    for (var i in value) {
        var num = value[i];
        if (frequencies[num.toString()] == undefined) {
            frequencies[num.toString()] = 1;
        } else {
            frequencies[num.toString()] += 1;
        }
    }
    var max = 0;
    var maxKey;

    for (var key in frequencies) {
        if (frequencies[key] > max) {
            max = frequencies[key];
            maxKey = key;
        }
    }

    return [maxKey, max];
}

var checkValues = [
    [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3],
    [2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1],
    [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
];

for (var val in checkValues) {
    var result = findMostFreqNum(checkValues[val]);
    console.log(result[0] + " (" + result[1] + " times)");
}