function displayProperties() {
    var properties = [];

    for (var property in document) {
        properties.push(property);
    }

    properties.sort();

    for (var i in properties) {
        console.log(properties[i]);
    }

    document.getElementById('message').innerHTML = 'Check the result in the console (F12)'
}
