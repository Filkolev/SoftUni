function solve(args) {
    for (var j in args) {
        var regex = /([^?=&]+)=([^?=&]+)/g;
        var results = {};
        var match;

        while (match = regex.exec(args[j])) {
            var key = match[1].replace(/(%20|\+)+/g, ' ').trim();
            var val = match[2].replace(/(%20|\+)+/g, ' ').trim();

            if (!results[key]) {
                results[key] = [];
            }

            if (results[key].indexOf(val) == -1) {
                results[key].push(val);
            }
        }

        var toPrint = '';
        for (var j in results) {
            toPrint += j + '=[' + results[j].join(', ') + ']';
        }

        console.log(toPrint);
    }
}