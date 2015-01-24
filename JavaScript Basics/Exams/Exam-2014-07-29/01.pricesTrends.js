function solve(args) {

    console.log('<table>');
    console.log('<tr><th>Price</th><th>Trend</th></tr>');
    console.log('<tr><td>' + parseFloat(args[0]).toFixed(2) + '</td><td><img src="fixed.png"/></td></td>');

    for (var i = 1; i < args.length; i++) {
        var previous = parseFloat(parseFloat(args[i - 1]).toFixed(2));
        var current = parseFloat(parseFloat(args[i]).toFixed(2));

        if (current > previous) {
            console.log('<tr><td>' + current.toFixed(2) + '</td><td><img src="up.png"/></td></td>');
        } else if (current == previous) {
            console.log('<tr><td>' + current.toFixed(2) + '</td><td><img src="fixed.png"/></td></td>');
        } else {
            console.log('<tr><td>' + current.toFixed(2) + '</td><td><img src="down.png"/></td></td>');
        }
    }

    console.log('</table>');
}

//solve([50, 60]);

//solve([36.333,
//36.5,
//37.019,
//35.4,
//35,
//35.001,
//36.225,
//]);