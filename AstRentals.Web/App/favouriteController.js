(function (module) {

    var favouriteController = function ($scope, $http) {


        $scope.addToFavouritesDetails = function (id) {
            console.log(id);
        }

        $scope.addToFavouritesIndex = function (e) {
            //console.log($(e.currentTarget).attr("data-id"));

            var id = $(e.currentTarget).attr("data-id");

            $http.post("http://localhost:50604/api/favourites", id).then(
                // success callback
                function (response) {
                    console.log("success - saved");
                },
                // error callback
                function (response) {
                    console.log("error - saving");
                }
            );

        }

    };

    module.controller("favouriteController", favouriteController);

}(angular.module("app")));