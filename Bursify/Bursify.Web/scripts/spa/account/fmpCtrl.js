(function (app) {
    'use strict';

    app.controller('fmpCtrl', fmpCtrl);

    fmpCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location', 'apiService'];

    function fmpCtrl($scope, membershipService, notificationService, $rootScope, $location, apiService) {
        $scope.pageClass = 'page-login';

        $scope.reset = function () {
           
            apiService.post('/api/BursifyUser/ResetPassword/?email=' +  $scope.user.useremail,null, Completed, Failed);
        }

        function Completed(result) {
            if (result) {
                notificationService.displaySuccess("Password reset email has been sent.");
            } else {
                notificationService.displayInfo("Email does not exist.");
             }
        }

        function Failed() {
            notificationService.displayError("Failed");
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