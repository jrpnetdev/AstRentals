(function (module) {

    var favouriteDetailsController = function ($scope, $rootScope, $http, toastr) {

        var model = this;

        model.favourites = [];
        model.favouritesCount = 0; 

        model.getFavourites = function (email) {

            if (email !== "null" || email !== undefined) {
                $http.get("http://localhost:50604/api/favourites?email=" + email).then(function (response) {
                    model.favouritesCount = response.data.length;
                    model.favourites = response.data;
                });
            }

        };

        model.removeFavourite = function(e) {
            var id = $(e.currentTarget).attr("data-id");
            var email = $(e.currentTarget).attr("data-email");

            $http.delete("http://localhost:50604/api/favourites?id=" + id + "&email=" + email).then(function(response) {
                if (response.data === 1) {
                    toastr.success("Favourite successfully removed");
                    model.getFavourites(email);
                }
            });
        };

        $rootScope.$on("updatedFavourites", function (event, email) { model.getFavourites(email); });

    };

    module.controller("favouriteDetailsController", favouriteDetailsController);

}(angular.module("app")));