(function (module) {

    var checkoutController = function ($http) {

        var model = this;

        model.confirm = function (data) {

            var days = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
            var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

            // Date conversion Json Date - DateTime
            function getDateFormat(date) {
                var dayofweek = days[date.getDay()];
                var month = months[date.getMonth()];
                var day = date.getDate();
                var year = date.getFullYear();
                return dayofweek + " " + day + " " + month + ", " + year;
            }

            var startDate = getDateFormat(new Date(parseInt(data.StartDate.substr(6)))); 
            var endDate = getDateFormat(new Date(parseInt(data.EndDate.substr(6))));


            $http({
                url: "http://localhost:50604/api/order",
                method: "POST",
                headers: { 'Content-Type': "application/x-www-form-urlencoded" },
                data: "carid=" + data.CarId + "&colour=" + data.Colour + "&features=" + data.Features + "&cover=" + data.Cover + "&startDate="
                        + startDate + "&endDate=" + endDate + "&RentalCost=" + data.RentalCost + "&coverCost=" + data.CoverCost + "&totalPrice="
                        + data.TotalPrice + "&numberOfDays=" + data.NumberOfDays + "&emailAddress=" + data.EmailAddress
            }).then(function () {
                window.location = "/Cars/Confirmation";
            });

        };
    };

    module.controller("checkoutController", checkoutController);

}(angular.module("app")));