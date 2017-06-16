(function (module) {

    var carDetailsController = function ($rootScope, $scope, $http, carService, carInfoService, carImageService) {

        var model = this;

        model.car = [];
        model.colour = "Red";
        model.features = "3door";
        model.cover = "basic";
        model.startDate = new Date();
        model.endDate = new Date();

        model.getCar = function (id) {

            carService.getCarById(id)
                .then(function(response) {
                    model.car = response.data;

                    carInfoService.getCarInfo(model.car.make, model.car.model).then(function (inforesponse) {
                        model.carInfo = inforesponse.data.info;
                        model.carInfoText = model.carInfo.substr(0, 250) + "...";
                    }, function (data, status, header, config) {
                        model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
                    });

                    carImageService.getCarImages(model.car.year, model.car.make, model.car.model, 6).then(function (imgresponse) {
                        model.carImages = angular.fromJson(imgresponse.data);
                    }, function (data, status, header, config) {
                        model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
                    });

                    $http.get("http://localhost:50604/api/cardetails").then(function(rcresponse) {
                        model.recommendedCars = rcresponse.data;
                    }, function (data, status, header, config) {
                        model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
                    });

                }), function (data, status, header, config) {
                    model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
            };
        };

        model.submitDetails = function () {

            $http({
                url: "/Cars/PreCheckout",
                method: "POST",
                headers: { 'Content-Type': "application/x-www-form-urlencoded" },
                data: "carid=" + model.car.id + "&colour=" + model.colour + "&features=" + model.features + "&cover=" + model.cover +
                            "&startDate=" + model.startDate + "&endDate=" + model.endDate
            }).then(function() {
                window.location = "/Cars/Checkout";
            }, function (data, status, header, config) {
                model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
            });
        };

        $rootScope.$on("selectedDates", function (e, startdate, enddate) {
            model.startDate = startdate;
            model.endDate = enddate;
        });
    };

    module.controller("carDetailsController", carDetailsController);

}(angular.module("app")));