var add = (function () {
    var sum = 0;

    function inner(increment) {
        sum += increment;
        return add;
    }

    inner.toString = function () {
        return sum;
    }

    return inner;
})();

console.log("Problem 4. Adding numbers using functions.");
var addTwo = add(2);
console.log(addTwo);
console.log(addTwo(3)(5));
console.log(add(1)(-1)(10));

console.log("\n\n");