function findCardFrequency(value) {
    var hand = value.split(/\s+/g);
    var totalCards = hand.length;
    var result = {};
    var order = [];

    var index;
    for (index = 0; index < hand.length; index += 1) {
        var card = hand[index];
        var face = card.substring(0, card.length - 1);

        if (result[face] == undefined) {
            result[face] = 1;
            order.push(face.toString());
        } else {
            result[face] += 1;
        }
    }

    for (var key in result) {        
        var percent = ((result[key] / totalCards) * 100).toFixed(2);
        result[key] = percent + "%";
    }

    return [result, order];
}

var checkValues = [
    '8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦',
    'J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠',
    '10♣ 10♥'
];


for (var i in checkValues) {
    var objAndOrder = findCardFrequency(checkValues[i]);
    var obj = objAndOrder[0];
    var orderOfKeys = objAndOrder[1];

    for (var j = 0; j < orderOfKeys.length; j += 1) {
        var key = orderOfKeys[j];
        console.log(key + " -> " + obj[key]);
    }    
}