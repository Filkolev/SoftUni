function checkBrackets(value) {
    value = value.replace(/[a-zA-Z]+/g, '1');
    value = value.replace('–', '-');

    try {
        var expression = eval(value);
        return true;
    }

    catch (err) {
        return false;
    }
}

var checkValues = [
    '( ( a + b ) / 5 – d )',
    ') ( a + b ) )',
    '( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )'
];

for (var i in checkValues) {
    if (checkBrackets(checkValues[i])) {
        console.log('correct');
    } else {
        console.log('incorrect');
    }
}