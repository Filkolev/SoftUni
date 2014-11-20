function divisionBy3(num) {
    var sumOfDigits = 0;
    num = Math.abs(num);

    while (num > 9) {
        while (num > 0) {
            sumOfDigits += (num % 10);
            num = Math.floor(num / 10);
        }

        num = sumOfDigits;
        sumOfDigits = 0;
    }

    var result = (num == 3 || num == 6 || num == 9);
    return result;
}

console.log('The number 12 is' + (divisionBy3(12) ? '' : ' not') + ' divided by 3 without remainder');
console.log('The number 188 is' + (divisionBy3(188) ? '' : ' not') + ' divided by 3 without remainder');
console.log('The number 591 is' + (divisionBy3(591) ? '' : ' not') + ' divided by without remainder');