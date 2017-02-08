(function (module) {

    var categories = function () {

        return {
            templateUrl: "../../App/directives/categories.html",
            scope: true
        };
    };

    module.directive("categories", categories);

}(angular.module("app")));