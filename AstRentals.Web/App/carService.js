(function (module) {

    var carService = function ($http) {

        var getCarsByPage = function (make, index, size) {
            return $http.get('http://localhost:50604/api/cars?make=' + make + '&index=' + index + '&size=' + size);
        };


        var getCarsByMake = function (make, size) {
            return $http.get('http://localhost:50604/api/cars?make=' + make + '&size=' + size);
        };

        var getCarById = function (id) {
            return $http.get('http://localhost:50604/api/cars?id=' + id);
        };

        return {
            getCarsByPage: getCarsByPage,
            getCarsByMake: getCarsByMake,
            getCarById: getCarById
        };
    };

    module.factory("carService", carService);

}(angular.module("app")));
