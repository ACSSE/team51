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
              
                apiService.get('/api/bursifyuser/GetUser/?email=' + $scope.user.useremail, null, loginUserCompleted, null);

            }
            else {
                notificationService.displayError('Login failed. Try again.');
            }


        }

        function loginUserCompleted(result) {
            $scope.user = result.data;

            if ($scope.user.UserType == "Student") {
                $location.path('/bursify/student/home');
                membershipService.saveCredentials($scope.user);
                $scope.userData.displayUserInfo();
                notificationService.displaySuccess('Hello ' + $scope.user.Name);
              
                $rootScope.User = $scope.user.Name; 
                $rootScope.ThisUserID = $scope.user.ID;

            } else if ($scope.user.UserType == "Sponsor") {
                $location.path('/bursify/sponsor/home');
                membershipService.saveCredentials($scope.user);
                $scope.userData.displayUserInfo();
                notificationService.displaySuccess('Hello ' + $scope.user.Name);
               
                $rootScope.User = $scope.user.Name;
                $rootScope.ThisUserID = $scope.user.ID;



            } else if ($scope.user.UserType == "Admin") {
                $location.path('/bursify/admin/home');
                membershipService.saveCredentials($scope.user);
                $scope.userData.displayUserInfo();
                notificationService.displaySuccess('Hello ' + $scope.user.Name);

                $rootScope.User = $scope.user.Name;
          
            }
        }
    }

})(angular.module('common.core'));