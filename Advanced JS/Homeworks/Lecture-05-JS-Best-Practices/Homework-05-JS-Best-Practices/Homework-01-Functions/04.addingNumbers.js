var addTwo;

var add = (function () {
    'use strict';

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

addTwo = add(2);
console.log(addTwo);
console.log(addTwo(3)(5));
console.log(add(1)(-1)(10));