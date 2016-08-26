(function (app) {
    'use strict';

    app.controller('addCampaignCtrl', addCampaignCtrl);

    addCampaignCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService'];

    function addCampaignCtrl($scope, $location,$routeParams, apiService, notificationService,fileUploadService) {
        $scope.pageClass = 'page-campaign-add';

        /*form input*/
        
        $scope.campaign = {};
        
        $scope.campaign.StudentId = 1;
        $scope.campaign.CampaignName = 'Soccer Event ';
        $scope.campaign.Tagline = 'Sporting event';
        $scope.campaign.location = 'Gauteng';
        $scope.campaign.Description = 'Please fund us we wanna go out for the first time to england ';
        $scope.campaign.AmountRequired = 50000;
        $scope.campaign.campaignType = 'Sport';
        $scope.campaign.videoPath = 'xxx';
        $scope.campaign.picturePath = 'campaign.jpg';
        $scope.campaign.startDate = new Date();
        $scope.campaign.endDate = new Date();
        $scope.campaign.amountContributed = 1500;
        $scope.campaign.fundUsage = 0;
        $scope.campaign.reasonsToSupport = 'Our Parents cant afford the trip costs';
        $scope.StudentName = "Mike Ross";
        $scope.campaign.PicturePath = "default-campaign.jpg";
        $scope.addStudentCampaign = addStudentCampaign;
        /* End of Form input */

       //Methods 
        function addStudentCampaign()
        {
            apiService.post('/api/campaign/SaveCampaign/?campaignId=', $scope.campaign,
            addCampaignSucceded,
            addCampaignFailed);
        }

        function addCampaignSucceded(response) {
            notificationService.displaySuccess($scope.campaign.title + ' has been submitted to bursify campaign list');
            $scope.campaign = response.data;

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
