pmcApp.service('productService', ['$http', function ($http) {
    this.getProducts = function (productFilter) {
        return $http.post('/product/getProducts', productFilter);
    };

    this.getProduct = function (id) {
        return $http.get('/api/products/' + id);
    };

    this.insertProduct = function (product) {
        return $http.post('/api/products', product);
    };

    this.updateProduct = function (product) {
        return $http.put('/api/products/' + product.id, product);
    };

    this.deleteProduct = function (id) {
        return $http.delete('/api/products/' + id);
    };
}]);
