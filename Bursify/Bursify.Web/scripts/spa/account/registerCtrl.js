(function (app) {
    'use strict';

    app.controller('registerCtrl', registerCtrl);

    registerCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location', '$route'];

    function registerCtrl($scope, membershipService, notificationService, $rootScope, $location, $route) {
        $scope.pageClass = 'page-login';
        $scope.register = register;
        $scope.user = {};
       
        $scope.preload = function () {
            notificationService.displayError('ey');
            $scope.userData.isUserLoggedIn = false;
            membershipService.removeCredentials();
        }

        function register() {
            if (!$scope.user.terms) {
                notificationService.displayInfo('Please agree to the terms.');
                return;
            }

          //  $location.path('/student/registration');
         //  notificationService.displayInfo($scope.user.usertype);

           membershipService.register($scope.user, registerCompleted)

        }

        $scope.inputType = 'password';

        // Hide & show password function
        $scope.hideShowPassword = function () {
            if ($scope.inputType == 'password')
                $scope.inputType = 'text';
            else
                $scope.inputType = 'password';
        };

        function registerCompleted(result) {
           
            if (result.data.success) {

                if ($scope.user.usertype == "Student") { 
                    $scope.user = result.data.user;
                    membershipService.saveCredentials($scope.user);
                   
                    $location.path('/student/registration');
                } else if ($scope.user.usertype == "Sponsor") {
                    $scope.user = result.data.user;
                    membershipService.saveCredentials($scope.user);
                  
                    $location.path('/sponsor/registration');
                }

            }
            else {
                notificationService.displayError('Registration failed. Email is already in use.');
               
            }
        }
    }

})(angular.module('common.core'));