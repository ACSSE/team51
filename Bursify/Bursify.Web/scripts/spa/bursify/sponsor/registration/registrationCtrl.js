(function (app) {
    'use strict';

    app.controller('registrationCtrl', registrationCtrl);

    registrationCtrl.$inject = ['$scope','$rootScope', '$timeout', 'apiService', '$location', 'notificationService', 'membershipService'];


    function registrationCtrl($scope, $rootScope, $timeout, apiService, $location, notificationService, membershipService) {
        $scope.pageClass = 'page-view-registration';
        $scope.max = 2;
        $scope.user = {};
        $scope.selectedIndex = 0;
        $scope.secondLocked = false;
 

        $scope.nextTab = function () {
            
             var index = ($scope.selectedIndex == $scope.max) ? 0 : $scope.selectedIndex + 1;
             $scope.selectedIndex = index;
        };

   

        $scope.Sponsor = {
            "ID":  "",
        "CompanyName": "Entelect",
        "NumberOfStudentsSponsored": "",
        "NumberOfSponsorships": "",
        "NumberOfApplicants": "",
        "BursifyRank": "",
        "BursifyScore": "",
        "CompanyEmail": "www.entelect.co.za",
        "Website": "www.entelect.co.za"
            
        };

        $scope.provin = null;
        $scope.Industry = null;
     
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

        $scope.Location = {
            "Prov": "",
            "City": ""
        };


        
        $scope.provinces = null;
        $scope.loadProvinces = function () {

            return $timeout(function () {
                $scope.provinces = $scope.provinces || [
                  { id: 1, name: 'EC' },
                  { id: 2, name: 'FS' },
                  { id: 3, name: 'GP' },
                  { id: 4, name: 'KZN' },
                  { id: 5, name: 'LMP' },
                  { id: 6, name: 'MP' },
                  { id: 7, name: 'NC' },
                  { id: 8, name: 'NW' },
                  { id: 9, name: 'WC' }
                ];
            }, 10);
        };

        $scope.create = function () {
           
            $scope.Sponsor.ID = $rootScope.repository.loggedUser.userIden;
            $scope.Sponsor.Location = $scope.Location.Prov.name + ', ' + $scope.Location.City;
            $scope.Sponsor.Industry = $scope.Sponsor.Industry.name;
           

            apiService.post('/api/BursifyUser/UpdateBio/?userId=' + $scope.Sponsor.ID + '&bio=' + $scope.BursifySponsor.Description, null, null, null);
            
            
             apiService.post('/api/Sponsor/SaveSponsor', $scope.Sponsor, completed1, failed);
           
        };

        function completed1() {
            notificationService.displayInfo('Account set up complete.');
            $scope.user = {};
            $scope.user.ID = $rootScope.repository.loggedUser.userIden;
            $scope.user.Email = $rootScope.repository.loggedUser.useremail;
            $scope.user.Name = $scope.Sponsor.CompanyName;
            membershipService.saveCredentials($scope.user);
            $scope.userData.displayUserInfo();
            $location.path('/sponsor/home');
        }

        function failed() {
            notificationService.displayInfo('Failed');
        }

    }


})(angular.module('BursifyApp'));

