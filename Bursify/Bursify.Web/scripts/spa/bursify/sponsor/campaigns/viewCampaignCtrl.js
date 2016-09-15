(function (app) {
    'use strict';

    app.controller('viewCampaignCtrl', viewCampaignCtrl);

    //Single Campaign view
    viewCampaignCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService', '$mdDialog', '$mdMedia','$rootScope'];

    function viewCampaignCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService, $mdDialog, $mdMedia, $rootScope) {
        $scope.pageClass = "page-campaign-details";

        //Default values 
        $scope.campaign = {};
        $scope.campaigns = [];
        $scope.loadingCampaign = true;
        $scope.vote = "upvote";
        $scope.upvoted = "black";
        $scope.numberOfSupporter = 0;
        $scope.sponsorId = $rootScope.repository.loggedUser.userIden;
        $scope.daysleft = 0;
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

            //Load suppoters
            //loadSupporters();

            //Load suggested campaigns 
            //Load suggested campaigns
            $scope.loadingCampaign = true;
            apiService.get('/api/Campaign/GetSimilarCampaigns/?campaignId=' + $routeParams.campaignId, null,
                campaignsLoadCompleted,
                campaignsLoadFailed);
        }

        function loadSupporters()
        {
            //Get number of supported campaigns
            $scope.loadingCampaign = true;
            apiService.get('/api/Student/GetNumberSupportedCampaign/?campaignId=' + $routeParams.campaignId, null,
            campaignSupportersLoadCompleted,
            myCampaignLoadFailed);
        }
        function campaignSupportersLoadCompleted(result)
        {
            $scope.numberOfSupporter = result.data;
            //$scope.numberOfSupporter = 800;
            $scope.loadingCampaign = false;
        }
        function campaignsLoadCompleted(result) {
            $scope.campaigns = result.data;
            $scope.loadingCampaigns = false;
        }

        function campaignsLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function campaignSupportersLoadFailed(response) {
            notificationService.displayError(response.data);
        }
        function myCampaignLoadCompleted(result) {
            $scope.campaign = result.data;
            $scope.loadingCampaign = false;
            $scope.daysleft =  (new Date().getDay() * 6);

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
            $scope.studentId = campaign.StudentId;
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
                //Date funded
                var date = new Date().toLocaleString();
                //Sponsor a Campaign

                var sponsorCampaign = {};
                sponsorCampaign.sponsorId = $scope.sponsorId;
                sponsorCampaign.Campaignid = $routeParams.campaignId;
                sponsorCampaign.amount = $scope.amount;

                //api / SponsorSponsorCampaign
                apiService.post('/api/Sponsor/SponsorCampaign/', sponsorCampaign,
                null,
                null);


                //Add Amount Contributed to the existing
                campaign.AmountContributed = parseInt(campaign.AmountContributed) + parseInt($scope.amount);
                apiService.post('/api/campaign/SaveCampaign', campaign,
                myCampaignLoadCompleted,
                myCampaignLoadFailed);

                $scope.AmountContributed = parseInt(campaign.AmountContributed);
                $scope.numberOfSupporter = $scope.numberOfSupporter + 1;
                //close modal 
                notificationService.displaySuccess("Thank you for the support of R" + $scope.amount);

                //$mdDialog.cancel(); // Disable if you want a user to view the see their payment progress on the campaign 
                //$location.path('/sponsor/campaign-details/' + $routeParams.campaignId);
            }

            $scope.cancelFunding = function () {
                $mdDialog.cancel();
            }

            $mdDialog.show({

                controller: 'viewCampaignCtrl', // this must be the name of your controller

                templateUrl: '/Scripts/spa/bursify/sponsor/campaigns/fund.html', //this is the url of the template u call

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

        $scope.upvodeCampaign = function (ev, id) {
    
            apiService.post('/api/campaign/EndorseCampaign/?userId=' + $scope.sponsorId + '&campaignId=' + id, null,
            upvodeCampaignSucceded,
            upvodeCampaignFailed);
        };

        function upvodeCampaignSucceded(response) {
            notificationService.displaySuccess('Campaign has been successfully upvoted');
            $scope.vote = "upvoted";
            $scope.upvoted = "green";
            loadCampaign();
            //redirectToCampaigns();// Take user to the campaigns page if campaign was uploaded succesfully
        }

        function upvodeCampaignFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }
    }
})(angular.module('BursifyApp'));