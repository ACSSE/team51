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

        $scope.diffDays = {};
        $scope.t = {};
        function sponsorshipLoadCompleted(result) {
            $scope.Sponsorship = result.data;

            var oneDay = 24*60*60*1000;	// hours*minutes*seconds*milliseconds
            var firstDate = new Date();
            var secondDate = new Date($scope.Sponsorship.ClosingDate);
            //$scope.diffDays = $scope.t.Subtract(new Date(1970, 1, 1)).TotalMilliseconds;
 
            var x = Math.abs((firstDate.getTime() - secondDate.getTime()) / (oneDay));
            $scope.diffDays = ~~x;

            var expenses = $scope.Sponsorship.ExpensesCovered;

            $scope.expenses = expenses.split(",");
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
            if ($scope.terms) {
                notificationService.displayError($rootScope.repository.loggedUser.userIden);
                $scope.StudentSponsorshipVM.StudentId = $rootScope.repository.loggedUser.userIden;
                $scope.StudentSponsorshipVM.SponsorshipId = $routeParams.sponsorshipId;
                var today = new Date();
                $scope.StudentSponsorshipVM.ApplicationDate = today;
                $scope.StudentSponsorshipVM.Status = "Pending";
                $scope.StudentSponsorshipVM.SponsorshipOffered = "false";
                apiService.post('/api/student/ApplyForSponsorship', $scope.StudentSponsorshipVM, ApplicationCompleted, ApplicationFailed);

            } else {
                notificationService.displayInfo("You need to agree to the terms and conditions first.")
            }
        }

  

        function ApplicationCompleted() {
            notificationService.displaySuccess("You have successfully applied for this sponsorship.")
        }

        function ApplicationFailed() {
            notificationService.displayInfo("Failed");
        }

    }

})(angular.module('BursifyApp'));

