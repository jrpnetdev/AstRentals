(function (module) {

    var favouriteController = function ($scope, $rootScope, $http, toastr) {

        $scope.addToFavourites = function (e) {

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
                        toastr.error("Please log in to save favourites");
                    }
                    $rootScope.$broadcast("updatedFavourites", email);
                    toastr.success("Successfully added to Favourites");
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