function solve(args) {
    for (var j in args) {
        var currentLine = args[j];
        var regex = /([^?=&]+)=([^?=&]+)/g;
        var match;

        var results = {};

        while (match = regex.exec(currentLine)) {
            var key = match[1].replace(/(%20|\+)+/g, ' ').trim();
            var val = match[2].replace(/(%20|\+)+/g, ' ').trim();            

            if (!results[key]) {
                results[key] = [];
            }

            if (results[key].indexOf(val) == -1) {
                results[key].push(val);
            }
        }

        var toPrint = '';
        for (var j in results) {
            toPrint += j + '=[' + results[j].join(', ') + ']';
        }

        console.log(toPrint);
    }
}

//var checkValues = [
//    [
//        'login=student&password=student'
//    ],
//    [
//        'field=value1&field=value2&field=value3',
//        'http://example.com/over/there?name=ferret'
//    ],
//    [
//        'foo=%20foo&value=+val&foo+=5+%20+203',
//        'foo=poo%20&value=valley&dog=wow+',
//        'url=https://softuni.bg/trainings/coursesinstances/details/1070',
//        'https://softuni.bg/trainings?trainer=nakov&course=oop&course=php '
//    ]
//];

//for (var i in checkValues) {
//    solve(checkValues[i]);
//}