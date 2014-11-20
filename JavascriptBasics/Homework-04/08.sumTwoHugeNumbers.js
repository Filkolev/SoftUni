function sumTwoHugeNumbers(value) {

    /* -----CHECK FOR NEGATIVE NUMBERS----- */

    var sign;

    if (value[0][0] == '-' && value[1][0] == '-') {
        sign = '';
        value[0] = value[0].substr(1, value[0].length - 1);
        value[1] = value[1].substr(1, value[1].length - 1);
    } else if (value[0][0] == '-') {
        sign = '-';
        value[0] = value[0].substr(1, value[0].length - 1);
    } else if (value[1][0] == '-') {
        sign = '-';
        value[1] = value[1].substr(1, value[1].length - 1);
    } else {
        sign = '';
    }


    /* -----CHECK FOR FLOATING-POINT NUMBERS----- */

    var firstNumSplit = value[0].split('.');
    var secondNumSplit = value[1].split('.');

    var realPartLength = 0;
    var areFloatingPoint = false;

    if (firstNumSplit[1] != undefined || secondNumSplit[1] != undefined) {
        realPartLength = parseInt(Math.max(firstNumSplit[1].length, secondNumSplit[1].length));
        areFloatingPoint = true;
    }

    if (firstNumSplit[1] == undefined) {
        firstNumSplit[1] += '.'
        for (var j = 0; j < realPartLength; j++) {
            firstNumSplit[1] += '0';
        }
    } else if (firstNumSplit[1].length < realPartLength) {
        var toAppend = realPartLength - firstNumSplit[1].length;
        for (var j = 0; j < toAppend; j++) {
            firstNumSplit[1] += '0';
        }
    }

    if (secondNumSplit[1] == undefined) {
        secondNumSplit[1] += '.'
        for (var j = 0; j < realPartLength; j++) {
            secondNumSplit[1] += '0';
        }
    } else if (secondNumSplit[1].length < realPartLength) {
        var toAppend = realPartLength - secondNumSplit[1].length;
        for (var j = 0; j < toAppend; j++) {
            secondNumSplit[1] += '0';
        }
    }


    /* -----PAD-LEFT WITH ZEROS ----- */

    var integerLength = parseInt(Math.max(firstNumSplit[0].length, secondNumSplit[0].length));

    if (firstNumSplit[0].length < integerLength) {
        for (var j = 0; j < integerLength - firstNumSplit[0].length; j++) {
            firstNumSplit[0] = '0' + firstNumSplit[0];
        }
    }

    if (secondNumSplit[0].length < integerLength) {
        for (var j = 0; j < integerLength - secondNumSplit[0].length; j++) {
            secondNumSplit[0] = '0' + secondNumSplit[0];
        }
    }


    /* -----CALCULATE RESULT----- */

    var result = '';
    var temp = 0;
    var firstRealPart = firstNumSplit[1];
    var secondRealPart = secondNumSplit[1];
    var firstIntegerPart = firstNumSplit[0];
    var secondIntegerPart = secondNumSplit[0];

    if (areFloatingPoint) {
        for (var j = firstRealPart.length - 1; j >= 0; j--) {
            var firstDigit = parseInt(firstRealPart[j]);
            var secondDigit = parseInt(secondRealPart[j]);
            var sum = firstDigit + secondDigit + temp;
            result = parseInt(sum % 10) + result;
            temp = parseInt(sum / 10);
        }

        result = '.' + result;
    }

    for (var j = firstIntegerPart.length - 1; j >= 0; j--) {
        var firstDigit = parseInt(firstIntegerPart[j]);
        var secondDigit = parseInt(secondIntegerPart[j]);
        var sum = firstDigit + secondDigit + temp;
        result = parseInt(sum % 10) + result;
        temp = parseInt(sum / 10);
    }

    if (temp > 0) {
        result = temp + result;
    }

    return sign + result;

}

var checkValues = [
    ['155', '65'],
    ['123456789', '123456789'],
    ['887987345974539', '4582796427862587'],
    ['347135713985789531798031509832579382573195807', '817651358763158761358796358971685973163314321'],
    ['24235.11135', '-3423122234252453462452231.03'] // to show it works with negative and floating point numbers
];

for (var i in checkValues) {
    console.log(sumTwoHugeNumbers(checkValues[i]));
}