/* This solution finds all increasing sequences of consecutive numbers 
 * in the input array, e.g. [0, 4, 2, 3] will return [2, 3] and not [0, 2, 3] */

function findMaxSequence(value) {
    var result = [];

    var currentArr = [];
    currentArr.push(value[0]);    

    for (var i = 1; i < value.length; i++) {
        if (value[i] > value[i-1]) {
            currentArr.push(value[i]);
        } else {
            if (currentArr.length > result.length) {
                result = currentArr;
            }

            currentArr = [];
            currentArr.push(value[i]);
        }

        if (currentArr.length > result.length) {
            result = currentArr;
        }
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
