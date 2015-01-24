function roundNumber(num) {
    var roundedNum = Math.round(num);
    var truncatedNum = Math.floor(num);

    console.log('Math.round(' + num + ') = ' + roundedNum);
    console.log('Math.floor(' + num + ') = ' + truncatedNum);
}


var testNums = [22.7, 12.3, 58.7];

testNums.forEach(function (num) {
    roundNumber(num);
})