(function (app) {
    'use strict';

    app.controller('loginCtrl', loginCtrl);

    loginCtrl.$inject = ['$scope', 'membershipService', 'notificationService','$rootScope', '$location', 'apiService'];

    function loginCtrl($scope, membershipService, notificationService, $rootScope, $location, apiService) {
        $scope.pageClass = 'page-login';
        $scope.login = login;
        $scope.user = {};

        function login() {
            membershipService.login($scope.user, loginCompleted)
        }

        function loginCompleted(result) {
            if (result.data.success) {
                membershipService.saveCredentials($scope.user);
                $scope.userData.displayUserInfo();

                apiService.get('/api/bursifyuser/user/?email=' + $scope.user.useremail, null,loginUserCompleted,null);
                if ($rootScope.previousState)
                    $location.path($rootScope.previousState);
                else
                    $location.path('/');
          
            }
            else {
                notificationService.displayError('Login failed. Try again.');
            }
        }

        function loginUserCompleted(result) {
            $scope.user = result.data;
            if ($scope.user.UserType == "Student") {
                $location.path('/bursify/student/home');
                notificationService.displaySuccess('Hello ' + $scope.user.Name );
            } else if ($scope.user.UserType == "Sponsor"){
                $location.path('/bursify/sponsor/home');
            } else if ($scope.user.UserType == "Admin") {
                $location.path('/bursify/admin/home');
            }
        }
    }

})(angular.module('common.core'));