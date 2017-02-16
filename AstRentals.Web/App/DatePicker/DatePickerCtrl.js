angular.module('app').controller('DatepickerCtrl', function ($scope) {
    $scope.today = function () {
        $scope.dt = new Date();
    };
    $scope.today();

    $scope.minDate = -1;

    $scope.start = null;
    $scope.end = null;



    $scope.dateOptions = {
        formatYear: 'yy',
        startingDay: 1
    };

    $scope.getDayClass = function (date, mode) {
        if (mode === 'day') {
            var calDay = new Date(date).setHours(0, 0, 0, 0);
            for (var i = 0; i < $scope.events.length; i++) {
                var eventDate = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                if (calDay === eventDate) {

                    return $scope.events[i].status;
                }
            }
        }
        //console.log('event start', $scope.start);
        //console.log('event end', $scope.end);
        console.log('digest');


        return '';
    };

    $scope.$watch('dt', function () {


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
            $scope.events.push({ date: $scope.start, status: 'full', label: 'start' })
        }
        if ($scope.end) {
            $scope.events.push({ date: $scope.end, status: 'full', label: 'end' })

            var tempDate;
            for (var i = 1; i <= daydiff($scope.start, $scope.end) ; i++) {
                tempDate = new Date();
                tempDate.setDate($scope.start.getDate() + i);
                $scope.events.push({ date: tempDate, status: 'partially' })

            }

        }

        $scope.dt = null;

    });

});