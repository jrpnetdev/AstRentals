(function (module) {

    var myAccountFavouritesController = function ($http) {

        var model = this;

        model.removeFavourite = function (e) {

            console.log(e);

            var id = $(e.currentTarget).attr("data-id");
            var email = $(e.currentTarget).attr("data-email");

            $http.delete("http://localhost:50604/api/favourites?id=" + id + "&email=" + email).then(function(response) {
                if (response.data === 1) {
                    window.location = "/MyAccount/Favourites";
                }
            });
        };
    };

    module.controller("myAccountFavouritesController", myAccountFavouritesController);

}(angular.module("app")));