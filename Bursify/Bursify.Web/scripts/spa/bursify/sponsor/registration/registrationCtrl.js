(function (app) {
    'use strict';

    app.controller('registrationCtrl', registrationCtrl);

    registrationCtrl.$inject = ['$scope','$timeout', 'apiService', '$location', 'notificationService'];


    function registrationCtrl($scope, $timeout, apiService, $location, notificationService) {
        $scope.pageClass = 'page-view-registration';
        $scope.max = 2;
        $scope.selectedIndex = 0;
        $scope.secondLocked = false;
        $scope.nextTab = function () {
             var index = ($scope.selectedIndex == $scope.max) ? 0 : $scope.selectedIndex + 1;
            $scope.selectedIndex = index;

        };

        $scope.field = null;
        $scope.fields = null;
        $scope.loadFields = function () {
           
            return $timeout(function () {
                $scope.fields = $scope.fields || [
                  { id: 1, name: 'Accounting' },
                  { id: 2, name: 'Aviation' },
                  { id: 3, name: 'Animation' },
                  { id: 4, name: 'Arts & Crafts' },
                  { id: 5, name: 'Automotive' },
                  { id: 6, name: 'Aerospace' },
                  { id: 7, name: 'Banking' }
                ];
            }, 10);
        };

        $scope.create = function () {
            $location.path('/bursify/sponsor/home');
        };

    }


})(angular.module('BursifyApp'));

