(function (app) {
    'use strict';

    app.controller('loginCtrl', loginCtrl);

    loginCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location', 'apiService'];

    function loginCtrl($scope, membershipService, notificationService, $rootScope, $location, apiService) {
        $scope.pageClass = 'page-login';
        
        $scope.$watch('viewContentLoaded', function () {
            membershipService.removeCredentials();
        });

        $scope.login = login;
        $scope.user = {};

        $scope.isOpen = false;
        $scope.demo = {
            isOpen: false,
            count: 0,
            selectedDirection: 'right'
        };


        function login() {
            membershipService.removeCredentials();
            membershipService.login($scope.user, loginCompleted);
        }

        function loginCompleted(result) {

       
            if (result.data.success) {
                loginCompleted(result);
            }
            else {
                notificationService.displayError('Login failed. Try again.');
            }


        }

        function loginUserCompleted(result) {
            $scope.user = result.data.user;
            membershipService.saveCredentials($scope.user);
            $scope.userData.displayUserInfo();

            if ($scope.user.UserType == "Student") {
                $location.path('/bursify/student/home');
                notificationService.displaySuccess('Welcome back ' + $scope.user.Name + "!");
           } else if ($scope.user.UserType == "Sponsor") {
                $location.path('/bursify/sponsor/home');
              
                notificationService.displaySuccess('Welcome back ' + $scope.user.Name + ".");

            } else if ($scope.user.UserType == "Admin") {
                $location.path('/bursify/admin/home');
                notificationService.displaySuccess('Admin ' + $scope.user.Name);

            }
        }
    }

})(angular.module('common.core'));