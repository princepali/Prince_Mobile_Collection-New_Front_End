pmcApp.service('accountService', ['$http', function ($http) {

    this.getSiteUsers = function (userFilter) {
        return $http.post('/siteUser/getSiteUsers', userFilter);
    };

    this.upsertSiteUser = function (siteUser) {
        return $http.post('/account/UpsertSiteUser', siteUser);
    };
}]);
