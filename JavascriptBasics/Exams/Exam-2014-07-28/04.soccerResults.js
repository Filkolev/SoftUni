function solve(args) {

    var results = {};

    for (var i = 0; i < args.length; i++) {
        var currentMatch = args[i].split(/[/:-]/g);

        var host = currentMatch[0].trim();
        var guest = currentMatch[1].trim();
        var hostGoals = parseInt(currentMatch[2].trim());
        var guestGoals = parseInt(currentMatch[3].trim());

        if (!results[guest]) {
            results[guest] = {
                goalsScored: 0,
                goalsConceded: 0,
                matchesPlayedWith: []
            }
        }

        results[guest].goalsScored += guestGoals;
        results[guest].goalsConceded += hostGoals;

        if (results[guest].matchesPlayedWith.indexOf(host) == -1) {
            results[guest].matchesPlayedWith.push(host);
        }

        if (!results[host]) {
            results[host] = {
                goalsScored: 0,
                goalsConceded: 0,
                matchesPlayedWith: []
            }
        }

        results[host].goalsScored += hostGoals;
        results[host].goalsConceded += guestGoals;

        if (results[host].matchesPlayedWith.indexOf(guest) == -1) {
            results[host].matchesPlayedWith.push(guest);
        }
    }

    for (var j in results) {
        results[j].matchesPlayedWith.sort();
    }

    var keys = Object.keys(results).sort();

    var sortedResults = {};

    for (var l in keys) {
        sortedResults[keys[l]] = results[keys[l]];
    }

    console.log(JSON.stringify(sortedResults));
}


//solve([
//    'Germany / Argentina: 1-0',
//    'Brazil / Netherlands: 0-3',
//    'Netherlands / Argentina: 0-0',
//    'Brazil / Germany: 1-7',
//    'Argentina / Belgium: 1-0',
//    'Netherlands / Costa Rica: 0-0',
//    'France / Germany: 0-1',
//    'Brazil / Colombia: 2-1'
//])