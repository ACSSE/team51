(function (app) {
    'use strict';

    app.controller('sponsorshipCtrl', sponsorshipCtrl);

    sponsorshipCtrl.$inject = ['$scope', '$rootScope', 'apiService', 'notificationService', '$routeParams', '$mdDialog', '$mdMedia' , '$mdBottomSheet', '$mdToast'];

    function sponsorshipCtrl($scope, $rootScope, apiService, notificationService, $routeParams, $mdDialog, $mdMedia, $mdBottomSheet, $mdToast) {
        $scope.pageClass = 'page-view-sponsorship';
      
        this.isOpen = false;

        function doesNotQ() {
            var useFullScreen = ($mdMedia('sm') || $mdMedia('xs')) && $scope.customFullscreen;
            $mdDialog.show({
                controller: 'sponsorshipCtrl',
                templateUrl: '/Scripts/spa/bursify/student/sponsorship/dialog.tmpl.html',
                parent: angular.element(document.body),
              
                clickOutsideToClose: true
            })
            .then(function (answer) {
                $mdDialog.hide();
            }, function () {
                $scope.status = 'You cancelled the dialog.';
            });

       
            $scope.$watch(function () {
                return $mdMedia('xs') || $mdMedia('sm');
            }, function (wantsFullScreen) {
                $scope.customFullscreen = (wantsFullScreen === true);
            });
        };
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
       
        function sponsorshipLoadCompleted(result) {
            $scope.Sponsorship = result.data;

            var oneDay = 24*60*60*1000;	// hours*minutes*seconds*milliseconds
            var firstDate = new Date();
            var secondDate = new Date($scope.Sponsorship.ClosingDate);
           
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
                
                apiService.get('/api/student/getstudent/?studentId=' + $rootScope.repository.loggedUser.userIden, null, doesQ, studentFailed);
        
            } else {
                notificationService.displayInfo("You need to agree to the terms and conditions first.")
            }
        }

        $scope.Student = {}
        function doesQ(result) {
            $scope.Student = result.data;
            var qualifies = $scope.Sponsorship.AverageMarkRequired <= $scope.Student.AverageMark;
            if(qualifies){
                isValid();
            } else {
                doesNotQ();
              
            }
        }

        $scope.closeModal = function () {
            $mdDialog.hide();
        }
        function studentFailed() {
            notificationService.displayError("Could not load student.");
        }

        function isValid() {
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

