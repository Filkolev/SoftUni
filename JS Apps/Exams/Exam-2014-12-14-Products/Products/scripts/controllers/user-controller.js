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

    UserController.prototype.loadEditProfileView = function (selector) {
        var data = {
            username: sessionStorage['username']
        };

        this.viewBag.editProfileView.loadEditProfileView(selector, data);
    };

    UserController.prototype.login = function (username, password) {
        return this.model.login(username, password)
            .then(function (loginData) {
                setUserToStorage(loginData);
                window.location.replace('#/home/');
                Noty.success('Welcome!', 'topCenter');
            }, function (error) {
                Noty.error(error.responseJSON.error, 'topCenter');
            });
    };

    UserController.prototype.register = function (username, pass) {
        return this.model.register(username, pass)
            .then(function (registerData) {
                var data = {
                    username: username,
                    objectId: registerData.objectId,
                    sessionToken: registerData.sessionToken
                };

                setUserToStorage(data);
                window.location.replace('#/home/');
                Noty.success('Registration successful! Welcome!', 'topCenter');
            }, function (error) {
                Noty.error(error.responseJSON.error, 'topCenter');
            });
    };

    UserController.prototype.logout = function () {
        return this.model.logout()
            .then(function () {
                clearUserFromStorage();
                window.location.replace('#/');
                Noty.success('Goodbye!', 'topCenter');
            }, function (error) {
                Noty.error(error.responseJSON.error, 'topCenter');
            });
    };

    UserController.prototype.editProfile = function (username, pass) {
        var userId = sessionStorage['userId'];

        return this.model.editProfile(userId, username, pass)
            .then(function () {
                if (username !== '') {
                    sessionStorage['username'] = username;
                }

                window.location.replace('#/home/');
            });
    };

    function setUserToStorage(data) {
        sessionStorage['username'] = data.username;
        sessionStorage['userId'] = data.objectId;
        sessionStorage['sessionToken'] = data.sessionToken;
    }

    function clearUserFromStorage() {
        delete sessionStorage['username'];
        delete sessionStorage['userId'];
        delete sessionStorage['sessionToken'];
    }

    return {
        load: function (model, views) {
            return new UserController(model, views);
        }
    }
})();