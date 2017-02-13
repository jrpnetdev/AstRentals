(function (module) {

    var carSearchService = function ($http) {

        var getSearchResults = function (searchText) {
            return $http.get('http://localhost:50604/api/carsearch?searchtext=' + searchText);
        };

        return {
            getSearchResults: getSearchResults
        };
    };

    module.factory("carSearchService", carSearchService);

}(angular.module("app")));