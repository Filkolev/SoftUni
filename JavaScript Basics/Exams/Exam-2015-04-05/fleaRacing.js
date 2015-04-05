function solve(input) {
    var jumpsAllowed = parseInt(input[0]),
        lengthOfTrack = parseInt(input[1]),
        competitorInfo = [],
        currentBestPosition = 0,
        audience = Array(lengthOfTrack + 1).join('#'),
        raceOver = false,
        winner;

    input.splice(0, 2);

    input.forEach(function (competitor) {
        var competitorName = competitor.split(', ')[0],
            jumpStrength = parseInt(competitor.split(', ')[1]);

        competitorInfo.push({
            name: competitorName,
            currentPosition: 0,
            jumpStrength: jumpStrength,
            initial: competitorName[0].toLocaleUpperCase()
        });
    });

    for (var i = 0; i < jumpsAllowed; i += 1) {
        competitorInfo.forEach(function (flea) {
            if (!raceOver) {
                flea.currentPosition += flea.jumpStrength;

                if (flea.currentPosition >= lengthOfTrack - 1) {
                    raceOver = true;
                    winner = flea.name;
                    flea.currentPosition = lengthOfTrack - 1;
                }
            }
        });

        if (raceOver) {
            break;
        }
    }

    console.log(audience);
    console.log(audience);

    competitorInfo.forEach(function (flea) {
        var trackLine = [],
            j;

        if (!raceOver && flea.currentPosition >= currentBestPosition) {
            currentBestPosition = flea.currentPosition;
            winner = flea.name;
        }

        for (j = 0; j < lengthOfTrack; j += 1) {
            if (j === flea.currentPosition) {
                trackLine.push(flea.initial);
            } else {
                trackLine.push('.');
            }
        }

        console.log(trackLine.join(''));
    });

    console.log(audience);
    console.log(audience);

    console.log('Winner: ' + winner);
}