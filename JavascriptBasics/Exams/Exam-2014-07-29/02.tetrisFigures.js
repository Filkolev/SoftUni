function solve(args) {
    var obj = {
        I: 0,
        L: 0,
        J: 0,
        O: 0,
        Z: 0,
        S: 0,
        T: 0
    };

    var width = args[0].length;

    for (var i = 0; i < args.length - 3; i++) {
        for (var j = 0; j < width; j++) {
            if (args[i][j] == 'o' &&
                args[i + 1][j] == 'o' &&
                args[i + 2][j] == 'o' &&
                args[i + 3][j] == 'o') {
                obj.I += 1;
            }           
        }
    }

    for (var i = 0; i < args.length - 2; i++) {
        for (var j = 0; j < width - 1; j++) {
            if (args[i][j] == 'o' &&
                args[i + 1][j] == 'o' &&
                args[i + 2][j] == 'o' &&
                args[i + 2][j + 1] == 'o') {
                obj.L += 1;
            }            
        }
    }

    for (var i = 0; i < args.length - 1; i++) {
        for (var j = 0; j < width - 1; j++) {
            if (args[i][j] == 'o' &&
                args[i][j + 1] == 'o' &&
                args[i + 1][j] == 'o' &&
                args[i + 1][j + 1] == 'o') {
                obj.O += 1;
            }
        }
    }    

    for (var i = 0; i < args.length - 1; i++) {
        for (var j = 0; j < width - 2; j++) {

            if (args[i][j] == 'o' &&
                args[i][j + 1] == 'o' &&
                args[i + 1][j + 1] == 'o' &&
                args[i + 1][j + 2] == 'o') {
                obj.Z += 1;
            }

            if (args[i][j] == 'o' &&
                args[i][j + 1] == 'o' &&
                args[i][j + 2] == 'o' &&
                args[i + 1][j + 1] == 'o') {
                obj.T += 1;
            }
        }
    }

    for (var i = 0; i < args.length - 2; i++) {
        for (var j = 1; j < width; j++) {
            if (args[i][j] == 'o' &&
                args[i + 1][j] == 'o' &&
                args[i + 2][j] == 'o' &&
                args[i + 2][j - 1] == 'o') {
                obj.J += 1;
            }            
        }
    }

    for (var i = 0; i < args.length - 1; i++) {
        for (var j = 1; j < width - 1; j++) {            
            if (args[i][j] == 'o' &&
                args[i + 1][j] == 'o' &&
                args[i + 1][j - 1] == 'o' &&
                args[i][j + 1] == 'o') {
                obj.S += 1;
            }
        }
    }

    console.log(JSON.stringify(obj));
}

//solve([
//'--o--o-',
//'--oo-oo',
//'ooo-oo-',
//'-ooooo-',
//'---oo--'
//]);

//solve([
//'-oo',
//'ooo',
//'ooo'
//]);