(function (module) {

    var carDetailsController = function (carService) {

        var model = this;
        
        model.getCar = function (id) {

            carService.getCarById(id)
                .then(function(response) {
                    model.car = response.data;
                    console.log(model.car);
                    console.log(id);
                }), function (data, status, header, config) {
                    model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
            };
        };

    };

    module.controller("carDetailsController", carDetailsController);

}(angular.module("app")));