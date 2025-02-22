﻿(function (app) {
    'use strict';

    app.controller('viewCampaignCtrl', viewCampaignCtrl);

    //Single Campaign view
    viewCampaignCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService', '$mdDialog', '$mdMedia','$rootScope'];

    function viewCampaignCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService, $mdDialog, $mdMedia, $rootScope) {
        $scope.pageClass = "page-campaign-details";

        //Default values 
        $scope.campaign = {};
        $scope.campaigns = [];
        $scope.funders = [];
        $scope.loadingCampaign = true;
        $scope.vote = "upvote";
        $scope.upvoted = false;
        $scope.numberOfSupporter = 0;
        $scope.sponsorId = $rootScope.repository.loggedUser.userIden;
        $scope.daysleft = 0;
        $scope.upVoteColor = "black";
        //For Payments
        $scope.cardNumber = '5284 2272 4736 5532';
        $scope.CardType = 'Credit Card';
        $scope.NameOnCard = $rootScope.repository.loggedUser.username;
        $scope.cvv = 306;
        $scope.month = 09;
        $scope.year = 21;
        $scope.amount = 0;

        $scope.loadCampaign = function () {
        };

        function loadFunders() {
            $scope.loadingCampaign = true;
            apiService.get('/api/Campaign/GetCampaignFunders/?campaignId=' + $routeParams.campaignId, null,
            myFundersLoadCompleted,
            myFundersLoadFailed);
        }

        function myFundersLoadCompleted(response) {
            $scope.funders = response.data;
        }

        function myFundersLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function loadCampaign() {
            $scope.loadingCampaign = true;
            apiService.get('/api/Campaign/GetCampaign/?campaignId=' + $routeParams.campaignId, null,
            myCampaignLoadCompleted,
            myCampaignLoadFailed);

            //Load funders
            loadFunders();
            //Voted or not
            campaignUpvoted();
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

        function upvodeCampaignSucceded(response) {
            notificationService.displaySuccess('Campaign has been successfully upvoted');
            $scope.vote = "upvoted";
            $scope.upvoted = "green";
            //redirectToCampaigns();// Take user to the campaigns page if campaign was uploaded succesfully
        }
        function campaignUpvoted() {
            apiService.post('/api/Campaign/IsEndorsed/?userId=' + $rootScope.repository.loggedUser.userIden + "&campaignId=" + $routeParams.campaignId, null, campaignVoted, campaignUnvoted);
        }

        function campaignVoted(response) {

            if (response.data) {
                $scope.upvoted = true;
                $scope.upVoteColor = "green";
            }
        }
        function campaignUnvoted(response) {
            notificationService.displayError(response.data);
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
            
            //Check days left 
            var oneDay = 24 * 60 * 60 * 1000;	// hours*minutes*seconds*milliseconds
            var firstDate = new Date($scope.campaign.StartDate);
            var secondDate = new Date($scope.campaign.EndDate);

            var x = Math.abs((firstDate.getTime() - secondDate.getTime()) / (oneDay));
            $scope.daysleft = ~~x;

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
                var shortage = $scope.AmountRequired - $scope.AmountContributed;

                var deducted = 0;

                if($scope.amount > 0)
                {
                if ($scope.amount > shortage)
                {
                    deducted = shortage;
                }
                else
                {
                    deducted = $scope.amount;
                }

                var sponsorCampaign = {};
                sponsorCampaign.sponsorId = $scope.sponsorId;
                sponsorCampaign.Campaignid = $routeParams.campaignId;
                sponsorCampaign.amount = deducted;

                //api / SponsorSponsorCampaign
                apiService.post('/api/Sponsor/SponsorCampaign/', sponsorCampaign,
                myCampaignSponsorCompleted,
                myCampaignSponsorFailed);


                //Add Amount Contributed to the existing
                campaign.AmountContributed = parseInt(campaign.AmountContributed) + parseInt(deducted);
                apiService.post('/api/campaign/SaveCampaign', campaign,
                myCampaignLoadCompleted,
                myCampaignLoadFailed);

                $scope.AmountContributed = parseInt(campaign.AmountContributed);
                $scope.numberOfSupporter = $scope.numberOfSupporter + 1;
                //close modal 
                notificationService.displaySuccess("Thank you for the support of R" + deducted);
                }
                else
                {
                    notificationService.displayError("Invalid amount Entered");
                }

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

        function myCampaignSponsorCompleted() {

        }

        function myCampaignSponsorFailed() {

        }
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