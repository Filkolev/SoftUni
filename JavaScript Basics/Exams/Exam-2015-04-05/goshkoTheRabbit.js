function solve(input) {
    var garden = [],
        visitedCells = [],
        currentRow = 0,
        currentCol = 0,
        directions = input.splice(0, 1)[0].split(', '),
        result = {
            '&': 0,
            '*': 0,
            '#': 0,
            '!': 0,
            'wall hits': 0
        };

    input.forEach(function (gardenRow) {
        garden.push(gardenRow.split(', '));
    });

    directions.forEach(function (direction) {
        var deltaRow = 0,
            deltaCol = 0,
            regex = /{([&!#*])}/g,
            match;

        switch (direction) {
            case 'up':
                deltaRow = -1;
                break;
            case 'down':
                deltaRow = 1;
                break;
            case 'right':
                deltaCol = 1;
                break;
            case 'left':
                deltaCol = -1;
                break;
        }

        if (garden[currentRow + deltaRow] && garden[currentRow + deltaRow][currentCol + deltaCol]) {
            currentRow += deltaRow;
            currentCol += deltaCol;

            match = regex.exec(garden[currentRow][currentCol]);
            while (match) {
                switch (match[1]) {                    
                    case '#':
                        result['#'] += 1;
                        break;
                    case '&':
                        result['&'] += 1;
                        break;
                    case '*':
                        result['*'] += 1;
                        break;
                    case '!':
                        result['!'] += 1;
                        break;
                }

                match = regex.exec(garden[currentRow][currentCol]);
            }

            garden[currentRow][currentCol] = garden[currentRow][currentCol].replace(regex, '@');
            visitedCells.push(garden[currentRow][currentCol]);
        } else {
            result['wall hits'] += 1;
        }
    });

    console.log(JSON.stringify(result));

    if (visitedCells.length) {
        console.log(visitedCells.join('|'));
    } else {
        console.log('no');
    }
}