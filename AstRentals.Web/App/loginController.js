(function (module) {

    var loginController = function ($window, loginService) {

        var model = this;

        // Login page
        model.email = "";
        model.password = "";
        model.error = "";

        model.loginSubmit = function() {
            loginService.login(model.email, model.password).then(function() {
                var response = loginService.getError();

                if (response === "") {
                    $window.location.href = 'http://localhost:50592/Cars/Index';
                } else {
                    model.error = response.data.error_description;
                }
            });
        };
    };

    module.controller("loginController", loginController);

}(angular.module("app")));