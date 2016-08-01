(function (app) {
    'use strict';

    app.controller('registerCtrl', registerCtrl);

    registerCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location'];

    function registerCtrl($scope, membershipService, notificationService, $rootScope, $location) {
        $scope.pageClass = 'page-login';
        $scope.register = register;
        $scope.user = {};
        $scope.bTypes = ["Student", "Sponsor"];

        function register() {
            if (!$scope.user.terms) {
                notificationService.displayInfo('Please agree to the terms.');
                return; 
            }

            if ($scope.user.usertype == "none") {
                notificationService.displayInfo('Please select a UserType.');
                return;
            }

          
             membershipService.register($scope.user, registerCompleted)
            
        }

        function registerCompleted(result) {
            if (result.data.success) {
                membershipService.saveCredentials($scope.user);
             
                $scope.userData.displayUserInfo();
                if ($scope.user.usertype == "Student") {
                    $location.path('/bursify/student/home');
                    membershipService.saveCredentials($scope.user);
                    $scope.userData.displayUserInfo();
                    notificationService.displaySuccess('Hello ' + $scope.user.Name);

                    $rootScope.User = $scope.user.Name;
                } else if ($scope.user.usertype == "Sponsor") {
                    $location.path('/bursify/sponsor/home');
                    membershipService.saveCredentials($scope.user);
                    $scope.userData.displayUserInfo();
                    notificationService.displaySuccess('Hello ' + $scope.user.Name);

                    $rootScope.User = $scope.user.Name;
                }
               
            }
            else {
                
                notificationService.displayError('Registration failed. Email is already in use.');
                $location.reload();
            }
        }
    }

})(angular.module('common.core'));