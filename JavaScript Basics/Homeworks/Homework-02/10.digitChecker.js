function checkDigit(num) {
    if (num <= 1000) {
        console.log('Invalid input: number should be greater than 1000. ');
        return;
    }

    var digit = Math.floor(num / 100) % 10;

    if (digit == 3) {
        return true;
    } else {
        return false;
    }
}

console.log(checkDigit(1235));
console.log(checkDigit(25368));
console.log(checkDigit(123456));