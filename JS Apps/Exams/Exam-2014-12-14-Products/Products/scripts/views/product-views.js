var app = app || {};

app.productViews = (function () {
    function ProductViews() {
        this.listProducts = {
            loadProductView: loadProductsView
        };

        this.addProduct = {
            loadAddProductView: addProductView
        };

        this.editProduct = {
            loadEditPhoneView: editProductView
        };

        this.deleteProduct = {
            loadDeletePhoneView: deleteProductView
        }
    }

    function loadProductsView(selector, data) {
        $.get('templates/products.html', function (template) {
            var outHtml = Mustache.render(template, data);

            $(selector).html(outHtml);
        }).then(function () {
            $('#filter').click(function () {
                var keyword = $('#search-bar').val(),
                    minPrice = Number($('#min-price').val()),
                    maxPrice = Number($('#max-price').val()),
                    category = $('#category').val();

                $.sammy(function () {
                    this.trigger('filterProducts', {
                        keyword: keyword,
                        category: category,
                        minPrice: minPrice,
                        maxPrice: maxPrice
                    });
                });

                return false;
            });

            $('#clear-filters').click(function () {
                $.sammy(function () {
                    this.trigger('listAllProducts');
                });

                return false;
            });
        });
    }

    function addProductView(selector) {
        $.get('templates/add-product.html', function (template) {
            var outHtml = Mustache.render(template);

            $(selector).html(outHtml);
        }).then(function () {
            $('#add-product-button').click(function () {
                var name = $('#name').val(),
                    category = $('#category').val(),
                    price = Number($('#price').val());

                $.sammy(function () {
                    this.trigger('addProduct', {name: name, category: category, price: price});
                });

                return false;
            })
        });
    }

    function editProductView(selector, data) {
        $.get('templates/edit-product.html', function (template) {
            var outHtml = Mustache.render(template, data);

            $(selector).html(outHtml);
        }).then(function () {
            $('#edit-product-button').click(function () {
                var name = $('#item-name').val(),
                    category = $('#category').val(),
                    price = Number($('#price').val());

                if (isNaN(price)) {
                    Noty.error('Ivalid price!', 'topCenter');
                } else {
                    $.sammy(function () {
                        this.trigger('editProduct', {id: data.id, name: name, category: category, price: price});
                    });
                }

                return false;
            })
        });
    }

    function deleteProductView(selector, data) {
        $.get('templates/delete-product.html', function (template) {
            var outHtml = Mustache.render(template, data);

            $(selector).html(outHtml);
        }).then(function () {
            $('#delete-product-button').click(function () {
                $.sammy(function () {
                    this.trigger('deleteProduct', {id: data.id});
                });

                return false;
            })
        });
    }

    return {
        load: function () {
            return new ProductViews();
        }
    }
})();