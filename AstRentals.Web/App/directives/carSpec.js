(function (module) {

    var carSpec = function () {

        return {
            templateUrl: "../../App/directives/carSpec.html",
            scope: true
        };
    };

    module.directive("carSpec", carSpec);

}(angular.module("app")));