function solve(input) {
    var totalCoins = 0;

    input.forEach(function (entry) {
        var coinMatcher = /coin\s([.\d]+)/gi,
            match = coinMatcher.exec(entry.trim());

        if (match) {
            if (parseInt(match[1]) === parseFloat(match[1])) {
                totalCoins += parseInt(match[1]);
            }
        }
    });

    console.log('gold : ' + Math.floor(totalCoins / 100));
    console.log('silver : ' + Math.floor((totalCoins / 10) % 10));
    console.log('bronze : ' + Math.floor(totalCoins % 10));
}