var array;

Array.prototype.flatten = function () {
    'use strict';

    var resultArray = [];

    function getValues(array) {
        var i,
            value;

        for (i = 0; i < array.length; i += 1) {
            value = array[i];

            if (Array.isArray(value)) {
                getValues(value);
            } else {
                resultArray.push(value);
            }
        }
    }

    getValues(this);

    return resultArray;
};

array = [1, 2, 3, 4];
console.log(array.flatten());

array = [1, 2, [3, 4], [5, 6]];
console.log(array.flatten());
console.log(array); // Not changed

array = [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10];
console.log(array.flatten());