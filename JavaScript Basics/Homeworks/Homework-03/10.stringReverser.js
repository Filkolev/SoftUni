function reverseString(value) {
    var result = value.split('');
    result = result.reverse();
    result = result.join('');
    return result;
}

var checkValues = ['sample', 'softUni', 'java script'];

for (var i in checkValues) {
    console.log(reverseString(checkValues[i]));
}