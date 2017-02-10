(function (module) {

    var carDetailsController = function (carService, carInfoService) {

        var model = this;

        model.car = [];

        model.getCar = function (id) {

            carService.getCarById(id)
                .then(function(response) {
                    model.car = response.data;

                    carInfoService.getCarInfo(model.car.make, model.car.model).then(function (response) {
                        model.carInfo = response.data.info;
                    }), function (data, status, header, config) {
                        model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
                    };

                }), function (data, status, header, config) {
                    model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
            };
        };

    };

    module.controller("carDetailsController", carDetailsController);

}(angular.module("app")));