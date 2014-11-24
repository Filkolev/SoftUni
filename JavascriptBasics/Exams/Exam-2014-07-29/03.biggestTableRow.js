function solve(args) {
    var text = args.join(' ');
    var maxSum;
    var data = [];
    var regex = /<td>([\d-.]+)<\/td><td>([\d-.]+)<\/td><td>([\d-.]+)<\/td>/g;
    var matches;

    while (matches = regex.exec(text)) {
        var first = matches[1];
        var second = matches[2];
        var third = matches[3];

        var one, two, three;

        one = first == '-' ? 0 : parseFloat(first);
        two = second == '-' ? 0 : parseFloat(second);
        three = third == '-' ? 0 : parseFloat(third);

        var sum = one + two + three;
        var currentData = [];

        if (first != '-') {
            currentData.push(first);
        }
        if (second != '-') {
            currentData.push(second);
        }
        if (third != '-') {
            currentData.push(third);
        }

        if (maxSum == undefined || sum > maxSum) {
            maxSum = sum;
            data = currentData;
        }
    }

    if (data.length > 0) {
        console.log(maxSum + ' = ' + data.join(' + '));
    } else {
        console.log('no data');
    }
}

//var checkValues = [
//    [
//        '<table>',
//        '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
//        '<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>',
//        '<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>',
//        '<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>',
//        '<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>',
//        '</table>'
//    ],
//    [
//        '<table>',
//        '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
//        '<tr><td>Sofia</td><td>-</td><td>-</td><td>-</td></tr>',
//        '</table>'
//    ],
//    [
//        '<table>',
//        '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
//        '<tr><td>Sofia</td><td>12850</td><td>-560</td><td>20833</td></tr>',
//        '<tr><td>Rousse</td><td>-</td><td>50000.0</td><td>-</td></tr>',
//        '<tr><td>Bourgas</td><td>25000</td><td>25000</td><td>-</td></tr>',
//        '</table>'
//    ]
//];

//for (var j in checkValues) {
//    solve(checkValues[j]);
//}