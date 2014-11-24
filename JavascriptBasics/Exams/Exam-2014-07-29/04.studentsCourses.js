function solve(args) {
    var result = {};

    for (var i in args) {
        var data = args[i].split('|');
        var name = data[0].trim();
        var course = data[1].trim();
        var grade = parseFloat(data[2].trim());
        var visits = parseFloat(data[3].trim());

        if (!result[course]) {
            result[course] = {
                avgGrade: 0,
                avgVisits: 0,
                students: [],
                totalVisits: 0
            };
        }

        result[course].avgGrade += grade;
        result[course].avgVisits += visits;
        result[course].totalVisits += 1;

        if (result[course].students.indexOf(name) == -1) {
            result[course].students.push(name);
        }
    }

    var resultKeys = Object.keys(result).sort();

    var result2 = {};

    for (var j in resultKeys) {
        result2[resultKeys[j]] = result[resultKeys[j]];
    }    

    for (var k in result2) {
        var totalVisitors = result[k].totalVisits;

        result2[k].avgGrade = parseFloat((result2[k].avgGrade / totalVisitors).toFixed(2));
        result2[k].avgVisits = parseFloat((result2[k].avgVisits / totalVisitors).toFixed(2));
        delete result2[k].totalVisits;
        result2[k].students.sort();
    }

    console.log(JSON.stringify(result2));
}

//var checkValue = [
//    'Peter Nikolov | PHP  | 5.50 | 8',
//    'Maria Ivanova | Java | 5.83 | 7',
//    'Ivan Petrov   | PHP  | 3.00 | 2',
//    'Ivan Petrov   | C#   | 3.00 | 2',
//    'Peter Nikolov | C#   | 5.50 | 8',
//    'Maria Ivanova | C#   | 5.83 | 7',
//    'Ivan Petrov   | C#   | 4.12 | 5',
//    'Ivan Petrov   | PHP  | 3.10 | 2',
//    'Peter Nikolov | Java | 6.00 | 9'
//];

//solve(checkValue);