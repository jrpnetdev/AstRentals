(function (module) {

    var favouriteController = function ($scope, $http) {

        $scope.addToFavourites = function(e) {

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
                        // todo: toastr 'please log in to save favourites'
                    } 

                    // todo: toastr notification 'successfully added favourites'
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