pmcApp.controller('accountCtrl', ['$scope', 'accountService', function ($scope, accountService) {

    $scope.signupData = {};
    $scope.message = '';

    //$scope.registerUser = function () {
    //    if ($scope.signupForm.$valid && $scope.signupData.Password === $scope.signupData.ConfirmPassword) {
    //        $http.post('/Account/UpsertSiteUser', $scope.signupData)
    //            .then(function (response) {
    //                if (response.data.success) {
    //                    $scope.message = "Registration successful!";
    //                } else {
    //                    $scope.message = "Error during registration!";
    //                }
    //            })
    //            .catch(function (error) {
    //                $scope.message = "Server error occurred!";
    //            });
    //    } else {
    //        $scope.message = "Please fill out all fields correctly.";
    //    }
    //};
    $scope.upsertSiteUser = function () {
        if ($scope.signupForm.$valid && $scope.signupData.Password === $scope.signupData.ConfirmPassword) {
            accountService.upsertSiteUser($scope.signupData).then(function (response) {
                if (response.data.isValid) {
                    $scope.message = response.data.message;
                } else {
                    $scope.message = response.data.message;
                }
            })
        }
        else {
            $scope.message = "Please fill out all fields correctly.";
        }
    };
}]);
