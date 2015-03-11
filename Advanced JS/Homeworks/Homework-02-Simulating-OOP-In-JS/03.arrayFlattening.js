Array.prototype.flatten = function() {
    var resultArray = [];

    function getValues(array) {
        var i;
        for (i = 0; i < array.length; i += 1) {
            var value = array[i];
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

console.log("Problem 3. Array Flattening");
var array = [1, 2, 3, 4];
console.log(array.flatten());
var array = [1, 2, [3, 4], [5, 6]];
console.log(array.flatten());
console.log(array); // Not changed
var array = [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10];
console.log(array.flatten());
console.log("\n\n");