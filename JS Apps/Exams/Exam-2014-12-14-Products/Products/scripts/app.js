var app = app || {};

(function () {
    var appId = 'rP5t9cAmleQX0Ic4KoruSVks6UKyQlDhccCHydFL',
        restAPI = 'axEGmV6cN6JKqFIxgPml7NOvhZbC7Ay6ZVhgyi5C',
        baseUrl = 'https://api.parse.com/1/',

        headers = app.headers.load(appId, restAPI),
        requester = app.requester.load(),
        userModel = app.userModel.load(baseUrl, requester, headers),
        productModel = app.productModel.load(baseUrl, requester, headers),

        homeViews = app.homeViews.load(),
        userViews = app.userViews.load(),
        productViews = app.productViews.load(),

        userController = app.userController.load(userModel, userViews),
        productController = app.productController.load(productModel, productViews),
        homeController = app.homeController.load(homeViews);


    app.router = Sammy(function () {
        var selector = '#main';

        this.before(function () {
            var userId = sessionStorage['userId'];

            if (userId) {
                $('#default-menu').hide();
                $('#logged-menu').show();

            } else {
                $('#default-menu').show();
                $('#logged-menu').hide();
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

        this.before('#/products/(.*)', function () {
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

        this.get('#/products/', function () {
            productController.listAllProducts(selector);
        });

        this.get('#/products/add/', function () {
            productController.loadAddProductView(selector);
        });

        this.get('#/products/edit/:id', function () {
            productController.loadProductView(selector, this.params['id'], 'edit');
        });

        this.get('#/products/delete/:data', function () {
            productController.loadProductView(selector, this.params['data'], 'delete');
        });

        this.bind('login', function (e, data) {
            userController.login(data.username, data.password);
        });

        this.bind('register', function (e, data) {
            userController.register(data.username, data.password, data.repeatPass);
        });

        this.bind('addProduct', function (e, data) {
            productController.addProduct(data.name, data.category, data.price);
        });

        this.bind('listAllProducts', function (e, data) {
            productController.listAllProducts(selector);
        });

        this.bind('filterProducts', function (e, data) {
            productController.listFilteredProducts(selector, data.minPrice, data.maxPrice, data.category, data.keyword);
        });

        this.bind('editProduct', function (e, data) {
            productController.editProduct(data.id, data.name, data.category, data.price);
        });

        this.bind('deleteProduct', function (e, data) {
            productController.deleteProduct(data.id);
        });
    });

    app.router.run('#/');
})();