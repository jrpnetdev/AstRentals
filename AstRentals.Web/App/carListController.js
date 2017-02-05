(function (module) {

    var carListController = function ($http, $scope, carService) {

        var model = this;

        model.cars = [];

        model.cars = carService.getCars();

    };

    module.controller("carListController", carListController);

}(angular.module("app")));