(function (module) {

    var carImageService = function ($http) {

        var getCarImages = function (year, make, model, limit) {
            return $http.get('http://localhost:50604/api/carimage?year=' + year + '&make=' + make + '&model=' + model + '&limit=' + limit);
        };

        return {
            getCarImages: getCarImages
        };
    };

    module.factory("carImageService", carImageService);

}(angular.module("app")));
