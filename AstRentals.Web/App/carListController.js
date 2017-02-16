﻿(function (module) {

    var carListController = function (carService, carSearchService) {

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
            if (page > model.numberOfPages || page < 1) {
                return;
            }
            carService.getCarsByPage(make, page, size).then(function(response) {
                    model.cars = response.data.cars;
                    model.totalCars = response.data.totalCars;
                    model.numberOfPages = response.data.numberOfPages;
                    model.currentPage = response.data.currentPage;
                }), function (data, status, header, config) {
                    model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
            };
        };

        model.search = function(searchtext) {
            carSearchService.getSearchResults(searchtext)
                .then(function(response) {
                    model.cars = response.data.cars;
                    model.totalCars = response.data.totalCars;
                    model.numberOfPages = response.data.numberOfPages;
                    model.currentPage = response.data.currentPage;
                }), function(data, status, header, config) {
                model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
            };
        }


        model.addToWishlist = function (id) {
            console.log(id);
        }

        model.getNumber = function (num) {
            if (num > 10) { num = 10 }
            return new Array(num);
        }

    };

    module.controller("carListController", carListController);

}(angular.module("app")));