function bitChecker(num) {
    var bit = (num >> 3) & 1;
    return (bit == 1);
}

console.log('333: ' + bitChecker(333));
console.log('425: ' + bitChecker(425));
console.log('2567564754: ' + bitChecker(2567564754));