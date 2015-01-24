function solve(args) {
    console.log('<table border="1">');
    console.log('<thead>');
    console.log('<tr><th colspan="3">Blades</th></tr>');
    console.log('<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>');
    console.log('</thead>');
    console.log('<tbody>');

    for (var i in args) {
        var currentBladeLength = parseInt(args[i]);
        var type;
        var application;

        type = currentBladeLength <= 40 ? 'dagger' : 'sword';

        switch (currentBladeLength % 5) {
            case 0: application = '*rap-poker'; break;
            case 1: application = 'blade'; break;
            case 2: application = 'quite a blade'; break;
            case 3: application = 'pants-scraper'; break;
            case 4: application = 'frog-butcher'; break;

        }

        if (currentBladeLength > 10) {
            console.log('<tr><td>' + currentBladeLength + '</td><td>' + type + '</td><td>' + application + '</td></tr>');
        }
        
    }

    console.log('</tbody>');
    console.log('</table>');
}

//solve([
//        '17.8',
//        '19.4',
//        '13',
//        '55.8',
//        '126.96541651',
//        '3'
//])