function solve(arr) {
    var bill = parseFloat(arr[0]);
    var mood = arr[1];

    var result = 0;

    if (mood == 'happy') {
        result = bill * .1;
    } else if (mood == 'married') {
        result = bill * 0.0005;
    } else if (mood == 'drunk') {
        var temp = parseFloat(bill * 0.15);
        while (temp > 10) {
            temp /= 10;
        }
        var power = Math.floor(temp % 10);
        result = Math.pow((bill * 0.15), power);
        result = parseFloat(result);
    } else {
        result = bill * 0.05;
    }

    console.log(result.toFixed(2));
}