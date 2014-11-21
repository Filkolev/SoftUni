function switchValue() {
    var button = document.getElementById('butt');
    var value = button.innerHTML;

    if (value == 'Like') {
        button.innerHTML = 'Unlike';
    } else {
        button.innerHTML = 'Like';
    }
}