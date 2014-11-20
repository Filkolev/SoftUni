function findMostFreqWord(value) {
    var arr = value.toLowerCase().split(/[^a-zA-Z]+/g);

    var frequencies = {};

    var maxFrequency = 0;

    for (var index in arr) {
        var key = arr[index];
        if (frequencies[key] == undefined) {
            frequencies[key] = 1;
        } else {
            frequencies[key] += 1;
        }

        if (frequencies[key] > maxFrequency) {
            maxFrequency = frequencies[key];
        }
    }

    var keyset = Object.keys(frequencies).sort();
    for (var index in keyset) {
        var key = keyset[index];

        if (frequencies[key] == maxFrequency) {
            console.log(key + " -> " + maxFrequency);
        }
    }
}

var checkValues = [
    'in the middle of the night',
    'Welcome to SoftUni. Welcome to Java. Welcome everyone.',
    'Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.'
];

for (var i in checkValues) {
    findMostFreqWord(checkValues[i]);
}