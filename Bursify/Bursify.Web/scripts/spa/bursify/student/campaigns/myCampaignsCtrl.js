(function (app) {
    'use strict';
    /** Remove the Http when calling the API**/
    app.controller('myCampaignsCtrl', myCampaignsCtrl);

    myCampaignsCtrl.$inject = ['$scope', 'apiService', '$routeParams', 'notificationService', '$rootScope'];

    function myCampaignsCtrl($scope, apiService, $routeParams, notificationService, $rootScope) {
        $scope.pageClass = 'page-home-my-campaigns';

        $scope.demo = {
            showTooltip: false,
            tipDirection: ''
        };
                $scope.campaigns = [];
                $scope.loadingCampaigns = true;
                $scope.isReadOnly = true;
        
                $scope.campaigns = [];
                $scope.studentName = '';
        
                $scope.loadData = loadData;
        
               
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
                
                function removeCampaign(id)
                {
                    //Call api
                    notificationService.displaySuccess("Removed");
                }
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