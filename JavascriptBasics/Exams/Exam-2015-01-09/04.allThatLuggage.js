function solve(args) {
    var sortBy = args[args.length - 1];
    var result = {};

    for (var i = 0; i < args.length - 1; i++) {
        var pattern = /(.*?)\.*\*\.*([a-z]+)\.*\*\.*(.*?)\.*\*\.*(.*?)\.*\*\.*(.*?)\.*\*\.*(.*?)\.*\*\.*(.*)/;
        var data = pattern.exec(args[i]);

        var owner = data[1];
        var luggage = data[2];
        var isFood = data[3];
        var isDrink = data[4];
        var isFragile = data[5];
        var weight = parseFloat(data[6]);
        var transferredWith = data[7];

        var type;

        if (isFood == 'true') {
            type = 'food';
        } else if (isDrink == 'true') {
            type = 'drink';
        } else {
            type = 'other';
        }

        if (!result[owner]) {
            result[owner] = {};
        }

        result[owner][luggage] = {
            'kg': weight,
            'fragile': isFragile == 'true' ? true : false,
            'type': type,
            'transferredWith': transferredWith
        };
    }

    var toPrint = {};

    for (var owner in result) {
        var keys = Object.keys(result[owner]);

        keys.sort(function (a, b) {
            switch (sortBy) {
                case 'luggage name':
                    return a.localeCompare(b);
                    break;
                case 'weight':
                    return result[owner][a].kg < result[owner][b].kg ? -1 : result[owner][a].kg == result[owner][b].kg ? 0 : 1;
                    break;
            }
        });

        toPrint[owner] = {};

        for (var j in keys) {
            toPrint[owner][keys[j]] = result[owner][keys[j]];
        }
    }

    console.log(JSON.stringify(toPrint));
}