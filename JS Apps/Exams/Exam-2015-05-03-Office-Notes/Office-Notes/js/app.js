var app = app || {};

(function () {
    var appId = 'VVAX25JrqpumPRY4dL8uae776KTfXso7oH9avhMU',
        restAPI = '4yjXP1aWhh9GJnr8nkw4QX5p9qUg1tKB1Tk21wEd',
        baseUrl = 'https://api.parse.com/1/',

        headers = app.headers.load(appId, restAPI),
        requester = app.requester.load(),
        userModel = app.userModel.load(baseUrl, requester, headers),
        noteModel = app.noteModel.load(baseUrl, requester, headers),

        homeViews = app.homeViews.load(),
        userViews = app.userViews.load(),
        noteViews = app.noteViews.load(),

        homeController = app.homeController.load(homeViews),
        userController = app.userController.load(userModel, userViews),
        noteController = app.noteController.load(noteModel, noteViews);

    app.router = Sammy(function () {
        var selector = '#container';

        this.before(function () {
            var userId = sessionStorage['userId'];

            if (userId) {
                $('#menu').show();
            } else {
                $('#menu').hide();
            }
        });

        this.before('#/', function () {
            var userId = sessionStorage['userId'];

            if (userId) {
                this.redirect('#/home/');

                return false;
            }
        });

        this.before('#/home/', function () {
            var userId = sessionStorage['userId'];

            if (!userId) {
                this.redirect('#/');

                return false;
            }
        });

        this.before('#/office/(.*?)', function (data) {
            var userId = sessionStorage['userId'],
                params = data.path.split('/'),
                page = params[params.length - 1];

            if (!userId) {
                this.redirect('#/');

                return false;
            }

            if (!page) {
                this.redirect('#/office/1');
            } else {
                this.redirect('#/office/' + page);
            }
        });

        this.before('#/myNotes/(.*?)', function (data) {
            var userId = sessionStorage['userId'],
                params = data.path.split('/'),
                page = params[params.length - 1];

            if (!userId) {
                this.redirect('#/');

                return false;
            }

            if (!page) {
                this.redirect('#/myNotes/1');
            } else {
                this.redirect('#/myNotes/' + page);
            }
        });

        this.before('#/addNote/', function () {
            var userId = sessionStorage['userId'];

            if (!userId) {
                this.redirect('#/');

                return false;
            }
        });

        this.before('#/editNote/(.*?)', function () {
            var userId = sessionStorage['userId'];

            if (!userId) {
                this.redirect('#/');

                return false;
            }
        });

        this.before('#/deleteNote/(.*?)', function () {
            var userId = sessionStorage['userId'];

            if (!userId) {
                this.redirect('#/');

                return false;
            }
        });

        this.before('#/logout/', function () {
            var userId = sessionStorage['userId'];

            if (!userId) {
                this.redirect('#/');

                return false;
            }
        });

        this.get('#/', function () {
            homeController.welcomeScreen(selector);
        });

        this.get('#/login/', function () {
            userController.loadLoginPage(selector);
        });

        this.get('#/register/', function () {
            userController.loadRegisterPage(selector);
        });

        this.get('#/logout/', function () {
            userController.logout();
        });

        this.get('#/home/', function () {
            homeController.homeScreen(selector);
        });

        this.get('#/office/(.*?)', function (data) {
            var params = data.path.split('/'),
                page = params[params.length - 1];

            if (!page) {
                page = 1;
            }

            noteController.listOfficeNotes(selector, page);
        });

        this.get('#/myNotes/(.*?)', function (data) {
            var params = data.path.split('/'),
                page = params[params.length - 1];

            if (!page) {
                page = 1;
            }

            noteController.listCurrentUserNotes(selector, page);
        });

        this.get('#/addNote/', function () {
            noteController.loadAddNoteView(selector);
        });

        this.get('#/editNote/:data', function () {
            noteController.loadNoteView(selector, this.params['data'], 'edit');
        });

        this.get('#/deleteNote/:data', function () {
            noteController.loadNoteView(selector, this.params['data'], 'delete');
        });

        this.bind('login', function (e, data) {
            userController.login(data.username, data.password);
        });

        this.bind('register', function (e, data) {
            userController.register(data.username, data.password, data.fullName);
        });

        this.bind('addNote', function (e, data) {
            noteController.addNote(data.title, data.text, data.deadline);
        });

        this.bind('listAllNotes', function (e, data) {
            noteController.listOfficeNotes(selector);
        });

        this.bind('listOwnedNotes', function (e, data) {
            noteController.listCurrentUserNotes(selector);
        });

        this.bind('editNote', function (e, data) {
            noteController.editNote(data.id, data.title, data.text, data.deadline);
        });

        this.bind('deleteNote', function (e, data) {
            noteController.deleteNote(data.id);
        });
    });

    app.router.run('#/');
})();