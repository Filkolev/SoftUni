/* This solution returns the left-most sequence of non-consecutive numbers in the input array which 
 * form an array of increasing numbers (i.e I find increasing subsequences). E.g. [3, 0, 2, 5, 1, 6] 
 * will return [0, 2, 5, 6] instead of [0, 2, 5] */

function findMaxSequence(value) {
    var result = [];

    var mask = (1 << value.length) - 1;
    var maxLength = 0;

    for (var i = 3; i <= mask; i++) {
        var currentArr = [];

        for (var position = 0; position < value.length; position++) {
            if (((i >> position) & 1) == 1) {
                currentArr.push(value[position]);
            }
        }

        if (isConsecutive(currentArr) && (currentArr.length > result.length)) {
            result = currentArr;
        }
    }

    function isConsecutive(arr) {
        for (var index = 1; index < arr.length; index++) {
            if (arr[index] <= arr[index - 1]) {
                return false;
            }
        }

        return true;
    }

    return result;
}

var checkValues = [
    [3, 2, 3, 4, 2, 2, 4],
    [3, 5, 4, 6, 1, 2, 3, 6, 10, 32],
    [3, 2, 1]
];

for (var arr in checkValues) {
    if (findMaxSequence(checkValues[arr]).length > 1) {
        console.log(findMaxSequence(checkValues[arr]))
    } else {
        console.log('no');
    }
   
}