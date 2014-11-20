function replaceSpaces(value) {
    var result = value.replace(/\s+/g, '');
    return result;
}

var checkValue = 'But you were living in another world tryin\' to get your message through';

console.log(replaceSpaces(checkValue));