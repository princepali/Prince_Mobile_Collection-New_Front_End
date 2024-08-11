pmcApp.controller('productCtrl', ['$scope', 'productService', function ($scope, productService) {
    $scope.products = [];

    $scope.getProducts = function (productFilter) {
        productService.getProducts(productFilter).then(function (response) {
            $scope.products = response.data;
        });
    };

    $scope.getProduct = function (id) {
        productService.getProduct(id).then(function (response) {
            $scope.product = response.data;
        });
    };

    $scope.insertProduct = function (product) {
        productService.insertProduct(product).then(function (response) {
            $scope.products.push(response.data);
            $scope.product = {}; // Clear the form
        });
    };

    $scope.updateProduct = function (product) {
        productService.updateProduct(product).then(function (response) {
            $scope.getProducts(); // Refresh the product list
        });
    };

    $scope.deleteProduct = function (id) {
        productService.deleteProduct(id).then(function (response) {
            $scope.getProducts(); // Refresh the product list
        });
    };

    // Initialize the product list
    $scope.getProducts();
}]);
