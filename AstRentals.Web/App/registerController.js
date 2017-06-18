(function (module) {

    var registerController = function($http) {

        var model = this;

        // Registration page

        model.email = "";
        model.password = "";
        model.confirmpassword = "";
        model.acceptedtc = false;
        model.error = "";

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
                .then(function() {
                    $http({
                        url: "/Cars/AddEmailToCookie",
                        method: "POST",
                        headers: { 'Content-Type': "application/x-www-form-urlencoded" },
                        data: "email=" + model.email
                    }).then(function () {
                        window.location = "/Cars/Index";
                    }, function () {
                        model.error = response.data.error_description;
                    });
                }, function (err) {
                    // ToDo Json strigify this
                    model.error = err.data.modelState;
            });
        }

    };

    module.controller("registerController", registerController);

}(angular.module("app")));