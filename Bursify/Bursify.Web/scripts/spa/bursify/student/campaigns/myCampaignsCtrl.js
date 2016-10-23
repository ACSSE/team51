(function (app) {
    'use strict';
    /** Remove the Http when calling the API**/
    app.controller('myCampaignsCtrl', myCampaignsCtrl);

    myCampaignsCtrl.$inject = ['$scope', 'apiService', '$routeParams', 'notificationService', '$rootScope', '$mdDialog', '$mdMedia'];

    function myCampaignsCtrl($scope, apiService, $routeParams, notificationService, $rootScope,$mdDialog,$mdMedia) {
        $scope.pageClass = 'page-home-my-campaigns';

        $scope.demo = {
            showTooltip: false,
            tipDirection: ''
        };
                $scope.campaigns = [];
                $scope.loadingCampaigns = true;
                $scope.isReadOnly = true;
                $scope.removeCampaign = removeCampaign;
                $scope.loadData = loadData;
                $scope.canDelete = false;
                $scope.userPassword = "";
                $scope.campaignId;
               
                function loadData() {
                   
                    apiService.get('/api/Campaign/GetAllCampaigns/?userId=' + $rootScope.repository.loggedUser.userIden, null,
                                campaignsLoadCompleted,
                                campaignsLoadFailed);
                }
        
                function campaignsLoadCompleted(result) {
                    $scope.campaigns = result.data;
                    $scope.loadingCampaigns = false;
        
                    //Use student id to get the name of the student who started the campaign  *****NBNB****
                    $scope.studentName = $rootScope.repository.loggedUser.username;
                }
        
                function campaignsLoadFailed(response) {
                    notificationService.displayError(response.data);
                }

                function removeCampaign(campaignId)
                {
                   // alert(campaignId);
                    $scope.campaignId = campaignId;

                   $scope.showAdvanced();
                    
                }

                function addCampaignSucceded(response) {
                    notificationService.displaySuccess('Campaign Deleted');
                }

                function addCampaignFailed(response) {
                    console.log(response);
                    notificationService.displayError(response.statusText);
                }

        //Confirm Delete or edit 
                $scope.showAdvanced = function (ev) {
                    var useFullScreen = ($mdMedia('sm') || $mdMedia('xs')) && $scope.customFullscreen;
                    $mdDialog.show({
                        controller: 'myCampaignsCtrl',
                        templateUrl: '/Scripts/spa/bursify/student/campaigns/dialog.tmpl.html',
                        parent: angular.element(document.body),
                        targetEvent: ev,
                        scope: $scope,
                        clickOutsideToClose: true
                    })
                    .then(function (answer) {
                        $mdDialog.hide($scope.campaignId);
                     
                    }, function () {
                        $scope.status = 'You cancelled the dialog.';
                    });

                    $scope.$watch(function () {
                        return $mdMedia('xs') || $mdMedia('sm');
                    }, function (wantsFullScreen) {
                        $scope.customFullscreen = (wantsFullScreen === true);
                    });
                };

                $scope.Approve = function () {
                    apiService.post('/api/account/verifypassword/?userId=' + $rootScope.repository.loggedUser.userIden + '&password=' + $scope.userPassword, null, verified, verifiedFailed)
                }

                function verified(result) {
                    if (result.data.success)
                    {
                        var x = $scope.campaignId;

                        apiService.post('/api/campaign/DelCampaign/?campaignId=' + x, null,
                         approveSuccessful,
                         approveFailed);

                    } else {
                        notificationService.displayError("Incorrect password !");
                        $mdDialog.hide();
                    }
                }

                function verifiedFailed(result) {
                    notificationService.displayError("Could not verify password");
                }

                function approveSuccessful() {
                    notificationService.displaySuccess("Approved.");
                    $mdDialog.hide();
                }

                function approveFailed() {
                    notificationService.displayError("Could not remove campaign at this moment in time. Try again later.")
                }
        //End of confirm password 
                loadData();


                $scope.demo.delayTooltip = undefined;
                $scope.$watch('demo.delayTooltip', function (val) {
                    $scope.demo.delayTooltip = parseInt(val, 10) || 0;
                });
                $scope.$watch('demo.tipDirection', function (val) {
                    if (val && val.length) {
                        $scope.demo.showTooltip = true;
                    }
                })
    }

})(angular.module('BursifyApp'));