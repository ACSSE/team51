(function (app) {
    'use strict';

    app.controller('campaignsCtrl', campaignsCtrl);

    campaignsCtrl.$inject = ['$scope', 'apiService', '$http', 'notificationService', '$mdDialog', '$mdMedia', '$location'];

    function campaignsCtrl($scope, apiService, $http, notificationService, $mdDialog, $mdMedia, $location) {
        $scope.pageClass = 'page-home-campaigns';

        $scope.Years = [2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025];
        $scope.Months = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
        $scope.loadingCampaigns = true;
        $scope.isReadOnly = true;
        $scope.NumberOfContributers = 3;
        $scope.campaigns = [];
        $scope.StudentName = '';
        $scope.currentCampaign = {};
        $scope.length = 0;
        $scope.Live = 'ACTIVE';

        //For Payments
        $scope.cardNumber = '5284 2272 4736 5532';
        $scope.CardType = 'Credit Card';
        $scope.NameOnCard = "";
        $scope.cvv = 306;
        $scope.month = 09;
        $scope.year = 21;
        $scope.amount = 0;
       
        $scope.loadData = loadData;

        function loadData() {
            apiService.get('/api/Campaign/', null,
                        campaignsLoadCompleted,
                        campaignsLoadFailed);
        }

        function campaignsLoadCompleted(result) {
            $scope.campaigns = result.data;
            $scope.loadingCampaigns = false;
        }

        function campaignsLoadFailed(response) {
            notificationService.displayError(response.data);
        }
        loadData();

        $scope.fundCampaign = function (ev, campaign) {
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
                addCampaignSucceded,
                addCampaignFailed);

                $scope.AmountContributed = parseInt(campaign.AmountContributed) + parseInt($scope.amount)
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

                controller: 'campaignsCtrl', // this must be the name of your controller

                templateUrl: '/Scripts/spa/sponsor/campaigns/fund.html', //this is the url of the template u call

                parent: angular.element(document.body),

                targetEvent: ev,
                scope: $scope, //pass the scope to dialog

                clickOutsideToClose: true,
                fullscreen: useFullScreen
            })
            $scope.$watch(function () {

                return $mdMedia('xs') || $mdMedia('sm');

            }, function (wantsFullScreen) {

                $scope.customFullscreen = (wantsFullScreen === true);

            });
        };

        $scope.upvodeCampaign = function (ev, id)
        {
            //upvode a campaign
            apiService.post('/api/campaign/EndorseCampaign/?campaignId=' + id, null,
            addCampaignSucceded,
            addCampaignFailed);

            notificationService.displaySuccess("upvoded");
        };


    }

})(angular.module('BursifyApp'));