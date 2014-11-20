function replaceATag(value) {
    var matches = [];
    var regex = /<[^><]+>(.*?)<\/[^><]+>/gi;
    var match;
    while (match = regex.exec(value)) {
        matches.push(match[1]);
    }

    return matches.join('');
}

var checkValue = '<p>Hello</p><a href=\'http://w3c.org\'>W3C</a>';

console.log(replaceATag(checkValue));