(function (module) {

    var carHeader = function () {

        return {
            restrict: 'E',
            scope: true,
            templateUrl: '/Cars/Header'
        }
    };

    module.directive("carHeader", carHeader);

}(angular.module("app")));