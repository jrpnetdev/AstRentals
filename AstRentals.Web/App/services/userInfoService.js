(function (module) {


    var userInfoService = function($http) {

        var error = "";

        var setEmail = function(email) {
            return $http({
                url: "http://localhost:50604/api/UserInfo",
                method: "POST",
                data: "email=" + email
            }).then(function () {

            },
            function (data, status, header, config) {
                error = "error :" + data + "   status:" + status + "   header:" + header + "   config:" + config;
            });

        };

        var getEmail = function () {
            return $http.get("http://localhost:50604/api/UserInfo");
        };

        return {
            setEmail: setEmail,
            getEmail: getEmail
        };

    };

    module.factory("userInfoService", userInfoService);

}(angular.module("app")));