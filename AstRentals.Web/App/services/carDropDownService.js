(function (module) {


    var carDropDownService = function($http) {

        var getMakeDropDownValues = function() {
            return $http.get("http://localhost:50604/api/cardropdown?searchType=make");
        };

        var getModelDropDownValues = function() {
            return $http.get("http://localhost:50604/api/cardropdown?searchType=model");
        };

        var getYearDropDownValues = function() {
            return $http.get("http://localhost:50604/api/cardropdown?searchType=year");
        };

        var onChanged = function (searchTerm, searchType) {
            return $http.get("http://localhost:50604/api/cardropdown?searchTerm=" + searchTerm + "&searchType=" + searchType);
        };

        return {
            getMakeDropDownValues: getMakeDropDownValues,
            getModelDropDownValues: getModelDropDownValues,
            getYearDropDownValues: getYearDropDownValues,
            onChanged: onChanged
        };
    };

    module.factory("carDropDownService", carDropDownService);

}(angular.module("app")));