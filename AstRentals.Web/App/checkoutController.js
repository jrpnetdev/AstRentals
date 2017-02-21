(function (module) {

    var checkoutController = function () {

        var model = this;

        model.confirm = function (data) {
            console.log(data);
            var currentTime = new Date();
            window.location = '/Cars/Confirmation?carid=' + data.Car.Id + '&colour=' + data.Colour + '&features=' + data.Features + '&cover=' + data.Cover + '&startdate=' + currentTime + '&enddate=' + currentTime;
        };

    }

    module.controller("checkoutController", checkoutController);

}(angular.module("app")));