(function (module) {

    var wishlistController = function ($scope) {


        $scope.addToWishlist = function (id) {
            console.log(id);
        }

        $scope.test = function (e) {
            console.log($(e.currentTarget).attr("data-id"));
        }

    };

    module.controller("wishlistController", wishlistController);

}(angular.module("app")));