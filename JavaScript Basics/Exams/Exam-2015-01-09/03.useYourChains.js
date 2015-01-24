function solve(args) {
    var text = '';

    var regex = /<p>(.*?)<\/p>/g;
    var match;

    while (match = regex.exec(args[0])) {        
        text += match[1];
    }

    text = text.replace(/[^a-z0-9]/g, ' ');
    text = text.replace(/\s+/g, ' ');

    var result = '';

    for (var ch in text) {
        if (text[ch] >= 'a' && text[ch] <= 'm') {
            var code = text[ch].charCodeAt(0);
            code += 13;
            result += String.fromCharCode(code);
        } else if (text[ch] >= 'n' && text[ch] <= 'z') {
            var code = text[ch].charCodeAt(0);
            code -= 13;
            result += String.fromCharCode(code);
        } else {
            result += text[ch];
        }
    }

    console.log(result);
}