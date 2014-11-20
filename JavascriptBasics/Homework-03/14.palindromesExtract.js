function findPalindromes(value) {
    var arr = value.toLowerCase().split(/[\b\W]+/g);
    var result = [];

    for (var i in arr) {
        if (arr[i].split('').reverse().join('') == arr[i] && arr[i] != '') {
            result.push(arr[i]);
        }
    }

    return result;
}

var checkValue = 'There is a man, his name was Bob.';

console.log(findPalindromes(checkValue).join(', '));
