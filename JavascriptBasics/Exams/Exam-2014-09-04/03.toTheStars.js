function solve(args) {
    var firstSystemData = args[0].split(/\s+/g);

    var firstSystemName = firstSystemData[0].toLowerCase();
    var firstSystemX = parseFloat(firstSystemData[1]);
    var firstSystemY = parseFloat(firstSystemData[2]);

    var secondSystemData = args[1].split(/\s+/g);

    var secondSystemName = secondSystemData[0].toLocaleLowerCase();
    var secondSystemX = parseFloat(secondSystemData[1]);
    var secondSystemY = parseFloat(secondSystemData[2]);

    var thirdSystemData = args[2].split(/\s+/g);

    var thirdSystemName = thirdSystemData[0].toLocaleLowerCase();
    var thirdSystemX = parseFloat(thirdSystemData[1]);
    var thirdSystemY = parseFloat(thirdSystemData[2]);

    var normandyX = parseFloat(args[3].split(/\s+/g)[0]);
    var normandyY = parseFloat(args[3].split(/\s+/g)[1]);

    var steps = parseInt(args[4]);

    for (var i = 0; i <= steps; i++) {
        if (normandyX >= firstSystemX - 1 &&
            normandyX <= firstSystemX + 1 &&
            normandyY >= firstSystemY - 1 &&
            normandyY <= firstSystemY + 1) {
            console.log(firstSystemName);
        } else if (normandyX >= secondSystemX - 1 &&
            normandyX <= secondSystemX + 1 &&
            normandyY >= secondSystemY - 1 &&
            normandyY <= secondSystemY + 1) {
            console.log(secondSystemName);
        } else if (normandyX >= thirdSystemX - 1 &&
            normandyX <= thirdSystemX + 1 &&
            normandyY >= thirdSystemY - 1 &&
            normandyY <= thirdSystemY + 1) {
            console.log(thirdSystemName)
        } else {
            console.log('space');
        }

        normandyY += 1;
    }
}

//solve([
//'Sirius 3 7',
//'Alpha-Centauri 7 5',
//'Gamma-Cygni 10 10',
//'8 1',
//'6'
//]);

//solve([
//'Terra-Nova 16 2',
//'Perseus 2.6 4.8',
//'Virgo 1.6 7',
//'2 5',
//'4'
//]);