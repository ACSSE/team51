(function (app) {
    'use strict';

    app.controller('viewStudentCtrl', viewStudentCtrl);

    viewStudentCtrl.$inject = ['$scope', '$rootScope', '$routeParams', '$timeout', 'apiService', '$location', 'notificationService', '$mdDialog', '$mdMedia'];


    function viewStudentCtrl($scope, $rootScope, $routeParams, $timeout, apiService, $location, notificationService, $mdDialog, $mdMedia) {
        $scope.pageClass = 'page-view-sponsorship';
        $scope.max = 2;
        $scope.selectedIndex = 0;
        $scope.secondLocked = false;
        $scope.nextTab = function () {
            var index = ($scope.selectedIndex == $scope.max) ? 0 : $scope.selectedIndex + 1;
            $scope.selectedIndex = index;

        };
        $scope.Student = {};

        $scope.loadStudent = function () {
          
            apiService.get('/api/bursifyUser/getuser/?userId=' + $routeParams.StudentId, null, profileLoaded, profileLoadFailed);
        }
       
        function profileLoaded(result) {
           
            $scope.Student = result.data;
        }


        function profileLoadFailed() {
            notificationService.displayError('Error');
        }

    }


})(angular.module('BursifyApp'));

