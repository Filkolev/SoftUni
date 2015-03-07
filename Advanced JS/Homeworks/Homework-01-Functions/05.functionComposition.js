console.log("Problem 5. Function composition");

function compose(outerFunc, innerFunc) {
    return function() {
        var innerResult = innerFunc.apply(null, arguments);
        var finalResult = outerFunc(innerResult);
        return finalResult;
    }
}

var add = function add(x, y) {
    return x + y;
}
var addOne = function addOne(x) {
    return x + 1;
}
var square = function square(x) {
    return x * x;
}

console.log(compose(addOne, square)(5));
console.log(compose(addOne, add)(5, 6));
console.log(compose(Math.cos, addOne)(-1));
console.log(compose(addOne, Math.cos)(-1));

var compositeFunction = compose(Math.sqrt, Math.cos);
console.log(compositeFunction(0.5));
console.log(compositeFunction(1));
console.log(compositeFunction(-1));
console.log("\n\n");