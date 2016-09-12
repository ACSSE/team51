(function (app) {
    'use strict';

    app.controller('studentProfileCtrl', studentProfileCtrl);

    studentProfileCtrl.$inject = ['$scope','$rootScope', 'apiService', 'notificationService', 'membershipService', '$timeout', 'fileUploadService'];


    function studentProfileCtrl($scope, $rootScope, apiService, notificationService, membershipService, $timeout, fileUploadService) {
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
        $scope.BursifyUser = {};
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

        $scope.triggerUpload = function () {
            var fileuploader = angular.element("#fileInput");
            fileuploader.on('click', function () {
                console.log("File upload triggered programatically");
            })
            fileuploader.trigger('click')
        }

        var ImageFile = null;
        $scope.prepareImage = function prepareImage($files) {
            ImageFile = $files;
            UploadImage();    
        }

        function UploadImage() {
            $scope.uploading = true;
            fileUploadService.uploadFile(ImageFile, $rootScope.repository.loggedUser.userIden, ImageUploadDone);
        }

        function ImageUploadDone() {
            loadBursifyuser();
        }


        function loadUser(result) {
            $scope.Student = result.data;

            loadBursifyuser();
        }

        function loadBursifyuser() {
            apiService.get('/api/Bursifyuser/getuser/?userId=' + $rootScope.repository.loggedUser.userIden, null, loadUserDone, loadUserFailed);
        }

        function loadUserDone(result) {
            $scope.BursifyUser = result.data;
        }
        function loadUserFailed() {
            notificationService.displayError('Failed to load user.');
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

