function evenNumber(num) {
    var even = (num % 2 == 0);
    return even;
}

console.log('3: ' + evenNumber(3));
console.log('127: ' + evenNumber(127));
console.log('588: ' + evenNumber(588));