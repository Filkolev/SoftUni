function solve(args) {
    var pos;
    var row;

    for (var i = 0; i < 10; i++) {
        if (args[i].indexOf('o') != -1) {
            pos = args[i].indexOf('o');
            row = i;
            break;
        }
    }

    for (var i = row + 1; i < 10; i++) {
        var direction = getDirection(args[i]);
        pos += direction;

        if (args[i][pos] == '_') {
            console.log('Landed on the ground like a boss!');
            console.log(i + ' ' + pos);
            break;
        } else if (args[i][pos] == '~') {
            console.log('Drowned in the water like a cat!');
            console.log(i + ' ' + pos);
            break;
        } else if (args[i][pos] == '-' || args[i][pos] == '<' || args[i][pos] == '>') {            
        } else {
            console.log('Got smacked on the rock like a dog!');
            console.log(i + ' ' + pos);
            break;
        }
    }

    function getDirection(line) {
        var dir = 0;
        for (var ch in line) {
            if (line[ch] == '<') {
                dir--;
            } else if (line[ch] == '>') {
                dir++;
            }
        }

        return dir;
    }
}