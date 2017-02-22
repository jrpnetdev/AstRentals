(function (module) {

    var result = 0;

    var carCountService = function ($http) {

        var getCarCountMake = function (make) {

            $http.get('http://localhost:50604/api/carcount?make=' + make)
                .then(function (response) {
                    // Success
                    result = response.data;
                }, function () {
                    // Failure
            });

            return result;
        };
 

        var getCarCountYear = function (year) {

            $http.get('http://localhost:50604/api/carcount?year=' + year)
                .then(function (response) {
                    // Success
                    result = response.data;
                }, function () {
                    // Failure
            });

            return result;
        };

        return {
            getCarCountMake: getCarCountMake,
            getCarCountYear: getCarCountYear
        };
    };

    module.factory("carCountService", carCountService);

}(angular.module("app")));