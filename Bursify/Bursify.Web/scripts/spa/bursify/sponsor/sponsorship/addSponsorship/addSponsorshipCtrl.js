 (function (app) {
    'use strict';


    app.controller('addSponsorshipCtrl', addSponsorshipCtrl);

    addSponsorshipCtrl.$inject = ['$scope', '$rootScope', '$timeout', 'apiService', 'notificationService', '$mdDialog', '$mdMedia', '$location'];

    function addSponsorshipCtrl($scope,$rootScope, $timeout, apiService, notificationService, $mdDialog, $mdMedia, $location) {

        $mdDialog.hide();

        $scope.pageClass = 'page-add-sponsorship';
    
       
        $scope.provinces = ['EC', 'FS', 'GP', 'KZN', 'LMP', 'MP', 'NC', 'NW', 'WC'];

        $scope.ages = ['16-20', '21-25', '26-30', 'Any'];

        $scope.races = ['African', 'Asain', 'Indian', 'Coloured', 'White'];
   
        $scope.fields = null;
        $scope.loadFields = function () {

            return $timeout(function () {
                $scope.fields = $scope.fields || [
                  { id: 1, name: 'Accounting' },
                  { id: 2, name: 'Aviation' },
                  { id: 3, name: 'Animation' },
                  { id: 4, name: 'Arts & Crafts' },
                  { id: 5, name: 'Automotive' },
                  { id: 6, name: 'Aerospace' },
                  { id: 7, name: 'Banking' }
                ];
            }, 10);
        };
      
        $scope.Sponsorship = {
            "ID": "",
            "SponsorId": "",
            "Name": "",
            "Description": "",
            "ClosingDate": "",
            "EssayRequired": "false",
            "SponsorshipValue": "",
            "StudyFields": "",
            "Province": "",
            "AverageMarkRequired": "",
            "EducationLevel": "",
            "PreferredInstitutions": "",
            "ExpensesCovered": "",
            "TermsAndConditions": "",
            "SponsorshipType": "",
            "AgeGroup": ""
        };

        $(document).mousemove(function (e) {
            window.x = e.pageX;
            window.y = e.pageY;
        });

        $scope.data = {
            cb1: false
        };

        $scope.create = function () {
           
            $scope.Sponsorship.SponsorId = $rootScope.ThisUserID;
            $scope.Sponsorship.StudyFields = $scope.selectedField;
            $scope.Sponsorship.Province = $scope.selectedProvince;
            $scope.Sponsorship.AgeGroup = $scope.selectedAgeGroup;
            $scope.Sponsorship.SponsorshipType = "High School";
          
            apiService.post('/api/Sponsorship/SaveSponsorship', $scope.Sponsorship, completed1, failed);
        }

        function completed1() {
            notificationService.displaySuccess("Sponsorship Successfuly Submitted");
            $location.path('/sponsor/sponsorships');
        }

        function failed() {
            notificationService.displayError("An error occured.");
        }
        

        $scope.fixPosition = function () {
            
            $timeout(function () {
                $('body').removeAttr('style');
                if (document.getElementsByClassName('md-active')) {
                    for (var i = 0; i < document.getElementsByClassName('md-active').length; i++) {
                        var ele = document.getElementsByClassName('md-active')[i];
                        if (ele.localName == 'div') {
                            var position = y - ele.clientHeight;
                            ele.style.top = position + "px";
                        }
                    }
                }
            }, 0);
        };
        // The md-select directive eats keydown events for some quick select
        // logic. Since we have a search input here, we don't need that logic.
      
        $scope.isOpen = false;
        $scope.demo = {
            isOpen: false,
            count: 0,
            selectedDirection: 'left'
        };


    }

})(angular.module('BursifyApp'));

