function solve(args) {

    var result = {};

    for (var i in args) {
        var data = args[i].split('|');

        var band = data[0].trim();
        var city = data[1].trim();
        var venue = data[3].trim();

        if (!result[city]) {
            result[city] = {};
            result[city][venue] = [];
            result[city][venue].push(band);
        } else if (!result[city][venue]) {
            result[city][venue] = [];
            result[city][venue].push(band);
        } else {
            if (result[city][venue].indexOf(band) == -1) {
                result[city][venue].push(band);                
            }            
        }

        result[city][venue].sort();
        
    }

    result = sortObjByKey(result);

    for (var k in result) {
        result[k] = sortObjByKey(result[k]);
    }

    function sortObjByKey(obj) {
        var sortedObj = {};
        var objKeysSorted = Object.keys(obj).sort();

        for (var j in objKeysSorted) {
            sortedObj[objKeysSorted[j]] = obj[objKeysSorted[j]];
        }

        return sortedObj;
    }

    console.log(JSON.stringify(result));

}

//var checkValue = [
//    'ZZ Top | London | 2-Aug-2014 | Wembley Stadium',
//'Iron Maiden | London | 28-Jul-2014 | Wembley Stadium',
//'Metallica | Sofia | 11-Aug-2014 | Lokomotiv Stadium',
//'Helloween | Sofia | 1-Nov-2014 | Vassil Levski Stadium',
//'Iron Maiden | Sofia | 20-June-2015 | Vassil Levski Stadium',
//'Helloween | Sofia | 30-July-2015 | Vassil Levski Stadium',
//'Iron Maiden | Sofia | 26-Sep-2014 | Lokomotiv Stadium ',
//'Helloween | London | 28-Jul-2014 | Wembley Stadium    ',
//'Twisted Sister | London | 30-Sep-2014 | Wembley Stadium',
//'Metallica | London | 03-Oct-2014 | Olympic Stadium    ',
//'Iron Maiden | Sofia | 11-Apr-2016 | Lokomotiv Stadium ',
//'Iron Maiden | Buenos Aires | 03-Mar-2014 | River Plate'
//];

//solve(checkValue);