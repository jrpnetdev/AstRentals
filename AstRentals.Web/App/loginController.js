(function (module) {

    var loginController = function ($window, loginService) {

        var model = this;

        // Login page
        model.email = "";
        model.password = "";

        model.loginSubmit = function () {
            loginService.login(model.email, model.password).then(function() {
                $window.location.href = 'http://localhost:50592/Cars/Index';
            });
        }
    };

    module.controller("loginController", loginController);

}(angular.module("app")));