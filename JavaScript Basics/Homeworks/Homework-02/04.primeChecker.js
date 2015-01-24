function isPrime(num) {
    if (num < 1) {
        return false;
    } else {
        for (var i = 2; i <= Math.sqrt(num) ; i++) {
            if (num % i == 0) {
                return false;
            };
        }
        return true;
    };
}

console.log('Is 7 prime? - ' + isPrime(7));
console.log('Is 254 prime? - ' + isPrime(254));
console.log('Is 587 prime? - ' + isPrime(587));