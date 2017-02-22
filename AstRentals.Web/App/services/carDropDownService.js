(function (module) {


    var carDropDownService = function ($http) {

        var getMakeDropDownValues = function () {
            return $http.get('http://localhost:50604/api/cardropdown?var=make');
        };

        var getModelDropDownValues = function () {
            return $http.get('http://localhost:50604/api/cardropdown?var=model');
        };

        var getYearDropDownValues = function () {
            return $http.get('http://localhost:50604/api/cardropdown?var=year');
        };

        return {
            getMakeDropDownValues: getMakeDropDownValues,
            getModelDropDownValues: getModelDropDownValues,
            getYearDropDownValues: getYearDropDownValues
        };
    }

    module.factory("carDropDownService", carDropDownService);

}(angular.module("app")));