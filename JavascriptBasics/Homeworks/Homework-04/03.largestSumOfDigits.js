// Function returns the left-most number with largest sum of digits

function findLargestBySumOfDigits(arr) {
    if (arr.length == 0) {
        return undefined;
    }

    var maxSum = 0;
    var number;

    for (var j in arr) {

        if (typeof(arr[j]) != 'number' || arr[j] % 1 != 0) {
            return undefined;
        }

        var currentNum = parseInt(Math.abs(arr[j]));
        var sum = 0;

        while (currentNum > 0) {
            sum += currentNum % 10;
            currentNum /= 10;
            currentNum = parseInt(currentNum);
        }

        if (sum > maxSum) {
            number = arr[j];
            maxSum = sum;
        }
    }

    return number;
}

var checkValues = [
    [5, 10, 15, 111],
    [33, 44, -99, 0, 20],
    ['hello'],
    [5, 3.3]
];

for (var i in checkValues) {
    console.log(findLargestBySumOfDigits(checkValues[i]));
}