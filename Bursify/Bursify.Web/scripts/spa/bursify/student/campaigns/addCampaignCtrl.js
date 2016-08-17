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
        $scope.campaign.Tagline = 'Sporting event';
        $scope.campaign.Location = 'Gauteng';
        $scope.campaign.Description = 'Please fund us we wanna go out for the first time to england ';
        $scope.campaign.AmountRequired = 50000;
        $scope.campaign.CampaignType = 'Sport';
        $scope.campaign.VideoPath = 'xxx';
        $scope.campaign.PicturePath = 'campaign.jpg';
        $scope.campaign.StartDate = new Date();
        $scope.campaign.EndDate = new Date();
        $scope.campaign.AmountContributed = 0;
        $scope.campaign.FundUsage = 0;
        $scope.campaign.ReasonsToSupport = 'Our Parents cant afford the trip costs';
        $scope.campaign.Status = 'Active';
        $scope.StudentName = "Mike Ross";
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
            notificationService.displaySuccess($scope.campaign.CampaignName + ' has been submitted to bursify campaign list');
            $scope.campaign = response.data;

            redirectToCampaigns();// Take user to the campaigns page if campaign was uploaded succesfully
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
