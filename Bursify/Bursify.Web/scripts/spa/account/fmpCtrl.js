(function (app) {
    'use strict';

    app.controller('fmpCtrl', fmpCtrl);

    fmpCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location', 'apiService'];

    function fmpCtrl($scope, membershipService, notificationService, $rootScope, $location, apiService) {
        $scope.pageClass = 'page-login';


        function retrievePassword() {
            membershipService.removeCredentials();
            membershipService.login($scope.email, loginCompleted);
        }

        function loginCompleted(result) {
            if (result.data.success) {
                loginUserCompleted(result);
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
                $location.path('/student/home');
                notificationService.displaySuccess('Welcome back ' + $scope.user.Name + " !");
           } else if ($scope.user.UserType == "Sponsor") {
                $location.path('/sponsor/home');
              
                notificationService.displaySuccess('Welcome back ' + $scope.user.Name + ".");

            } else if ($scope.user.UserType == "Admin") {
                $location.path('/admin/home');
                notificationService.displaySuccess('Welcome Admin.');
         }
       }
    }

})(angular.module('common.core'));