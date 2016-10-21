(function (app) {
    'use strict';

    app.controller('adminCampaignCtrl', adminCampaignCtrl);

    adminCampaignCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function adminCampaignCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home-admin';
       

    


    }

})(angular.module('BursifyApp'));