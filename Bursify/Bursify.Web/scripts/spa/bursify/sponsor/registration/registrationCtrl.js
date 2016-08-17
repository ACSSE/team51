(function (app) {
    'use strict';

    app.controller('registrationCtrl', registrationCtrl);

    registrationCtrl.$inject = ['$scope','$rootScope', '$timeout', 'apiService', '$location', 'notificationService'];


    function registrationCtrl($scope, $rootScope, $timeout, apiService, $location, notificationService) {
        $scope.pageClass = 'page-view-registration';
        $scope.max = 2;
        $scope.user = {};
        $scope.selectedIndex = 0;
        $scope.secondLocked = false;
       
    
        apiService.get('/api/bursifyuser/GetUser/?email=' + $rootScope.Email, null, Completed, null);

        function Completed(result) {
            $scope.BSponsor = result.data;
            $scope.user = result.data;
            $rootScope.User = $scope.user.Name;
            $rootScope.ThisUserID = $scope.user.ID;
          
           
        }
        
        

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

            $scope.Sponsor.ID = $scope.BSponsor.ID;
            $scope.Sponsor.Location = $scope.Location.Prov.name + ', ' + $scope.Location.City;
            $scope.Sponsor.Industry = $scope.Sponsor.Industry.name;
           

            apiService.post('/api/BursifyUser/UpdateBio/?userId=' + $scope.BSponsor.ID + '&bio=' + $scope.BursifySponsor.Description, null, null, null);
            
            
             apiService.post('/api/Sponsor/SaveSponsor', $scope.Sponsor, completed1, failed);
           
        };

        function completed1() {
            notificationService.displayInfo('Account set up complete.');
            $location.path('/bursify/sponsor/home');
        }

        function failed() {
            notificationService.displayInfo('Failed');
        }

    }


})(angular.module('BursifyApp'));

