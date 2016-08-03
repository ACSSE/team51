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

<<<<<<< HEAD

=======
>>>>>>> 64c3c32a16b391f83495a50a99aa05d0733809b2
        function login() {
            membershipService.removeCredentials();
            membershipService.login($scope.user, loginCompleted)
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
             
<<<<<<< HEAD
             

=======
>>>>>>> 64c3c32a16b391f83495a50a99aa05d0733809b2
            } else if ($scope.user.UserType == "Sponsor") {
                $location.path('/bursify/sponsor/home');
                membershipService.saveCredentials($scope.user);
                $scope.userData.displayUserInfo();
                notificationService.displaySuccess('Hello ' + $scope.user.Name);
<<<<<<< HEAD

=======
>>>>>>> 64c3c32a16b391f83495a50a99aa05d0733809b2
                $rootScope.User = $scope.user.Name;

            } else if ($scope.user.UserType == "Admin") {
                $location.path('/bursify/admin/home');
                membershipService.saveCredentials($scope.user);
                $scope.userData.displayUserInfo();
                notificationService.displaySuccess('Hello ' + $scope.user.Name);
<<<<<<< HEAD

                $rootScope.User = $scope.user.Name;
          
=======
                $rootScope.User = $scope.user.Name;          
>>>>>>> 64c3c32a16b391f83495a50a99aa05d0733809b2
            }
        }
    }

})(angular.module('common.core'));