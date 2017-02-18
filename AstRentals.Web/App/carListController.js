(function (module) {

    var carListController = function (carService, carSearchService) {

        var model = this;

        model.searchType = "make";
        model.searchText = "";
        model.pages = [];
        var pgx = 0;
        
        model.getPageMake = function (make, index, size) {
            if (index > model.numberOfPages || index <= 0) {
                return;
            }
            carService.getCarsByPage(make, index, size).then(function (response) {
                    model.searchType = "make";
                    model.cars = response.data.cars;
                    model.totalCars = response.data.totalCars;
                    model.numberOfPages = response.data.numberOfPages;
                    model.currentPage = response.data.currentPage;
                    
                    (model.numberOfPages < 10) ? pgx = model.numberOfPages : pgx = size;
                    
                    model.pages = new Array(pgx);
                    for (var i = 1; i <= pgx; i++) {
                        model.pages[i - 1] = i;
                    }

                }), function (data, status, header, config) {
                    model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
            };
        };

        model.getPageYear = function (year, index, size) {
            if (index > model.numberOfPages || index <= 0) {
                return;
            }
            carService.getCarsByYear(year, index, size).then(function (response) {
                model.searchType = "year";
                model.cars = response.data.cars;
                model.totalCars = response.data.totalCars;
                model.numberOfPages = response.data.numberOfPages;
                model.currentPage = response.data.currentPage;

                (model.numberOfPages < 10) ? pgx = model.numberOfPages : pgx = size;

                model.pages = new Array(pgx);
                for (var i = 1; i <= pgx; i++) {
                    model.pages[i - 1] = i;
                }

            }), function (data, status, header, config) {
                model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
            };
        };

        model.search = function (stext, index, size) {
            if (index > model.numberOfPages || index <= 0) {
                return;
            }
            model.searchText = stext;
            carSearchService.getSearchResults(model.searchText, index, 10)
                .then(function (response) {
                    model.searchType = "search";
                    model.cars = response.data.cars;
                    model.totalCars = response.data.totalCars;
                    model.numberOfPages = response.data.numberOfPages;
                    model.currentPage = response.data.currentPage;

                    (model.numberOfPages < 10) ? pgx = model.numberOfPages : pgx = size;

                    model.pages = new Array(pgx);
                    for (var i = 1; i <= pgx; i++) {
                        model.pages[i - 1] = i;
                    }

                }), function(data, status, header, config) {
                model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
            };
        }

        model.getNumber = function () {

            //Add elements when increasing currentPage
            for (var i = 0; i < model.currentPage - model.pages[model.pages.length - 1]; i++) {
                model.pages.shift();
                model.pages.push(model.currentPage);
            }

            //Add elements when decreasing currentPage
            for (var i = 0; i < model.pages[0] - model.currentPage; i++) {
                model.pages.pop();
                model.pages.unshift(model.currentPage);
            }

            return model.pages;
        }

    };

    module.controller("carListController", carListController);

}(angular.module("app")));