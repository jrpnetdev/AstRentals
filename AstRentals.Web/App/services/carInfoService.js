(function (module) {

    var carInfoService = function ($http) {

        var getCarInfo = function (make, model) {
            return $http.get('http://localhost:50604/api/carinfo?make=' + make + '&model=' +model);
        };

        return {
            getCarInfo: getCarInfo
        };
    };

    module.factory("carInfoService", carInfoService);

}(angular.module("app")));
