function solve(args) {
    var start = parseInt(args[0]);
    var end = parseInt(args[1]);

    var fibNums = [0, 1];
    var fib1 = fibNums[0];
    var fib2 = fibNums[1];

    var fibN = fib1 + fib2;

    while (fibN <= 1000000) {
        fibNums.push(fibN);
        fib1 = fib2;
        fib2 = fibN;
        fibN = fib1 + fib2;
    }

    console.log('<table>');
    console.log('<tr><th>Num</th><th>Square</th><th>Fib</th></tr>');

    for (var i = start; i <= end; i++) {
        var isFibonacci = fibNums.indexOf(i) == -1 ? false : true;
        console.log('<tr><td>' + i + '</td><td>' + i * i + '</td><td>' + (isFibonacci ? 'yes' : 'no') + '</td></tr>');
    }

    console.log('</table>');
}