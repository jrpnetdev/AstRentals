(function (module) {

    var cars = [];

    var carService = function ($http) {

        var getCars = function () {

            $http.get('http://localhost:50604/api/cars?make=Ford&index=1&size=10')
                .then(function (response) {
                    // Success
                    angular.copy(response.data, cars);
                }, function () {
                    // Failure
            });

            return cars;
        };


        var getCarsByMake = function (make) {
            
            $http.get('http://localhost:50604/api/cars?make=' + make +'&index=1&size=10')
                .then(function (response) {
                    // Success
                    angular.copy(response.data, cars);
                }, function () {
                    // Failure
                });

            return cars;
        };

        return {
            getCars: getCars,
            getCarsByMake: getCarsByMake
        };
    };

    module.factory("carService", carService);

}(angular.module("app")));
