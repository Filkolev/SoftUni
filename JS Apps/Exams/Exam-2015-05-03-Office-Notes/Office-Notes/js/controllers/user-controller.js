var app = app || {};

app.userController = (function () {
    function UserController(model, views) {
        this.model = model;
        this.viewBag = views;
    }

    UserController.prototype.loadLoginPage = function (selector) {
        this.viewBag.loginView.loadLoginView(selector);
    };

    UserController.prototype.loadRegisterPage = function (selector) {
        this.viewBag.registerView.loadRegisterView(selector);
    };

    UserController.prototype.login = function (username, password) {
        return this.model.login(username, password)
            .then(function (loginData) {
                setUserToStorage(loginData);
                $('#welcomeMenu').text('Welcome, ' + sessionStorage.username);
                window.location.replace('#/home/');
                Noty.success('You have successfully logged in!', 'top');
            }, function (error) {
                Noty.error(error.responseJSON.error, 'top');
            });
    };

    UserController.prototype.register = function (username, pass, fullName) {
        return this.model.register(username, pass, fullName)
            .then(function (registerData) {
                var data = {
                    username: username,
                    fullName: fullName,
                    objectId: registerData.objectId,
                    sessionToken: registerData.sessionToken
                };

                setUserToStorage(data);
                $('#welcomeMenu').text('Welcome, ' + sessionStorage.username);
                window.location.replace('#/home/');
                Noty.success('Registration successful! Welcome!', 'top');
            }, function (error) {
                Noty.error(error.responseJSON.error, 'top');
            });
    };

    UserController.prototype.logout = function () {
        return this.model.logout()
            .then(function () {
                clearUserFromStorage();
                $('#welcomeMenu').text('');
                window.location.replace('#/');
                Noty.success('Goodbye!', 'top');
            }, function (error) {
                Noty.error(error.responseJSON.error, 'top');
            });
    };

    function setUserToStorage(data) {
        sessionStorage['username'] = data.username;
        sessionStorage['fullName'] = data.fullName;
        sessionStorage['userId'] = data.objectId;
        sessionStorage['sessionToken'] = data.sessionToken;
    }

    function clearUserFromStorage() {
        delete sessionStorage['username'];
        delete sessionStorage['fullName'];
        delete sessionStorage['userId'];
        delete sessionStorage['sessionToken'];
    }

    return {
        load: function (model, views) {
            return new UserController(model, views);
        }
    }
})();