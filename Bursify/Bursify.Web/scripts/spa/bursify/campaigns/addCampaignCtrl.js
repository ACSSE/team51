(function (app) {
    'use strict';

    app.controller('addCampaignCtrl', addCampaignCtrl);

    //addCampaignCtrl.$inject = ['$scope', '$http', 'apiService', 'notificationService'];

    addCampaignCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService'];

    function addCampaignCtrl($scope, $location,$routeParams, apiService, notificationService,fileUploadService) {
        $scope.pageClass = 'page-campaign-add';

        /*form input*/
        
        $scope.campaign = {};

        $scope.campaign.StudentId = 1;
        $scope.campaign.CampaignName = 'Scoccer';
        $scope.campaign.Tagline = 'Scoccer';
        $scope.campaign.Location = 'Gauteng';
        $scope.campaign.Description = 'Scoccer';
        $scope.campaign.AmountRequired = 5000;
        $scope.campaign.CampaignType = 'Scoccer';
        $scope.campaign.VideoPath = 'Scoccer';
        $scope.campaign.PicturePath = 'Scoccer';
        $scope.campaign.StartDate = new Date();
        $scope.campaign.EndDate = new Date();
        $scope.campaign.AmountContributed = 0;
        $scope.campaign.FundUsage = 0;
        $scope.campaign.ReasonsToSupport = 'Scoccer';

        $scope.addStudentCampaign = addStudentCampaign;
        /* End of Form input */

       //Methods 
        function addStudentCampaign()
        {
            notificationService.displaySuccess('Hello ');
            apiService.post('/api/campaigns/add', $scope.campaign,
            addCampaignSucceded,
            addCampaignFailed);
        }

        function addCampaignSucceded(response) {
            notificationService.displaySuccess($scope.campaign.title + ' has been submitted to bursify campaign list');
            $scope.campaign = response.data;

            if (campaignImage) {
                fileUploadService.uploadImage(campaignImage, $scope.campaign.ID, redirectToEdit);
            }
            else

            redirectToCampaigns();// Take user to the campaigns page if campaign was uploaded succesfully
        }

        function addCampaignFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }

        function redirectToCampaigns() {
            $location.url('/bursify/student/campaigns-view' + $scope.movie.ID);
        }
    }

})(angular.module('BursifyApp'));
