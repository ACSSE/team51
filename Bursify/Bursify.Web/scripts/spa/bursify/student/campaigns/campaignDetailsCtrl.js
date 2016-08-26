(function (app) {
    'use strict';

    app.controller('campaignDetailsCtrl', campaignDetailsCtrl);

    //Single Campaign view
    campaignDetailsCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService', '$mdDialog', '$mdMedia'];

    function campaignDetailsCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService, $mdDialog, $mdMedia) {
        $scope.pageClass = "page-campaign-details";

        //Default values 
        $scope.campaign = {};
        $scope.loadingCampaign = true;

        //For Payments
        $scope.cardNumber = '';
        $scope.CardType = '';
        $scope.NameOnCard = '';
        $scope.cvv = 0;
        $scope.month;
        $scope.year = 0;
        $scope.amount = 0;

        $scope.loadCampaign = function () {
        };

        function loadCampaign() {
            $scope.loadingCampaign = true;
            apiService.get('/api/Campaign/GetCampaign/?campaignId=' + $routeParams.campaignId, null,
            myCampaignLoadCompleted,
            myCampaignLoadFailed);
        }

        function myCampaignLoadCompleted(result) {
            $scope.campaign = result.data;
            $scope.loadingCampaign = false;
        }

        function myCampaignLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        loadCampaign();
       
        //Fund Campaign
        $scope.fundCampaign = function (ev,campaign) {

            $scope.CampaignName = campaign.CampaignName;
            $scope.CampaignLocation = campaign.Location;
            $scope.CampaignId = campaign.CampaignId;
            $scope.StudentId = campaign.StudentId;
            $scope.Tagline = campaign.Tagline;
            $scope.Description = campaign.Description;
            $scope.AmountRequired = campaign.AmountRequired;
            $scope.CampaignType = campaign.CampaignType;
            $scope.VideoPath = campaign.VideoPath;
            $scope.PicturePath = campaign.PicturePath;
            $scope.StartDate = campaign.StartDate;
            $scope.EndDate = campaign.EndDate;
            $scope.AmountContributed = campaign.AmountContributed;
            $scope.FundUsage = campaign.FundUsage;
            $scope.ReasonsToSupport = campaign.ReasonsToSupport;
            $scope.numberOfSupporter = 0;

            var useFullScreen = ($mdMedia('sm') || $mdMedia('xs')) && $scope.customFullscreen;

            $scope.saveFunding = function () {
                //Fund this Campign
                //Get sponsor ID 
                //Get Campaign ID 
                //Amount funded
                //Date funded

                //Add Amount Contributed to the existing
                campaign.AmountContributed = parseInt(campaign.AmountContributed) + parseInt($scope.amount);
                apiService.post('/api/campaign/SaveCampaign', campaign,
                myCampaignLoadCompleted,
                myCampaignLoadFailed);

                $scope.AmountContributed = parseInt(campaign.AmountContributed) + parseInt($scope.amount);
                $scope.numberOfSupporter = $scope.numberOfSupporter + 1;
                //close modal 
                notificationService.displaySuccess("Thank you for the support of R" + $scope.amount);

                $mdDialog.cancel();

                //Take them to campaign view
                // redirectToCampaignDetails();
            }

            $scope.cancelFunding = function () {
                $mdDialog.cancel();
            }

            $mdDialog.show({

                controller: 'campaignDetailsCtrl', // this must be the name of your controller


                templateUrl: '/Scripts/spa/bursify/student/campaigns/fund.html', //this is the url of the template u call

                parent: angular.element(document.body),

                targetEvent: ev,
                scope: $scope, //pass the scope to dialog

                clickOutsideToClose: true,

            });

            $scope.$watch(function () {

                return $mdMedia('xs') || $mdMedia('sm');

            }, function (wantsFullScreen) {

                $scope.customFullscreen = (wantsFullScreen === true);
            });
        };
    }
})(angular.module('BursifyApp'));