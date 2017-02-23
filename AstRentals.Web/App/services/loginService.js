(function (module) {


    var loginService = function ($http) {

        var isloggedin = false;
        var token = "";

        var login = function(username, password) {
            return $http({
                url: 'http://localhost:50604/Token',
                method: 'POST',
                headers: {'Content-Type': 'application/x-www-form-urlencoded'},
                data: "userName=" + username + "&password=" + password + "&grant_type=password"
            }).then(function (data) {
                isloggedin = true;
                token = data.data.access_token;
            }, function () {
                isloggedin = false;
                token = "";
            });

        }

        var logout = function () {
            isloggedin = false;
            token = "";
            return;
        }

        var userIsloggedin = function () {
            return isloggedin;
        }

        var userToken = function () {
            return token;
        }

        return {
            login: login,
            logout: logout,
            userIsloggedin: userIsloggedin,
            userToken: userToken
        }

    }

    module.factory("loginService", loginService);

}(angular.module("app")));