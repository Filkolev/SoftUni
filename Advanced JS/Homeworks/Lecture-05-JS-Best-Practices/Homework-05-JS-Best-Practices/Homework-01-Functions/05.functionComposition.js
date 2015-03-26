var add,
    addOne,
    square,
    compositeFunction;

function compose(outerFunc, innerFunc) {
    'use strict';

    return function () {
        var innerResult = innerFunc.apply(null, arguments),
         finalResult = outerFunc(innerResult);
        return finalResult;
    }
}

add = function add(x, y) {
    'use strict';

    return x + y;
}

addOne = function addOne(x) {
    'use strict';

    return x + 1;
}

square = function square(x) {
    'use strict';

    return x * x;
}

console.log(compose(addOne, square)(5));
console.log(compose(addOne, add)(5, 6));
console.log(compose(Math.cos, addOne)(-1));
console.log(compose(addOne, Math.cos)(-1));

compositeFunction = compose(Math.sqrt, Math.cos);
console.log(compositeFunction(0.5));
console.log(compositeFunction(1));
console.log(compositeFunction(-1));