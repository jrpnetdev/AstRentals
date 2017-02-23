(function (module) {

    var loginController = function(loginService) {

        var model = this;

        // Login page
        model.email = "";
        model.password = "";

        model.loginSubmit = function () {
            loginService.login(model.email, model.password).then(function() {
                // todo: redirect to car list
            });
        }
    };

    module.controller("loginController", loginController);

}(angular.module("app")));