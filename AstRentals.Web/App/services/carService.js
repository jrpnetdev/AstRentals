(function (module) {

    var carService = function ($http) {

        var getCars = function (term, index, size, type) {

            if (type === "year") {
                return $http.get('http://localhost:50604/api/cars?year=' + term + '&index=' + index + '&size=' + size);
            }
            else if (type === "search") {
                return $http.get('http://localhost:50604/api/carsearch?searchtext=' + term + '&index=' + index + '&size=' + size);
            }

            return $http.get('http://localhost:50604/api/cars?make=' + term + '&index=' + index + '&size=' + size);
        };

        var getCarById = function (id) {
            return $http.get('http://localhost:50604/api/cars?id=' + id);
        };

        return {
            getCars: getCars,
            getCarById: getCarById
        };
    };

    module.factory("carService", carService);

}(angular.module("app")));
