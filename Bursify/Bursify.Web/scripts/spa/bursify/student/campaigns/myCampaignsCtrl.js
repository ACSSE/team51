(function (app) {
    'use strict';
    /** Remove the Http when calling the API**/
    app.controller('myCampaignsCtrl', myCampaignsCtrl);

    myCampaignsCtrl.$inject = ['$scope', 'apiService', '$routeParams', 'notificationService'];

    function myCampaignsCtrl($scope, apiService, $routeParams, notificationService) {
        $scope.pageClass = 'page-home-my-campaigns';

                $scope.campaigns = [];
                
                $scope.userId = $routeParams.userId;
                $scope.loadingCampaigns = true;
                $scope.isReadOnly = true;
        
                $scope.campaigns = [];
                $scope.studentName = '';
        
                $scope.loadData = loadData;
        
                function loadData() {
                    apiService.get('/api/Campaign/GetAllCampaigns/?userId=' + parseInt($routeParams.userId), null,
                                campaignsLoadCompleted,
                                campaignsLoadFailed);
                }
        
                function campaignsLoadCompleted(result) {
                    $scope.campaigns = result.data;
                    $scope.loadingCampaigns = false;
        
                    //Use student id to get the name of the student who started the campaign  *****NBNB****
                    $scope.studentName = 'Mike Ross';
                }
        
                function campaignsLoadFailed() {
                    notificationService.displayError("Unable to load your Campaigns.");
                }
                loadData();
    }

})(angular.module('BursifyApp'));