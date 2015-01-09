function solve(args) {
    for (var i in args) {
        var data = args[i].split(' ');
        var model = data[0];
        var fuel = data[1];
        var route = data[2];
        var luggage = parseFloat(data[3]);

        var consumption = 10 / 100;

        switch (fuel) {
            case 'gas': consumption *= 1.2; break;
            case 'diesel': consumption *= 0.8; break;
        }

        consumption += luggage * 0.0001;
        var extraConsumption = 0.30 * consumption;

        switch (route) {
            case '1':
                consumption *= 110;
                consumption += extraConsumption * 10;
                break;
            case '2':
                consumption *= 95;
                consumption += extraConsumption * 35;
                break;
        }

        console.log(model + ' ' + fuel + ' ' + route + ' ' + Math.round(consumption));
    }
}