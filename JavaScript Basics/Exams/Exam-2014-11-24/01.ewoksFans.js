function solve(args) {
    var fans = [];
    var haters = [];

    for (var j in args) {
        var splitInput = args[j].split('.');
        var date = new Date(splitInput[2] + '-' + splitInput[1] + '-' + splitInput[0]);

        if (date > new Date('1973-05-25') && date < new Date('2015-01-01')) {
            fans.push(date);
        } else if (date > new Date('1900-01-01') && date <= new Date('1973-05-25')) {
            haters.push(date);
        }
    }


    fans.sort(function (a, b) {
        return b - a;
    });

    haters.sort(function (a, b) {
        return a - b;
    });

    if (fans.length == 0 && haters.length == 0) {
        console.log('No result');
        return;
    } 

    if (fans.length > 0) {
        console.log('The biggest fan of ewoks was born on ' + fans[0].toDateString());
    }
    if (haters.length > 0) {
        console.log('The biggest hater of ewoks was born on ' + haters[0].toDateString());
    }
}

//var checkValues = [
//    [
//        '22.03.2014',
//        '17.05.1933',
//        '10.10.1954'
//    ],
//    [
//        '22.03.2000'
//    ],
//    [
//        '22.03.1700',
//        '01.07.2020'
//    ]
//];

//for (var i in checkValues) {
//    solve(checkValues[i]);
//}