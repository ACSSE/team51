(function (app) {
    'use strict';

    app.controller('resetCtrl', resetCtrl);

    resetCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location', 'apiService', '$routeParams'];

    function resetCtrl($scope, membershipService, notificationService, $rootScope, $location, apiService, $routeParams) {
        $scope.pageClass = 'page-login';
       


        $scope.Reset = function () {
           notificationService.displayError($routeParams.ems);
            apiService.post('/api/BursifyUser/DecryptEmail/?encryptedEmail=' + $routeParams.ems, null, Completed, Failed);

        }

        function Completed(result) {
            notificationService.displayInfo(result.email);
            if ($scope.Password1 == $scope.Password2) {
                var myEmail = result.email;
                apiService.post('/api/BursifyUser/UpdatePassword/?email=' + $routeParams.ems + "?password=" + $scope.Password1, null, Completed1, Failed);
               
            } else {
                notificationService.displayInfo("Passwords do not match.");
            }
        }

        function Completed1() {
            notificationService.displaySuccess("Password changed.");
            $location.path("#/login");
        }

        function Failed() {
            notificationService.displayError("Failed");
        }
     
    }

})(angular.module('common.core'));