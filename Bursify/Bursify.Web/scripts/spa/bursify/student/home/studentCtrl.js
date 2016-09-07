(function (app) {
    'use strict';

    app.controller('studentCtrl', studentCtrl);

    studentCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$rootScope'];

    function studentCtrl($scope, apiService, notificationService, $rootScope) {
        $scope.pageClass = 'page-home-student';
        $scope.sortType     = 'name'; // set the default sort type
        $scope.sortReverse  = false; 

        $scope.isOpen = false;
        $scope.demo = {
            isOpen: false,
            count: 0,
            selectedDirection: 'left'
        };


        $scope.loadSponsorships = function () {
            apiService.get('/api/sponsorship/GetAllSponsorships', null, CompletedSponsorship, FailedSponsorship);
        }
       
        function CompletedSponsorship(result) {
            $scope.Sponsorships = result.data;
            loadReccommended();
        }

        function loadReccommended() {
            apiService.get('/api/student/getsponsorshipsuggestions/?studentId=' + $rootScope.repository.loggedUser.userIden, null, reccoCompleted, reccoFailed);
        }

        $scope.Recco = {};
        function reccoCompleted(result) {
            $scope.Recco = result.data;
        }

        function reccoFailed() {
            notificationService.displayInfo('Unable to load reccommended sponsorships.');
        }

        function FailedSponsorship() {
            notificationService.displayInfo('Unable to load sponsorships.');
        }


    }

})(angular.module('BursifyApp'));

