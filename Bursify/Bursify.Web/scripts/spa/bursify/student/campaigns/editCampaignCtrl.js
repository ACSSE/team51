(function (app) {
    'use strict';

    app.controller('editCampaignCtrl', editCampaignCtrl);

    editCampaignCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService', '$rootScope'];

    function editCampaignCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService, $rootScope) {
        $scope.pageClass = 'page-campaign-add';

        $scope.campaign = {};

        $scope.campaign.StudentId = $rootScope.repository.loggedUser.userIden;
        $scope.StudentName = $rootScope.repository.loggedUser.username;
        $scope.loadMyCampaign = loadMyCampaign;
        $scope.editStudentCampaign = editStudentCampaign;

        /* End of Form input */

        //Methods 
        function loadMyCampaign() {
            $scope.loadingCampaign = true;
            apiService.get('/api/Campaign/GetCampaign/?campaignId=' + $routeParams.campaignId, null,
            EditCampaignLoadCompleted,
            EditCampaignFailed);
        }

        function EditCampaignLoadCompleted(result) {
            $scope.campaign = result.data;
            $scope.loadingCampaign = false;
        }
        function editStudentCampaign()
        {
            apiService.post('/api/campaign/SaveCampaign/?campaign=', $scope.campaign,
                    EditCampaignSucceded,
                    EditCampaignFailed);

            //Check User password *******************************************************sdfsdfdsfdsfdsfsdf***************************************
            //if(log)
            // {
            //    apiService.post('/api/campaign/SaveCampaign/?campaign=', $scope.campaign,
            //    EditCampaignSucceded,
            //    EditCampaignFailed);
            // }
           
        }

        function EditCampaignSucceded(response) {
            notificationService.displaySuccess($scope.campaign.CampaignName + ' has been submitted to bursify campaign list');
            $scope.campaign = response.data;

            redirectToCampaigns();// Take user to the campaigns page if campaign was uploaded succesfully
        }

        function EditCampaignFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }

        function redirectToCampaigns() {
            $location.path('/student/campaigns');
        }

        loadMyCampaign();
    }
})(angular.module('BursifyApp'));
