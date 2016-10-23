(function (app) {
    'use strict';

    app.controller('campaignDetailsCtrl', campaignDetailsCtrl);

    //Single Campaign view
    campaignDetailsCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService', '$mdDialog', '$mdMedia', '$rootScope'];

    function campaignDetailsCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService, $mdDialog, $mdMedia, $rootScope) {
        $scope.pageClass = "page-campaign-details";

        //Default values 
        $scope.campaign = {};
        $scope.campaigns = [];
        $scope.funders = [];
        $scope.loadingCampaign = true;
        $scope.vote = "upvote";
        $scope.upvoted = false;
        $scope.numberOfSupporter = 2;
        $scope.studentId = $rootScope.repository.loggedUser.userIden;
        $scope.upVoteColor= "black";
        //For Payments
        $scope.cardNumber = '';
        $scope.CardType = '';
        $scope.NameOnCard = '';
        $scope.cvv = 0;
        $scope.month;
        $scope.year = 0;
        $scope.amount = 0;
        $scope.isMyCampaign = false;

        $scope.loadCampaign = function () {
        };

        function loadFunders()
        {
            $scope.loadingCampaign = true;
            apiService.get('/api/Campaign/GetCampaignFunders/?campaignId=' + $routeParams.campaignId, null,
            myFundersLoadCompleted,
            myFundersLoadFailed);
        }

        function myFundersLoadCompleted(response)
        {
            $scope.funders = response.data;
        }

        function myFundersLoadFailed(response)
        {
            notificationService.displayError(response.data);
        }

        function loadCampaign() {
            $scope.loadingCampaign = true;
            apiService.get('/api/Campaign/GetCampaign/?campaignId=' + $routeParams.campaignId, null,
            myCampaignLoadCompleted,
            myCampaignLoadFailed);
            //Load funders
            loadFunders();
            //load upvoters
            campaignUpvoted();
            //Load suggested campaigns
            $scope.loadingCampaign = true;
            apiService.get('/api/Campaign/GetSimilarCampaigns/?campaignId=' + $routeParams.campaignId, null,
                campaignsLoadCompleted,
                campaignsLoadFailed);
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

        function campaignVoted(response)
        {
            
            if (response.data)
            {
                $scope.upvoted = true;
                $scope.upVoteColor = "green";
            }
        }
        function campaignUnvoted(response)
        {
            notificationService.displayError(response.data);
        }

        function myCampaignLoadCompleted(result) {
            $scope.campaign = result.data;
            $scope.loadingCampaign = false;

            if ($scope.campaign.StudentId == $scope.studentId)
            {
                $scope.isMyCampaign = false;
            }
            else
            {
                $scope.isMyCampaign = true;
            }

        }

        function myCampaignLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function campaignsLoadCompleted(result) {
            $scope.campaigns = result.data;
            $scope.loadingCampaigns = false;
        }

        function campaignsLoadFailed(response) {
            notificationService.displayError(response.data);
        }
        loadCampaign();
       
        //Fund Campaign
        $scope.fundCampaign = function (ev,campaign) {

            $scope.StudentName = campaign.Name + ' ' + campaign.Surname;
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

                $scope.AmountContributed = parseInt(campaign.AmountContributed);
                $scope.numberOfSupporter = $scope.numberOfSupporter + 1;
                //close modal 
                notificationService.displaySuccess("Thank you for the support of R" + $scope.amount);

                //$mdDialog.cancel(); // Disable if you want a user to view the see their payment progress on the campaign 
                $location.path('/student/campaign-details/' + $routeParams.campaignId);
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

        $scope.upvodeCampaign = function (ev, id) {
    
            apiService.post('/api/campaign/EndorseCampaign/?userId=' + $scope.studentId + '&campaignId=' + id, null,
            upvodeCampaignSucceded,
            upvodeCampaignFailed);
        };

        function upvodeCampaignFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }
    }
})(angular.module('BursifyApp'));