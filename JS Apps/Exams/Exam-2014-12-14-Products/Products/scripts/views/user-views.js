var app = app || {};

app.userViews = (function () {
    function UserViews() {
        this.loginView = {
            loadLoginView: loadLoginView
        };

        this.registerView = {
            loadRegisterView: loadRegisterView
        };
    }

    function loadLoginView(selector) {
        $.get('templates/login.html', function (template) {
            var outHtml = Mustache.render(template);

            $(selector).html(outHtml);
        }).then(function () {
            $('#login-button').click(function () {
                var username = $('#username').val(),
                    password = $('#password').val();

                $.sammy(function () {
                    this.trigger('login', {username: username, password: password});
                });

                return false;
            })
        });
    }

    function loadRegisterView(selector) {
        $.get('templates/register.html', function (template) {
            var outHtml = Mustache.render(template);

            $(selector).html(outHtml);
        }).then(function () {
            $('#register-button').click(function () {
                var username = $('#username').val(),
                    password = $('#password').val(),
                    repeatPass = $('#confirm-password').val();

                if (password !== repeatPass) {
                    Noty.error('Passwords do not match!', 'topCenter');
                } else {
                    $.sammy(function () {
                        this.trigger('register', {username: username, password: password});
                    });
                }

                return false;
            })
        });
    }

    return {
        load: function () {
            return new UserViews();
        }
    }
})();