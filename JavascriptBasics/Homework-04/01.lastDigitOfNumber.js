function lastDigitAsText(number) {
    if (typeof(number) != 'number') {
        return 'Input was not a valid number';
    }

    var result;
    var digit = Math.abs(number) % 10;

    switch (digit) {
        case 0: result = 'Zero'; break;
        case 1: result = 'One'; break;
        case 2: result = 'Two'; break;
        case 3: result = 'Three'; break;
        case 4: result = 'Four'; break;
        case 5: result = 'Five'; break;
        case 6: result = 'Six'; break;
        case 7: result = 'Seven'; break;
        case 8: result = 'Eight'; break;
        case 9: result = 'Nine'; break;        
        default: result = 'Input was not an integer'; break;

    }

    return result;
}

var checkValues = [6, -55, 133, 14567, 1.5, false, null, undefined, 'assd', [], [2, 3], {}, { 'key': 3 }];

for (var i in checkValues) {
    console.log(lastDigitAsText(checkValues[i]));
}