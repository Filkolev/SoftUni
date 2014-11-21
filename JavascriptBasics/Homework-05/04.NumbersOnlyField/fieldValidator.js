function validate() {
    var input = document.getElementById('text-field');
    input.addEventListener("keydown", check());

    function check() {
        var keyPressed = event.keyCode;

        if (keyPressed < 48 || keyPressed > 57) {
            input.disabled = true;
            input.style.backgroundColor = "red";

            var delay = 500;

            setTimeout(function () {
                input.style.backgroundColor = "white";
                input.disabled = false;
                input.focus();
            }, delay);
        }
    }
}