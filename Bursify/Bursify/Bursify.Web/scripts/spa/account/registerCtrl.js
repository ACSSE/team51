(function (app) {
    'use strict';

    app.controller('registerCtrl', registerCtrl);

    registerCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location'];

    function registerCtrl($scope, membershipService, notificationService, $rootScope, $location) {
        $scope.pageClass = 'page-login';
        $scope.register = register;
        $scope.user = {};

        function register() {
            membershipService.register($scope.user, registerCompleted)
        }

        function registerCompleted(result) {
            if (result.data.success) {
                membershipService.saveCredentials($scope.user);
                notificationService.displaySuccess('Hello ' + $scope.user.username);
                
                notificationService.displaySuccess('Type ' + $scope.user.usertype);

                if ($scope.user.usertype == "Sponsor") {
                    $location.path('/bursify/sponsor/home');
                }
                
              
               
            }
            else {
                notificationService.displayError('Registration failed. Try again.');
            }
        }
    }

})(angular.module('common.core'));