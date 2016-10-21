(function (app) {
    'use strict';

    app.controller('editSponsorshipCtrl', editSponsorshipCtrl);

    editSponsorshipCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$routeParams', '$location'];

    function editSponsorshipCtrl($scope, apiService, notificationService, $routeParams, $location) {
        $scope.pageClass = 'page-view-sponsorship';



        $scope.loadAll = function () {
            apiService.get('/api/sponsorship/GetSponsorship/?sponsorshipId=' + $routeParams.sponsorshipId, null,
          sponsorshipLoadCompleted,
          sponsorshipLoadFailed);
        }

        $scope.Sponsorship = {}

        function sponsorshipLoadCompleted(result) {
            $scope.Sponsorship = result.data;
           
        }

        function sponsorshipLoadFailed() {
            notificationService.displayError("Failed");
        }

        $scope.Edit = function () {
            apiService.post('/api/Sponsorship/SaveSponsorship', $scope.Sponsorship, completed, failed);
        }

        function completed() {
            notificationService.displayInfo("Successfully edited.");
            $location.path('/sponsor/sponsorships');
        }

        function failed() {
            notificationService.displayError("Failed to update.");
        }
        $scope.isOpen = false;
        $scope.demo = {
            isOpen: false,
            count: 0,
            selectedDirection: 'left'
        };


    }

})(angular.module('BursifyApp'));

