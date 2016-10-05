(function (app) {
    'use strict';

    app.controller('addCampaignCtrl', addCampaignCtrl);

    addCampaignCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService', '$rootScope', 'membershipService', '$timeout'];

                              function addCampaignCtrl($scope, $location,$routeParams, apiService, notificationService,fileUploadService,$rootScope,membershipService,$timeout) {
        $scope.pageClass = 'page-campaign-add';

        /*form input*/
        
        $scope.campaign = {};
        
        $scope.campaign.StudentId = $rootScope.repository.loggedUser.userIden;
        $scope.campaign.CampaignName = 'Soccer Event ';
        $scope.campaign.Location = 'Gauteng';
        $scope.campaign.Description = 'We would like to make an application for £1000 from the AN Other Fund. We are a group of local people in Anytown, and we have recently set up a community group running free sports activities for children in the area. ';
        $scope.campaign.Tagline = 'Please provide a short description of your campaign';
        $scope.campaign.AmountRequired = 50000;
        $scope.campaign.CampaignType = 'Sport';
        $scope.campaign.VideoPath = 'xxx';
        $scope.campaign.PicturePath = 'default-campaign.jpg';
        $scope.campaign.StartDate = new Date();
        $scope.campaign.EndDate = new Date();
        $scope.campaign.AmountContributed = 0;
        $scope.campaign.FundUsage = 0;
        $scope.campaign.ReasonsToSupport = 'Our Parents cant afford the trip costs';
        $scope.campaign.Status = 'Active';
        $scope.StudentName = $rootScope.repository.loggedUser.username;
        $scope.addStudentCampaign = addStudentCampaign;

        $scope.CampaignId;

        var ImageFile = null;
        
        $scope.triggerUpload = function () {
            var fileuploader = angular.element("#fileInput");
            fileuploader.on('click', function () {
                console.log("File upload triggered programatically");
            })
            fileuploader.trigger('click')
        }

        $scope.prepareImage = function prepareImage($files) {
            ImageFile = $files;
            //UploadImage();
        }

        function UploadImage() {
            $scope.uploading = true;
            fileUploadService.uploadCampImage(ImageFile, $rootScope.repository.loggedUser.userIden, $scope.CampaignId, ImageUploadDone);

            notificationService.displaySuccess(ImageFile.FileName);
        }

        function ImageUploadDone() {
            
        }


        $scope.nextTab = function () {

            var index = ($scope.selectedIndex == $scope.max) ? 0 : $scope.selectedIndex + 1;
            $scope.selectedIndex = index;
        };

        function addStudentCampaign()
        {
            var text = $scope.campaign.Description;
            text = text.replace(/\r?\n/g, '<br/>');
            $scope.campaign.Description = text;
            apiService.post('/api/campaign/SaveCampaign/?campaign', $scope.campaign,
            addCampaignSucceded,
            addCampaignFailed);

            redirectToCampaigns();// Take user to the campaigns page if campaign was uploaded succesfully
        }

        function addCampaignSucceded(response) {
            notificationService.displaySuccess($scope.campaign.CampaignName + ' has been submitted to bursify campaign list');
            $scope.CampaignId = response.data.CampaignId;
            UploadImage();
        }

        function addCampaignFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }

        function redirectToCampaigns() {
            $location.path('/student/campaigns');
        }
    }
})(angular.module('BursifyApp'));
