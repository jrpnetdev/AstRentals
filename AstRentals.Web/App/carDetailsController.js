(function (module) {

    var carDetailsController = function ($http, carService, carInfoService, carImageService) {

        var model = this;

        model.car = [];
        model.colour = "Red";
        model.features = "3door";
        model.cover = "basic";

        model.getCar = function (id) {

            carService.getCarById(id)
                .then(function(response) {
                    model.car = response.data;

                    carInfoService.getCarInfo(model.car.make, model.car.model).then(function (response) {
                        model.carInfo = response.data.info;
                        model.carInfoText = res.substr(0, 250) + "...";
                    }, function (data, status, header, config) {
                        model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
                    });

                    carImageService.getCarImages(model.car.year, model.car.make, model.car.model, 6).then(function (response) {
                        model.carImages = angular.fromJson(response.data);
                    }, function (data, status, header, config) {
                        model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
                    });

                    $http.get("http://localhost:50604/api/cardetails").then(function(response) {
                        model.recommendedCars = response.data;
                    }, function (data, status, header, config) {
                        model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
                    });

                }), function (data, status, header, config) {
                    model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
            };
        };

        model.submitDetails = function () {
            var currentTime = new Date();
            window.location = '/Cars/Checkout?carid=' + model.car.id + '&colour=' + model.colour + '&features=' + model.features + '&cover=' + model.cover + '&startdate=' + currentTime + '&enddate=' + currentTime;
        };

    };

    module.controller("carDetailsController", carDetailsController);

}(angular.module("app")));