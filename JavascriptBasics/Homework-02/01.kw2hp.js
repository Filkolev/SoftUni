function convertKW2HP(input) {
    var result = input / 0.745699872;
    return result.toFixed(2);
}

console.log(convertKW2HP(75));
console.log(convertKW2HP(150));
console.log(convertKW2HP(1000));