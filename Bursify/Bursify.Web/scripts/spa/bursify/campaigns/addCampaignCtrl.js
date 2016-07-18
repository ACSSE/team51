(function (app) {
    'use strict';

    app.controller('addCampaignCtrl', addCampaignCtrl);

    addCampaignCtrl.$inject = ['$scope', '$http', 'apiService', 'notificationService'];


    function addCampaignCtrl($scope, $http, apiService, notificationService) {
        $scope.pageClass = 'page-home-add-campaign';

    }

})(angular.module('BursifyApp'));