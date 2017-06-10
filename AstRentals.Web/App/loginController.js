(function (module) {

    var loginController = function ($window, loginService, userInfoService) {

        var model = this;

        // Login page
        model.email = "";
        model.password = "";
        model.error = "";
        model.test = "";

        model.loginSubmit = function() {
            loginService.login(model.email, model.password).then(function() {
                var response = loginService.getError();

                if (response === "") {
                    userInfoService.setEmail(model.email).then(function() {
                        console.log("userInfoService.setEmail Success");
                    });

                    userInfoService.getEmail().then(function (response) {
                        console.log(response.data);
                    });

                    //$window.location.href = "http://localhost:50592/Cars/Index";
                } else {
                    model.error = response.data.error_description;
                }
            });
        };
    };

    module.controller("loginController", loginController);

}(angular.module("app")));