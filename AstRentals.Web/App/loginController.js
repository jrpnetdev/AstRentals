(function (module) {

    var loginController = function ($window, loginService, $http) {

        var model = this;

        // Login page
        model.email = "";
        model.password = "";
        model.error = "";

        model.loginSubmit = function() {
            loginService.login(model.email, model.password).then(function() {
                var response = loginService.getError();

                if (response === "") {

                    $http({
                        url: "/Cars/AddEmailToTempData",
                        method: "POST",
                        headers: { 'Content-Type': "application/x-www-form-urlencoded" },
                        data: "email=" + model.email
                    }).then(function() {
                        $window.location.href = "http://localhost:50592/Cars/Index";
                    }, function () {
                        model.error = response.data.error_description;
                });
                } else {
                    model.error = response.data.error_description;
                }
            });
        };
    };

    module.controller("loginController", loginController);

}(angular.module("app")));