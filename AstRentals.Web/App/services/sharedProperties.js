(function (module) {

    var sharedProperties = function () {

        var carId = 0;

        return {
            getCarId: function () {
                return carId;
            },
            setCarId: function (value) {
                carId = value;
            }
        }
    };

    module.factory("sharedProperties", sharedProperties);

}(angular.module("app")));