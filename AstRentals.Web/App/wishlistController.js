(function (module) {

    var wishlistController = function ($scope, sharedProperties) {


        $scope.addToWishlist = function () {
            var id = sharedProperties.getCarId();
            console.log(id);
        }

    };

    module.controller("wishlistController", wishlistController);

}(angular.module("app")));