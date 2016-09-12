(function (app) {
    'use strict';

    app.controller('addCampaignCtrl', addCampaignCtrl);

    addCampaignCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService','$rootScope'];

    function addCampaignCtrl($scope, $location,$routeParams, apiService, notificationService,fileUploadService,$rootScope) {
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
        
        /* End of Form input */
        $scope.prepareVideo = prepareVideo;

        //Picture
        var campaignFile = null;
     
        var campaignVideo = null;
        function UploadPicture() {
            $scope.uploading = true;
            fileUploadService.uploadCampImage(campaignVideo, $scope.campaign.StudentId, $scope.campaign.id, VideoUploadDone);
        }

        function VideoUploadDone() {
            notificationService.displayInfo("Campaign Image has been uploaded.");
            $scope.uploading = false;
        }

        function prepareVideo($files) {
            campaignVideo = $files;
            UploadPicture();
        }

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
            //$scope.campaign = response.data;

            UploadPicture();
        }

        function addCampaignFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }

        function redirectToCampaigns() {
            $location.path('/student/myCampaigns/');
        }
    }
})(angular.module('BursifyApp'));
