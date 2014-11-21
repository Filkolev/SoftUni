function countSubstringOccur(value) {
    var splitWord = value[0].toLowerCase();
    var arr = value[1].toLowerCase().split(splitWord);
    return arr.length - 1;
}

var checkValues = [
    ['in', 'We are living in a yellow submarine. We don\'t have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.'],
    ['your', 'No one heard a single word you said. They should have seen it in your eyes. What was going around your head.'],
    ['but', 'But you were living in another world tryin\' to get your message through.']
]

for (var i in checkValues) {
    console.log(countSubstringOccur(checkValues[i]));
}