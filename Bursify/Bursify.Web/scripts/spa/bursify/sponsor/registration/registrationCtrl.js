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

   
        $scope.Location = {};
        $scope.Location.City = "Johannesburg";
        $scope.Sponsor = {
            "ID":  "",
        "CompanyName": "Entelect",
        "NumberOfStudentsSponsored": "",
        "NumberOfSponsorships": "",
        "NumberOfApplicants": "",
        "Description": "Entelect assists the world's best companies in the delivery of customised software solutions that differentiate them in the marketplace.",
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
                  { id: 1, name: 'Eastern Cape' },
                  { id: 2, name: 'Free State' },
                  { id: 3, name: 'Gauteng' },
                  { id: 4, name: 'KwaZulu-Natal' },
                  { id: 5, name: 'Limpopo' },
                  { id: 6, name: 'Mpumalanga' },
                  { id: 7, name: 'Northern Cape' },
                  { id: 8, name: 'North West' },
                  { id: 9, name: 'Western Cape' }
                ];
            }, 10);
        };

        $scope.create = function () {
           
            $scope.Sponsor.ID = $rootScope.repository.loggedUser.userIden;
            $scope.Sponsor.Location = $scope.Location.Prov.name + ', ' + $scope.Location.City;
            $scope.Sponsor.Industry = $scope.Sponsor.Industry.name;
           

            apiService.post('/api/BursifyUser/UpdateBio/?userId=' + $scope.Sponsor.ID + '&bio=' + $scope.Sponsor.Description, null, null, null);
            
            
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

