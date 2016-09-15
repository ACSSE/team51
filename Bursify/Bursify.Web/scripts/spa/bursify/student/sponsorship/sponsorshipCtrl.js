(function (app) {
    'use strict';

    app.controller('sponsorshipCtrl', sponsorshipCtrl);

    sponsorshipCtrl.$inject = ['$scope', '$rootScope', 'apiService', 'notificationService', '$routeParams', '$mdDialog', '$mdMedia' , '$mdBottomSheet', '$mdToast'];

    function sponsorshipCtrl($scope, $rootScope, apiService, notificationService, $routeParams, $mdDialog, $mdMedia, $mdBottomSheet, $mdToast) {
        $scope.pageClass = 'page-view-sponsorship';
      
        this.isOpen = false;

 
        $scope.printer = function () {
           
            window.print();
        }


        $scope.isOpen = false;
        $scope.demo = {
            isOpen: false,
            count: 0,
            selectedDirection: 'left'
        };

        apiService.get('/api/sponsorship/GetSponsorship/?sponsorshipId=' + $routeParams.sponsorshipId, null,
        sponsorshipLoadCompleted,
        sponsorshipLoadFailed);
        apiService.get('/api/sponsorship/GetSimilar/?sponsorshipId=' + $routeParams.sponsorshipId, null,
        similarLoadCompleted,
        similarLoadFailed);

        $scope.diffDays = {};

        $scope.Similar = {};
        function similarLoadCompleted(result) {
            $scope.Similar = result.data;
        }

        function similarLoadFailed() {
            notificationService.displayError("Could not load similar.");
         }
       
        $scope.myFields = {};
        function sponsorshipLoadCompleted(result) {
            $scope.Sponsorship = result.data;

            var oneDay = 24*60*60*1000;	// hours*minutes*seconds*milliseconds
            var firstDate = new Date();
            var secondDate = new Date($scope.Sponsorship.ClosingDate);
           
            var x = Math.abs((firstDate.getTime() - secondDate.getTime()) / (oneDay));
            $scope.diffDays = ~~x;

            var expenses = $scope.Sponsorship.ExpensesCovered;

            $scope.expenses = expenses.split(",");
            $scope.expenses.pop();
            $scope.Sponsorship.StudyFields = $scope.Sponsorship.StudyFields.replace(",", " - - ");
            apiService.get('/api/student/Getstudent/?studentId=' + $rootScope.repository.loggedUser.userIden, null,
      studentLoadCompleted,
      studentLoadFailed);
        }

        $scope.Student = {};
        function studentLoadCompleted(result) {
            $scope.Student = result.data;
        }

        function studentLoadFailed() {
            notificationService.displayError('Could not load student.');
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
            $scope.StudentSponsorshipVM.StudentId = $rootScope.repository.loggedUser.userIden;
            $scope.StudentSponsorshipVM.SponsorshipId = $routeParams.sponsorshipId;
            var today = new Date();
            $scope.StudentSponsorshipVM.ApplicationDate = today;
            $scope.StudentSponsorshipVM.Status = "Pending";
            $scope.StudentSponsorshipVM.SponsorshipOffered = "false";
            apiService.post('/api/student/ApplyForSponsorship', $scope.StudentSponsorshipVM, ApplicationCompleted, ApplicationFailed);
        }

  

        function ApplicationCompleted() {
            notificationService.displaySuccess("You have successfully applied for this sponsorship.");
        }

        function ApplicationFailed() {
            notificationService.displayInfo("Failed");
        }


    }

})(angular.module('BursifyApp'));

