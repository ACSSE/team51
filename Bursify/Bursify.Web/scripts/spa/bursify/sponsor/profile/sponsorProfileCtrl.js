(function (app) {
    'use strict';

    app.controller('sponsorProfileCtrl', sponsorProfileCtrl);

    sponsorProfileCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$rootScope'];

    function sponsorProfileCtrl($scope, apiService, notificationService, $rootScope) {
        $scope.pageClass = 'page-view-profile';
        $scope.markselect = {};

        $scope.loadSponsor = function () {
            apiService.get('/api/sponsor/Getsponsor/?userId=' + $rootScope.repository.loggedUser.userIden, null, CompletedSponsor, FailedSponsor);
            apiService.get('/api/bursifyuser/Getuser/?userId=' + $rootScope.repository.loggedUser.userIden, null, CompletedUser, FailedUser);


        }

        $scope.Sponsor = {};
        function CompletedSponsor(result) {
            $scope.Sponsor = result.data;
        }

        function FailedSponsor() {
            notificationService.displayError('Could not your profile.');
        }

        $scope.User = {};
        function CompletedUser(result) {
            $scope.User = result.data;
        }

        function FailedUser() {
            notificationService.displayError('Could not your user.');
        }

    }

})(angular.module('BursifyApp'));

