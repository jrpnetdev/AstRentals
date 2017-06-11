(function (module) {

    var favouriteController = function ($scope, $http) {


        $scope.addToFavouritesDetails = function(id) {
            console.log(id);
        };

        $scope.addToFavouritesIndex = function(e) {
            //console.log($(e.currentTarget).attr("data-id"));

            var id = $(e.currentTarget).attr("data-id");
            var email = $(e.currentTarget).attr("data-email");

            $http({
                url: "http://localhost:50604/api/favourites",
                method: "POST",
                headers: { 'Content-Type': "application/x-www-form-urlencoded" },
                data: "carid=" + id + "&email=" + email
            }).then(
                // success callback
                function(response) {
                    if (response.data === 0) {
                        // todo: pop up 'please log in to save favourites'
                    }
                },
                // error callback
                function(data, status, header, config) {
                    console.log(
                        "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config);
                });
        };

    };

    module.controller("favouriteController", favouriteController);

}(angular.module("app")));