(function (app) {
    'use strict';

    app.controller('studentCtrl', studentCtrl);

    studentCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function studentCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home-student';
       

        $scope.isOpen = false;
        $scope.demo = {
            isOpen: false,
            count: 0,
            selectedDirection: 'left'
        };

        apiService.get('/api/sponsorship/GetAllSponsorships', null, CompletedSponsorship, FailedSponsorship);

        function CompletedSponsorship(result) {
            $scope.Sponsorships = result.data;
        }

        function FailedSponsorship() {
            notificationService.displayInfo('Unable to load students.');
        }


    }

})(angular.module('BursifyApp'));

