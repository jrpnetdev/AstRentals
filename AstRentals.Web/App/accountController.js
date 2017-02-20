﻿(function (module) {

    var accountController = function($http) {

        var model = this;

        // Registration page

        model.email = "";
        model.password = "";
        model.confirmpassword = "";
        model.acceptedtc = false;
        model.error = "";
        model.success = "";

        model.registerUser = function () {
            if (model.acceptedtc === false) {
                model.error = "Terms & Conditions have not been accepted. Please check the box.";
                return;
            }
            if (model.password !== model.confirmpassword) {
                model.error = "The Passwords do not match.";
                return;
            }

            $http.post('http://localhost:50604/api/Account/Register',
                    { email: model.email, password: model.password, confirmpassword: model.confirmpassword })
                .then(function(response) {
                    model.success = response.data;
                }, function (err) {
                    model.error = err.data.modelState;
                    // ToDo Json strigify this
                    console.log(err.data.modelState);
            });
        }

    };

    module.controller("accountController", accountController);

}(angular.module("app")));