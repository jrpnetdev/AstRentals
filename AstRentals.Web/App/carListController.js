(function (module) {

    var carListController = function (carService) {

        var model = this;

        model.carList = carService.getCarsByPage("Bentley", 1, 10).then(function (response) {
            model.cars = response.data.cars;
            model.totalCars = response.data.totalCars;
            model.numberOfPages = response.data.numberOfPages;
            model.currentPage = response.data.currentPage;
        }), function (data, status, header, config) {
            model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
        };
        
        model.getPage = function (make, page, size) {
            //if (page >= model.numberOfPages || page <= 1) {
            //    return;
            //}
            carService.getCarsByPage(make, page, size)
                .then(function(response) {
                    model.cars = response.data.cars;
                    model.totalCars = response.data.totalCars;
                    model.numberOfPages = response.data.numberOfPages;
                    model.currentPage = response.data.currentPage;
                }), function (data, status, header, config) {
                    model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
            };
        };

        model.getNumber = function (num) {
            return new Array(num);
        }

    };

    module.controller("carListController", carListController);

}(angular.module("app")));