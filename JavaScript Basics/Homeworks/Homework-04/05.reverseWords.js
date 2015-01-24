function reverseWordsInString(str) {
    var words = str.trim().split(/\s+/g);

    for (var j in words) {
        words[j] = words[j].split('').reverse().join('');
    }
  
    return words.join(' ');
}

var checkValues = [
    'Hello, how are you.',
    'Life is pretty good, isn’t it?'
];

for (var i in checkValues) {
    console.log(reverseWordsInString(checkValues[i]));
}