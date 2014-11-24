function solve(args) {
    var result = {
        students: [],
        trainers: []
    };

    var studentsSort = args[0].split('^')[0];

    for (var i = 1; i < args.length; i++) {
        var currentEntry = JSON.parse(args[i]);

        if (currentEntry['role'] == 'student') {
            result.students.push(currentEntry);
        } else {
            delete currentEntry.role;
            delete currentEntry.town;
            result.trainers.push(currentEntry);
        }
    }

    result.students.sort(function (a, b) {
        if (studentsSort == 'name') {
            if (a.firstname == b.firstname) {
                return a.lastname.localeCompare(b.lastname);
            }
            return a.firstname.localeCompare(b.firstname);
        } else {
            if (a.level == b.level) {
                return a.id - b.id;
            }
            return a.level - b.level;
        }
    });

    result.trainers.sort(function (a, b) {
        if (a.courses.length == b.courses.length) {
            return a.lecturesPerDay - b.lecturesPerDay;
        }
        return a.courses.length - b.courses.length;
    });

    for (var j in result.students) {
        var currentStudent = result.students[j];
        var totalScore = 0;

        for (var grade in currentStudent.grades) {
            totalScore += parseFloat(currentStudent.grades[grade]);
        }

        var avg = (totalScore / currentStudent.grades.length).toFixed(2);
        currentStudent['averageGrade'] = avg;  
        
        var orderedStudent = {};
        orderedStudent['id'] = currentStudent.id;
        orderedStudent['firstname'] = currentStudent.firstname;
        orderedStudent['lastname'] = currentStudent.lastname;
        orderedStudent['averageGrade'] = currentStudent.averageGrade;
        orderedStudent['certificate'] = currentStudent.certificate;

        result.students[j] = orderedStudent;
    }

    console.log(JSON.stringify(result));
}

//var checkValues = [
//    [
//        'level^courses',
//        '{"id":0,"firstname":"Angel","lastname":"Ivanov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
//        '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
//        '{"id":2,"firstname":"Bobi","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
//        '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
//        '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps","Java"],"lecturesPerDay":2}'
//    ],
//    [
//        'name^courses',
//        '{"id":0,"firstname":"Angel","lastname":"Ivanov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
//        '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
//        '{"id":2,"firstname":"Angel","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
//        '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
//        '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps"],"lecturesPerDay":2}'
//    ]
//];

//solve(checkValues[0]);
