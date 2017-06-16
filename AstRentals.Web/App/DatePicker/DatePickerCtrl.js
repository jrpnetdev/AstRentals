angular.module("app").controller("DatepickerCtrl", function ($rootScope, $scope) {

    $scope.today = function () {
        $scope.dt = new Date();
    };

    $scope.today();

    $scope.minDate = -1;

    $scope.start = null;
    $scope.end = null;

    $scope.dateOptions = {
        formatYear: "yy",
        startingDay: 1
    };

    $scope.getDayClass = function (date, mode) {
        if (mode === "day") {
            var calDay = new Date(date).setHours(0, 0, 0, 0);
            for (var i = 0; i < $scope.events.length; i++) {
                var eventDate = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                if (calDay === eventDate) {

                    return $scope.events[i].status;
                }
            }
        }

        return "";
    };

    $scope.$watch("dt", function () {

        if (!$scope.dt) {
            return;
        }

        if (!$scope.start || $scope.start > $scope.dt) {
            $scope.start = $scope.dt;

        } else {
            $scope.end = $scope.dt;

        }

        $scope.events = [];

        function daydiff(first, second) {
            return Math.round((second - first) / (1000 * 60 * 60 * 24));
        }

        if ($scope.start) {
            $scope.events.push({ date: $scope.start, status: "full", label: "start" });
        }
        if ($scope.end) {
            $scope.events.push({ date: $scope.end, status: "full", label: "end" });

            var tempDate;
            for (var i = 1; i <= daydiff($scope.start, $scope.end); i++) {
                tempDate = new Date();
                tempDate.setDate($scope.start.getDate() + i);
                $scope.events.push({ date: tempDate, status: "partially" });

            }

        }

        //console.log("event start ", $scope.start);
        //console.log("event end ", $scope.end);

        $rootScope.$broadcast("selectedDates", $scope.start, $scope.end);

        $scope.dt = null;

    });

});