pmcApp.controller('globalCtrl', ['$scope', 'searchService', function ($scope, searchService) {
    // Initialize search query and suggestions
    $scope.searchQuery = '';
    $scope.suggestions = [];
    $scope.showSuggestions = false;

    // Fetch suggestions based on the search query
    $scope.getSuggestions = function () {
        if ($scope.searchQuery.length > 0) {
            searchService.getSuggestions($scope.searchQuery).then(function (response) {
                $scope.suggestions = response.data;
                $scope.showSuggestions = $scope.suggestions.length > 0;
            });
        } else {
            $scope.suggestions = [];
            $scope.showSuggestions = false;
        }
    };

    // Select a suggestion and update the search query
    $scope.selectSuggestion = function (suggestion) {
        $scope.searchQuery = suggestion;
        $scope.showSuggestions = false;  // Hide the suggestions after selection
    };

    // Function to handle the search
    $scope.searchProducts = function () {
        searchService.searchProducts($scope.searchQuery).then(function (response) {
            // Handle the search results (could redirect to a results page or display in the same view)
            $scope.searchResults = response.data;
        });
    };

    // Clear the search query and suggestions
    $scope.clearSearch = function () {
        $scope.searchQuery = '';
        $scope.suggestions = [];
        $scope.showSuggestions = false;
    };
}]);
