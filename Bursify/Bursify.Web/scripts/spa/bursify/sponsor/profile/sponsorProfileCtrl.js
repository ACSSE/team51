(function (app) {
    'use strict';

    app.controller('sponsorProfileCtrl', sponsorProfileCtrl);

    sponsorProfileCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$rootScope', 'fileUploadService'];

    function sponsorProfileCtrl($scope, apiService, notificationService, $rootScope, fileUploadService) {
        $scope.pageClass = 'page-view-profile';
        $scope.markselect = {};

        $scope.loadSponsor = function () {
            apiService.get('/api/sponsor/Getsponsor/?userId=' + $rootScope.repository.loggedUser.userIden, null, CompletedSponsor, FailedSponsor);
            apiService.get('/api/bursifyuser/Getuser/?userId=' + $rootScope.repository.loggedUser.userIden, null, CompletedUser, FailedUser);


        }

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
            loadSP();
        }

        function loadSP(){
        apiService.get('/api/sponsor/Getsponsor/?userId=' + $rootScope.repository.loggedUser.userIden, null, CompletedSponsor, FailedSponsor);
        apiService.get('/api/bursifyuser/Getuser/?userId=' + $rootScope.repository.loggedUser.userIden, null, CompletedUser, FailedUser);

        }

        $scope.Sponsor = {};
        function CompletedSponsor(result) {
            $scope.Sponsor = result.data;
        }

        function FailedSponsor() {
            notificationService.displayError('Could not your profile.');
        }

        $scope.User = {};
        function CompletedUser(result) {
            $scope.User = result.data;
        }

        function FailedUser() {
            notificationService.displayError('Could not your user.');
        }

    }

})(angular.module('BursifyApp'));

