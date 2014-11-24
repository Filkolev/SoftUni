function solve(args) {
    console.log('<table>');
    console.log('<tr><th>Product</th><th>Price</th><th>Votes</th></tr>');

    var data = [];

    for (var i = 2; i < args.length - 1; i++) {
        var regex = /<td>.*?<\/td><td>([.\d]+)<\/td>/g;
        var price = parseFloat(regex.exec(args[i])[1]);

        data.push([price, args[i]]);
    }

   data.sort(function (a, b) {
        if (a[0] != b[0]) {
            return a[0] - b[0];
        } else {
            return a[1].localeCompare(b[1]);
        }

    })

    for (var p in data) {
        console.log(data[p][1]);
    }

    console.log('</table>');
}