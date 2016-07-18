(function (app) {
    'use strict';

    app.controller('campaignsCtrl', campaignsCtrl);

    campaignsCtrl.$inject = ['$scope', '$http', 'apiService', 'notificationService'];

    function campaignsCtrl($scope, $http, apiService, notificationService) {
        $scope.pageClass = 'page-home-campaigns';

        $scope.campaigns = []; // stores campaigns
        
        //Get all the campaigns from the Json file 
        $http.get('campaigns.json').success(function (data) {

            $scope.campaigns = data;
        });
    }

})(angular.module('BursifyApp'));