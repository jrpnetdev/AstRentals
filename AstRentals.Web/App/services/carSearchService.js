(function (module) {

    var carSearchService = function ($http) {

        var getSearchResults = function (searchText, page, size) {
            return $http.get('http://localhost:50604/api/carsearch?searchtext=' + searchText + '&index=' + page + '&size=' + size);
        };

        return {
            getSearchResults: getSearchResults
        };
    };

    module.factory("carSearchService", carSearchService);

}(angular.module("app")));