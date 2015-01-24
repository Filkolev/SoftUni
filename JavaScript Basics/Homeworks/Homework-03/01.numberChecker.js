function printNumbers(n) {
    if (n <= 0) {
        console.log('no');
    } else {
        var results = [];
        for (var i = 1; i <= n; i++) {
            if (i % 4 != 0 && i % 5 != 0) {
                results.push(i);
            }
        }

        console.log(results.join(', '));
    }
}

printNumbers(20);
printNumbers(-5);
printNumbers(13);