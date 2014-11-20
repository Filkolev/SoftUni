function findMinAndMax(value) {
    value.sort(function (a, b) { return a > b });
    return [value[0], value[value.length - 1]];
}

var checkValues = [
    [1, 2, 1, 15, 20, 5, 7, 31],
    [2, 2, 2, 2, 2],
    [500, 1, -23, 0, -300, 28, 35, 12]
];

for (var i = 0; i < checkValues.length; i++) {
    var results = findMinAndMax(checkValues[i]);
    console.log('Min -> ' + results[0]);
    console.log('Max -> ' + results[1]);
}

