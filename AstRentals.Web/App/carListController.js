(function (module) {

    var carListController = function (carService, carDropDownService) {

        var model = this;

        model.pageSizeSelection = "10";
        model.searchType = "make";
        model.searchText = "";
        model.term = "";
        model.pages = [];
        var pgx = 0;

        model.getCars = function (term, index, size, type) {
            if (index > model.numberOfPages || index <= 0) {
                return;
            }
            carService.getCars(term, index, size, type).then(function (response) {
                model.term = term;
                model.searchType = type;
                model.pageSizeSelection = size;

                // poulate data from returned results
                console.log(response.data);
                model.cars = response.data.cars;
                model.totalCars = response.data.totalCars;
                model.numberOfPages = response.data.numberOfPages;
                model.currentPage = response.data.currentPage;

                // page calculation for pagination links
                model.numberOfPages < model.pageSizeSelection ? pgx = model.numberOfPages : pgx = size;
                
                model.pages = new Array(pgx);
                for (var i = 1; i <= pgx; i++) {
                    model.pages[i - 1] = i;
                }

            }, function (data, status, header, config) {
                    model.error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
            });
        };

        model.getNumber = function() {

            //Add elements when increasing currentPage
            for (var i = 0; i < model.currentPage - model.pages[model.pages.length - 1]; i++) {
                model.pages.shift();
                model.pages.push(model.currentPage);
            }

            //Add elements when decreasing currentPage
            for (var j = 0; j < model.pages[0] - model.currentPage; j++) {
                model.pages.pop();
                model.pages.unshift(model.currentPage);
            }

            return model.pages;
        };

        // Drop down list functionality

        model.makeDropDownValues = [];
        model.modelDropDownValues = [];
        model.yearDropDownValues = [];

        model.selectedMake = "Ferrari";
        model.selectedYear = "2013";
        model.selectedModel = "Mustang";

        model.ddlInit = function() {
            carDropDownService.getMakeDropDownValues().then(function(response) {
                model.makeDropDownValues = response.data;
            });
            carDropDownService.getModelDropDownValues().then(function(response) {
                model.modelDropDownValues = response.data;
            });
            carDropDownService.getYearDropDownValues().then(function(response) {
                model.yearDropDownValues = response.data;
            });
        };
    };

    module.controller("carListController", carListController);

}(angular.module("app")));