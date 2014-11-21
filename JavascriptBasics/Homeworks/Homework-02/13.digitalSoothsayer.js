function soothsayer(value) {
    var years = value[0];
    var languages = value[1];
    var cities = value[2];
    var cars = value[3];

    var result = new Object;
    result[0] = years[Math.floor((Math.random() * 5))];
    result[1] = languages[Math.floor((Math.random() * 5))];
    result[2] = cities[Math.floor((Math.random() * 5))];
    result[3] = cars[Math.floor((Math.random() * 5))];

    console.log('You will work ' + result[0] + ' years on ' + result[1] + '. You will live in '+ result[2] + ' and drive ' + result[3] + '.');
}

soothsayer([
[3, 5, 2, 7, 9], 
['Java', 'Python', 'C#', 'JavaScript', 'Ruby'], 
['Silicon Valley', 'London', 'Las Vegas', 'Paris', 'Sofia'], 
['BMW', 'Audi', 'Lada', 'Skoda', 'Opel']]);
