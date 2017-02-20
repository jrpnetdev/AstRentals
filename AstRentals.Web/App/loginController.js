(function (module) {

    var loginController = function($http) {

        var model = this;

        // Login page
        model.loginemail = "";
        model.loginpassword = "";

        model.loginSubmit = function () {
        }
    };

    module.controller("loginController", loginController);

}(angular.module("app")));