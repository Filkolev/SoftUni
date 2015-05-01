var app = app || {};

app.productModel = (function () {
    function ProductModel(baseUrl, requester, headers) {
        this.serviceUrl = baseUrl + 'classes/Product';
        this.requester = requester;
        this.headers = headers;
    }

    ProductModel.prototype.listAllProducts = function () {
        return this.requester.get(this.serviceUrl, this.headers.getHeaders(true));
    };

    ProductModel.prototype.listFilteredProducts = function (minPrice, maxPrice, category, keyword) {
        var url = this.serviceUrl + '?order=createdAt&where={' +
            '"price":{"$gte":' + minPrice + ',"$lte":' + maxPrice + '}';

        if (category != 'All') {
            url += ',"category":"' + category + '"';
        }

        url += '}';

        return this.requester.get(url, this.headers.getHeaders(true));
    };

    ProductModel.prototype.addProduct = function (name, category, price) {
        var userId = sessionStorage['userId'],
            data = {
                name: name,
                category: category,
                price: price,
                ACL: {
                    "*": {
                        read: true
                    }
                }
            };

        data.ACL[userId] = {
            "write": true,
            "read": true
        };

        return this.requester.post(this.serviceUrl, this.headers.getHeaders(true), data);
    };

    ProductModel.prototype.editProduct = function (productId, name, category, price) {
        var url = this.serviceUrl + '/' + productId,
            data = {
                name: name,
                category: category,
                price: price
            };

        return this.requester.put(url, this.headers.getHeaders(true), data);
    };

    ProductModel.prototype.deleteProduct = function (productId) {
        var url = this.serviceUrl + '/' + productId;

        return this.requester.remove(url, this.headers.getHeaders(true));
    };

    return {
        load: function (baseUrl, requester, headers) {
            return new ProductModel(baseUrl, requester, headers);
        }
    }
})();