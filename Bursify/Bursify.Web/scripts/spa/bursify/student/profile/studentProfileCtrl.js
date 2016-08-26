(function (app) {
    'use strict';

    app.controller('studentProfileCtrl', studentProfileCtrl);

    studentProfileCtrl.$inject = ['$scope','$rootScope', 'apiService', 'notificationService'];


    function studentProfileCtrl($scope, $rootScope, apiService, notificationService) {
        $scope.pageClass = 'page-view-profile';
        $scope.markselect = {};

     apiService.get('/api/student/getstudent/?studentId=' + $rootScope.repository.loggedUser.userIden,null,  loadUser, loadFailed);


    function loadUser(result) {
         $scope.user = result.data;
    }

    function loadFailed() {
        notificationService.displayError('Could not load profile.');
    }

     $scope.saveDetails = function () {
    
         $scope.PDetails = {};
         $scope.PDetails.StudentId = $rootScope.repository.loggedUser.userIden;
         $scope.PDetails.Firstname = $scope.user.Firstname;
         $scope.PDetails.Surname = $scope.user.Surname;
         $scope.PDetails.Headline = $scope.user.Headline;
         $scope.PDetails.Biography = $scope.user.Biography;
         apiService.post('/api/student/SavePersonalDetails/', $scope.PDetails, saveDetailsDone, saveDetailsFailed);
     }

     function saveDetailsDone() {
         $scope.userD = {};
         $scope.userD.ID = $rootScope.repository.loggedUser.userIden;
         $scope.userD.Email = $rootScope.repository.loggedUser.useremail;
         $scope.userD.Name = $scope.user.FirstName + " " + $scope.user.Surname;
         membershipService.saveCredentials($scope.userD);
         $scope.userData.displayUserInfo();
         notificationService.displaySuccess("Done");
     }

     function saveDetailsFailed() {
         notificationService.displaySuccess("Failed");
     }





    
}})(angular.module('BursifyApp'));

