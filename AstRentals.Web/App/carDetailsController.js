(function (module) {

    var carDetailsController = function (carService, carInfoService, carImageService) {

        var model = this;

        this.owl = {
            items: ["item 1", "item 2"],
            options: {
                loop: true,
                nav: false
            }
        };

        model.getCar = function (id) {

            carService.getCarById(id)
                .then(function(response) {
                    model.car = response.data;

                    carInfoService.getCarInfo(model.car.make, model.car.model).then(function (response) {
                        model.carInfo = response.data.info;
                    }), function (data, status, header, config) {
                        model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
                    };

                    carImageService.getCarImages(model.car.year, model.car.make, model.car.model, 6).then(function (response) {
                        model.carImages = angular.fromJson(response.data);;
                        console.log(model.carImages.data.images);
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