function solve(args) {
    var text = args[0];

    var regex = /\d+/g;

    var matches = text.match(regex);

    for (var i in matches) {
        matches[i] = parseInt(matches[i]).toString(16).toUpperCase();

        while (matches[i].length < 4) {
            matches[i] = '0' + matches[i];
        }

        matches[i] = '0x' + matches[i];
    }

    console.log(matches.join('-'));
}

//solve(['20']);
//solve(['482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312']);
//solve(['5tffwj(//*7837xzc2---34rlxXP%$”.']);