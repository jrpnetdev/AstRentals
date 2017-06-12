(function (module) {

    var favouriteDetailsController = function ( $http) {

        var model = this;

        model.favourites = [];
        model.favouritesCount = 0; 

        model.getFavourites = function (email) {

            if (email !== "null" || email !== undefined) {
                $http.get("http://localhost:50604/api/favourites?email=" + email).then(function (response) {
                    model.favouritesCount = response.data.length;
                    model.favourites = JSON.stringify(response.data);
                });
            }

        };

    };

    module.controller("favouriteDetailsController", favouriteDetailsController);

}(angular.module("app")));