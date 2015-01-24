function solve(args) {
    var notebook = {};

    for (var i in args) {
        var data = args[i].split('|');
        var color = data[0];
        var key = data[1];
        var value = data[2];

        if (!notebook[color]) {
            notebook[color] = {
                age: 0,
                name: '',
                opponents: [],
                wins: 0,
                losses: 0,
                rank: 0
            };
        }

        if (key == 'win') {
            notebook[color].wins += 1;
            notebook[color].opponents.push(value);
        } else if (key == 'loss') {
            notebook[color].losses += 1;
            notebook[color].opponents.push(value);
        } else if (!notebook[color][key]) {
            notebook[color][key] = value;
        }        
    }

    for (var j in notebook) {
        if (!notebook[j].name || !notebook[j].age) {
            delete notebook[j];
        } else {
            var rank = parseFloat(((notebook[j].wins + 1) / (notebook[j].losses + 1))).toFixed(2);
            notebook[j].rank = rank;
            notebook[j].opponents.sort();

            delete notebook[j].wins;
            delete notebook[j].losses;
        }
    }

    var result = {};

    var sortedKeys = Object.keys(notebook).sort();

    for (var p in sortedKeys) {
        result[sortedKeys[p]] = notebook[sortedKeys[p]];
    }

    console.log(JSON.stringify(result));
}

//solve([
//        'purple|age|99',
//        'red|age|44',
//        'blue|win|pesho',
//        'blue|win|mariya',
//        'purple|loss|Kiko',
//        'purple|loss|Kiko',
//        'purple|loss|Kiko',
//        'purple|loss|Yana',
//        'purple|loss|Yana',
//        'purple|loss|Manov',
//        'purple|loss|Manov',
//        'red|name|gosho',
//        'blue|win|Vladko',
//        'purple|loss|Yana',
//        'purple|name|VladoKaramfilov',
//        'blue|age|21',
//        'blue|loss|Pesho'
//])