var app = app || {};

app.productController = (function () {
    function ProductController(model, views) {
        this.model = model;
        this.viewBag = views;
    }

    ProductController.prototype.loadAddProductView = function (selector) {
        this.viewBag.addProduct.loadAddProductView(selector);
    };

    ProductController.prototype.loadProductView = function (selector, urlParams, action) {
        var data = urlParams.split('&'),
            outData = {
                id: data[0].split('id=')[1],
                name: data[1].split('name=')[1],
                category: data[2].split('category=')[1],
                price: parseFloat(data[3].split('price=')[1])
            };

        if (action === 'delete') {
            this.viewBag.deleteProduct.loadDeletePhoneView(selector, outData);
        } else {
            this.viewBag.editProduct.loadEditPhoneView(selector, outData);
        }
    };

    ProductController.prototype.listAllProducts = function (selector) {
        var _this = this;

        return this.model.listAllProducts()
            .then(function (data) {
                data.results.forEach(function (product) {
                    product.show = product.ACL[sessionStorage.userId];
                });

                _this.viewBag.listProducts.loadProductView(selector, data);
            }, function (error) {
                Noty.error(error.responseJSON.error, 'topCenter');
            });
    };

    ProductController.prototype.listFilteredProducts = function (selector, minPrice, maxPrice, category, keyword) {
        var _this = this;

        minPrice = parseFloat(minPrice);
        maxPrice = parseFloat(maxPrice);

        return this.model.listFilteredProducts(minPrice, maxPrice, category, keyword)
            .then(function (data) {
                data.results.forEach(function (product) {
                    product.show = product.ACL[sessionStorage.userId];
                });

                data.results = data.results.filter(function (product) {
                    return product.name.indexOf(keyword) !== -1;
                });

                _this.viewBag.listProducts.loadProductView(selector, data);
            }, function (error) {
                Noty.error(error.responseJSON.error, 'topCenter');
            });
    };

    ProductController.prototype.addProduct = function (name, category, price) {
        return this.model.addProduct(name, category, price)
            .then(function () {
                window.location.replace('#/products/');
                Noty.success('Product added successfully!', 'topCenter');
            }, function (error) {
                Noty.error(error.responseJSON.error, 'topCenter');
            });
    };

    ProductController.prototype.editProduct = function (productId, name, category, price) {
        return this.model.editProduct(productId, name, category, price)
            .then(function () {
                window.location.replace('#/products/');
                Noty.success('Product edited successfully!', 'topCenter');
            }, function (error) {
                Noty.error(error.responseJSON.error, 'topCenter');
            });
    };

    ProductController.prototype.deleteProduct = function (productId) {
        return this.model.deleteProduct(productId)
            .then(function () {
                window.location.replace('#/products/');
                Noty.success('Product deleted successfully!', 'topCenter');
            }, function (error) {
                Noty.error(error.responseJSON.error, 'topCenter');
            });
    };

    return {
        load: function (model, views) {
            return new ProductController(model, views);
        }
    }
})();