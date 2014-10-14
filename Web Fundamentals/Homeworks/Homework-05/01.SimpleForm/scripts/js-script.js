function checkPasswords () {
    var pass = document.getElementById("pass").value;
    var confirm = document.getElementById("confirm-pass").value;

    var result;

    if (pass.toString() != confirm.toString() && pass.length >= 4) {
        result = "Passwords do not match!";
        document.getElementById("register-button").setAttribute("disabled", "disabled");
        document.getElementById("valid").setAttribute("style", "display:none");
        document.getElementById("valid").setAttribute("background-color", "red");
        document.getElementById("invalid").setAttribute("style", "display:inline-block");        
    } else if (pass.length >=4) {
        result = "Passwords match!";
        document.getElementById("register-button").removeAttribute("disabled");
        document.getElementById("invalid").setAttribute("style", "display:none");
        document.getElementById("valid").setAttribute("style", "display:inline-block");
    }

    document.getElementById("pass-check").innerHTML = result;
}

