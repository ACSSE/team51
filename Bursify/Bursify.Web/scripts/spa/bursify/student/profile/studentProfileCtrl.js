(function (app) {
    'use strict';

    app.controller('studentProfileCtrl', studentProfileCtrl);

    studentProfileCtrl.$inject = ['$scope','$rootScope', 'apiService', 'notificationService', 'membershipService', '$timeout'];


    function studentProfileCtrl($scope, $rootScope, apiService, notificationService, membershipService, $timeout) {
        $scope.pageClass = 'page-view-profile';
        $scope.markselect = {};
        $scope.CDetails = {};
        $scope.loadProvinces = function () {

            return $timeout(function () {
                $scope.provinces = $scope.provinces || [
                  { id: 1, name: 'Eastern Cape' },
                  { id: 2, name: 'Free State' },
                  { id: 3, name: 'Gauteng' },
                  { id: 4, name: 'Kwa-Zulu Natal' },
                  { id: 5, name: 'Limpopo' },
                  { id: 6, name: 'Mpumalanga' },
                  { id: 7, name: 'Northern Cape' },
                  { id: 8, name: 'North West' },
                  { id: 9, name: 'Western Cape' }
                ];
            }, 0);
        };

        $scope.loadRelates = function () {

            return $timeout(function () {
                $scope.relates = $scope.relates || [
                  { id: 1, name: 'Mother' },
                  { id: 2, name: 'Father' },
                  { id: 3, name: 'Uncle' },
                  { id: 4, name: 'Aunt' },
                  { id: 5, name: 'Gaurdian' }
                ];
            }, 0);
        };

        apiService.get('/api/student/getstudent/?studentId=' + $rootScope.repository.loggedUser.userIden,null,  loadUser, loadFailed);


    function loadUser(result) {
         $scope.Student = result.data;
    }

    function loadFailed() {
        notificationService.displayError('Could not load profile.');
    }

     $scope.saveDetails = function () {
    
         $scope.PDetails = {};
         $scope.PDetails.StudentId = $rootScope.repository.loggedUser.userIden;
         $scope.PDetails.Firstname = $scope.Student.Firstname;
         $scope.PDetails.Surname = $scope.Student.Surname;
         $scope.PDetails.Headline = $scope.Student.Headline;
         $scope.PDetails.Biography = $scope.Student.Biography;
         apiService.post('/api/student/SavePersonalDetails/', $scope.PDetails, saveDetailsDone, saveDetailsFailed);
     }

     function saveDetailsDone() {
         $scope.StudentD = {};
         $scope.StudentD.ID = $rootScope.repository.loggedUser.userIden;
         $scope.StudentD.Email = $rootScope.repository.loggedUser.Studentemail;
         $scope.StudentD.Name = $scope.Student.Firstname + " " + $scope.Student.Surname;
         membershipService.saveCredentials($scope.StudentD);
         $scope.StudentData.displayUserInfo();
         notificationService.displaySuccess("Done");
     }

     function saveDetailsFailed() {
         notificationService.displaySuccess("Failed");
     }

     $scope.saveContact = function() {
        //       public int StudentId { get; set; }
        //public string AddressType { get; set; }
        //public string CellphoneNumber { get; set; }
        //public string Email { get; set; }
        //public string GuardianPhoneNumber { get; set; }
        //public string GuardianRelationship { get; set; }
        //public string GuardianEmail { get; set; }
        //public string StreetAddress { get; set; }
        //public string City { get; set; }
        //public string Province { get; set; }
        //public string PostalCode { get; set; }

   
         $scope.CDetails.StudentId = $rootScope.repository.loggedUser.userIden;
         $scope.CDetails.AddressType = "Main";
         apiService.post('/api/student/SaveContactDetails/', $scope.CDetails, saveContactDone, saveContactFailed);

        
     }

     function saveContactDone() {
         notificationService.displaySuccess('Done.');
     }

     function saveContactFailed() {
         notificationService.displayError('Failed.');
     }





    
}})(angular.module('BursifyApp'));

