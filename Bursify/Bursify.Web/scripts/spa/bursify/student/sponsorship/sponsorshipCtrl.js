(function (app) {
    'use strict';

    app.controller('sponsorshipCtrl', sponsorshipCtrl);

    sponsorshipCtrl.$inject = ['$scope', '$rootScope', 'apiService', 'notificationService', '$routeParams'];

    function sponsorshipCtrl($scope, $rootScope, apiService, notificationService, $routeParams) {
        $scope.pageClass = 'page-view-sponsorship';


        $scope.isOpen = false;
        $scope.demo = {
            isOpen: false,
            count: 0,
            selectedDirection: 'left'
        };

        apiService.get('/api/sponsorship/GetSponsorship/?sponsorshipId=' + $routeParams.sponsorshipId, null,
        sponsorshipLoadCompleted,
        sponsorshipLoadFailed);


        function sponsorshipLoadCompleted(result) {    
            $scope.Sponsorship = result.data;
        }

        function sponsorshipLoadFailed() {
            notificationService.displayInfo("Failed");
        }

        $scope.StudentSponsorshipVM = {
           
            "SponsorshipId": "",
            "ApplicationDate": "",
            "Status": "",
            "SponsorshipOffered": ""
        }

        $scope.studentApply = function () {
            notificationService.displayError($rootScope.repository.loggedUser.userIden);
            $scope.StudentSponsorshipVM.StudentId = $rootScope.repository.loggedUser.userIden;
            $scope.StudentSponsorshipVM.SponsorshipId = $routeParams.sponsorshipId;
            var today = new Date();
            $scope.StudentSponsorshipVM.ApplicationDate = today;
            $scope.StudentSponsorshipVM.Status = "Pending";
            $scope.StudentSponsorshipVM.SponsorshipOffered = "false";
            apiService.post('/api/student/ApplyForSponsorship', $scope.StudentSponsorshipVM, ApplicationCompleted, ApplicationFailed);
        }

  

        function ApplicationCompleted() {
            notificationService.displaySuccess("You have successfully applied for this sponsorship.")
        }

        function ApplicationFailed() {
            notificationService.displayInfo("Failed");
        }

    }

})(angular.module('BursifyApp'));

